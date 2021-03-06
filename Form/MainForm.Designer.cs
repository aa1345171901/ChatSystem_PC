using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QQ_piracy
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.min = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.anquan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripM3enuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.addFriendButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.IlMessage = new System.Windows.Forms.ImageList(this.components);
            this.tmrMessage = new System.Windows.Forms.Timer(this.components);
            this.tmrAddFriend = new System.Windows.Forms.Timer(this.components);
            this.tmrChatRequest = new System.Windows.Forms.Timer(this.components);
            this.cmsFriendList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smallT = new System.Windows.Forms.ToolStripMenuItem();
            this.addfriendItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fresh = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.minSystem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.selfMessage = new System.Windows.Forms.PictureBox();
            this.sbFriends = new Aptech.UI.SideBar();
            this.ilFaces = new System.Windows.Forms.ImageList(this.components);
            this.nickName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SyncTimer = new System.Windows.Forms.Timer(this.components);
            this.ConnectNet = new System.Windows.Forms.Timer(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.cmsFriendList.SuspendLayout();
            this.minSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selfMessage)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // min
            // 
            this.min.BackColor = System.Drawing.Color.White;
            this.min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.min.FlatAppearance.BorderSize = 0;
            this.min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.min.Font = new System.Drawing.Font("方正舒体", 15F);
            this.min.ForeColor = System.Drawing.Color.Black;
            this.min.Location = new System.Drawing.Point(226, -1);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(35, 33);
            this.min.TabIndex = 14;
            this.min.Text = "-";
            this.min.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.min.UseVisualStyleBackColor = false;
            this.min.Click += new System.EventHandler(this.min_Click);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.White;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("方正舒体", 15F);
            this.close.ForeColor = System.Drawing.Color.Black;
            this.close.Location = new System.Drawing.Point(260, -1);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(35, 33);
            this.close.TabIndex = 13;
            this.close.Text = "×";
            this.close.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(295, 109);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.addFriendButton,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 633);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(294, 38);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.anquan,
            this.toolStripMenuItem5,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(44, 35);
            this.toolStripDropDownButton1.Text = "更多";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "超级会员";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "会员官网";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem3.Text = "会员专享";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem4.Text = "续费超级会员";
            // 
            // anquan
            // 
            this.anquan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripM3enuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.anquan.Name = "anquan";
            this.anquan.Size = new System.Drawing.Size(124, 22);
            this.anquan.Text = "安全";
            // 
            // toolStripM3enuItem5
            // 
            this.toolStripM3enuItem5.Name = "toolStripM3enuItem5";
            this.toolStripM3enuItem5.Size = new System.Drawing.Size(148, 22);
            this.toolStripM3enuItem5.Text = "安全沟通";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem6.Text = "设备锁";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem7.Text = "安全中心首页";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem8.Text = "QQ安全帮助";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem5.Text = "帮助";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem9.Text = "升级";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem10.Text = "设置";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem11.Text = "退出";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // addFriendButton
            // 
            this.addFriendButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addFriendButton.Image = ((System.Drawing.Image)(resources.GetObject("addFriendButton.Image")));
            this.addFriendButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.addFriendButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addFriendButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFriendButton.Name = "addFriendButton";
            this.addFriendButton.Size = new System.Drawing.Size(34, 35);
            this.addFriendButton.Text = "加好友";
            this.addFriendButton.Click += new System.EventHandler(this.addFriendButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(32, 35);
            this.toolStripButton2.Text = "腾讯文档";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(32, 35);
            this.toolStripButton3.Text = "应用管理";
            this.toolStripButton3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton3_MouseDown);
            // 
            // IlMessage
            // 
            this.IlMessage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IlMessage.ImageStream")));
            this.IlMessage.TransparentColor = System.Drawing.Color.Transparent;
            this.IlMessage.Images.SetKeyName(0, "1.ico");
            this.IlMessage.Images.SetKeyName(1, "message.png");
            // 
            // tmrMessage
            // 
            this.tmrMessage.Enabled = true;
            this.tmrMessage.Interval = 200;
            this.tmrMessage.Tick += new System.EventHandler(this.tmrMessage_Tick);
            // 
            // tmrAddFriend
            // 
            this.tmrAddFriend.Interval = 500;
            this.tmrAddFriend.Tick += new System.EventHandler(this.tmrAddFriend_Tick);
            // 
            // tmrChatRequest
            // 
            this.tmrChatRequest.Interval = 500;
            this.tmrChatRequest.Tick += new System.EventHandler(this.tmrChatRequest_Tick);
            // 
            // cmsFriendList
            // 
            this.cmsFriendList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallT,
            this.addfriendItem,
            this.fresh,
            this.delete});
            this.cmsFriendList.Name = "cmsFriendList";
            this.cmsFriendList.Size = new System.Drawing.Size(125, 92);
            this.cmsFriendList.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFriendList_Opening);
            // 
            // smallT
            // 
            this.smallT.Name = "smallT";
            this.smallT.Size = new System.Drawing.Size(124, 22);
            this.smallT.Text = "小头像";
            this.smallT.Click += new System.EventHandler(this.smallT_Click);
            // 
            // addfriendItem
            // 
            this.addfriendItem.Name = "addfriendItem";
            this.addfriendItem.Size = new System.Drawing.Size(124, 22);
            this.addfriendItem.Text = "加为好友";
            this.addfriendItem.Click += new System.EventHandler(this.addfriendItem_Click);
            // 
            // fresh
            // 
            this.fresh.Name = "fresh";
            this.fresh.Size = new System.Drawing.Size(124, 22);
            this.fresh.Text = "刷新";
            this.fresh.Click += new System.EventHandler(this.fresh_Click);
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(124, 22);
            this.delete.Text = "删除";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.minSystem;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "QQ";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // minSystem
            // 
            this.minSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14});
            this.minSystem.Name = "minSystem";
            this.minSystem.Size = new System.Drawing.Size(137, 70);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem12.Text = "打开主面板";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem13.Text = "最小化托盘";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem14.Text = "退出";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // selfMessage
            // 
            this.selfMessage.BackColor = System.Drawing.Color.White;
            this.selfMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selfMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selfMessage.Image = global::QQ_piracy.Properties.Resources.Mask3;
            this.selfMessage.Location = new System.Drawing.Point(12, 28);
            this.selfMessage.Name = "selfMessage";
            this.selfMessage.Size = new System.Drawing.Size(60, 60);
            this.selfMessage.TabIndex = 19;
            this.selfMessage.TabStop = false;
            this.selfMessage.Click += new System.EventHandler(this.selfMessage_Click);
            // 
            // sbFriends
            // 
            this.sbFriends.AllowDragItem = false;
            this.sbFriends.BackColor = System.Drawing.Color.White;
            this.sbFriends.ContextMenuStrip = this.cmsFriendList;
            this.sbFriends.FlatStyle = Aptech.UI.SbFlatStyle.Flat;
            this.sbFriends.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sbFriends.ForeColor = System.Drawing.Color.AliceBlue;
            this.sbFriends.GroupHeaderBackColor = System.Drawing.Color.AliceBlue;
            this.sbFriends.GroupTextColor = System.Drawing.Color.Black;
            this.sbFriends.ImageList = this.ilFaces;
            this.sbFriends.ItemContextMenuStrip = null;
            this.sbFriends.ItemStyle = Aptech.UI.SbItemStyle.PushButton;
            this.sbFriends.ItemTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sbFriends.Location = new System.Drawing.Point(0, 108);
            this.sbFriends.Name = "sbFriends";
            this.sbFriends.RadioSelectedItem = null;
            this.sbFriends.Size = new System.Drawing.Size(294, 522);
            this.sbFriends.TabIndex = 20;
            this.sbFriends.View = Aptech.UI.SbView.SmallIcon;
            this.sbFriends.VisibleGroup = null;
            this.sbFriends.VisibleGroupIndex = -1;
            this.sbFriends.VisibleGroupChanged += new Aptech.UI.SbGroupEventHandler(this.sbFriends_VisibleGroupChanged);
            this.sbFriends.ItemDoubleClick += new Aptech.UI.SbItemEventHandler(this.sbFriends_ItemDoubleClick);
            // 
            // ilFaces
            // 
            this.ilFaces.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilFaces.ImageStream")));
            this.ilFaces.TransparentColor = System.Drawing.Color.Transparent;
            this.ilFaces.Images.SetKeyName(0, "1.jpg");
            this.ilFaces.Images.SetKeyName(1, "1.jpg");
            this.ilFaces.Images.SetKeyName(2, "2.jpg");
            this.ilFaces.Images.SetKeyName(3, "3.jpg");
            this.ilFaces.Images.SetKeyName(4, "4.jpg");
            this.ilFaces.Images.SetKeyName(5, "5.jpg");
            this.ilFaces.Images.SetKeyName(6, "6.jpg");
            this.ilFaces.Images.SetKeyName(7, "7.jpg");
            this.ilFaces.Images.SetKeyName(8, "8.jpg");
            this.ilFaces.Images.SetKeyName(9, "9.jpg");
            this.ilFaces.Images.SetKeyName(10, "10.jpg");
            this.ilFaces.Images.SetKeyName(11, "11.jpg");
            this.ilFaces.Images.SetKeyName(12, "12.jpg");
            this.ilFaces.Images.SetKeyName(13, "13.jpg");
            this.ilFaces.Images.SetKeyName(14, "14.jpg");
            this.ilFaces.Images.SetKeyName(15, "15.jpg");
            this.ilFaces.Images.SetKeyName(16, "16.jpg");
            this.ilFaces.Images.SetKeyName(17, "17.jpg");
            this.ilFaces.Images.SetKeyName(18, "18.jpg");
            this.ilFaces.Images.SetKeyName(19, "19.jpg");
            this.ilFaces.Images.SetKeyName(20, "20.jpg");
            this.ilFaces.Images.SetKeyName(21, "21.jpg");
            this.ilFaces.Images.SetKeyName(22, "22.jpg");
            this.ilFaces.Images.SetKeyName(23, "23.jpg");
            this.ilFaces.Images.SetKeyName(24, "24.jpg");
            this.ilFaces.Images.SetKeyName(25, "25.jpg");
            this.ilFaces.Images.SetKeyName(26, "26.jpg");
            this.ilFaces.Images.SetKeyName(27, "27.jpg");
            this.ilFaces.Images.SetKeyName(28, "28.jpg");
            this.ilFaces.Images.SetKeyName(29, "29.jpg");
            this.ilFaces.Images.SetKeyName(30, "30.jpg");
            this.ilFaces.Images.SetKeyName(31, "31.jpg");
            this.ilFaces.Images.SetKeyName(32, "32.jpg");
            this.ilFaces.Images.SetKeyName(33, "33.jpg");
            this.ilFaces.Images.SetKeyName(34, "34.jpg");
            this.ilFaces.Images.SetKeyName(35, "35.jpg");
            this.ilFaces.Images.SetKeyName(36, "36.jpg");
            this.ilFaces.Images.SetKeyName(37, "37.jpg");
            this.ilFaces.Images.SetKeyName(38, "38.jpg");
            this.ilFaces.Images.SetKeyName(39, "39.jpg");
            this.ilFaces.Images.SetKeyName(40, "40.jpg");
            this.ilFaces.Images.SetKeyName(41, "41.jpg");
            this.ilFaces.Images.SetKeyName(42, "42.jpg");
            this.ilFaces.Images.SetKeyName(43, "43.jpg");
            this.ilFaces.Images.SetKeyName(44, "44.jpg");
            this.ilFaces.Images.SetKeyName(45, "45.jpg");
            this.ilFaces.Images.SetKeyName(46, "46.jpg");
            this.ilFaces.Images.SetKeyName(47, "47.jpg");
            this.ilFaces.Images.SetKeyName(48, "48.jpg");
            this.ilFaces.Images.SetKeyName(49, "49.jpg");
            this.ilFaces.Images.SetKeyName(50, "50.jpg");
            this.ilFaces.Images.SetKeyName(51, "51.jpg");
            this.ilFaces.Images.SetKeyName(52, "52.jpg");
            this.ilFaces.Images.SetKeyName(53, "53.jpg");
            this.ilFaces.Images.SetKeyName(54, "54.jpg");
            this.ilFaces.Images.SetKeyName(55, "55.jpg");
            this.ilFaces.Images.SetKeyName(56, "56.jpg");
            this.ilFaces.Images.SetKeyName(57, "57.jpg");
            this.ilFaces.Images.SetKeyName(58, "58.jpg");
            this.ilFaces.Images.SetKeyName(59, "59.jpg");
            this.ilFaces.Images.SetKeyName(60, "60.jpg");
            this.ilFaces.Images.SetKeyName(61, "61.jpg");
            this.ilFaces.Images.SetKeyName(62, "62.jpg");
            this.ilFaces.Images.SetKeyName(63, "63.jpg");
            this.ilFaces.Images.SetKeyName(64, "64.jpg");
            this.ilFaces.Images.SetKeyName(65, "65.jpg");
            this.ilFaces.Images.SetKeyName(66, "66.jpg");
            this.ilFaces.Images.SetKeyName(67, "67.jpg");
            this.ilFaces.Images.SetKeyName(68, "68.jpg");
            this.ilFaces.Images.SetKeyName(69, "69.jpg");
            this.ilFaces.Images.SetKeyName(70, "70.jpg");
            this.ilFaces.Images.SetKeyName(71, "71.jpg");
            this.ilFaces.Images.SetKeyName(72, "72.jpg");
            this.ilFaces.Images.SetKeyName(73, "73.jpg");
            this.ilFaces.Images.SetKeyName(74, "74.jpg");
            this.ilFaces.Images.SetKeyName(75, "75.jpg");
            this.ilFaces.Images.SetKeyName(76, "76.jpg");
            this.ilFaces.Images.SetKeyName(77, "77.jpg");
            this.ilFaces.Images.SetKeyName(78, "78.jpg");
            this.ilFaces.Images.SetKeyName(79, "79.jpg");
            this.ilFaces.Images.SetKeyName(80, "80.jpg");
            this.ilFaces.Images.SetKeyName(81, "81.jpg");
            this.ilFaces.Images.SetKeyName(82, "82.jpg");
            this.ilFaces.Images.SetKeyName(83, "83.jpg");
            this.ilFaces.Images.SetKeyName(84, "84.jpg");
            this.ilFaces.Images.SetKeyName(85, "85.jpg");
            this.ilFaces.Images.SetKeyName(86, "86.jpg");
            this.ilFaces.Images.SetKeyName(87, "87.jpg");
            this.ilFaces.Images.SetKeyName(88, "88.jpg");
            this.ilFaces.Images.SetKeyName(89, "89.jpg");
            this.ilFaces.Images.SetKeyName(90, "90.jpg");
            this.ilFaces.Images.SetKeyName(91, "91.jpg");
            this.ilFaces.Images.SetKeyName(92, "92.jpg");
            this.ilFaces.Images.SetKeyName(93, "93.jpg");
            this.ilFaces.Images.SetKeyName(94, "94.jpg");
            this.ilFaces.Images.SetKeyName(95, "95.jpg");
            this.ilFaces.Images.SetKeyName(96, "96.jpg");
            this.ilFaces.Images.SetKeyName(97, "97.jpg");
            this.ilFaces.Images.SetKeyName(98, "98.jpg");
            this.ilFaces.Images.SetKeyName(99, "99.jpg");
            this.ilFaces.Images.SetKeyName(100, "100.jpg");
            this.ilFaces.Images.SetKeyName(101, "101.jpg");
            this.ilFaces.Images.SetKeyName(102, "102.jpg");
            this.ilFaces.Images.SetKeyName(103, "103.jpg");
            this.ilFaces.Images.SetKeyName(104, "104.jpg");
            this.ilFaces.Images.SetKeyName(105, "105.jpg");
            this.ilFaces.Images.SetKeyName(106, "106.jpg");
            this.ilFaces.Images.SetKeyName(107, "107.jpg");
            this.ilFaces.Images.SetKeyName(108, "108.jpg");
            this.ilFaces.Images.SetKeyName(109, "109.jpg");
            this.ilFaces.Images.SetKeyName(110, "110.jpg");
            this.ilFaces.Images.SetKeyName(111, "111.jpg");
            this.ilFaces.Images.SetKeyName(112, "112.jpg");
            this.ilFaces.Images.SetKeyName(113, "113.jpg");
            this.ilFaces.Images.SetKeyName(114, "114.jpg");
            this.ilFaces.Images.SetKeyName(115, "115.jpg");
            this.ilFaces.Images.SetKeyName(116, "116.jpg");
            this.ilFaces.Images.SetKeyName(117, "117.jpg");
            this.ilFaces.Images.SetKeyName(118, "118.jpg");
            this.ilFaces.Images.SetKeyName(119, "119.jpg");
            this.ilFaces.Images.SetKeyName(120, "120.jpg");
            this.ilFaces.Images.SetKeyName(121, "121.jpg");
            this.ilFaces.Images.SetKeyName(122, "122.jpg");
            this.ilFaces.Images.SetKeyName(123, "123.jpg");
            this.ilFaces.Images.SetKeyName(124, "124.jpg");
            this.ilFaces.Images.SetKeyName(125, "125.jpg");
            this.ilFaces.Images.SetKeyName(126, "126.jpg");
            this.ilFaces.Images.SetKeyName(127, "127.jpg");
            this.ilFaces.Images.SetKeyName(128, "128.jpg");
            this.ilFaces.Images.SetKeyName(129, "129.jpg");
            this.ilFaces.Images.SetKeyName(130, "130.jpg");
            this.ilFaces.Images.SetKeyName(131, "131.jpg");
            this.ilFaces.Images.SetKeyName(132, "132.jpg");
            this.ilFaces.Images.SetKeyName(133, "133.jpg");
            this.ilFaces.Images.SetKeyName(134, "134.jpg");
            this.ilFaces.Images.SetKeyName(135, "135.jpg");
            this.ilFaces.Images.SetKeyName(136, "136.jpg");
            this.ilFaces.Images.SetKeyName(137, "137.jpg");
            this.ilFaces.Images.SetKeyName(138, "138.jpg");
            this.ilFaces.Images.SetKeyName(139, "139.jpg");
            this.ilFaces.Images.SetKeyName(140, "140.jpg");
            this.ilFaces.Images.SetKeyName(141, "141.jpg");
            this.ilFaces.Images.SetKeyName(142, "142.jpg");
            this.ilFaces.Images.SetKeyName(143, "143.jpg");
            this.ilFaces.Images.SetKeyName(144, "144.jpg");
            this.ilFaces.Images.SetKeyName(145, "145.jpg");
            this.ilFaces.Images.SetKeyName(146, "146.jpg");
            this.ilFaces.Images.SetKeyName(147, "147.jpg");
            this.ilFaces.Images.SetKeyName(148, "148.jpg");
            this.ilFaces.Images.SetKeyName(149, "149.jpg");
            this.ilFaces.Images.SetKeyName(150, "150.jpg");
            // 
            // nickName
            // 
            this.nickName.AutoSize = true;
            this.nickName.BackColor = System.Drawing.Color.White;
            this.nickName.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nickName.Location = new System.Drawing.Point(93, 28);
            this.nickName.MaximumSize = new System.Drawing.Size(130, 0);
            this.nickName.Name = "nickName";
            this.nickName.Size = new System.Drawing.Size(0, 24);
            this.nickName.TabIndex = 21;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SyncTimer
            // 
            this.SyncTimer.Tick += new System.EventHandler(this.SyncTimer_Tick);
            // 
            // ConnectNet
            // 
            this.ConnectNet.Interval = 10000;
            this.ConnectNet.Tick += new System.EventHandler(this.ConnectNet_Tick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(221, 588);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(42, 42);
            this.toolStrip2.TabIndex = 22;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.Visible = false;
            this.toolStrip2.MouseLeave += new System.EventHandler(this.toolStrip2_MouseLeave);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(39, 39);
            this.toolStripButton1.Text = "音乐";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(294, 671);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.nickName);
            this.Controls.Add(this.selfMessage);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.min);
            this.Controls.Add(this.close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sbFriends);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1000, 0);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsFriendList.ResumeLayout(false);
            this.minSystem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selfMessage)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        //this.toolStripMenuItem2.Click += Sorry_Click;
        //this.toolStripMenuItem3.Click += Sorry_Click;
        //this.toolStripMenuItem4.Click += Sorry_Click;
        //this.toolStripM3enuItem5.Click += Sorry_Click;
        //this.toolStripMenuItem6.Click += Sorry_Click;
        //this.toolStripMenuItem7.Click += Sorry_Click;
        //this.toolStripMenuItem8.Click += Sorry_Click;
        //this.toolStripMenuItem5.Click += Sorry_Click;
        //this.toolStripMenuItem9.Click += Sorry_Click;
        //this.toolStripButton2.Click += Sorry_Click;
        //this.toolStripButton3.Click += Sorry_Click;
        //this.pictureBox1.MouseMove += PictureBox1_MouseMove;
        // 控制无边框窗体的移动
        //using System.Runtime.InteropServices;

        #endregion

        private System.Windows.Forms.Button min;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripButton addFriendButton;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem anquan;
        private ToolStripMenuItem toolStripM3enuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ImageList IlMessage;
        private Timer tmrMessage;
        private Timer tmrAddFriend;
        private Timer tmrChatRequest;
        private ContextMenuStrip cmsFriendList;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip minSystem;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem toolStripMenuItem14;
        private PictureBox selfMessage;
        private Aptech.UI.SideBar sbFriends;
        private ToolStripMenuItem delete;
        private ToolStripMenuItem addfriendItem;
        private ToolStripMenuItem smallT;
        private Label nickName;
        private ToolStripMenuItem fresh;
        private Timer timer1;
        private Timer SyncTimer;
        private Timer ConnectNet;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton1;
        private ImageList ilFaces;
    }
}