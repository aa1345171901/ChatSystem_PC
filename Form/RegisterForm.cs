namespace QQ_piracy
{
    using System;
    using System.Windows.Forms;
    using QQ_piracy.Manager.Request;

    public partial class RegisterForm : Form
    {
        public int IsRegister = 0; // 用于标识异步调用

        private RegisterRequest registerRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterForm"/> class.
        /// 初始化form
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();
            registerRequest = new RegisterRequest(this);
        }

        /// <summary>
        /// 对注册的请求服务器的反馈做下一步操作
        /// </summary>
        public void ResponseRegister()
        {
            if (IsRegister == 1)
            {
                IsRegister = 0;
                ChooseForm chooseForm = new ChooseForm();
                chooseForm.Show();
                registerRequest.Close();
                this.Close();
                MessageBox.Show(string.Format("注册成功！请小心保管您的账号\n您的MyQQ号码是{0}", UserHelper.LoginId), "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (IsRegister == 2)
            {
                IsRegister = 0;
                MessageBox.Show("服务器没有响应，请稍后再试", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        /// <summary>
        /// 注册按钮点击
        /// </summary>
        private void registerButton_Click(object sender, EventArgs e)
        {
            // 输入验证通过，发送请求给服务器
            if (ValidateInput())
            {
                try
                {
                    string nickName = textNick.Text.Trim();
                    string password = textPsw.Text.Trim();
                    string data = nickName + "," + password;
                    registerRequest.SendRequest(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "连接服务器出错，请检查你的网络", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 验证用户的输入
        /// </summary>
        private bool ValidateInput()
        {
            if (textNick.Text.Trim() == "")
            {
                MessageBox.Show("请输入昵称！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textNick.Focus();
                return false;
            }

            if (textPsw.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textPsw.Focus();
                return false;
            }

            if (textPswR.Text.Trim() == "")
            {
                MessageBox.Show("请输入确认密码！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textPswR.Focus();
                return false;
            }

            if (textPsw.Text.Trim() != textPswR.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一样！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textPswR.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 加载主界面
        /// </summary>
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            SyncTimer.Start();
        }

        /// <summary>
        /// 用于判断昵称是否点击的lable
        /// </summary>
        private void userLabel_Click(object sender, EventArgs e)
        {
            userLabel.Visible = false;
            textNick.Select();
            if (string.IsNullOrEmpty(textPsw.Text))
            {
                Pswlabel.Visible = true;
            }

            if (string.IsNullOrEmpty(textPswR.Text))
            {
                PswRLabel.Visible = true;
            }
        }

        /// <summary>
        /// 用于判断密码文本框是否点击的lable
        /// </summary>
        private void Pswlabel_Click(object sender, EventArgs e)
        {
            Pswlabel.Visible = false;
            textPsw.Select();
            if (string.IsNullOrEmpty(textNick.Text))
            {
                userLabel.Visible = true;
            }

            if (string.IsNullOrEmpty(textPswR.Text))
            {
                PswRLabel.Visible = true;
            }
        }

        /// <summary>
        /// 用于判断重复密码文本框是否点击的lable
        /// </summary>
        private void PswRLabel_Click(object sender, EventArgs e)
        {
            PswRLabel.Visible = false;
            textPswR.Select();
            if (string.IsNullOrEmpty(textNick.Text))
            {
                userLabel.Visible = true;
            }

            if (string.IsNullOrEmpty(textPsw.Text))
            {
                Pswlabel.Visible = true;
            }
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            registerRequest.Close();
        }

        private void SyncTimer_Tick(object sender, EventArgs e)
        {
            ResponseRegister();
        }
    }
}
