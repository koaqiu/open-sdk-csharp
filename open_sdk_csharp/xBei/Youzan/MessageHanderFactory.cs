using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YZOpenSDK.xBei.Youzan.Entrys;

namespace YZOpenSDK.xBei.Youzan {
    public class MessageHanderFactory {
        private static readonly IList<IMessageHander> Handlers = new List<IMessageHander>();
        private static readonly Queue<MsgPushEntity> MessageQueue = new Queue<MsgPushEntity>(55);
        private static Timer timer = new Timer(checkTask, null, Timeout.Infinite, Timeout.Infinite);
        private const int MaxTask = 50;
        private static IList<Task> taskLst = new List<Task>();

        public static void AddQueue(MsgPushEntity msg) {
            MessageQueue.Enqueue(msg);
            RunTask();
        }

        public static int QueueCount => MessageQueue.Count + taskLst.Count;
        public static bool RunTask() {
            Console.WriteLine($"runTask task.count={taskLst.Count},{MessageQueue.Count}");
            if (taskLst.Count >= MaxTask) return beginTimer();
            if (MessageQueue.Count < 1) return beginTimer();
            var msg = MessageQueue.Dequeue();
            if (!Enum.TryParse<PushMessageType>(msg.Type, true, out var msgType)) {
                return beginTimer();
            }

            var task = new Task(() => {
                runHadler(msgType, msg);
                RunTask();
            });
            taskLst.Add(task);
            Console.WriteLine($"runTask task {task.Id},{task.Status}");
            task.Start();
            return beginTimer();
        }

        private static bool beginTimer() {
            return timer.Change(1, Timeout.Infinite);
        }
        private static void checkTask(object state) {
            Console.WriteLine("check Task");
            var toRemove = taskLst.Where(task => task.Status != TaskStatus.Running).ToArray();
            foreach (var item in toRemove) {
                Console.WriteLine($"remove task {item.Id},{item.Status}");
                taskLst.Remove(item);
            }

            if (MessageQueue.Count < 1 && taskLst.Count < 1) {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
            } else {
                RunTask();
                beginTimer();
            }
        }
        private static void runHadler(PushMessageType msgType, MsgPushEntity msg) {
            Console.WriteLine($"handler msg:{msg.MsgId}");
            Thread.Sleep(new Random().Next(10, 2000));
            var list = Handlers.Where(h => h.Type == msgType).OrderByDescending(h => h.OrderBy).ToList();
            foreach (var hander in list) {
                var r = hander.Execute(msg, out var isBreadk);
                if (r > 0) {
                    MessageQueue.Enqueue(msg);
                }
                if (isBreadk) break;
            }
        }
    }

    public interface IMessageHander {
        PushMessageType Type { get; }
        /// <summary>
        /// 数字越大越优先
        /// </summary>
        int OrderBy { get; }
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="msg">要处理的消息</param>
        /// <param name="isBreak">是否终止</param>
        /// <returns>0-表示没有错误，发送错误可能会重新执行</returns>
        int Execute(MsgPushEntity msg, out bool isBreak);
    }
    public enum PushMessageType {
        /// <summary>
        /// 订单状态事件
        /// </summary>
        TRADE_ORDER_STATE = 1,
        /// <summary>
        /// 退款事件
        /// </summary>
        TRADE_ORDER_REFUND,
        /// <summary>
        /// 物流事件
        /// </summary>
        TRADE_ORDER_EXPRESS,
        /// <summary>
        /// 商品状态事件
        /// </summary>
        ITEM_STATE,
        /// <summary>
        /// 商品基础信息事件
        /// </summary>
        ITEM_INFO,
        ITEM_SKU_INFO,
        /// <summary>
        /// 积分
        /// </summary>
        POINTS,
        SCRM_CUSTOMER_EVENT,
        /// <summary>
        /// 会员卡（商家侧）
        /// </summary>
        SCRM_CARD,
        /// <summary>
        /// 会员卡（用户侧）
        /// </summary>
        SCRM_CUSTOMER_CARD,
        /// <summary>
        /// 交易V1
        /// </summary>
        TRADE,
        /// <summary>
        /// 商品V1
        /// </summary>
        ITEM
    }
}
