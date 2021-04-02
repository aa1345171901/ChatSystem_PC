namespace QQ_piracy.Manager.Request
{
    using System;
    using System.Data;
    using System.Text;
    using ChatSystemServer.Helper;
    using Common;

    public class SearchFriendRequest : BaseRequest
    {
        private SearchFriendForm searchFriendForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchFriendRequest"/> class.
        /// 构造函数，将form传递进来
        /// </summary>
        public SearchFriendRequest(SearchFriendForm searchFriendForm)
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
            actionCode = ActionCode.SearchFriend;
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
                searchFriendForm.IsSearch = 2;
            }
            else
            {
                DataSet dataSet = DataHelper.DataSetFromString(strs[1]);
                dataSet.Tables[0].Columns.Remove("faceid");
                searchFriendForm.DataSet = dataSet;
                searchFriendForm.IsSearch = 1;
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
