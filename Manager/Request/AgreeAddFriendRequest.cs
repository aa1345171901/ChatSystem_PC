namespace QQ_piracy.Manager.Request
{
    using Common;

    public class AgreeAddFriendRequest : BaseRequest
    {
        private RequestForm requestForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="AgreeAddFriendRequest"/> class.
        /// 构造函数，将form传递进来
        /// </summary>
        public AgreeAddFriendRequest(RequestForm requestForm)
        {
            this.requestForm = requestForm;
            Init();
        }

        /// <summary>
        /// 设置requestCode和ActionCode
        /// </summary>
        public override void Init()
        {
            requestCode = RequestCode.Friend;
            actionCode = ActionCode.AgreeAddFriend;
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
                requestForm.ResponseAgree(false);
            }
            else
            {
                requestForm.ResponseAgree(true);
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
