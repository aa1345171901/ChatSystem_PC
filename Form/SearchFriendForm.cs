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
    public partial class SearchFriendForm : Form
    {
        private DataSet dataSet;  // 数据集
        private MySqlDataAdapter dataAdapter;  // 数据适配器

        public SearchFriendForm()
        {
            InitializeComponent();
        }

        private void SearchFriendForm_Load(object sender, EventArgs e)
        {
            // 实例化数据集和数据适配器并填充
            string sql = "SELECT user.Id, NickName, Age, Sex FROM userdata,user where user.dataid=userdata.id";
            dataAdapter = new MySqlDataAdapter(sql, DBHelper.Connect());
            dataSet = new DataSet("❀");
            dataAdapter.Fill(dataSet, "userdata,user");

            // 指定DataGridView的数据源
            dgvBasicResult.DataSource = dataSet.Tables[0];
            dataSet.Tables[0].Clear();
            //dgvAdvancedResult.DataSource = dataSet.Tables[0];
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text.Trim()))
            {
                //搜索栏非空就按昵称和id查找
                BasicallySearch();
            }
            else if(!string.IsNullOrEmpty(cboAge.Text)|| !string.IsNullOrEmpty(cboSex.Text))
            {
                //搜索栏为空，但是age和sex不为空
                AdvancedSearch();
            }
            else
            {
                //全都没选择，随机推荐
                RandomSearch();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int friendshipPolicyId = -1;  // 对方的好友策略            

            int friendId = GetSelectedFriendId();  // 获得选中的好友的Id

            // 是否有可添加的好友
            if (friendId == -1)
            {
                MessageBox.Show("请选择一个好友！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (friendId == UserHelper.loginId)
            {
                MessageBox.Show("不能加自己为好友！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (HasAdded(friendId))  // 确认是否需要添加（是否已经是好友了）
            {
                MessageBox.Show("对方已在你的好友列表中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 确认对方能否被加为好友
            friendshipPolicyId = GetFriendshipPolicyId(friendId);

            if (friendshipPolicyId == 3) // 3表示不允许任何人添加，在S2可以使用常量或枚举
            {
                MessageBox.Show("对方不允许任何人加他为好友！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (friendshipPolicyId == 2) // 2：表示需要身份验证
            {
                int result = SendRequest(friendId);  // 发验证消息
                if (result == 1)
                {
                    MessageBox.Show("对方需要身份验证才能被加为好友，已发出请求！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("添加失败，请稍候再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (friendshipPolicyId == 1) // 1：表示允许任何人添加为好友
            {
                // 执行添加操作
                int result = AddFriend(friendId);
                if (result == 1)
                {
                    MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("添加失败，请稍候再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// 基本查找
        /// </summary>
        private void BasicallySearch()
        {
            string sql = "";
            // 查询语句的前半部分
            sql = "SELECT user.Id,NickName,Age,Sex FROM Userdata,user";

            if (tbSearch.Text.Trim() != "")
            {
                try
                {
                    // 重新填充DataSet
                    dataSet.Tables[0].Clear();

                    sql += string.Format(" WHERE nickname='{0}' and user.dataid=userdata.id", tbSearch.Text.Trim());
                    dataAdapter.SelectCommand.CommandText = sql;
                    dataAdapter.Fill(dataSet, "userdata,user");

                    sql = "SELECT user.Id,NickName,Age,Sex FROM Userdata,user"+string.Format(" WHERE user.id={0} and user.dataid=userdata.id", int.Parse(tbSearch.Text.Trim()));
                    dataAdapter.SelectCommand.CommandText = sql;
                    dataAdapter.Fill(dataSet, "userdata,user");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                btnAdd.Visible = true;  //“加为好友”按钮可见
            }
        }

        /// <summary>
        /// 高级查找
        /// </summary>
        private void AdvancedSearch()
        {
            string sql = "";
            // 查询语句的前半部分
            sql = "SELECT user.Id,NickName,Age,Sex FROM Userdata,user";

            string ageCondition = "";  // 年龄条件
            string sexCondition = cboSex.Text;  // 性别条件

            // 确定年龄的范围
            switch (cboAge.SelectedIndex)
            {
                case 1:
                    ageCondition = " Age>=0 AND Age<18";
                    break;
                case 2:
                    ageCondition = " Age>=18 AND Age<22";
                    break;
                case 3:
                    ageCondition = " Age>=23 AND Age<26";
                    break;
                case 4:
                    ageCondition = " Age>=27 AND Age<35";
                    break;
                case 5:
                    ageCondition = " Age>=35 AND Age<50";
                    break;
                case 6:
                    ageCondition = " Age>=50";
                    break;
                default:
                    ageCondition = "";
                    break;
            }

            if (ageCondition != "" && sexCondition == "")
            {
                sql += string.Format(" WHERE {0} and userdata.id=user.dataid", ageCondition);
            }
            else if (ageCondition == "" && sexCondition != "")
            {
                sql += string.Format(" WHERE Sex='{0}' and userdata.id=user.dataid", sexCondition);
            }
            else if(ageCondition != "" && sexCondition != "")
            {
                sql += string.Format(" WHERE {0} AND Sex='{1}' and userdata.id=user.dataid", ageCondition, sexCondition);
            }

            // 开始查找
            dataAdapter.SelectCommand.CommandText = sql;
            dataSet.Tables[0].Clear();
            dataAdapter.Fill(dataSet, "userdata,user");

            btnAdd.Visible = true;
        }

        /// <summary>
        /// 基本查找
        /// </summary>
        private void RandomSearch()
        {
            string sql = "";
            // 查询语句的前半部分
            sql = "SELECT user.id,nickname,age,sex FROM userdata,user where user.dataid=userdata.id ORDER BY RAND() LIMIT 10";

                    // 重新填充DataSet
                    dataSet.Tables[0].Clear();

                    dataAdapter.SelectCommand.CommandText = sql;
                    dataAdapter.Fill(dataSet, "userdata,user");

                btnAdd.Visible = true;  //“加为好友”按钮可见
        }

        /// <summary>
        /// 获得选中的好友的Id
        /// </summary>        
        private int GetSelectedFriendId()
        {
            int friendId = -1;  // 好友的号码

            // 没有选中任何一行
            if (dgvBasicResult.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一个好友！", "操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // 确保第一个单元格有值
            else if (dgvBasicResult.SelectedRows[0].Cells[0] != null)
            {
                // 获得DataGridView中选中的行的第一个单元格的值
                friendId = int.Parse(dgvBasicResult.SelectedRows[0].Cells[0].Value.ToString());
            }
            return friendId;
        }

        /// <summary>
        /// 确认对方能否被加为好友
        /// </summary>        
        private int GetFriendshipPolicyId(int userId)
        {
            int friendshipPolicyId = 1;  // 好友策略
            try
            {
                MySqlCommand cmd = new MySqlCommand("select FriendshipPolicyId from userdata,user where user.id=@id and userdata.id=user.dataid", DBHelper.Connect());
                cmd.Parameters.AddWithValue("id", userId);

                friendshipPolicyId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
            return friendshipPolicyId;
        }

        /// <summary>
        /// 查找好友是否已被添加
        /// </summary>        
        private bool HasAdded(int friendId)
        {
            int result = 0;  // 查找结果
            bool returnValue; // 返回值
            try
            {
                MySqlCommand cmd = new MySqlCommand("select count(*) from friend where hostfriendid=@hostfriendid and accetfriendid=@accetfriendid", DBHelper.Connect());
                cmd.Parameters.AddWithValue("hostfriendid", UserHelper.loginId);
                cmd.Parameters.AddWithValue("accetfriendid", friendId);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }

            // 已有记录存在
            returnValue = result > 0 ? true : false;
            return returnValue;
        }

        /// <summary>
        /// 执行添加好友的操作   策略为1时直接相互添加好友
        /// </summary>        
        private int AddFriend(int friendId)
        {
            int resunlt = 0; // 操作结果

            try
            {
                // 执行添加操作  可以发送消息 但是对于对方是陌生人
                MySqlCommand cmd = new MySqlCommand("insert into friend set hostfriendid=@hostfriendid,accetfriendid=@accetfriendid", DBHelper.Connect());
                cmd.Parameters.AddWithValue("hostfriendid", UserHelper.loginId);
                cmd.Parameters.AddWithValue("accetfriendid", friendId);
                resunlt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
            return resunlt;
        }

        /// <summary>
        /// 发出添加好友请求
        /// </summary>        
        private int SendRequest(int friendId)
        {
            int resunlt = 0; // 操作结果
            string sql = string.Format("INSERT INTO Messages (FromUserId, ToUserId, MessageTypeId, MessageState) VALUES ({0},{1},{2},{3})",
                UserHelper.loginId, friendId, 2, 0);

            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into messages set fromuserid=@fromuserid,touserid=@touserid,messagetype=2,messagestate=0", DBHelper.Connect());
                cmd.Parameters.AddWithValue("fromuserid", UserHelper.loginId);
                cmd.Parameters.AddWithValue("touserid", friendId);
                resunlt = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.Connect().Close();
            }
            return resunlt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
