namespace QQ_piracy.Manager.Request
{
    using Common;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 获取未读消息的request
    /// </summary>
    public class GetUnreadMessageRequest : BaseRequest
    {
        private MainForm mainForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUnreadMessageRequest"/> class.
        /// 构造函数，将form传递进来
        /// </summary>
        public GetUnreadMessageRequest(MainForm mainForm)
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
            actionCode = ActionCode.GetUnreadMessage;
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
                mainForm.ResponseGetUnreadMsg(false, null);
            }
            else
            {
                string strList = data.Substring(2);
                string[] listString = strList.Split('-');
                List<string> list = new List<string>();
                for (int i = 0; i < listString.Length; i++)
                {
                    list.Add(listString[i]);
                }

                mainForm.ResponseGetUnreadMsg(true, list);
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
