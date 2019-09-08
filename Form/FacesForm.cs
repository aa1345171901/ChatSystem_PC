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
    public partial class FacesForm : Form
    {

        public PersonalInfoForm personalInfoForm;  // 个人信息窗体
        public MainForm mainForm;  // 个人信息窗体

        public FacesForm()
        {
            InitializeComponent();
        }

        private void FacesForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ilFaces.Images.Count; i++)
            {
                lvFace.Items.Add(i.ToString());
                lvFace.Items[i].ImageIndex = i;
            }
            if (lvFace.SelectedItems.Count == 0)
            {
                sure.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                sure.Enabled = false;
            }
        }

        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            personalInfoForm.Enabled = true;
            this.Close();
        }

        //确认
        private void sure_Click(object sender, EventArgs e)
        {
            int faceId = lvFace.SelectedItems[0].ImageIndex;  // 获得当前选中的头像的索引
            int result = -1;
            try
            {
                MySqlCommand cmd = new MySqlCommand("update userdata set faceid=@faceid where id=@dataid", DBHelper.Connect());
                cmd.Parameters.AddWithValue("faceid", faceId);
                cmd.Parameters.AddWithValue("dataid", UserHelper.dataId);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
            if (result!=1)
            {
                MessageBox.Show("更换头像失败，连接数据库时发生错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                personalInfoForm.ShowFace(faceId);  // 设置个人信息窗体中显示的头像
                mainForm.ShowSelfInfo();
            }

            personalInfoForm.Enabled=true;
            this.Close();
        }

        // 双击时选择头像
        private void lvIcons_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int faceId = lvFace.SelectedItems[0].ImageIndex;  // 获得当前选中的头像的索引
            personalInfoForm.ShowFace(faceId);  // 设置个人信息窗体中显示的头像
            //mainForm.ShowSelfInfo();
            personalInfoForm.Enabled = true;
            this.Close();
        }

        // 单击时选择头像
        private void lvIcons_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvFace.SelectedItems.Count != 0)
            {
                sure.ForeColor = System.Drawing.SystemColors.WindowText;
                sure.Enabled = true;
            }
        }

        private void FacesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            personalInfoForm.Enabled = true;
        }
    }
}
