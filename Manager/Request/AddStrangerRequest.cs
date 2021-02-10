namespace QQ_piracy.Manager.Request
{
    using Common;

    public class AddStrangerRequest : BaseRequest
    {
        private MainForm mainForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddStrangerRequest"/> class.
        /// 构造函数，将form传递进来
        /// </summary>
        public AddStrangerRequest(MainForm mainForm)
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
            actionCode = ActionCode.AddStranger;
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
                mainForm.IsAdd = 2;
                mainForm.Result = strs[1];
            }
            else
            {
                mainForm.IsAdd = 1;
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
