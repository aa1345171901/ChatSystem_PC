namespace QQ_piracy
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using QQ_piracy.Manager.Request;

    public partial class ChatForm : Form
    {
        // 用于异步接收发送的标识，使用timer处理
        public int IsSend = 0;   // 发送是否成功，1为成功，2为失败，0为不是回调发送
        public int IsReceive = 0;   // 接收是否成功，1为成功，2为失败，0为不是回调发送

        public long MessageTimeTicks; // 用于异步设置发送时间
        public string Message; // 用于异步设置发送的信息

        public int FriendId;     // 当前聊天的好友号码
        public string NickName;  // 当前聊天的好友昵称
        public string SelfnickName;  // 当前聊天的好友昵称
        public int FaceId;       // 当前聊天的好友头像Id
        public MainForm MainForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatForm"/> class.
        /// 加载界面
        /// </summary>
        public ChatForm()
        {
            InitializeComponent();

            // 给按钮添加事件
            this.toolStripButton1.Click += sorry_Click;
            this.toolStripButton2.Click += sorry_Click;
            this.toolStripButton3.Click += sorry_Click;
            this.toolStripButton4.Click += sorry_Click;
            this.toolStripButton5.Click += sorry_Click;
            this.toolStripButton6.Click += sorry_Click;
            this.toolStripButton7.Click += sorry_Click;
            this.toolStripButton8.Click += sorry_Click;
            this.toolStripButton9.Click += sorry_Click;
            this.toolStripButton10.Click += sorry_Click;
            this.more.Click += sorry_Click;
            this.shiping.Click += sorry_Click;
            this.ToolStripMenuItem.Click += sorry_Click;
            this.ToolStripMenuItem2.Click += sorry_Click;
        }

        /// <summary>
        /// 发送成功执行的操作
        /// </summary>
        public void ResponseSend()
        {
            if (IsSend == 1)
            {
                IsSend = 0;
                messageLabel.Text += string.Format("\r\n{0}  {1}\r\n  {2}", SelfnickName, DateTime.Now, tbMessage.Text);
                tbMessage.Text = "";  // 输入消息清空
            }
            else if (IsSend == 2)
            {
                IsSend = 0;
                MessageBox.Show("服务器未响应，请稍后再试", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 接收消息响应
        /// </summary>
        public void ResponseReceive()
        {
            // 将消息添加到窗体上
            if (IsReceive == 1)
            {
                IsReceive = 0;
                DateTime sendTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                sendTime = sendTime.AddMilliseconds(MessageTimeTicks);
                messageLabel.Text += string.Format("\r\n{0}  {1}\r\n  {2}", NickName, sendTime, Message);
            }
        }

        /// <summary>
        /// 初始化主界面
        /// </summary>
        private void ChatForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;    // 更换窗体边框
            this.ShowInTaskbar = true;                     // 显示任务栏
            this.Icon = new Icon("1.ico");

            // 设置窗体标题
            this.Text = "         " + NickName + " (" + FriendId + ")";

            // 读取所有的未读消息，显示在窗体中
            ShowMessage();
        }

        /// <summary>
        /// 向服务器发送请求给好友发消息
        /// </summary>
        private void sendButton_Click(object sender, EventArgs e)
        {
            // 不能发送空消息
            if (tbMessage.Text.Trim() == "")
            {
                MessageBox.Show("不能发送空消息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (tbMessage.Text.Trim().Length > 120)
            {
                MessageBox.Show("消息内容过长，请分为几条发送！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            { // 发送消息，向服务器发送请求
                try
                {
                    int id = UserHelper.LoginId;
                    int friendId = FriendId;
                    string message = tbMessage.Text;
                    DateTime datetime = DateTime.Now;
                    DateTime epoc = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                    TimeSpan delta = default(TimeSpan);
                    delta = datetime.Subtract(epoc);
                    long ticks = (long)delta.TotalMilliseconds;
                    string data = id + "," + friendId + "," + message + "," + ticks;
                    MainForm.ChatSendRequest.SendRequest(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "连接错误，请检查您的网络", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 读取所有的未读消息，显示在窗体中
        /// </summary>
        private void ShowMessage()
        {
            try
            {
                int id = UserHelper.LoginId;
                int friendId = FriendId;
                string data = id + "," + friendId;
                MainForm.ChatReceiveRequest.SendRequest(data);
            }
            catch (Exception ex)
            {
                showmsg.Stop();
                MessageBox.Show(ex.Message, "连接错误，请检查您的网络", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QQ秀功能暂未开通", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void sorry_Click(object sender, EventArgs e)
        {
            MessageBox.Show("该功能暂未开通", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // 关闭窗体
        private void gbButton_Click(object sender, EventArgs e)
        {
            this.Close();

            this.Dispose();               // 释放资源
        }

        /// <summary>
        /// 关闭聊天窗口时，移除主窗口的列表对应的chatForm
        /// </summary>
        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.UserChatDict.Remove(FriendId);
            MainForm.ChatForms.Remove(FriendId);
        }

        /// <summary>
        /// 计时器用于接收消息
        /// </summary>
        private void showmsg_Tick(object sender, EventArgs e)
        {
            ShowMessage();
            ResponseSend();
            ResponseReceive();
        }
    }
}
