namespace QQ_piracy.Manager.Request
{
    using Common;

    public class ModifyRequest : BaseRequest
    {
        private XGMessageForm xGMessageForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyRequest"/> class.
        /// 构造函数，将form传递进来
        /// </summary>
        public ModifyRequest(XGMessageForm xGMessageForm)
        {
            this.xGMessageForm = xGMessageForm;
            Init();
        }

        /// <summary>
        /// 设置requestCode和ActionCode
        /// </summary>
        public override void Init()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Modify;
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
                xGMessageForm.ResponseModify(false);
            }
            else
            {
                xGMessageForm.ResponseModify(true);
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
