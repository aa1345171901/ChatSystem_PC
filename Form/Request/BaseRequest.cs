namespace QQ_piracy.Form.Request
{
    using Common;

    public abstract class BaseRequest
    {
        protected RequestCode requestCode = RequestCode.None;
        protected ActionCode actionCode = ActionCode.None;
        protected ManagerController managerController;

        /// <summary>
        /// 获取managerController的全局变量
        /// </summary>
        public ManagerController ManagerController
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
            managerController.AddRequest(actionCode, this);
        }

        /// <summary>
        /// 该form关闭时，将该Request也从字典移除
        /// </summary>
        public virtual void Close()
        {
            managerController.RemoveRequest(actionCode);
        }

        /// <summary>
        /// 对收到的信息进行处理
        /// </summary>
        public virtual void OnResponse(string data)
        {
        }

        /// <summary>
        /// 项服务器发送请求，通过managerController发送
        /// </summary>
        public virtual void SendRequest(string data)
        {
            managerController.SendRequest(requestCode, actionCode, data);
        }
    }
}