using Aptech.UI;
using Lordeo.Framework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ_piracy
{
    public partial class MainForm : Form
    {
        int fromUserId;  　// 消息的发起者
        int friendFaceId;  // 发消息的好友的头像Id  

        int messageImageIndex = 0;  // 工具栏中的消息图标的索引

        bool haveMessage = false;

        bool isXF=true;              //在最小化的时候设定不能启用悬浮 //需要在designer里更改状态

        public List<int> chatForms = new List<int>();  //用于判断chat是否重复

        Icon icon1 = null;
        Icon icon2 = null;
        public MainForm()
        {
            InitializeComponent();
            icon1 = new Icon("1.ico");
            icon2 = new Icon("2.ico");          
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;    //隐藏窗体边框
                                                            // 工具栏的消息图标
            notifyIcon1.Icon = icon1;
            this.ShowInTaskbar = false;                     //隐藏任务栏
            this.WindowState = FormWindowState.Normal;


            // 显示个人的信息            
            ShowSelfInfo();

            // 添加 SideBar 的两个组
            sbFriends.AddGroup("我的好友");
            sbFriends.AddGroup("陌生人");

            // 向我的好友组中添加我的好友列表
            ShowFriendList();

        }

        private void min_Click(object sender, EventArgs e)
        {
            this.Hide();                     //隐藏窗体
            this.WindowState = FormWindowState.Minimized;
            isXF = false;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sorry_Click(object sender, EventArgs e)
        {
            MessageBox.Show("抱歉！该功能尚未开通！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;  //设置图标不可见

            this.Close();                 //关闭窗体

            this.Dispose();               //释放资源

            Application.Exit();           //关闭应用程序窗体
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            this.Show();                               //窗体显示

            this.WindowState= FormWindowState.Normal;  //窗体状态默认大小

            this.Activate();                           //激活窗体给予焦点
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            this.Hide();                     //隐藏窗体
        }

        //悬浮即时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isXF)
            {
                //如果鼠标在窗体边缘附近  
                if (Cursor.Position.X > Location.X && (Cursor.Position.X < (Location.X + 310)) && (Cursor.Position.Y < 5 && Cursor.Position.Y > -5))
                {
                    this.Show();                               //窗体显示

                    this.WindowState = FormWindowState.Normal;  //窗体状态默认大小

                    this.Activate();                           //激活窗体给予焦点
                }
                //Console.WriteLine(Cursor.Position.X+"+"+ Cursor.Position.Y);
                //如果鼠标在窗体外面则隐藏  并且top在屏幕top
                if ((Cursor.Position.Y > 710 || Cursor.Position.X < Location.X || (Cursor.Position.X > (Location.X + 310)))
                    && (Location.Y < 5 && Location.Y > -5))
                {
                    this.Hide();                     //隐藏窗体
                }
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible= false;  //设置图标不可见

            this.Close();                 //关闭窗体

            this.Dispose();               //释放资源

            Application.Exit();           //关闭应用程序窗体
        }

        private void selfMessage_Click(object sender, EventArgs e)
        {
            PersonalInfoForm personalInfoForm;
            if (!CheckFormIsOpen("PersonalInfoForm"))
                personalInfoForm = new PersonalInfoForm();
            else
                personalInfoForm= (PersonalInfoForm)Application.OpenForms["PersonalInfoForm"];
            personalInfoForm.mainForm = this;  // 将当前窗体本身传给个人信息窗体
            this.Hide();
            personalInfoForm.Show();
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

        private void addFriendButton_Click(object sender, EventArgs e)
        {
            SearchFriendForm searchFriendForm;
            if (!CheckFormIsOpen("SearchFriendForm"))
                searchFriendForm = new SearchFriendForm();
            else
                searchFriendForm = (SearchFriendForm)Application.OpenForms["SearchFriendForm"];
            searchFriendForm.Show();
        }

        // 双击一项，弹出聊天窗体        
        private void sbFriends_ItemDoubleClick(SbItemEventArgs e)
        {
            // 消息timer停止运行
            if (tmrChatRequest.Enabled == true)
            {
                tmrChatRequest.Stop();
                e.Item.ImageIndex = this.friendFaceId;
            }

            // 显示聊天窗体
            if (!chatForms.Contains(Convert.ToInt32(e.Item.Tag)))
            {
                ChatForm chatForm = new ChatForm();
                chatForm.friendId = Convert.ToInt32(e.Item.Tag); // 号码
                chatForms.Add(Convert.ToInt32(e.Item.Tag));
                chatForm.nickName = e.Item.Text;  // 昵称
                chatForm.faceId = e.Item.ImageIndex;  // 头像
                chatForm.selfnickName = nickName.Text;
                chatForm.mainForm = this;
                chatForm.Show();
            }
        }

        // 定时扫描数据库，找到未读消息
        private void tmrMessage_Tick(object sender, EventArgs e)
        {
            ShowFriendList();       // 刷新好友列表
            int messageTypeId = 1;  // 消息类型 2代表添加好友，1代表好友消息
            int messageState = 1;   // 消息状态 1表示已读，0表示未读
            //int havePlayAdiuo = -1;   //声音只能播放一次
            //int AdiuoType = -1;      //0播放消息，1播放系统

            MySqlCommand cmd=null;
            // 消息有两种类型：聊天消息、添加好友消息
            try
            {
                // 找出未读消息对应的好友Id
                cmd = new MySqlCommand("select  FromUserId, MessageType, MessageState,havePlayAdiuo,msgId from Messages where touserid=@touserid and messagestate=0", DBHelper.Connect());
                cmd.Parameters.AddWithValue("touserid", UserHelper.loginId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // 读出一个未读消息
                while(dataReader.Read())
                {
                    haveMessage = true;
                    fromUserId = dataReader.GetInt32("FromUserId");
                    messageTypeId = dataReader.GetInt32("MessageType");
                    messageState = dataReader.GetInt32("MessageState");
                    if (dataReader.GetInt32("havePlayAdiuo") == 0)
                    {
                        //havePlayAdiuo = 0;
                        //if ((AdiuoType == 1 && messageTypeId == 1) || (AdiuoType == 0 && messageTypeId == 2))
                        //{
                        //    AdiuoType = 2;
                        //}
                        //if (messageTypeId == 1&& AdiuoType != 2)
                        //    AdiuoType = 0;
                        //if (messageTypeId == 2 && AdiuoType != 2)
                        //    AdiuoType = 1;
                        SoundPlayer player=null;
                        if (messageTypeId == 1)
                        {
                            player = new SoundPlayer("msg.wav");
                        }
                        if(messageTypeId == 2)
                        {
                            player = new SoundPlayer("system.wav");
                        }
                        player.Play();
                    }
                    // 判断消息类型，如果是添加好友消息，就启动喇叭timer，让小喇叭闪烁
                    if (messageTypeId == 2 && messageState == 0)
                    {
                        tmrAddFriend.Start();
                    }
                    // 如果是聊天消息，就启动聊天timer，让好友头像闪烁
                    if (messageTypeId == 1 && messageState == 0)
                    {
                        // 获得发消息的人的头像Id
                        MySqlCommand command;
                        command = new MySqlCommand("SELECT FaceId FROM Userdata,user WHERE userdata.id=user.dataid and user.id=@userid",DBHelper.Connect());
                        try
                        {
                            command.Parameters.AddWithValue("userid", fromUserId);
                            friendFaceId = Convert.ToInt32(command.ExecuteScalar());   // 设置发消息的好友的头像索引
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        // 如果发消息的人没有在列表中就添加到陌生人列表中
                        if (!HasShowUser(fromUserId))
                        {
                            UpdateStranger(fromUserId);
                        }
                        tmrChatRequest.Start();  // 启动闪烁头像定时器
                    }
                }
                dataReader.Close();
                cmd.CommandText = "update messages set haveplayadiuo=1";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
            //if (havePlayAdiuo == 0)
            //{
            //    SoundPlayer player;
            //    if (AdiuoType == 0)
            //        player = new SoundPlayer("msg.wav");
            //    else if(AdiuoType == 1)
            //        player = new SoundPlayer("system.wav");
            //    else
            //    {
            //        player = new SoundPlayer("system.wav");
            //        player.Play();
            //        player = new SoundPlayer("msg.wav");
            //    }
            //    player.Play();
            //}
        }

        // 控制喇叭闪烁
        private void tmrAddFriend_Tick(object sender, EventArgs e)
        {
            // 反复修改它的图像
            messageImageIndex = messageImageIndex == 0 ? 1 : 0;
            if(messageImageIndex==0)
                notifyIcon1.Icon = icon1;
            else
                notifyIcon1.Icon = icon2;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (haveMessage)//有未读系统信息 双击打开聊天框
            {
                tmrAddFriend.Stop();  // 消息timer停止运行 
                                      // 图片恢复正常
                messageImageIndex = 0;
                notifyIcon1.Icon = icon1;

                // 显示系统消息窗体
                RequestForm requestForm = new RequestForm();
                requestForm.Show();
            }
            else//么有未读系统信息  双击打开面版
            {
                this.Show();                               //窗体显示

                this.WindowState = FormWindowState.Normal;  //窗体状态默认大小

                this.Activate();                           //激活窗体给予焦点
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
                    if (Convert.ToInt32(sbFriends.Groups[i].Items[j].Tag) == this.fromUserId)
                    {
                        if (sbFriends.Groups[i].Items[j].ImageIndex < 100)
                        {
                            sbFriends.Groups[i].Items[j].ImageIndex = 100;// 索引为100的图片是一个空白图片
                        }
                        else
                        {
                            sbFriends.Groups[i].Items[j].ImageIndex = this.friendFaceId;
                        }
                        sbFriends.Invalidate();  //
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

        //删除好友
        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result;   // 对话框结果
            int deleteResult = 0;  // 操作结果
            if (sbFriends.SeletedItem != null)
            {
                result = MessageBox.Show("确实要删除该好友吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // 确认删除
                {
                    if (sbFriends.VisibleGroup == sbFriends.Groups[0])
                    {
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM Friend WHERE hostFriendId=@hostFriendId AND accetFriendId=@accetFriendId",DBHelper.Connect());
                        cmd.Parameters.AddWithValue("hostFriendId", UserHelper.loginId);
                        cmd.Parameters.AddWithValue("accetFriendId", sbFriends.SeletedItem.Tag);
                        try
                        {
                            deleteResult = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            DBHelper.Connect().Close();
                        }
                        if (deleteResult == 1)
                        {
                            MessageBox.Show("好友已删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("好友已删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                    }
                }
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

        // 将选中的人加为好友 
        private void addfriendItem_Click(object sender, EventArgs e)
        {
            int result = 0;  // 操作结果

            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Friend set hostFriendId=@hostFriendId,accetFriendId=@accetFriendId", DBHelper.Connect());
                cmd.Parameters.AddWithValue("hostFriendId", UserHelper.loginId);
                cmd.Parameters.AddWithValue("accetFriendId", sbFriends.SeletedItem.Tag);
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
            if (result == 1)
            {
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                ShowFriendList();   // 更新好友列表             
            }
            else
            {
                MessageBox.Show("添加失败，请稍候再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 可见组发生变化时，发出声音
        private void sbFriends_VisibleGroupChanged(SbGroupEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("folder.wav");
            player.Play();
        }

        /// <summary>
        /// 登录后显示个人的信息
        /// </summary>
        public void ShowSelfInfo()
        {
            string nickName = "";  // 昵称
            int faceId = 0;        // 头像索引
            bool error = false;    // 标识是否出现错误
           
            try
            {
                // 取得当前用户的昵称、头像
                MySqlCommand cmd = new MySqlCommand("SELECT NickName, FaceId FROM UserData WHERE id=@id", DBHelper.Connect());
                cmd.Parameters.AddWithValue("id", UserHelper.dataId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    if (!string.IsNullOrEmpty(dataReader.GetString("nickname")))  // 判断数据库类型是否为空
                    {
                        nickName = dataReader.GetString("nickname");
                    }
                    faceId = dataReader.GetInt32("FaceId");
                }
                dataReader.Close();
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

            // 根据操作数据库结果进行不同的操作
            if (error)
            {
                MessageBox.Show("服务器请求失败！请重新登录！", "意外错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                // 在窗体标题显示登录的昵称、号码
                this.Text = UserHelper.loginId.ToString();
                this.selfMessage.Image = ilFaces.Images[faceId];
                string appPath = Application.StartupPath + @"\" + faceId + ".jpg";
                //if (File.Exists(appPath)) //图片需跟exe同一路径下
                //{
                //    Image img = Image.FromFile(appPath);
                //    this.selfMessage.Image = img;
                //}

                this.nickName.Text = nickName;
                this.notifyIcon1.Text = "QQ:" + nickName + "(" + UserHelper.loginId.ToString() + ")" + "\n声音：开启" + "\n消息提醒框：关闭" + "\n会话消息：任务栏头像不闪动";
            }
        }

        /// <summary>
        /// 向我的好友组中添加我的好友列表
        /// </summary>
        private void ShowFriendList()
        {
            // 清空原来的列表
            sbFriends.Groups[0].Items.Clear();

            bool error = false;   // 标识数据库是否出错
         
            try
            {
                // 查找有哪些好友
                MySqlCommand cmd = new MySqlCommand("SELECT accetFriendId,NickName,FaceId FROM UserData,Friend,user WHERE Friend.hostFriendId=@hostFriendId  AND user.id=friend.accetFriendId AND UserData.id=user.dataid", DBHelper.Connect());
                cmd.Parameters.AddWithValue("hostFriendId",UserHelper.loginId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // 循环添加好友列表
                while (dataReader.Read())
                {
                    // 创建一个SideBar项
                    SbItem item = new SbItem((string)dataReader["NickName"], (int)dataReader["FaceId"]);
                    item.Tag = (int)dataReader["accetFriendId"]; // 将号码放在Tag属性中

                    // SideBar中的组可以通过数组的方式访问，按照添加的顺序索引从0开始
                    // Groups[0]表示SideBar中的第一个组，也就是“我的好友”组
                    sbFriends.Groups[0].Items.Add(item); // 向SideBar的“我的好友”组中添加项
                }

                dataReader.Close();
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
                MessageBox.Show("服务器发生意外错误！请尝试重新登录", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// 判断发消息的人是否在列表中
        /// </summary>        
        private bool HasShowUser(int loginId)
        {
            bool find = false;  // 表示是否在当前显示出的用户列表中找到了该用户

            // 循环 SideBar 中的2个组，寻找发消息的人是否在列表中
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < sbFriends.Groups[i].Items.Count; j++)
                {
                    if (Convert.ToInt32(sbFriends.Groups[i].Items[j].Tag) == loginId)
                    {
                        find = true;
                    }
                }
            }
            return find;
        }

        /// <summary>
        /// 更新陌生人列表
        /// </summary>        
        private void UpdateStranger(int loginId)
        {
            bool error = false; // 用来标识是否出现错误
            try
            {
                // 选出这个人的基本信息
                MySqlCommand cmd = new MySqlCommand("SELECT NickName, FaceId FROM Userdata,user WHERE user.Id=@userId and user.dataid=userdata.id",DBHelper.Connect());
                cmd.Parameters.AddWithValue("userId", loginId);
                MySqlDataReader dataReader = cmd.ExecuteReader(); // 查询
                if (dataReader.Read())
                {
                    SbItem item = new SbItem((string)dataReader["NickName"], (int)dataReader["FaceId"]);
                    item.Tag = this.fromUserId;           // 将Id记录在Tag属性中
                    sbFriends.Groups[1].Items.Add(item);  // 向陌生人组中添加项
                }
                sbFriends.VisibleGroup = sbFriends.Groups[1];  // 设定陌生人组为可见组
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
                MessageBox.Show("服务器出现意外错误！", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 点击刷新好友列表
        private void fresh_Click(object sender, EventArgs e)
        {
            ShowFriendList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isXF = true;
        }
    }

}
