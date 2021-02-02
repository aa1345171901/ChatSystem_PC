using Common;

namespace QQ_piracy.Manager
{
    /// <summary>
    /// Manager的基类
    /// </summary>
    public class BaseManager
    {
        protected ManagerController managerController;

        public BaseManager(ManagerController managerController)
        {
            this.managerController = managerController;
        }

        public void Init()
        {
        }

        public void OnResponse(string data)
        {
        }
    }
}
