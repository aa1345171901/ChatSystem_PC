namespace QQ_piracy.Manager.Request
{
    using System.Text;
    using Common;

    public class AddFriendRequest : BaseRequest
    {
        private SearchFriendForm searchFriendForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddFriendRequest"/> class.
        /// 构造函数，将form传递进来
        /// </summary>
        public AddFriendRequest(SearchFriendForm searchFriendForm)
        {
            this.searchFriendForm = searchFriendForm;
            Init();
        }

        /// <summary>
        /// 设置requestCode和ActionCode
        /// </summary>
        public override void Init()
        {
            requestCode = RequestCode.Friend;
            actionCode = ActionCode.AddFriend;
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
                searchFriendForm.IsAdd = 2;
                searchFriendForm.Result = strs[1];
            }
            else
            {
                searchFriendForm.IsAdd = 1;
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
