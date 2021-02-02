namespace QQ_piracy.Manager
{
    using Common;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 管理客户端的各种请求以及响应
    /// </summary>
    public class RequestManager : BaseManager
    {
        private Dictionary<ActionCode, BaseManager> requestDict = new Dictionary<ActionCode, BaseManager>();

        public RequestManager(ManagerController managerController)
            : base(managerController)
        {
        }

        public void HandleResponse(ActionCode actionCode, string data)
        {
            requestDict.TryGetValue(actionCode, out BaseManager request);
            if (request == null)
            {
                Console.WriteLine("无法得到ActionCode[" + actionCode + "]对应的类");
                return;
            }

            request.OnResponse(data);
        }
    }
}
