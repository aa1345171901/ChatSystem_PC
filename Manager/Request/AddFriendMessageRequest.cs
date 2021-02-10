namespace QQ_piracy.Manager.Request
{
    using Common;

    public class AddFriendMessageRequest : BaseRequest
    {
        private MainForm mainForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddFriendMessageRequest"/> class.
        /// 构造函数，将form传递进来
        /// </summary>
        public AddFriendMessageRequest(MainForm mainForm)
        {
            this.mainForm = mainForm;
            Init();
        }

        /// <summary>
        /// 设置requestCode和ActionCode
        /// </summary>
        public override void Init()
        {
            requestCode = RequestCode.Message;
            actionCode = ActionCode.AddFriendMessageRequest;
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
                int fromUserId = int.Parse(strs[1]);
                RequestForm request;
                mainForm.UserRequestDict.TryGetValue(fromUserId, out request);
                request.IsRequest = 2;
            }
            else
            {
                int fromUserId = int.Parse(strs[1]);
                RequestForm request;
                mainForm.UserRequestDict.TryGetValue(fromUserId, out request);
                string nickName = strs[2];
                request.NickName = nickName;
                request.IsRequest = 1;
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
