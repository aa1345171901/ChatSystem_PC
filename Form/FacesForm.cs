namespace QQ_piracy
{
    using System;
    using System.Windows.Forms;
    using QQ_piracy.Manager.Request;

    public partial class FacesForm : Form
    {
        private PersonalInfoForm personalInfoForm;  // 个人信息窗体
        private SetSystemFaceRequest setSystemFaceRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacesForm"/> class.
        /// 主窗体加载
        /// </summary>
        public FacesForm(PersonalInfoForm personalInfoForm)
        {
            InitializeComponent();
            this.personalInfoForm = personalInfoForm;
        }

        /// <summary>
        /// 对发送的更换头像请求做出响应
        /// </summary>
        public void ResponseSetFaceSystem(bool isSet, int faceId)
        {
            if (isSet)
            {
                UserHelper.FaceId = faceId;
                personalInfoForm.PersonalInfoForm_Load(null, null);  // 设置个人信息窗体和主窗体中显示的头像
                personalInfoForm.Enabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("更换头像失败，服务器无响应", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 确认按钮向服务器发送更改头像请求
        /// </summary>
        private void sure_Click(object sender, EventArgs e)
        {
            int faceId = lvFace.SelectedItems[0].ImageIndex;  // 获得当前选中的头像的索引
            try
            {
                int dataId = UserHelper.DataId;
                string data = dataId + "," + faceId;
                setSystemFaceRequest.SendRequest(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("更换头像失败，请检查您的网络", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FacesForm_Load(object sender, EventArgs e)
        {
            setSystemFaceRequest = new SetSystemFaceRequest(this);

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

        // 取消
        private void button2_Click(object sender, EventArgs e)
        {
            personalInfoForm.Enabled = true;
            this.Close();
        }

        /*// 双击时选择头像
        private void lvIcons_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int faceId = lvFace.SelectedItems[0].ImageIndex;  // 获得当前选中的头像的索引
            personalInfoForm.PersonalInfoForm_Load(null, null);  // 设置个人信息窗体和主窗体中显示的头像
            personalInfoForm.Enabled = true;
            this.Close();
        }*/

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
