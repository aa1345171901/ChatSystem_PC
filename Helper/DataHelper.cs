namespace ChatSystemServer.Helper
{
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// 用于将DataSet转换成byte数组，或者数组转换成DataSet数据集
    /// </summary>
    public class DataHelper
    {
        /// <summary>
        /// 将DataSet转byte数组
        /// </summary>
        /// <returns>返回转换后的Byte数组</returns>
        public static byte[] GetBinaryFormatDataSet(DataSet ds)
        {
            // 创建内存流
            MemoryStream memStream = new MemoryStream();

            // 产生二进制序列化格式
            IFormatter formatter = new BinaryFormatter();

            // 指定DataSet串行化格式是二进制
            ds.RemotingFormat = SerializationFormat.Binary;

            // 串行化到内存中
            formatter.Serialize(memStream, ds);

            // 将DataSet转化成byte[]
            byte[] binaryResult = memStream.ToArray();

            // 清空和释放内存流
            memStream.Close();
            memStream.Dispose();
            return binaryResult;
        }

        /// <summary>
        /// 将byte数组转换成DataSet
        /// </summary>
        /// <returns>转换后的DataSet</returns>
        public static DataSet RetrieveDataSet(byte[] binaryData)
        {
            // 创建内存流
            MemoryStream memStream = new MemoryStream(binaryData);

            memStream.Seek(0, SeekOrigin.Begin);

            // 产生二进制序列化格式
            IFormatter formatter = new BinaryFormatter();

            // 反串行化到内存中
            object obj = formatter.Deserialize(memStream);

            // 类型检验
            if (obj is DataSet)
            {
                DataSet dataSetResult = (DataSet)obj;
                return dataSetResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将字典转换成字符串转换
        /// </summary>
        /// <returns>返回字符串,用逗号分割</returns>
        public static string DicToString(Dictionary<int, (string, int)> dics)
        {
            string returnValue = "";
            foreach (var item in dics)
            {
                returnValue += item.Key + ",";
                returnValue += item.Value.Item1 + ",";
                returnValue += item.Value.Item2 + ",";
            }

            return returnValue;
        }

        /// <summary>
        /// 将字符串转字典
        /// </summary>
        /// <returns>返回转换好的字典</returns>
        public static Dictionary<int, (string, int)> StringToDic(string data)
        {
            Dictionary<int, (string, int)> returnDic = null;
            int index = 0;
            string[] strs = data.Split(',');
            while (index < strs.Length)
            {
                returnDic.Add(int.Parse(strs[index++]), (strs[index++], int.Parse(strs[index++])));
            }

            return returnDic;
        }
    }
}
