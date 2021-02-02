using Common;
using QQ_piracy.Manager;

namespace QQ_piracy
{
    /// <summary>
    /// 用于管理所有Manager
    /// </summary>
    public class ManagerController
    {
        private ManagerController instance;

        private ClientManager clientManager;
        private RequestManager requestManager;

        /// <summary>
        /// 单例模式，是全局只有一个ManagerController
        /// </summary>
        public ManagerController Instance
        {
            get { return instance; }
        }

        public void Init()
        {
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
    }
}
