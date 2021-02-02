namespace QQ_piracy.Manager
{
    using Common;
    using QQ_piracy.Manager.Net;
    using System;
    using System.Net.Sockets;

    /// <summary>
    /// 用于连接管理服务器
    /// </summary>
    public class ClientManager : BaseManager
    {
        private const string Ip = "127.0.0.1";
        private const int Port = 6688;

        private Socket clientSocket;
        private Message msg;

        public ClientManager(ManagerController managerController)
            : base(managerController)
        {
        }

        /// <summary>
        /// Client初始化
        /// </summary>
        public void Init()
        {
            base.Init();
            msg = new Message();
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                clientSocket.Connect(Ip, Port);
                StartReceive();
            }
            catch (Exception e)
            {
                Console.WriteLine("无法连接服务器，请减查您的网络:" + e.Message);
            }
        }

        /// <summary>
        /// 开始异步接收服务器数据
        /// </summary>
        private void StartReceive()
        {
            clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None,);
        }

        /// <summary>
        /// 异步回调
        /// </summary>
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                if (clientSocket == null || clientSocket.Connected == false)
                {
                    return;
                }

                int count = clientSocket.EndReceive(ar);

                msg.ReadMessage(count, OnProcessCallBack);
                StartReceive();
            }
            catch (Exception e)
            {
                Console.WriteLine("异步回调出错:" + e.Message);
            }
        }

        private void OnProcessCallBack(ActionCode actionCode, string data)
        {
            managerController.HandleResponse(actionCode, data);
        }
    }
}
