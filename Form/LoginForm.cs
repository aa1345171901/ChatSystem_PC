namespace QQ_piracy
{
    using System;
    using System.Windows.Forms;
    using QQ_piracy.Manager.Request;

    public partial class LoginForm : Form
    {
        private LoginRequest loginRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// 初始化Form
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            loginRequest = new LoginRequest(this);
        }

        /// <summary>
        /// 对服务器的登录反馈进行下一步操作
        /// </summary>
        public void ResponseLogin(bool logined)
        {
            if (logined)
            {
                LoginingForm loginingForm = new LoginingForm(this);
                loginingForm.Show();
                this.Visible = false;
                if (LoginingForm.Delay(2))
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();  // 显示窗体
                    loginRequest.Close();
                    loginingForm.Close();
                }
            }
            else
            {
                MessageBox.Show("输入的用户名或密码有误！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 登录按钮，向服务器发送请求
        /// </summary>
        private void loginButton_Click(object sender, EventArgs e)
        {
            // 如果输入验证成功，就验证身份，并转到相应的窗体
            if (ValidateInput())
            {
                try
                {
                    int id = int.Parse(textBox1.Text.Trim());
                    string password = textBox2.Text.Trim();
                    string data = id + "," + password;
                    loginRequest.SendRequest(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接服务器出错，请检查你的网络", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 隐藏窗体边框,在Form出现时
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        /// <summary>
        /// 账号的文本显示
        /// </summary>
        private void label1_Click(object sender, EventArgs e)
        {
            userLabel.Visible = false;
            textBox1.Select();
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                PasswordLabel.Visible = true;
            }
        }

        /// <summary>
        /// 显示密码的label
        /// </summary>
        private void label2_Click(object sender, EventArgs e)
        {
            PasswordLabel.Visible = false;
            textBox2.Select();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                userLabel.Visible = true;
            }
        }

        /// <summary>
        /// 找回密码，todo
        /// </summary>
        private void getPsw_Click(object sender, EventArgs e)
        {
            MessageBox.Show("该功能尚未开通！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        private void close_Click(object sender, EventArgs e)
        {
            loginRequest.Close();

            this.Close();                 // 关闭窗体

            this.Dispose();               // 释放资源

            Application.Exit();           // 关闭应用程序窗体
        }

        /// <summary>
        /// 最小化
        /// </summary>
        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 注册按钮点击
        /// </summary>
        private void register_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            if (!CheckFormIsOpen("RegisterForm"))
            {
                register = new RegisterForm();
            }
            else
            {
                register = (RegisterForm)Application.OpenForms["RegisterForm"];
            }

            register.Show();
        }

        /// <summary>
        /// 判断form是否出现
        /// </summary>
        private bool CheckFormIsOpen(string form)
        {
            bool bResult = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == form)
                {
                    bResult = true;
                    break;
                }
            }

            return bResult;
        }

        // 用户输入验证
        private bool ValidateInput()
        {
            // 验证用户输入
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入登录的账号", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return false;
            }
            else if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }

            return true;
        }
    }
}
