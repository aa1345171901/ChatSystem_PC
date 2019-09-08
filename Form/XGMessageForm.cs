using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ_piracy
{
    public partial class XGMessageForm : Form
    {

        private string[] stars = new string[12];      // 星座Id数组
        private string[] bloodTypes = new string[4];  // 血型Id数组
        public  PersonalInfoForm personalInfoForm;

        public XGMessageForm()
        {
            InitializeComponent();
        }

        private void XGMessageForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;    //修改窗体边框


            save.Enabled = false;                          //信息未变动不能修改
            cbsex.Items.Add("男");
            cbsex.Items.Add("女");

            int starId = -1;             // 星座Id
            int bloodTypeId = -1;        // 血型Id
            int faceId = 0;              // 头像Id
            int friendshipPolicyId = 0;  // 添加好友策略Id
            bool error = false;          // 用来标识操作数据库是否出错

            try
            {
                MySqlCommand cmd = new MySqlCommand("select sex,age,name,nickname,starid,bloodtypeid,faceid,FriendshipPolicyId from userdata where id=@dataid", DBHelper.Connect());
                cmd.Parameters.AddWithValue("dataid", UserHelper.dataId);
                MySqlDataReader reader = cmd.ExecuteReader();

                // 将查出的数据显示在窗体上
                if (reader.Read())
                {
                    this.tbNick.Text = Convert.ToString(reader["NickName"]); // 昵称

                    if (!(reader["Sex"] is DBNull))
                    {
                        this.cbsex.Text = Convert.ToString(reader["Sex"]) == "男" ? "男" : "女"; // 性别
                    }

                    if (!(reader["Name"] is DBNull))
                    {
                        this.tbname.Text = reader["Name"].ToString(); // 真实姓名
                    }
                    this.tbAge.Text = Convert.ToString(reader["Age"]);   // 年龄

                    if (!(reader["StarId"] is DBNull))
                    {
                        starId = Convert.ToInt32(reader["StarId"]);  // 星座Id
                    }
                    if (!(reader["BloodTypeId"] is DBNull))
                    {
                        bloodTypeId = Convert.ToInt32(reader["BloodTypeId"]);  // 血型Id
                    }
                    faceId = Convert.ToInt32(reader["FaceId"]);  // 头像Id
                    friendshipPolicyId = Convert.ToInt32(reader["FriendshipPolicyId"]); // 好友策略Id
                }
            }
            catch (Exception ex)
            {
                error = true;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }

            // 出错了
            if (error)
            {
                MessageBox.Show("显示个人信息出错！", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // 处理星座
                FillStarsComboBox(starId);

                // 处理血型
                FillBloodTypesComboBox(bloodTypeId);

                //// 处理好友策略
                //switch (friendshipPolicyId)
                //{
                //    case 1:
                //        rdoAnybody.Checked = true;
                //        break;
                //    case 2:
                //        rdoValidation.Checked = true;
                //        break;
                //    case 3:
                //        rdoNobody.Checked = true;
                //        break;
                //    default:
                //        rdoAnybody.Checked = true;
                //        break;
                //}
            }
        }

        /// <summary>
        /// 读取星座信息
        /// </summary>
        private void FillStarsComboBox(int currentStarId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT start FROM Start order by id asc", DBHelper.Connect());
                MySqlDataReader dataReader = cmd.ExecuteReader();

                int i = 0;
                while (dataReader.Read())
                {
                    // 将星座存放在星座数组中
                    this.stars[i] = Convert.ToString(dataReader["Start"]);
                    i++;
                }

                // 将星座数组中的星座添加到星座组合框中
                for (i = 0; i < stars.Length; i++)
                {
                    star.Items.Add(stars[i]);
                    if (currentStarId == i + 1)
                    {
                        star.SelectedIndex = i;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("读星座出错");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
        }

        /// <summary>
        /// 读取血型信息
        /// </summary>
        private void FillBloodTypesComboBox(int currentBloodTypeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT bloodtype FROM bloodtype order by id asc", DBHelper.Connect());
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // 初始化血型数组
                int i = 0;
                while (dataReader.Read())
                {
                    // 将血型存放在血型数组中
                    this.bloodTypes[i] = Convert.ToString(dataReader["BloodType"]);
                    i++;
                }
                // 将血型数组中的血型添加到血型组合框中
                for (i = 0; i < bloodTypes.Length; i++)
                {
                    bloodtype.Items.Add(bloodTypes[i]);
                    if (currentBloodTypeId == i + 1)
                    {
                        bloodtype.SelectedIndex = i;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("读血型出错");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();                 //关闭窗体

            this.Dispose();               //释放资源
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (ValidataInput())
            {
                int result = -1;    //操作结果反馈给用户
                try
                {
                    MySqlCommand cmd = new MySqlCommand("update userdata set nickname=@nickname,sex=@sex,age=@age,name=@name,starid=@starid,bloodtypeid=@bloodtypeid where id=@dataid", DBHelper.Connect());
                    cmd.Parameters.AddWithValue("nickname", tbNick.Text);
                    cmd.Parameters.AddWithValue("sex", cbsex.Text);
                    cmd.Parameters.AddWithValue("age", int.Parse(tbAge.Text));
                    cmd.Parameters.AddWithValue("name", tbname.Text);
                    cmd.Parameters.AddWithValue("starid", star.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("bloodtypeid", bloodtype.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("dataid", UserHelper.dataId);
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    DBHelper.Connect().Close();
                }
                // 根据执行结果，显示不同的消息
                if (result == 1)
                {

                }
                else
                {
                    MessageBox.Show("服务器操作失败！", "操作结果", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Close();                 //关闭窗体

                this.Dispose();               //释放资源
                
                personalInfoForm.PersonalInfoForm_Load(null,null);
            }
        }

        //用于验证用户填写的信息是否正确
        private bool ValidataInput()
        {
            if (tbNick.Text.Length > 15)
            {
                MessageBox.Show("输入的昵称不能超过15个字符","输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNick.Focus();
                return false;
            }
            if (!int.TryParse(tbAge.Text.Trim(),out int i)|| tbAge.Text.Length>3)
            {
                MessageBox.Show("年龄只能是整数并且不能超过3位数", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNick.Focus();
                return false;
            }
            if (tbNick.Text.Length > 30)
            {
                MessageBox.Show("输入的姓名不能超过30个字符", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbname.Focus();
                return false;
            }
            return true;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            save.ForeColor=System.Drawing.SystemColors.ActiveCaptionText;
            save.Enabled = true;
        }

        private void XGMessageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            personalInfoForm.Enabled = true;
        }
    }
}
