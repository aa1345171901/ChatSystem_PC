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
    public partial class PersonalInfoForm : Form
    {
        public MainForm mainForm;  // 主窗体

        public PersonalInfoForm()
        {
            InitializeComponent();
        }

        public  void PersonalInfoForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;    //隐藏窗体边框


            int starId = -1;             // 星座Id
            int bloodTypeId = -1;        // 血型Id
            int faceId = 0;              // 头像Id
            int friendshipPolicyId = 0;  // 好友账号Id
            bool error = false;          // 用来标识操作数据库是否出错

            try
            {
                MySqlCommand cmd = new MySqlCommand("select sex,age,name,nickname,starid,bloodtypeid,faceid,FriendshipPolicyId from userdata where id=@dataid", DBHelper.Connect());
                cmd.Parameters.AddWithValue("dataid", UserHelper.dataId);
                MySqlDataReader reader = cmd.ExecuteReader();

                // 将查出的数据显示在窗体上
                if (reader.Read())
                {
                    this.idLabel.Text = UserHelper.loginId.ToString();        // 号码
                    this.nickLabel.Text = Convert.ToString(reader["NickName"]); // 昵称
                    
                    if (!(reader["Sex"] is DBNull))
                    {
                        this.sexlabel.Text = Convert.ToString(reader["Sex"]) == "男" ? "男" : "女"; // 性别
                    }

                    if (!(reader["Name"] is DBNull))
                    {
                        this.namelabel.Text = reader["Name"].ToString(); // 真实姓名
                    }
                    this.agelabel.Text = Convert.ToString(reader["Age"]);   // 年龄

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

                // 处理头像显示
                ShowFace(faceId);

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
                mainForm.ShowSelfInfo();
            }
        }

        /// <summary>
        /// 读取星座信息
        /// </summary>
        private void FillStarsComboBox(int currentStarId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT start FROM Start where id=@startid", DBHelper.Connect());
                cmd.Parameters.AddWithValue("startid", currentStarId);
                MySqlDataReader dataReader = cmd.ExecuteReader();


                if (dataReader.Read())
                {
                    // 将星座存放在星座数组中
                    this.startlabel.Text = Convert.ToString(dataReader["Start"]);
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
                MySqlCommand cmd = new MySqlCommand("SELECT bloodtype FROM bloodtype where id=@bloodtypeid", DBHelper.Connect());
                cmd.Parameters.AddWithValue("bloodtypeid", currentBloodTypeId);
                MySqlDataReader dataReader = cmd.ExecuteReader();


                if (dataReader.Read())
                {
                    // 将星座存放在星座数组中
                    this.bloodlabel.Text = Convert.ToString(dataReader["bloodtype"]);
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

        /// <summary>
        /// 处理显示的头像
        /// </summary>
        public void ShowFace(int currentFaceId)
        {
            touxiang.Image = ilFaces.Images[currentFaceId];
            touxiang.Tag = currentFaceId;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();                 //关闭窗体

            this.Dispose();               //释放资源
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void xiugai_Click(object sender, EventArgs e)
        {
            XGMessageForm xgform;
            if (!CheckFormIsOpen("XGMessageForm"))
                xgform = new XGMessageForm();
            else
                xgform = (XGMessageForm)Application.OpenForms["XGMessageForm"];
            xgform.personalInfoForm = this;
            this.Enabled = false;
            xgform.Show();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("抱歉！该功能尚未开通！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void touxiang_Click(object sender, EventArgs e)
        {
            FacesForm faceform;
            if (!CheckFormIsOpen("FacesForm"))
                faceform = new FacesForm();
            else
                faceform = (FacesForm)Application.OpenForms["FacesForm"];
            faceform.personalInfoForm = this;
            faceform.mainForm = this.mainForm;
            this.Enabled = false;
            faceform.Show();
        }
    }
}
