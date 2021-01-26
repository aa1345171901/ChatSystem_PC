using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ_piracy
{
    public partial class LoginingForm : Form
    {
        public static bool isLogin = true;

        public Form loginForm;

        public LoginingForm(Form loginForm)
        {
            this.loginForm = loginForm; 
            InitializeComponent();
            // 创建主窗体
        }

        private void LoginingForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;    //隐藏窗体边框
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();                 //关闭窗体

            loginForm.Close();

            this.Dispose();               //释放资源

            Application.Exit();           //关闭应用程序窗体
        }

        private void giveupButton_Click(object sender, EventArgs e)
        {
            isLogin = false;
            loginForm.Show();
            this.Close();
        }

        //延时
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
            return isLogin;
        }
    }
}
