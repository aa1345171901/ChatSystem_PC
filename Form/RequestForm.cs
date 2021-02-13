namespace QQ_piracy
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using QQ_piracy.Manager.Request;

    public partial class RequestForm : Form
    {
        // 用于异步回调标识
        public int IsRequest = 0;
        public int IsAgree = 0;

        // 用于异步回调昵称设置
        public string NickName;

        public MainForm MainForm;

        public int FromUserId = 0;
        public int FaceId;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestForm"/> class.
        /// 界面加载
        /// </summary>
        public RequestForm()
        {
            InitializeComponent();
            SyncTimer.Start();
        }

        /// <summary>
        /// 对设置消息为未读做响应
        /// </summary>
        public void ResponseRequest()
        {
            if (IsRequest == 1)
            {
                IsRequest = 0;

                // this.pbFace.BackgroundImage = ilFaces.Images[FaceId];

                // string appPath = Application.StartupPath + @"\" + FaceId + ".jpg";

                // 图片需跟exe同一路径下
                // if (File.Exists(appPath))
                // {
                //    Image img = Image.FromFile(appPath);
                //    this.pbFace.BackgroundImage = img;
                // }
                this.userMsg.Text = NickName + "     (" + FromUserId + ")";
                this.systemMsg.Text = "请求添加您为好友";
                this.btnAllow.Visible = true;
            }
            else if (IsRequest == 2)
            {
                IsRequest = 0;
                MessageBox.Show("服务器发生意外错误！稍后重试", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();  // 关闭窗体
            }
        }

        /// <summary>
        /// 同意添加好友的反馈，这里如果服务器错误需要重新更改消息为已读//todo
        /// </summary>
        public void ResponseAgree()
        {
            if (IsAgree == 1)
            {
                IsAgree = 0;
            }
            else if (IsAgree == 2)
            {
                IsAgree = 0;
                MessageBox.Show("服务器发生意外错误！稍后重试", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        private void RequestForm_Load(object sender, EventArgs e)
        {
            if (FromUserId == 0)
            {
                this.systemMsg.Text = "没有系统消息";
                this.btnAllow.Visible = false;
            }
            else
            {// 将该系统消息置为已读
                try
                {
                    int id = UserHelper.LoginId;
                    int fromUserId = FromUserId;
                    string data = id + "," + fromUserId;
                    MainForm.AddFriendRequest.SendRequest(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "无法连接服务器，请检查您的网络", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 同意添加好友请求
        private void btnAllow_Click(object sender, EventArgs e)
        {
            // 先查找是否已经添加过了，防止重复添加
            try
            {
                int hostFriendId = FromUserId;
                int accetFriendId = UserHelper.LoginId;
                string data = hostFriendId + "," + accetFriendId;
                MainForm.AgreeAddRequest.SendRequest(data);
                MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "无法连接服务器，请检查您的网络", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();

            this.Close();
        }

        private void RequestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.UserRequestDict.Remove(FromUserId);
        }

        private void SyncTimer_Tick(object sender, EventArgs e)
        {
            ResponseAgree();
            ResponseRequest();
        }
    }
}
