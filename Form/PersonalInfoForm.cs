namespace QQ_piracy
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using QQ_piracy.Helper;

    public partial class PersonalInfoForm : Form
    {
        private MainForm mainForm;  // 主窗体

        private string faceFilePath = Application.StartupPath + "\\FaceImage\\"; // 获取保存头像的文件

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalInfoForm"/> class.
        /// 界面初始化
        /// </summary>
        public PersonalInfoForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // 添加移动窗体事件
            this.pictureBox1.MouseMove += PictureBox1_MouseMove;
            this.panel1.MouseMove += PictureBox1_MouseMove;
        }

        /// <summary>
        /// 主界面加载
        /// </summary>
        public void PersonalInfoForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;    // 隐藏窗体边框

            int starId = UserHelper.StarId;             // 星座Id
            int bloodTypeId = UserHelper.BloodTypeId;        // 血型Id
            int faceId = UserHelper.FaceId;              // 头像Id

            this.idLabel.Text = UserHelper.LoginId.ToString();        // 号码
            this.nickLabel.Text = UserHelper.NickName; // 昵称
            if (UserHelper.Sex != null)
            {
                this.sexlabel.Text = UserHelper.Sex == "男" ? "男" : "女"; // 性别
            }

            if (UserHelper.Name != null)
            {
                this.namelabel.Text = UserHelper.Name.ToString(); // 真实姓名
            }

            this.agelabel.Text = UserHelper.Age.ToString();   // 年龄

            // 处理星座
            this.startlabel.Text = DataListHelper.StarList[starId];

            // 处理血型
            this.bloodlabel.Text = DataListHelper.BloodTypeList[bloodTypeId];

            // 处理头像显示
            ShowFace(faceId);

            // 主界面更改
            mainForm.ShowSelfInfo();
        }

        /// <summary>
        /// 处理显示的头像
        /// </summary>
        public void ShowFace(int currentFaceId)
        {
            string appPath = faceFilePath + currentFaceId + ".jpg";

            // 图片需跟exe同一路径下
            if (File.Exists(appPath))
            {
                Image img = Image.FromFile(appPath);
                touxiang.BackgroundImage = img.GetThumbnailImage(60, 60, null, IntPtr.Zero);
            }

            touxiang.Tag = currentFaceId;
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();                 // 关闭窗体

            this.Dispose();               // 释放资源
        }

        /// <summary>
        /// 最小化按钮
        /// </summary>
        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 修改按钮，点击进入修改界面
        /// </summary>
        private void xiugai_Click(object sender, EventArgs e)
        {
            XGMessageForm xgform;
            if (!CheckFormIsOpen("XGMessageForm"))
            {
                xgform = new XGMessageForm(this);
            }
            else
            {
                xgform = (XGMessageForm)Application.OpenForms["XGMessageForm"];
            }

            // xgform.personalInfoForm = this;
            this.Enabled = false;
            xgform.Show();
        }

        // 判断form是否出现
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("抱歉！该功能尚未开通！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 点击头像进入更换头像界面
        /// </summary>
        private void touxiang_Click(object sender, EventArgs e)
        {
            FacesForm faceform;
            if (!CheckFormIsOpen("FacesForm"))
            {
                faceform = new FacesForm(this);
            }
            else
            {
                faceform = (FacesForm)Application.OpenForms["FacesForm"];
            }

            this.Enabled = false;
            faceform.Show();
        }
    }
}
