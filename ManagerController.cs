namespace QQ_piracy
{
    using Common;
    using QQ_piracy.Manager;
    using QQ_piracy.Manager.Request;

    /// <summary>
    /// 用于管理所有Manager
    /// </summary>
    public class ManagerController
    {
        private static ManagerController instance;

        private ClientManager clientManager;
        private RequestManager requestManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerController"/> class.
        /// </summary>
        public ManagerController()
        {
            Init();
        }

        /// <summary>
        /// 单例模式，是全局只有一个ManagerController
        /// </summary>
        public static ManagerController Instance
        {
            get { return instance; }
        }

        public void Init()
        {
            instance = this;

            clientManager = new ClientManager(this);
            requestManager = new RequestManager(this);

            clientManager.Init();
            requestManager.Init();
        }

        /// <summary>
        /// 对服务器发送回的数据进行响应
        /// </summary>
        public void HandleResponse(ActionCode actionCode, string data)
        {
            requestManager.HandleResponse(actionCode, data);
        }

        /// <summary>
        /// 通过clientManager向服务器发送请求
        /// </summary>
        public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
        {
            clientManager.SendRequest(requestCode, actionCode, data);
        }

        /// <summary>
        /// 断开网络后用于重新连接
        /// </summary>
        /// <returns>返回重连是否成功</returns>
        public bool ConnectNetAgain()
        {
            return clientManager.ConnectNetAgain();
        }

        /// <summary>
        /// 通过单例增加request字典
        /// </summary>
        public void AddRequest(ActionCode actionCode, BaseRequest baseRequest)
        {
            requestManager.AddRequestDic(actionCode, baseRequest);
        }

        /// <summary>
        /// 通过单例移除request字典
        /// </summary>
        public void RemoveRequest(ActionCode actionCode)
        {
            requestManager.RemoveRequest(actionCode);
        }
    }
}
