namespace QQ_piracy.Manager.Request
{
    using ChatSystemServer.Helper;
    using Common;

    /// <summary>
    /// 获取好友列表的request
    /// </summary>
    public class GetFriendListRequest : BaseRequest
    {
        private MainForm mainForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFriendListRequest"/> class.
        /// 构造函数，将form传递进来
        /// </summary>
        public GetFriendListRequest(MainForm mainForm)
        {
            this.mainForm = mainForm;
            Init();
        }

        /// <summary>
        /// 设置requestCode和ActionCode
        /// </summary>
        public override void Init()
        {
            requestCode = RequestCode.Friend;
            actionCode = ActionCode.GetFriendList;
            base.Init();
        }

        /// <summary>
        /// 对服务器传递的消息响应
        /// </summary>
        public override void OnResponse(string data)
        {
            string[] strs = data.Split(',');
            ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
            if (returnCode == ReturnCode.Fail)
            {
                mainForm.IsGetFriends = 2;
            }
            else
            {
                mainForm.IsGetFriends = 1;
                string str = data.Substring(2);
                mainForm.FriendDic = DataHelper.StringToDic(str);
            }
        }

        /// <summary>
        /// 发送请求给服务器
        /// </summary>
        public override void SendRequest(string data)
        {
            ManagerController.SendRequest(requestCode, actionCode, data);
        }
    }
}
