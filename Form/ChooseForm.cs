namespace QQ_piracy
{
    using System;
    using System.Windows.Forms;
    using QQ_piracy.Helper;
    using QQ_piracy.Manager.Request;

    public partial class ChooseForm : Form
    {
        public int IsChoose = 0; // 用于处理异步回调的标识，0为正常，1为接收成功标识，2为接收失败标识

        private ChooseRequest chooseRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChooseForm"/> class.
        /// 选填界面初始化
        /// </summary>
        public ChooseForm()
        {
            InitializeComponent();
            chooseRequest = new ChooseRequest(this);
        }

        public void ResponseChoose()
        {
            if (IsChoose == 1)
            {
                IsChoose = 0;
                chooseRequest.Close();
                this.Close();
            }
            else if (IsChoose == 2)
            {
                IsChoose = 0;
                chooseRequest.Close();
                this.Close();
                MessageBox.Show("服务器无法响应", "请稍后重试", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 确定按钮，向服务器发送填写的数据
        /// </summary>
        private void sureButton_Click(object sender, EventArgs e)
        {
            string trueName = name.Text;
            int age = 0;
            if (!string.IsNullOrEmpty(this.age.Text))
            {
                age = int.Parse(this.age.Text.Trim());
            }

            string sex = male.Checked ? male.Text : fmale.Text;
            int startId = start.SelectedIndex;
            int bloodTypeId = blood.SelectedIndex;
            string data = UserHelper.DataId + "," + sex + "," + age + "," + name + "," + startId + "," + bloodTypeId;
            try
            {
                chooseRequest.SendRequest(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "无法连接网络，请检查您的网络", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 主窗口初始化
        /// </summary>
        private void ChooseForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;    // 修改窗体边框
            ApplyForm_Load();
            SyncTimer.Start();
        }

        // 窗体加载时，添加星座和血型组合框中的项
        private void ApplyForm_Load()
        {
            string[] star = DataListHelper.StarList;
            string[] bloodType = DataListHelper.BloodTypeList;
            for (int i = 0; i < star.Length; i++)
            {
                start.Items.Add(star[i]);
            }

            for (int i = 0; i < bloodType.Length; i++)
            {
                blood.Items.Add(bloodType);
            }
        }

        /// <summary>
        /// 进入登录界面
        /// </summary>
        private void goLoginButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 判断真实名字文本框是否点击的lable
        /// </summary>
        private void trueNameLabel_Click(object sender, EventArgs e)
        {
            trueNameLabel.Visible = false;
            name.Select();
            if (string.IsNullOrEmpty(age.Text))
            {
                ageLabel.Visible = true;
            }
        }

        /// <summary>
        /// 判断年龄文本框是否点击的lable
        /// </summary>
        private void ageLabel_Click(object sender, EventArgs e)
        {
            ageLabel.Visible = false;
            age.Select();
            if (string.IsNullOrEmpty(name.Text))
            {
                trueNameLabel.Visible = true;
            }
        }

        /// <summary>
        /// 用于异步处理
        /// </summary>
        private void SyncTimer_Tick(object sender, EventArgs e)
        {
            ResponseChoose();
        }
    }
}
