using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools {
    public partial class FrmConverter : Form {
        public FrmConverter() {
            InitializeComponent();
        }

        private void txtInput_DoubleClick(object sender, EventArgs e) {
            var fileOpen = new OpenFileDialog() {
                Multiselect = false,
                CheckFileExists = true,
                Filter = @"Java文件|*.java",
                // FileName = @"C:\Users\dell\Desktop\open-sdk-java-2.0.4-SNAPSHOT-sources\com\youzan\open\sdk\gen\v3_0_0\model\YouzanItemsOnsaleGetResult.java"
            };
            if (fileOpen.ShowDialog() == DialogResult.OK) {
                txtInput.Text = File.ReadAllText(fileOpen.FileName).Replace("\n", "\r\n");
                doConvert();
            }
        }

        private void doConvert() {
            var str = txtInput.Text;
            var c = findClass(str);
            txtOut.Text = string.Join("\r\n", c.Select(cc => cc.ToString()).ToArray());
        }

        private List<ClassStruct> findClass(string body) {
            var list = new List<ClassStruct>();
            var regClass = new Regex("class (\\w+)[ \\w]+", RegexOptions.Compiled | RegexOptions.Singleline);
            var regKh = new Regex("[{}]", RegexOptions.Compiled);
            var matches = regClass.Matches(body);
            while (matches.Count > 0) {
                var match = matches[0];
                var item = new ClassStruct {
                    ClassName = match.Groups[1].Value,
                    IsParams = match.Value.IndexOf("APIParams", StringComparison.Ordinal) > 0
                };
                //APIParams
                body = body.Substring(match.Index + match.Length);
                var classBody = "";
                var dkh = 0;
                var m = regKh.Match(body);
                while (m.Success) {
                    if (m.Value == "{") {
                        dkh++;
                    } else {
                        dkh--;
                    }
                    classBody += body.Substring(0, m.Index + m.Length);
                    body = body.Substring(m.Index + m.Length);
                    if (dkh < 1) break;
                    m = regKh.Match(body);
                }

                item.Body = classBody;
                item.Members = findMembers(classBody);
                item.SubClass = findClass(classBody);
                list.Add(item);
                matches = regClass.Matches(body);
            }
            return list;
        }

        private List<ClassMemberStruct> findMembers(string body) {
            var list = new List<ClassMemberStruct>();
            var regClass = new Regex("class (\\w+)[ \\w]+", RegexOptions.Compiled | RegexOptions.Singleline);
            var findClass = regClass.Match(body);
            if (findClass.Success) {
                body = body.Substring(0, findClass.Index);
            }
            var regMember = new Regex("@JsonProperty\\(value = \"(\\w+)\"\\)(.+?)private ([\\w\\[\\]<>,]+) (\\w+);", RegexOptions.Compiled | RegexOptions.Singleline);
            var matches = regMember.Matches(body);
            if (matches.Count > 0) {
                foreach (Match match in matches) {
                    var item = new ClassMemberStruct() {
                        JsonName = match.Groups[1].Value.ToLowerLine(),
                        Comment = ClassMemberStruct.FixComment(match.Groups[2].Value),
                        Type = ClassMemberStruct.FixType(match.Groups[3].Value),
                        Name = match.Groups[4].Value.ToCamel()
                    };
                    list.Add(item);
                }
            } else {
                var regMember2 = new Regex("/\\*(.+?)\\*/\\s+private ([\\w\\[\\]<>,]+) (\\w+);", RegexOptions.Compiled | RegexOptions.Singleline);
                matches = regMember2.Matches(body);
                foreach (Match match in matches) {
                    var item = new ClassMemberStruct() {
                        JsonName = match.Groups[3].Value.ToLowerLine(),
                        Comment = ClassMemberStruct.FixComment(match.Groups[1].Value),
                        Type = ClassMemberStruct.FixType(match.Groups[2].Value),
                        Name = match.Groups[3].Value.ToCamel()
                    };
                    list.Add(item);
                }
            }

            return list;
        }

        #region subClass
        public class ClassStruct {
            public string ClassName { get; set; }
            public string Body { get; set; }
            public bool IsParams { get; set; }

            public static string GetTab(int level) {
                var tab = "";
                if (level > 0) {
                    for (var i = level - 1; i >= 0; i--) {
                        tab += "\t";
                    }
                }
                return tab;
            }
            public string ToString(int level = 0) {
                var members = string.Join("", Members.Select(m => m.ToString(IsParams, level + 1)));
                if (!string.IsNullOrWhiteSpace(members)) members += "\r\n";
                var subclass = string.Join("\r\n\r\n", SubClass.Select(sc => sc.ToString(level + 1)));
                if (!string.IsNullOrWhiteSpace(subclass)) subclass += "\r\n";
                var tab = GetTab(level);
                return $"{tab}public class {ClassName} {(IsParams ? ": ApiParams" : "")}{{\r\n{members}{subclass}{tab}}}";
            }
            public IList<ClassStruct> SubClass { get; set; }
            public IList<ClassMemberStruct> Members { get; set; }
        }

        public class ClassMemberStruct {
            public static bool IsDefaultNull { get; set; } = false;
            public string Name { get; set; }
            public string JsonName { get; set; }
            public string Type { get; set; }
            public IEnumerable<string> Comment { get; set; }

            public static string FixType(string typeName) {
                switch (typeName) {
                    case "Float": return "float";
                    case "Long": return "long";
                    case "String": return "string";
                    case "Boolean": return "bool";
                    case "Date": return "DateTime";
                    default: return typeName;
                }
            }

            public static IEnumerable<string> FixComment(string comment) {
                return comment.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => Regex.Replace(s, "^[ \\t]+/{0,1}\\*{1,}/{0,1}", "", RegexOptions.Compiled))
                    .Select(s => Regex.Replace(s, " {0,}\\*{0,}", "", RegexOptions.Compiled))
                    .Where(s => !string.IsNullOrWhiteSpace(s));
            }
            public string ToString(bool isParams, int level = 0) {
                var tab = ClassStruct.GetTab(level);
                var s = $"\r\n{tab}/// <summary>\r\n";
                s += string.Join("\r\n", Comment.Select(str => $"{tab}/// {str}")).Replace("<", "&lt;").Replace(">", "&gt;") + "\r\n";
                s += tab + "/// </summary>\r\n";
                s += $"{tab}[JsonProperty(\"{JsonName}\")]\r\n";
                s += $"{tab}public {Type}{(IsDefaultNull && isParams && Type != "string" ? "?" : "")} {Name} {{ get; set; }}\r\n";
                return s;
            }
        }

        #endregion

        private void txtOut_DoubleClick(object sender, EventArgs e) {
            MessageBox.Show("to_string".ToCamel());
            MessageBox.Show("txtOut_DoubleClick".ToCamel());
        }

        private void chkBoxDefaultNull_CheckedChanged(object sender, EventArgs e) {
            ClassMemberStruct.IsDefaultNull = chkBoxDefaultNull.Checked;

        }
    }

    public static class StringHelper {
        public static string ToLowerLine(this string str) => Regex.Replace(str, "[A-Z]", match => $"{(match.Index > 0 ? "_" : "")}{match.Value.ToLower()}", RegexOptions.Compiled);
        //const toCamel = str =>str.replace(/([^_])(?:_+([^_]))/g, (_,p1, p2)=>p1+p2.toUpperCase());
        public static string FirstUpperCase(this string str) => str.Length > 0 ? $"{char.ToUpper(str[0])}{str.Substring(1)}" : str;
        public static string ToCamel(this string str) =>
            Regex.Replace(str, "([^_])(?:_+([^_]))", match => $"{match.Groups[1].Value}{match.Groups[2].Value.ToUpper()}").Trim('_').FirstUpperCase();
    }
}
