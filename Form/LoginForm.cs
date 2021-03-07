namespace QQ_piracy
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using QQ_piracy.Manager.Request;

    public partial class LoginForm : Form
    {
        // 控制异步回调的，使用计时器调用控制该线程的form,0表示没有更改，1表示返回成功，2表示返回失败
        public int IsLogin = 0;

        private LoginRequest loginRequest;

        private string passAutoFilePath = Application.StartupPath + @"\auto.pws.dll"; //保存自动登录的地址

        private MainForm mainForm = null; // 保证mainform唯一

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// 初始化Form
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            loginRequest = new LoginRequest(this);

            // 为窗口添加移动事件
            this.pictureBox1.MouseMove += PictureBox1_MouseMove;
            ReadAutoPsw();
        }

        // 控制无边框窗体的移动
        //using System.Runtime.InteropServices;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //常量
            int WM_SYSCOMMAND = 0x0112;

            //窗体移动
            int SC_MOVE = 0xF010;
            int HTCAPTION = 0x0002;

            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        /// <summary>
        /// 对服务器的登录反馈进行下一步操作
        /// </summary>
        public void ResponseLogin()
        {
            if (IsLogin == 1)
            {
                IsLogin = 0;
                LoginingForm loginingForm = new LoginingForm(this);
                loginingForm.Show();
                this.Visible = false;
                if (loginingForm.Delay(2))
                {
                    if (mainForm == null)
                    {
                        mainForm = new MainForm();
                        mainForm.Show();  // 显示窗体
                        loginRequest.Close();
                        loginingForm.Close();
                        SaveAutoPswFile();   // 保存用户设置
                    }
                    else
                    {
                        mainForm.Show();  // 显示窗体
                        loginRequest.Close();
                        loginingForm.Close();
                        SaveAutoPswFile();   // 保存用户设置
                    }
                }
                else
                {
                    mainForm = null;
                }
            }
            else if (IsLogin == 2)
            {
                IsLogin = 0;
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
                    MessageBox.Show(ex.Message, "连接服务器出错，请检查你的网络", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 用于保存用户的状态，是否自动登录，是否记住密码
        /// </summary>
        private void SaveAutoPswFile()
        {
            int id = int.Parse(textBox1.Text.Trim());
            string password = forgetPsw.Checked ? textBox2.Text.Trim() : "";
            int autoBox = autoLogin.Checked == true ? 1 : 0;  // 选定自动登录为1 否则为0
            string data = id + "};{" + password + "};{" + autoBox;
            File.WriteAllText(passAutoFilePath, data);
        }

        /// <summary>
        /// 读取用户设置
        /// </summary>
        private void ReadAutoPsw()
        {
            string readString = "";
            if (File.Exists(passAutoFilePath))
            {
                readString = File.ReadAllText(passAutoFilePath);
                if (readString != "")
                {
                    try
                    {
                        string[] arr = readString.Split(new string[] { "};{" }, StringSplitOptions.None);
                        int id = int.Parse(arr[0]);
                        textBox1.Text = id.ToString();
                        string password = arr[1];
                        if (password != "")
                        {
                            forgetPsw.Checked = true;
                            textBox2.Text = password;
                        }

                        //控制textbox上的label是否显示
                        if (!string.IsNullOrEmpty(textBox1.Text))
                        {
                            userLabel.Visible = false;
                        }

                        if (!string.IsNullOrEmpty(textBox2.Text))
                        {
                            PasswordLabel.Visible = false;
                        }

                        int autoLoginFlag = int.Parse(arr[2]);
                        if (autoLoginFlag == 0)
                        {
                            autoLogin.Checked = false;
                        }
                        else if (password != "")
                        {
                            autoLogin.Checked = true;
                            loginRequest.SendRequest(id + "," + password);  // 自动登录，直接发送请求
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                File.Create(passAutoFilePath);
            }
        }

        /// <summary>
        /// 隐藏窗体边框,在Form出现时
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            AsynTimer.Start();
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
            RegisterForm register = null;
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

        private void AsynTimer_Tick(object sender, EventArgs e)
        {
            ResponseLogin();
        }
    }
}
