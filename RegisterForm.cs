using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QQ_piracy
{
    public partial class RegisterForm : Form
    {

        public static long dataId = -1;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

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

        private void registerButton_Click(object sender, EventArgs e)
        {
            // 输入验证通过，就插入记录到数据库
            if (ValidateInput())
            {
                long myQQNum = 0;     // QQ号码
                long dataid = 0;      //与QQ关联的数据表id
                string message;      // 弹出的消息
                //string sex = rdoMale.Checked ? rdoMale.Text : rdoFemale.Text; // 获得选中的性别
                string sql;
                //int starId;          // 星座Id
                //int bloodTypeId;     // 血型Id   
                bool error = false;  // 操作数据库是否出错

                try
                {
                    // 创建数据biao
                    MySqlCommand cmd = new MySqlCommand("Insert into userdata set nickname=@nickname", DBHelper.Connect());
                    cmd.Parameters.AddWithValue("nickname", textNick.Text.Trim());
                    int result = cmd.ExecuteNonQuery();
                    if(result==1)
                    dataid =cmd.LastInsertedId;

                    // 创建账户并与数据表相连
                    sql = "Insert into user set password=@password,dataid=@dataid";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("password", textPsw.Text.Trim());
                    cmd.Parameters.AddWithValue("dataid", dataid);
                    result=cmd.ExecuteNonQuery();
                    if (result==1)
                    {
                        myQQNum = cmd.LastInsertedId;
                        message = string.Format("注册成功！请小心保管您的账号\n您的MyQQ号码是{0}", myQQNum);
                    }
                    else
                    {
                        message = "注册失败，请重试！";
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    message = "服务器出现意外错误！请稍候再试！";
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DBHelper.CloseConnection(DBHelper.Connect());  // 关闭数据库连接
                }

                // 显示注册结果
                if (error)
                {
                    MessageBox.Show(message, "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(message, "注册结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ChooseForm chooseForm = new ChooseForm();
                dataId = dataid;
                chooseForm.Show();
                this.Close();
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
    }
}
