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
    public partial class RequestForm : Form
    {
        int fromUserId = 0;

        public RequestForm()
        {
            InitializeComponent();
        }

        private void RequestForm_Load(object sender, EventArgs e)
        {
            int messageId = 0; // 消息的Id

            // 找到发给当前用户的请求消息
            string sql;
            try
            {
                // 查找一个未读消息
                MySqlCommand cmd = new MySqlCommand("select msgid,FromUserId from messages where touserid=@loginid and messagetype=2 and messagestate=0", DBHelper.Connect());
                cmd.Parameters.AddWithValue("loginid",UserHelper.loginId);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    messageId = (int)dataReader["msgid"];
                    this.fromUserId = (int)dataReader["FromUserId"];
                }
                dataReader.Close();

                // 将消息状态置为已读
                sql = "UPDATE Messages SET MessageState =1 WHERE msgid=@messageid";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("messageid", messageId);
                cmd.ExecuteNonQuery();

                // 读取请求人的信息，显示在窗体上
                sql = "SELECT NickName, FaceId FROM Userdata,user WHERE user.Id=@fromuserid and user.dataid=userdata.id";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("fromuserid", fromUserId);
                dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    int faceId = (int)dataReader["FaceId"];
                    string nickName = (string)dataReader["NickName"];
                    this.pbFace.BackgroundImage = ilFaces.Images[faceId];
                    this.userMsg.Text = nickName + "     (" + fromUserId + ")";
                    this.systemMsg.Text ="请求添加您为好友";
                    this.btnAllow.Visible = true;
                }
                else
                {
                    this.systemMsg.Text = "没有系统消息";
                    this.btnAllow.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
        }

        // 同意添加好友请求
        private void btnAllow_Click(object sender, EventArgs e)
        {
            // 先查找是否已经添加过了，防止重复添加
            try
            {
                MySqlCommand cmd = new MySqlCommand("select count(*) from friend where hostFriendId=@hostFriendId and AccetFriendId=@AccetFriendId", DBHelper.Connect());
                cmd.Parameters.AddWithValue("hostFriendId", fromUserId);
                cmd.Parameters.AddWithValue("AccetFriendId", UserHelper.loginId);
                int num = Convert.ToInt32(cmd.ExecuteScalar());

                if (num <= 0)  // 没有好友记录
                {
                    cmd = new MySqlCommand("insert into friend set hostFriendid=@hostFriendId,AccetFriendId=@AccetFriendId", DBHelper.Connect());
                    cmd.Parameters.AddWithValue("hostFriendId", fromUserId);
                    cmd.Parameters.AddWithValue("AccetFriendId", UserHelper.loginId);
                    // 执行添加操作 
                    cmd.ExecuteNonQuery();

                    //相互添加
                    cmd.CommandText = "insert into friend set hostfriendid=@hostfriendid,accetfriendid=@accetfriendid";
                    cmd.Parameters.AddWithValue("hostfriendid", UserHelper.loginId);
                    cmd.Parameters.AddWithValue("accetfriendid", fromUserId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
            this.Close();  // 关闭窗体
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();

            this.Close();
        }
    }
}
