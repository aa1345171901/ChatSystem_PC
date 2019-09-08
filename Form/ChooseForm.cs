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
    public partial class ChooseForm : Form
    {
        public ChooseForm()
        {
            InitializeComponent();
        }

        private void ChooseForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;    //修改窗体边框
            ApplyForm_Load();
        }

        // 窗体加载时，添加星座和血型组合框中的项
        private void ApplyForm_Load()
        {
            bool error = false;   // 标识操作数据库是否会出错
            string sql;
            try
            {
                // 添加星座组合框中的项                
                MySqlCommand cmd = new MySqlCommand("select start from start", DBHelper.Connect());
                MySqlDataReader reader = cmd.ExecuteReader();  // 执行查询

                while(reader.Read())
                {
                    start.Items.Add(reader.GetString("start"));
                }
                reader.Close();

                // 添加血型组合框中的项
                sql = "select bloodtype from bloodtype";  // 修改查询语句，查询血型
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    blood.Items.Add(reader.GetString("bloodtype"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                error = true;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.CloseConnection(DBHelper.Connect());
            }

            // 出错了
            if (error)
            {
                MessageBox.Show("服务器出现以外错误！", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void sureButton_Click(object sender, EventArgs e)
        {
            string trueName = name.Text;
            int age=0;
            if (!string.IsNullOrEmpty(this.age.Text))
                age= int.Parse(this.age.Text.Trim());
            string sex = male.Checked ? male.Text : fmale.Text;
            int startId = GetStarId();
            int bloodTypeId = GetBloodType();
            try
            {
                MySqlCommand cmd = new MySqlCommand("update userdata set age=@age,sex=@sex where id=@id", DBHelper.Connect());

                cmd.Parameters.AddWithValue("age", age);
                cmd.Parameters.AddWithValue("sex", sex);
                cmd.Parameters.AddWithValue("id", RegisterForm.dataId);
                cmd.ExecuteNonQuery();
                if (!string.IsNullOrEmpty(trueName))
                {
                    cmd.CommandText = "update userdata set name=@tureName where id=@id";
                    cmd.Parameters.AddWithValue("tureName", trueName);
                    cmd.ExecuteNonQuery();
                }
                if (bloodTypeId != -1)
                {
                    cmd.CommandText = "update userdata set bloodtypeid=@bloodtypeid where id=@id";
                    cmd.Parameters.AddWithValue("bloodtypeid", bloodTypeId);
                    cmd.ExecuteNonQuery();
                }
                if (startId != -1)
                {
                    cmd.CommandText = "update userdata set startid=@startid where id=@id";
                    cmd.Parameters.AddWithValue("startid", startId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString(),"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBHelper.Connect().Close();  // 关闭数据库连接
            }
            this.Close();
        }

        /// <summary>
        /// 取得星座的 Id
        /// </summary>        
        private int GetStarId()
        {
            int starId = -1;  // 返回值
            try
            {
                // 创建 Command 对象
                MySqlCommand cmd = new MySqlCommand("select id from start where start=@start", DBHelper.Connect());
                starId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }

            if (starId > 0)
            {
                return starId;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 取得血型的 Id
        /// </summary>        
        private int GetBloodType()
        {
            int bloodTypeId = -1;  // 返回值

          try
            {
                // 创建 Command 对象
                MySqlCommand cmd = new MySqlCommand("select id from bloodtype where bloodtype=@bloodtype", DBHelper.Connect());
                bloodTypeId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
            if (bloodTypeId > 0)
            {
                return bloodTypeId;
            }
            else
            {
                return -1;
            }
        }

        private void goLoginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trueNameLabel_Click(object sender, EventArgs e)
        {
            trueNameLabel.Visible = false;
            name.Select();
            if (string.IsNullOrEmpty(age.Text))
            {
                ageLabel.Visible = true;
            }
        }

        private void ageLabel_Click(object sender, EventArgs e)
        {
            ageLabel.Visible = false;
            age.Select();
            if (string.IsNullOrEmpty(name.Text))
            {
                trueNameLabel.Visible = true;
            }
        }
    }
}
