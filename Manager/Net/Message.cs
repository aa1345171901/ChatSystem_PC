namespace QQ_piracy.Manager.Net
{
    using System;
    using System.Linq;
    using System.Text;
    using Common;

    public class Message
    {
        private byte[] data = new byte[1024];
        private int startIndex = 0;

        private int count = 0; // 用于保存本次数据的长度
        private int allCount = 0; // 用于保存本次数据的总长度
        private string dataStr = "";  // 用于保存回传数据
        private ActionCode actionCode = ActionCode.None; // 用于设置actionCode

        /// <summary>
        /// 返回数据
        /// </summary>
        public byte[] Data
        {
            get { return data; }
        }

        /// <summary>
        /// 返回数组开始的索引
        /// </summary>
        public int StartIndex
        {
            get { return startIndex; }
        }

        /// <summary>
        /// 返回剩余的数组长度
        /// </summary>
        public int RemainSize
        {
            get { return data.Length - startIndex; }
        }

        /// <summary>
        /// 将数据打包发给服务器
        /// </summary>
        /// <returns>需要发送的数据</returns>
        public static byte[] PackData(RequestCode requestCode, ActionCode actionCode, string data)
        {
            byte[] requestCodeBytes = BitConverter.GetBytes((int)requestCode);
            byte[] actionCodeBytes = BitConverter.GetBytes((int)actionCode);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int dataAmount = requestCodeBytes.Length + dataBytes.Length + actionCodeBytes.Length;
            byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
            return dataAmountBytes.Concat(requestCodeBytes).ToArray<byte>()
                .Concat(actionCodeBytes).ToArray<byte>()
                .Concat(dataBytes).ToArray<byte>();
        }

        /// <summary>
        /// 解析数据或者叫做读取数据,服务器发送的数据为 |数据长度+actionCode+data|
        /// </summary>
        public void ReadMessage(int newDataAmount, Action<ActionCode, string> processDataCallback)
        {
            startIndex += newDataAmount;
            int newCount = newDataAmount;
            if (startIndex <= 4)
            {
                return;
            }

            if (startIndex >= 8 && count == 0)
            {
                count = BitConverter.ToInt32(data, 0);
                actionCode = (ActionCode)BitConverter.ToInt32(data, 4);
                Array.Copy(data, 8, data, 0, newCount - 8); // 剩余的数据往前移动
                startIndex -= 8;
                newCount -= 8;
                allCount += 4;
            }

            if (startIndex >= 0)
            {
                allCount += newCount;
                dataStr += Encoding.UTF8.GetString(data, 0, newCount);
                if (startIndex - newCount != 0)
                {
                    Array.Copy(data, newCount, data, 0, startIndex - newCount);
                }

                startIndex -= newCount;
            }

            if (allCount == count)
            {
                processDataCallback(actionCode, dataStr);
                actionCode = ActionCode.None;
                allCount = 0;
                count = 0;
                dataStr = "";
            }
        }
    }
}
