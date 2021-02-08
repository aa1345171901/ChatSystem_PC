namespace QQ_piracy.Manager.Request
{
    using Common;

    /// <summary>
    /// 选填消息的request
    /// </summary>
    public class ChooseRequest : BaseRequest
    {
        private ChooseForm chooseForm;

        public ChooseRequest(ChooseForm chooseForm)
        {
            this.chooseForm = chooseForm;
            Init();
        }

        /// <summary>
        /// 设置requestCode和ActionCode
        /// </summary>
        public override void Init()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Optional;
            base.Init();
        }

        /// <summary>
        /// 对服务器传递的消息响应
        /// </summary>
        public override void OnResponse(string data)
        {
            string[] strs = data.Split(',');
            ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
            if (returnCode == ReturnCode.Success)
            {
                chooseForm.IsChoose = 1;
            }
            else
            {
                chooseForm.IsChoose = 2;
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
