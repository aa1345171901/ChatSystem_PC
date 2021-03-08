namespace QQ_piracy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Media;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Aptech.UI;
    using QQ_piracy.Manager.Request;
    using QQ_piracy.MusicForms;

    public partial class MainForm : Form
    {
        // 用于异步标识，0为正常，1为 成功，2为失败
        public int IsGetMsgs = 0;
        public int IsGetFriends = 0;
        public int IsDel = 0;
        public int IsAdd = 0;
        public int IsUpdate = 0;
        public int IsShow = 0;

        public Dictionary<int, string> MsgDics;        // 用于异步设置接收的消息
        public Dictionary<int, (string, int)> FriendDic;   // 用于异步设置好友列表
        public string Result;                   // 用于异步设置添加陌生人好友的失败反馈
        public int StrangerId;          // 用于异步设置陌生人信息
        public string NickName;
        public int FaceId;
        public string ResultValue;     // 用于异步设置消息盒

        public List<int> ChatForms = new List<int>();  // 用于判断chat是否重复

        // 管理 requestFrom的回传消息
        public AddFriendMessageRequest AddFriendRequest;
        public AgreeAddFriendRequest AgreeAddRequest;

        // 管理 chatFrom的回传消息
        public ChatByReceiveReqeust ChatReceiveRequest;
        public SendByChatRequest ChatSendRequest;

        public Dictionary<int, RequestForm> UserRequestDict = new Dictionary<int, RequestForm>(); // 管理用户的requestForm
        public Dictionary<int, ChatForm> UserChatDict = new Dictionary<int, ChatForm>(); // 管理用户的chatForm 使消息能正确传达到指定form

        private GetUnreadMessageRequest getUnreadRequest;
        private GetFriendListRequest getFriends;
        private DeleteFriendRequest deleteFriend;
        private AddStrangerRequest addStrangerRequest;
        private UpdateStrangerRequest updateStrangerList;

        Dictionary<int, int> userFaceIdDic = new Dictionary<int, int>(); // 消息的发起者与发消息的好友的头像Id
        Dictionary<int, int> systemMsgDic = new Dictionary<int, int>(); // 系统消息好友的头像Id

        int messageImageIndex = 0;  // 工具栏中的消息图标的索引

        bool isXF = false;              // 在最小化的时候设定不能启用悬浮 //需要在designer里更改状态

        Icon icon1 = null;
        Icon icon2 = null;
        Icon icon3 = null;

        int timerRun = 0; // 获取自动连接的时间

        private string faceFilePath = Application.StartupPath + "\\FaceImage\\"; // 获取保存头像的文件

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// 初始化，设置好各种request
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            icon1 = new Icon("1.ico");
            icon2 = new Icon("2.ico");
            icon3 = new Icon("3.ico");

            // 给按钮添加事件
            this.toolStripMenuItem2.Click += Sorry_Click;
            this.toolStripMenuItem3.Click += Sorry_Click;
            this.toolStripMenuItem4.Click += Sorry_Click;
            this.toolStripM3enuItem5.Click += Sorry_Click;
            this.toolStripMenuItem6.Click += Sorry_Click;
            this.toolStripMenuItem7.Click += Sorry_Click;
            this.toolStripMenuItem8.Click += Sorry_Click;
            this.toolStripMenuItem5.Click += Sorry_Click;
            this.toolStripMenuItem9.Click += Sorry_Click;
            this.toolStripButton2.Click += Sorry_Click;
            this.pictureBox1.MouseMove += PictureBox1_MouseMove;

        }

        // 控制无边框窗体的移动
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //常量
            int WM_SYSCOMMAND = 0x0112;

            //窗体移动
            int SC_MOVE = 0xF010;
            int HTCAPTION = 0x0002;

            isXF = true; //设置能悬浮

            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        /// <summary>
        /// 登录后显示个人的信息,以及鼠标悬浮在最小化图标处的文本
        /// </summary>
        public void ShowSelfInfo()
        {
            int faceId = UserHelper.FaceId;
            string nickName = UserHelper.NickName;
            int id = UserHelper.LoginId;

            // 在窗体标题显示登录的昵称、号码
            this.Text = UserHelper.LoginId.ToString();

            string appPath = faceFilePath + faceId + ".jpg";

            // 设置头像
            if (File.Exists(appPath))
            {
                Image img = Image.FromFile(appPath);
                this.selfMessage.BackgroundImage = img.GetThumbnailImage(60, 60, null, IntPtr.Zero);
            }
            this.nickName.Text = nickName;
            this.notifyIcon1.Text = "QQ:" + nickName + "(" + id + ")" + "\n声音：开启" + "\n消息提醒框：关闭" + "\n会话消息：任务栏头像不闪动";
        }

        public void ResponseGetUnreadMsg()
        {
            if (IsGetMsgs == 1)
            {
                IsGetMsgs = 0;
                foreach (var item in MsgDics)
                {
                    int messageTypeId = -1;
                    int messageState = -1;
                    string[] strs = item.Value.Split(',');
                    messageTypeId = int.Parse(strs[1]);
                    messageState = int.Parse(strs[2]);
                    if (int.Parse(strs[3]) == 0)
                    {
                        SoundPlayer player = null;
                        if (messageTypeId == 1)
                        {
                            player = new SoundPlayer("msg.wav");
                        }

                        if (messageTypeId == 2)
                        {
                            player = new SoundPlayer("system.wav");
                        }

                        player.Play();
                    }

                    // 判断消息类型，如果是添加好友消息，就启动喇叭timer，让小喇叭闪烁
                    if (messageTypeId == 2 && messageState == 0)
                    {
                        if (!systemMsgDic.ContainsKey(int.Parse(strs[0])))
                        {
                            systemMsgDic.Add(int.Parse(strs[0]), int.Parse(strs[4]));
                            tmrAddFriend.Start();
                        }
                    }

                    // 如果是聊天消息，就启动聊天timer，让好友头像闪烁
                    if (messageTypeId == 1 && messageState == 0)
                    {
                        try
                        {
                            if (!userFaceIdDic.ContainsKey(int.Parse(strs[0])))
                            {
                                userFaceIdDic.Add(int.Parse(strs[0]), int.Parse(strs[4]));   // 设置发消息的好友的头像索引
                            }

                            tmrChatRequest.Start();  // 启动闪烁头像定时器
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                MsgDics.Clear();
                foreach (var item in userFaceIdDic)
                {
                    // 如果发消息的人没有在列表中就添加到陌生人列表中
                    if (!HasShowUser(item.Key))
                    {
                        UpdateStranger(item.Key);
                    }
                }

                tmrChatRequest.Start();  // 启动闪烁头像定时器
            }
            else if (IsGetMsgs == 2)
            {
                IsGetMsgs = 0;
                tmrChatRequest.Stop();
            }
        }

        /// <summary>
        /// 对发送的获取好友列表进行响应
        /// </summary>
        public void ResponseGetFriends()
        {
            if (IsGetFriends == 1)
            {
                IsGetFriends = 0;
                foreach (var it in FriendDic)
                {
                    // 创建一个SideBar项
                    SbItem item = new SbItem(it.Value.Item1, it.Value.Item2);
                    item.Tag = it.Key; // 将号码放在Tag属性中

                    // SideBar中的组可以通过数组的方式访问，按照添加的顺序索引从0开始
                    // Groups[0]表示SideBar中的第一个组，也就是“我的好友”组
                    sbFriends.Groups[0].Items.Add(item); // 向SideBar的“我的好友”组中添加项
                }
            }
        }

        /*todo
         * SbItem item = new SbItem(it.Value.Item1, it.Value.Item2);
         */
        public void AddIlfaces(Image img) // 用于添加用户自定义头像,网络上收到的头像保存到本地,初始化再存入
        {
            ilFaces.Images.Add(img);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            // dic.Add(FaceId, index); FaceId对应index //保存到dic
        }

        public void ResponseDelete()
        {
            if (IsDel == 1)
            {
                IsDel = 0;
                MessageBox.Show("好友已删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
            }
            else if (IsDel == 2)
            {
                IsDel = 0;
                MessageBox.Show("服务器发生意外错误！稍后重试", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ResponseAddStranger()
        {
            if (IsAdd == 1)
            {
                IsAdd = 0;
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                ShowFriendList();   // 更新好友列表
            }
            else if (IsAdd == 2)
            {
                IsAdd = 0;
                MessageBox.Show(Result, "添加失败，请稍候再试！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ResponseStrangerUpdate()
        {
            if (IsUpdate == 1)
            {
                IsUpdate = 0;
                SbItem item = new SbItem(NickName, FaceId);
                item.Tag = StrangerId;           // 将Id记录在Tag属性中
                sbFriends.Groups[1].Items.Add(item);  // 向陌生人组中添加项
                sbFriends.VisibleGroup = sbFriends.Groups[1];  // 设定陌生人组为可见组
            }
        }

        /// <summary>
        /// 用于显示消息反馈
        /// </summary>
        public void ShowMessage()
        {
            if (IsShow == 1)
            {
                IsShow = 0;
                MessageBox.Show(ResultValue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IsShow == 2)
            {
                IsShow = 0;
                MessageBox.Show(ResultValue, "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 定时向服务器发送请求，找到未读消息
        /// </summary>
        private void tmrMessage_Tick(object sender, EventArgs e)
        {
            try
            {
                // 获取一条未读消息
                getUnreadRequest.SendRequest(UserHelper.LoginId.ToString());
            }
            catch (Exception ex)
            {
                timerRun += 200;
                notifyIcon1.Text = "断开网络，将在" + (10 - (this.timerRun / 1000.0)) + "秒后连接";
                notifyIcon1.Icon = icon3;
                ConnectNet.Start();
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 向我的好友组中添加我的好友列表
        /// </summary>
        private void ShowFriendList()
        {
            // 清空原来的列表
            sbFriends.Groups[0].Items.Clear();
            try
            {
                getFriends.SendRequest(UserHelper.LoginId.ToString());
            }
            catch (Exception ex)
            {
                tmrMessage.Stop();
                MessageBox.Show(ex.Message, "更新好友发生意外错误！请检查网络，稍后重试", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 点击按钮，发送删除好友请求
        /// </summary>
        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result;   // 对话框结果
            if (sbFriends.SeletedItem != null)
            {
                result = MessageBox.Show("确实要删除该好友吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // 选中的时我的好友分组
                    if (sbFriends.VisibleGroup == sbFriends.Groups[0])
                    {
                        int hostFriendId = UserHelper.LoginId;
                        int accetFriendId = (int)sbFriends.SeletedItem.Tag;
                        string data = hostFriendId.ToString() + "," + accetFriendId.ToString();
                        try
                        {
                            deleteFriend.SendRequest(data);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("提示：" + ex.Message, "连接服务器出错，请检查您的网络", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {// 若是陌生人分组不需要连接服务器，可以直接从列表删除
                        MessageBox.Show("好友已删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                    }
                }
            }
        }

        /// <summary>
        /// 将选中的人加为好友
        /// </summary>
        private void addfriendItem_Click(object sender, EventArgs e)
        {
            try
            {
                int hostFriendId = UserHelper.LoginId;
                int accetFriendId = (int)sbFriends.SeletedItem.Tag;
                string data = hostFriendId.ToString() + "," + accetFriendId.ToString();
                addStrangerRequest.SendRequest(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("提示：" + ex.Message, "连接服务器出错，请检查您的网络", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 更新陌生人列表
        /// </summary>
        private void UpdateStranger(int strangerId)
        {
            try
            {
                updateStrangerList.SendRequest(strangerId.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "更新陌生人列表发生意外错误！请检查网络，稍后重试", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 主界面加载
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;    // 隐藏窗体边框
            notifyIcon1.Icon = icon1;                        // 工具栏的消息图标
            this.ShowInTaskbar = false;                     // 隐藏任务栏
            this.WindowState = FormWindowState.Normal;
            SyncTimer.Start();

            getUnreadRequest = new GetUnreadMessageRequest(this);
            getFriends = new GetFriendListRequest(this);
            deleteFriend = new DeleteFriendRequest(this);
            addStrangerRequest = new AddStrangerRequest(this);
            updateStrangerList = new UpdateStrangerRequest(this);

            AddFriendRequest = new AddFriendMessageRequest(this);
            AgreeAddRequest = new AgreeAddFriendRequest(this);

            ChatSendRequest = new SendByChatRequest(this);
            ChatReceiveRequest = new ChatByReceiveReqeust(this);

            // 显示个人的信息
            ShowSelfInfo();

            // 添加 SideBar 的两个组
            sbFriends.AddGroup("我的好友");
            sbFriends.AddGroup("陌生人");

            // 向我的好友组中添加我的好友列表
            ShowFriendList();
        }

        /// <summary>
        /// 将所有request移除
        /// </summary>
        private void RequestClose()
        {
            getUnreadRequest.Close();
            getFriends.Close();
            deleteFriend.Close();
            addStrangerRequest.Close();
            updateStrangerList.Close();

            AgreeAddRequest.Close();
            AddFriendRequest.Close();
        }

        /// <summary>
        /// 最小化
        /// </summary>
        private void min_Click(object sender, EventArgs e)
        {
            this.Hide();                     // 隐藏窗体
            this.WindowState = FormWindowState.Minimized;
            isXF = false;
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sorry_Click(object sender, EventArgs e)
        {
            MessageBox.Show("抱歉！该功能尚未开通！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 退出
        /// </summary>
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;  // 设置图标不可见

            this.Close();                 // 关闭窗体

            RequestClose();

            this.Dispose();               // 释放资源

            Application.Exit();           // 关闭应用程序窗体
        }

        /// <summary>
        /// 最小化图标右键菜单的打开主界面
        /// </summary>
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            this.Show();                               // 窗体显示

            this.WindowState = FormWindowState.Normal;  // 窗体状态默认大小

            this.Activate();                           // 激活窗体给予焦点
        }

        /// <summary>
        /// 最小化图标右键菜单的最小化按钮
        /// </summary>
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            this.Hide();                     // 隐藏窗体
        }

        // 悬浮即时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isXF)
            {
                // 如果鼠标在窗体边缘附近
                if (Cursor.Position.X > Location.X && (Cursor.Position.X < (Location.X + 310)) && (Cursor.Position.Y < 5 && Cursor.Position.Y > -5))
                {
                    this.Show();                               // 窗体显示

                    this.WindowState = FormWindowState.Normal;  // 窗体状态默认大小

                    this.Activate();                           // 激活窗体给予焦点
                }

                // Console.WriteLine(Cursor.Position.X+"+"+ Cursor.Position.Y);
                // 如果鼠标在窗体外面则隐藏  并且top在屏幕top
                if ((Cursor.Position.Y > 710 || Cursor.Position.X < Location.X || (Cursor.Position.X > (Location.X + 310)))
                    && (Location.Y < 5 && Location.Y > -5))
                {
                    this.Hide();                     // 隐藏窗体
                }
            }
        }

        /// <summary>
        /// 最小化图标右键菜单的退出按钮
        /// </summary>
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;  // 设置图标不可见

            this.Close();                 // 关闭窗体

            RequestClose();

            this.Dispose();               // 释放资源

            Application.Exit();           // 关闭应用程序窗体
        }

        /// <summary>
        /// 点击自己的头像用于跳转到显示个人信息
        /// </summary>
        private void selfMessage_Click(object sender, EventArgs e)
        {
            PersonalInfoForm personalInfoForm;
            if (!CheckFormIsOpen("PersonalInfoForm"))
            {
                personalInfoForm = new PersonalInfoForm(this);
            }
            else
            {
                personalInfoForm = (PersonalInfoForm)Application.OpenForms["PersonalInfoForm"];
            }

            this.Hide();
            personalInfoForm.Show();
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

        /// <summary>
        /// 添加好友按钮，搜索好友
        /// </summary>
        private void addFriendButton_Click(object sender, EventArgs e)
        {
            SearchFriendForm searchFriendForm;
            if (!CheckFormIsOpen("SearchFriendForm"))
            {
                searchFriendForm = new SearchFriendForm();
            }
            else
            {
                searchFriendForm = (SearchFriendForm)Application.OpenForms["SearchFriendForm"];
            }

            searchFriendForm.Show();
        }

        // 双击好友头像，弹出聊天窗体
        private void sbFriends_ItemDoubleClick(SbItemEventArgs e)
        {
            // 消息timer停止运行
            if (tmrChatRequest.Enabled == true)
            {
                tmrChatRequest.Stop();

                // e.Item.ImageIndex = this.friendFaceId;
            }

            // 显示聊天窗体
            if (!ChatForms.Contains(Convert.ToInt32(e.Item.Tag)))
            {
                // 将未读消息的该好友去掉
                if (userFaceIdDic.ContainsKey((int)e.Item.Tag))
                {
                    e.Item.ImageIndex = userFaceIdDic[Convert.ToInt32(e.Item.Tag)];
                    userFaceIdDic.Remove((int)e.Item.Tag);
                }

                ChatForm chatForm = new ChatForm();
                chatForm.FriendId = Convert.ToInt32(e.Item.Tag); // 号码
                ChatForms.Add(Convert.ToInt32(e.Item.Tag));
                chatForm.NickName = e.Item.Text;  // 昵称
                chatForm.FaceId = e.Item.ImageIndex;  // 头像
                chatForm.SelfnickName = nickName.Text;
                chatForm.MainForm = this;
                UserChatDict.Add(Convert.ToInt32(e.Item.Tag), chatForm);
                chatForm.Show();
            }
        }

        // 控制喇叭闪烁
        private void tmrAddFriend_Tick(object sender, EventArgs e)
        {
            // 反复修改它的图像
            messageImageIndex = messageImageIndex == 0 ? 1 : 0;
            if (messageImageIndex == 0)
            {
                notifyIcon1.Icon = icon1;
            }
            else
            {
                notifyIcon1.Icon = icon2;
            }
        }

        /// <summary>
        /// 鼠标双击最小化图标操作
        /// </summary>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 有未读系统信息 双击打开聊天框
            if (systemMsgDic.Count != 0)
            {
                tmrAddFriend.Stop();  // 消息timer停止运行// 图片恢复正常

                messageImageIndex = 0;
                notifyIcon1.Icon = icon1;

                foreach (var item in systemMsgDic)
                {
                    if (!UserRequestDict.ContainsKey(item.Key))
                    {
                        // 显示系统消息窗体
                        RequestForm requestForm = new RequestForm();
                        requestForm.MainForm = this;
                        requestForm.FromUserId = item.Key;
                        requestForm.FaceId = item.Value;
                        UserRequestDict.Add(item.Key, requestForm);
                        requestForm.Show();
                    }
                    else
                    {
                        int id = item.Key;
                        UserRequestDict[id].Show();
                    }
                }

                systemMsgDic.Clear();
            }
            else
            {// 么有未读系统信息  双击打开面版
                this.Show();                               // 窗体显示

                isXF = false;  // 关闭悬浮

                this.WindowState = FormWindowState.Normal;  // 窗体状态默认大小

                this.Activate();                           // 激活窗体给予焦点
            }
        }

        // 让相应的好友头像闪烁
        private void tmrChatRequest_Tick(object sender, EventArgs e)
        {
            // 循环好友列表两个组中的每个item，找到发消息的好友，让他的头像闪烁
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < sbFriends.Groups[i].Items.Count; j++)
                {
                    foreach (var item in userFaceIdDic)
                    {
                        if (Convert.ToInt32(sbFriends.Groups[i].Items[j].Tag) == item.Key)
                        {
                            if (sbFriends.Groups[i].Items[j].ImageIndex != 150)
                            {
                                sbFriends.Groups[i].Items[j].ImageIndex = 150; // 索引为150的图片是一个空白图片
                            }
                            else
                            {
                                sbFriends.Groups[i].Items[j].ImageIndex = item.Value;
                            }

                            sbFriends.Invalidate();
                        }
                    }
                }
            }
        }

        // 显示右键菜单时，控制哪些菜单不可见
        private void cmsFriendList_Opening(object sender, CancelEventArgs e)
        {
            // 如果没有选中的项
            if (sbFriends.SeletedItem == null)
            {
                delete.Visible = false;
            }
            else
            {
                delete.Visible = true;
            }

            // 如果选中的是陌生人，显示加为好友菜单
            if (sbFriends.SeletedItem != null && sbFriends.SeletedItem.Parent == sbFriends.Groups[1])
            {
                addfriendItem.Visible = true;
            }
            else
            {
                addfriendItem.Visible = false;
            }
        }

        // 显示大、小头像视图切换
        private void smallT_Click(object sender, EventArgs e)
        {
            if (sbFriends.View == SbView.LargeIcon)
            {
                sbFriends.View = SbView.SmallIcon;
                smallT.Text = "显示大头像";
            }
            else if (sbFriends.View == SbView.SmallIcon)
            {
                sbFriends.View = SbView.LargeIcon;
                smallT.Text = "显示小头像";
            }
        }

        // 可见组发生变化时，发出声音
        private void sbFriends_VisibleGroupChanged(SbGroupEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("folder.wav");
            player.Play();
        }

        /// <summary>
        /// 判断发消息的人是否在列表中
        /// </summary>
        private bool HasShowUser(int friendId)
        {
            bool find = false;  // 表示是否在当前显示出的用户列表中找到了该用户

            // 循环 SideBar 中的2个组，寻找发消息的人是否在列表中
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < sbFriends.Groups[i].Items.Count; j++)
                {
                    if (Convert.ToInt32(sbFriends.Groups[i].Items[j].Tag) == friendId)
                    {
                        find = true;
                    }
                }
            }

            return find;
        }

        // 点击刷新好友列表
        private void fresh_Click(object sender, EventArgs e)
        {
            ShowFriendList();
        }

        /// <summary>
        /// 鼠标点击上方拖动的box，设置自动悬浮
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isXF = true;
        }

        /// <summary>
        /// 用于异步调用窗口
        /// </summary>
        private void SyncTimer_Tick(object sender, EventArgs e)
        {
            ResponseAddStranger();
            ResponseDelete();
            ResponseGetFriends();
            ResponseGetUnreadMsg();
            ResponseStrangerUpdate();
            ShowMessage();
        }

        private void ConnectNet_Tick(object sender, EventArgs e)
        {
            if (ManagerController.Instance.ConnectNetAgain())
            {
                ConnectNet.Stop();
                notifyIcon1.Icon = icon1;
                this.notifyIcon1.Text = "QQ:" + UserHelper.NickName + "(" + UserHelper.LoginId + ")" + "\n声音：开启" + "\n消息提醒框：关闭" + "\n会话消息：任务栏头像不闪动";
            }
            else
            {
                this.notifyIcon1.Text = "正在重连，请稍后";
                timerRun = 0;
            }
        }

        /// <summary>
        /// 鼠标点击应用管理时弹出控件
        /// </summary>
        private void toolStripButton3_MouseDown(object sender, MouseEventArgs e)
        {
            toolStrip2.Visible = true;
        }

        /// <summary>
        /// 鼠标离开时消失
        /// </summary>
        private void toolStrip2_MouseLeave(object sender, EventArgs e)
        {
            toolStrip2.Visible = false;
        }

        /// <summary>
        /// 点击音乐按钮时弹出窗口
        /// </summary>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MusicMainForm musicForm;
            if (!CheckFormIsOpen("MusicMainForm"))
            {
                musicForm = new MusicMainForm();
            }
            else
            {
                musicForm = (MusicMainForm)Application.OpenForms["MusicMainForm"];
            }

            musicForm.Show();
        }
    }
}
