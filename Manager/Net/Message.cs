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
            while (true)
            {
                if (startIndex <= 4)
                {
                    return;
                }

                int count = BitConverter.ToInt32(data, 0);
                if ((startIndex - 4) >= count)
                {
                    ActionCode actionCode = (ActionCode)BitConverter.ToInt32(data, 4);
                    string s = Encoding.UTF8.GetString(data, 8, count - 4);
                    processDataCallback(actionCode, s);
                    Array.Copy(data, count + 4, data, 0, startIndex - 4 - count);
                    startIndex -= count + 4;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
