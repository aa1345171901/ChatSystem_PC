namespace QQ_piracy.Manager.Request
{
    using Common;

    public abstract class BaseRequest
    {
        protected RequestCode requestCode = RequestCode.None;
        protected ActionCode actionCode = ActionCode.None;
        protected ManagerController managerController;

        protected ManagerController ManagerController
        {
            get
            {
                if (managerController == null)
                {
                    managerController = ManagerController.Instance;
                }

                return managerController;
            }
        }

        /// <summary>
        /// 初始化，将该request存入requestManager字典
        /// </summary>
        public virtual void Init()
        {
            ManagerController.AddRequest(actionCode, this);
        }

        /// <summary>
        /// 该form关闭时，将该Request也从字典移除
        /// </summary>
        public virtual void Close()
        {
            ManagerController.RemoveRequest(actionCode);
        }

        /// <summary>
        /// 对收到的信息进行处理
        /// </summary>
        public abstract void OnResponse(string data);

        /// <summary>
        /// 项服务器发送请求，通过managerController发送
        /// </summary>
        public abstract void SendRequest(string data);
    }
}