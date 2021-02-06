namespace QQ_piracy
{
    using System;
    using System.Windows.Forms;

    public partial class LoginingForm : Form
    {
        public static bool IsLogin = true;

        public Form LoginForm;

        public LoginingForm(Form loginForm)
        {
            this.LoginForm = loginForm;
            InitializeComponent();

            // 创建主窗体
        }

        private void LoginingForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;    // 隐藏窗体边框
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();                 // 关闭窗体

            LoginForm.Close();

            this.Dispose();               // 释放资源

            Application.Exit();           // 关闭应用程序窗体
        }

        private void giveupButton_Click(object sender, EventArgs e)
        {
            IsLogin = false;
            LoginForm.Show();
            this.Close();
        }

        // 延时
        public static bool Delay(int delayTime)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return IsLogin;
        }
    }
}
