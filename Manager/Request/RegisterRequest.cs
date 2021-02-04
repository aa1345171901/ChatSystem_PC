namespace QQ_piracy.Manager.Request
{
    using Common;

    class RegisterRequest : BaseRequest
    {
        private RegisterForm registerForm;

        public RegisterRequest(RegisterForm registerForm)
        {
            this.registerForm = registerForm;
            Init();
        }

        /// <summary>
        /// 设置requestCode和ActionCode
        /// </summary>
        public override void Init()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Register;
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
                UserHelper.LoginId = int.Parse(strs[1]);
                UserHelper.DataId = int.Parse(strs[2]);
                registerForm.ResponseRegister(true);
            }
            else
            {
                registerForm.ResponseRegister(false);
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
