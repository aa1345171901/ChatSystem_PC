namespace QQ_piracy
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using QQ_piracy.Manager.Request;

    public partial class ChatForm : Form
    {
        public int FriendId;     // 当前聊天的好友号码
        public string NickName;  // 当前聊天的好友昵称
        public string SelfnickName;  // 当前聊天的好友昵称
        public int FaceId;       // 当前聊天的好友头像Id
        public MainForm MainForm;

        private ChatByReceiveReqeust chatReceiveRequest;
        private SendByChatRequest chatSendRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatForm"/> class.
        /// 加载界面
        /// </summary>
        public ChatForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 发送成功执行的操作
        /// </summary>
        public void ResponseSend(bool isSend)
        {
            if (isSend)
            {
                messageLabel.Text += string.Format("\r\n{0}  {1}\r\n  {2}", SelfnickName, DateTime.Now, tbMessage.Text);
                tbMessage.Text = "";  // 输入消息清空
            }
            else
            {
                MessageBox.Show("服务器未响应，请稍后再试", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 接收消息响应
        /// </summary>
        public void ResponseReceive(bool isReceive, long messageTimeTicks, string message)
        {
            // 将消息添加到窗体上
            if (isReceive)
            {
                DateTime sendTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                sendTime = sendTime.AddMilliseconds(messageTimeTicks);
                messageLabel.Text += string.Format("\r\n{0}  {1}\r\n  {2}", NickName, sendTime, message);
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

            chatSendRequest = new SendByChatRequest(this);
            chatReceiveRequest = new ChatByReceiveReqeust(this);

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
                    chatSendRequest.SendRequest(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接错误，请检查您的网络", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                chatReceiveRequest.SendRequest(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接错误，请检查您的网络", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            chatSendRequest.Close();
            chatReceiveRequest.Close();
            MainForm.ChatForms.Remove(FriendId);
        }

        /// <summary>
        /// 计时器用于接收消息
        /// </summary>
        private void showmsg_Tick(object sender, EventArgs e)
        {
            ShowMessage();
        }
    }
}
