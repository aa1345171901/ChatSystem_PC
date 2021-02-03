namespace QQ_piracy.Manager
{
    using Common;

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

        public virtual void Init()
        {
        }
    }
}
