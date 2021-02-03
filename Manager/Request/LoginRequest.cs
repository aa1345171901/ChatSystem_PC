namespace QQ_piracy.Manager.Request
{
    using Common;

    public class LoginRequest : BaseRequest
    {
        private LoginForm loginForm;

        public LoginRequest(LoginForm loginForm)
        {
            this.loginForm = loginForm;
        }

        public override void Init()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Login;
            base.Init();
        }

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

        public override void SendRequest(string data)
        {
            ManagerController.SendRequest(requestCode, actionCode, data);
        }
    }
}
