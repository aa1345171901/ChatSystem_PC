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
    public class UserHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserHelper"/> class.
        /// </summary>
        public UserHelper(int id, int dataId, string nickName)
        {
            LoginId = id;
            DataId = dataId;
            NickName = nickName;
        }

        /// <summary>
        /// 用于记录用户的id
        /// </summary>
        public int LoginId { get; set; }

        /// <summary>
        /// 用于记录用户数据的id，方便获取信息
        /// </summary>
        public int DataId { get; set; }

        /// <summary>
        /// 获取用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户头像Id
        /// </summary>
        public int FaceId { get; set; }

        /// <summary>
        /// 用户的真实姓名
        /// </summary>
        public string Name { get; set; }
    }
}
