namespace QQ_piracy.Manager
{
    using System;
    using System.Net.Sockets;
    using System.Threading;
    using Common;
    using QQ_piracy.Manager.Net;

    /// <summary>
    /// 用于连接管理服务器
    /// </summary>
    public class ClientManager : BaseManager
    {
        private const string Ip = "47.119.134.12"; // 47.119.134.12
        private const int Port = 8888;

        private Socket clientSocket;
        private Message msg;

        public ClientManager(ManagerController managerController)
            : base(managerController)
        {
        }

        /// <summary>
        /// Client初始化
        /// </summary>
        public override void Init()
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
                Close();
                Console.WriteLine("无法连接服务器，请减查您的网络:" + e.Message);
            }
        }

        /// <summary>
        /// 将数据打包发送给sever
        /// </summary>
        public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
        {
            if (clientSocket != null)
            {
                clientSocket.Send(Message.PackData(requestCode, actionCode, data));
            }
        }

        public bool ConnectNetAgain()
        {
            if (clientSocket.Connected)
            {
                return true;
            }
            msg = new Message();
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                clientSocket.Connect(Ip, Port);
                StartReceive();
                return true;
            }
            catch (Exception)
            {
                Close();
                return false;
            }
        }

        /// <summary>
        /// 开始异步接收服务器数据
        /// </summary>
        private void StartReceive()
        {
            clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack, null);
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
                Close();
                Console.WriteLine("异步回调出错:" + e.Message);
            }
        }

        /// <summary>
        /// 将处理好的信息通过managerController进行处理
        /// </summary>
        private void OnProcessCallBack(ActionCode actionCode, string data)
        {
            managerController.HandleResponse(actionCode, data);
        }

        /// <summary>
        /// 关闭时释放资源
        /// </summary>
        public void Close()
        {
            if (clientSocket != null)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                Thread.Sleep(10);
                clientSocket.Close();
                clientSocket.Dispose();
            }
        }
    }
}
