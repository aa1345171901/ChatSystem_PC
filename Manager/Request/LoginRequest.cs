namespace QQ_piracy.Manager.Request
{
    using Common;

    public class LoginRequest : BaseRequest
    {
        private LoginForm loginForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRequest"/> class.
        /// 构造函数，将form传递进来
        /// </summary>
        public LoginRequest(LoginForm loginForm)
        {
            this.loginForm = loginForm;
            Init();
        }

        /// <summary>
        /// 设置requestCode和ActionCode
        /// </summary>
        public override void Init()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Login;
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
                loginForm.ResponseLogin(false);
            }
            else
            {
                UserHelper.LoginId = int.Parse(strs[1]);
                UserHelper.NickName = strs[2];
                UserHelper.Sex = strs[3];
                UserHelper.Age = int.Parse(strs[4]);
                UserHelper.Name = strs[5];
                UserHelper.StarId = int.Parse(strs[6]);
                UserHelper.BloodTypeId = int.Parse(strs[7]);
                UserHelper.FaceId = int.Parse(strs[8]);
                loginForm.ResponseLogin(true);
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
