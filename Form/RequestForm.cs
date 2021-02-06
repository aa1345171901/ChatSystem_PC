namespace QQ_piracy
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using QQ_piracy.Manager.Request;

    public partial class RequestForm : Form
    {
        public int FromUserId = 0;
        public int FaceId;

        private AddFriendMessageRequest addFriendRequest;
        private AgreeAddFriendRequest agreeAddRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestForm"/> class.
        /// 界面加载
        /// </summary>
        public RequestForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 对设置消息为未读做响应
        /// </summary>
        public void ResponseRequest(bool isRequest, string nickName)
        {
            if (isRequest)
            {
                // this.pbFace.BackgroundImage = ilFaces.Images[FaceId];
                string appPath = Application.StartupPath + @"\" + FaceId + ".jpg";

                // 图片需跟exe同一路径下
                if (File.Exists(appPath))
                {
                    Image img = Image.FromFile(appPath);
                    this.pbFace.BackgroundImage = img;
                }

                this.userMsg.Text = nickName + "     (" + FromUserId + ")";
                this.systemMsg.Text = "请求添加您为好友";
                this.btnAllow.Visible = true;
            }
            else
            {
                this.Close();  // 关闭窗体
                MessageBox.Show("服务器发生意外错误！稍后重试", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 同意添加好友的反馈，这里如果服务器错误需要重新更改消息为已读//todo
        /// </summary>
        public void ResponseAgree(bool isAgree)
        {
            this.Close();  // 关闭窗体
            if (isAgree)
            {
            }
            else
            {
                MessageBox.Show("服务器发生意外错误！稍后重试", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        private void RequestForm_Load(object sender, EventArgs e)
        {
            addFriendRequest = new AddFriendMessageRequest(this);
            agreeAddRequest = new AgreeAddFriendRequest(this);

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
                    addFriendRequest.SendRequest(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法连接服务器，请检查您的网络", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                agreeAddRequest.SendRequest(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接服务器，请检查您的网络", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            agreeAddRequest.Close();
            addFriendRequest.Close();
            this.Dispose();

            this.Close();
        }
    }
}
