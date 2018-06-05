using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Entity;
using Repository;
using Core;
using System.Threading.Tasks;

namespace MyPorgamManage.Frm
{
    public partial class AddUser : DevExpress.XtraEditors.XtraForm
    {
        public AddUser()
        {
            InitializeComponent();
            this.radioGroup1.SelectedIndex = 0;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            User_MST _User_MST = new User_MST();
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                MsgBox.Warning("用户ID不可为空!!!");
                return;
            }
            if (string.IsNullOrEmpty(this.textBox2.Text.Trim()))
            {
                MsgBox.Warning("用户姓名不可为空!!!");
                return;
            }
            if (string.IsNullOrEmpty(this.textBox3.Text.Trim()))
            {
                MsgBox.Warning("用户密码不可为空!!!");
                return;
            }
            _User_MST.User_Id = this.textBox1.Text.Trim();
            _User_MST.User_Name = this.textBox2.Text.Trim();
            _User_MST.User_Pwd = SecurityUnitity.GetMD5_32(this.textBox3.Text.Trim());
            _User_MST.User_Email = this.textBox4.Text.Trim();
            if (0 == this.radioGroup1.SelectedIndex)
            {
                _User_MST.User_Gener = "M";//男M 女F
            }
            if (1 == this.radioGroup1.SelectedIndex)
            {
                _User_MST.User_Gener = "F";//男M 女F
            }
            _User_MST.User_RegTime = new CoreGetTime().GetNow();
            _User_MST.User_Status = 1;

            CoreUser_MST _CoreUser_MST = new CoreUser_MST();

            try
            {
                _CoreUser_MST.AddEntity(_User_MST);
                MsgBox.Infor("用户注册成功!!!");
            }
            catch (Exception ex)
            {
                MsgBox.Warning("用户注册失败:" + ex.Message);
            }


        }
        /// <summary>
        /// 验证 UserId是否可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim())) return;

            Task.Factory.StartNew(new Action(() =>
            {
                try
                {
                    if (this.textBox1 == null) return;
                    string _UserId = this.textBox1.Text.Trim();
                    CoreUser_MST thread_CoreUser_MST = new CoreUser_MST();

                    var _mlist = thread_CoreUser_MST.LoadEntities(t => t.User_Id == _UserId).ToList();
                    if (_mlist.Count <= 0)
                    {
                        if (this.InvokeRequired) this.Invoke(new Action(() =>
                        {
                            this.label6.Text = "用户Id已存在,推荐使用";
                            this.label6.Visible = false;
                        }));
                        return;//如果不存在编号 就不是有推荐的
                    }

                    DataTable _datatable = thread_CoreUser_MST.LoadEntitiesBySql("select  user_id*1 as user_id from User_MST order by user_id desc limit  0,1 ;", new List<SqlSugar.SugarParameter>());
                    if (_datatable.Rows.Count > 0)//用户ID已经存在
                    {
                        if (this.InvokeRequired) this.Invoke(new Action(() =>
                        {
                            this.label6.Text = "用户Id已存在,推荐使用" + (Convert.ToInt64(_datatable.Rows[0][0]) + 1);
                            this.label6.Visible = true;
                            this.textBox1.Text = (Convert.ToInt64(_datatable.Rows[0][0]) + 1).ToString();
                        }));
                    }
                    else
                    {
                        if (this.InvokeRequired) this.Invoke(new Action(() =>
                        {
                            this.label6.Text = "用户Id已存在,推荐使用";
                            this.label6.Visible = false;
                        }));
                    }
                }
                catch //(Exception)
                { }
            }));
        }
        /// <summary>
        /// 验证邮箱格式是否正确
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox4.Text.Trim())) return;

            Task.Factory.StartNew(new Action(() =>
            {
                try
                {
                    string _email = this.textBox4.Text.Trim();
                    if (!ValidateUnitity.IsEmail(_email))
                    {
                        if (this.InvokeRequired) this.BeginInvoke(new Action(() =>
                        {
                            this.label7.Visible = true;
                        }));
                    }
                    else
                    {
                        if (this.InvokeRequired) this.BeginInvoke(new Action(() =>
                        {
                            this.label7.Visible = false;
                        }));
                    }
                }
                catch //(Exception)
                { }

            }));

        }
    }
}