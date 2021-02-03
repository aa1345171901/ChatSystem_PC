namespace QQ_piracy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 记录登录的用户Id及用户信息
    /// </summary>
    public static class UserHelper
    {
        /// <summary>
        /// 用于记录用户的id
        /// </summary>
        public static int LoginId { get; set; }

        /// <summary>
        /// 用于记录用户数据的id，方便获取信息
        /// </summary>
        public static int DataId { get; set; }

        /// <summary>
        /// 获取用户昵称
        /// </summary>
        public static string NickName { get; set; }

        /// <summary>
        /// 设置的性别
        /// </summary>
        public static string Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public static int Age { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public static string Name { get; set; }

        /// <summary>
        /// 星座,对应数据库Star表
        /// </summary>
        public static int StarId { get; set; }

        /// <summary>
        /// 血型,对应数据库BloodType表
        /// </summary>
        public static int BloodTypeId { get; set; }

        /// <summary>
        /// 头像Id
        /// </summary>
        public static int FaceId { get; set; }
    }
}
