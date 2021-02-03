using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QQ_piracy
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;    //隐藏窗体边框
        }

        private void label1_Click(object sender, EventArgs e)
        {
            userLabel.Visible = false;
            textBox1.Select();
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                PasswordLabel.Visible = true;
            }
        }

        //显示密码的label
        private void label2_Click(object sender, EventArgs e)
        {
            PasswordLabel.Visible = false;
            textBox2.Select();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                userLabel.Visible = true;
            }
        }

        //找回密码
        private void getPsw_Click(object sender, EventArgs e)
        {
            MessageBox.Show("该功能尚未开通！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //关闭
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();                 //关闭窗体

            this.Dispose();               //释放资源

            Application.Exit();           //关闭应用程序窗体
        }

        //最小化
        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //注册按钮点击
        private void register_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            if (!CheckFormIsOpen("RegisterForm"))
                register = new RegisterForm();
            else
                register = (RegisterForm)Application.OpenForms["RegisterForm"];
            register.Show();
        }

        //判断form是否出现
        private bool CheckFormIsOpen(string Forms)
        {
            bool bResult = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == Forms)
                {
                    bResult = true;
                    break;
                }
            }
            return bResult;
        }

        //登录按钮
        private void loginButton_Click(object sender, EventArgs e)
        {
            bool error = false;   // 标志在执行数据库操作的过程中是否出错
            bool flag = false;    //标志用户账号密码是否匹配
            // 如果输入验证成功，就验证身份，并转到相应的窗体
            if (ValidateInput())
            {            

                try
                {

                    MySqlCommand cmd = new MySqlCommand("select count(*),dataid from user where id=@id and password=@password", DBHelper.Connect());
                    cmd.Parameters.AddWithValue("id", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("password", textBox2.Text.Trim());
                    MySqlDataReader reader= cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UserHelper.dataId = reader.GetInt32("dataid");
                        flag = true;
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DBHelper.CloseConnection(DBHelper.Connect());  // 关闭数据库连接
                }

                if (!error &&flag)  // 验证通过
                {
                    LoginingForm loginingForm = new LoginingForm(this); //
                    loginingForm.Show();
                    this.Visible = false;
                    if (LoginingForm.Delay(2))
                    {
                        UserHelper.loginId = int.Parse(textBox1.Text.Trim());
                        MainForm mainForm = new MainForm();
                        mainForm.Show();  // 显示窗体
                        loginingForm.Close();
                    }
                    //Thread.Sleep(3000);
                    // 设置登录的用户号码
                }
                else
                {
                    MessageBox.Show("输入的用户名或密码有误！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
