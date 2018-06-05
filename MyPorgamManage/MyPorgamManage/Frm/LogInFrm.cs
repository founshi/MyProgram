using System;
using Core;
using System.Threading.Tasks;
using Entity;
using Repository;
namespace MyPorgamManage.Frm
{
    public partial class LogInFrm : DevExpress.XtraEditors.XtraForm
    {
        CoreUser_MST _CoreUser_MST = new CoreUser_MST();
        CoreLoginUserPwd _CoreLoginUserPwd = new CoreLoginUserPwd();
        public LogInFrm()
        {
            InitializeComponent();
            LoadLoginUserPwd();

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                return;
            }

            Task.Factory.StartNew(new Action(() =>
                {
                    try
                    {
                        if (this.textBox1 == null) return;
                        string _UserId = this.textBox1.Text.Trim();
                        CoreUser_MST thread_CoreUser_MST = new CoreUser_MST();

                        var _list = thread_CoreUser_MST.LoadEntities(t => t.User_Id == _UserId).ToList();
                        if (_list.Count <= 0)
                        {
                            if (this.InvokeRequired) this.Invoke(new Action(() => { this.label3.Visible = true; }));
                        }
                        else
                        {
                            if (this.InvokeRequired) this.Invoke(new Action(() => { this.label3.Visible = false; }));
                        }
                    }
                    catch //(Exception)
                    { }
                }));
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var _usermst = CheckUserIdPWD();
                Program.UserMST = _usermst;
                if (null == _usermst)
                {
                    MsgBox.Warning("用户名或者密码不正确..");
                    return;
                }
                WriteUserTo_CoreLoginUserPwd();//记录用户名密码 到 记住用户表
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.Warning("登录失败:" + ex.Message);
            }

        }
        /// <summary>
        /// 记录用户名密码 到 记住用户表
        /// </summary>
        private void WriteUserTo_CoreLoginUserPwd()
        {
            _CoreLoginUserPwd.ExecuteCommand("delete from LoginUserPwd", null);
            LoginUserPwd _LoginUserPwd = new LoginUserPwd();
            if (this.checkEdit1.Checked)
            {
                _LoginUserPwd.Login_UserName = this.textBox1.Text.Trim();
                _LoginUserPwd.Login_Pwd = SecurityUnitity.AES_Encrypt(this.textBox2.Text.Trim(), ConstKeyUnitity.AESKEY);
                _LoginUserPwd.Login_Time = new CoreGetTime().GetNow();

                _CoreLoginUserPwd.AddEntity(_LoginUserPwd);
            }
        }
        /// <summary>
        /// 验证用户 如果正确就直接登录,并更新登录时间 登录IP
        /// </summary>
        /// <returns></returns>
        private User_MST CheckUserIdPWD()
        {
            string _UserId = this.textBox1.Text.Trim();
            string _PassWord = SecurityUnitity.GetMD5_32(this.textBox2.Text.Trim());
            var _list = _CoreUser_MST.LoadEntities(t => t.User_Id == _UserId && t.User_Pwd == _PassWord).ToList();
            if (_list.Count == 1)
            {
                DateTime _now = new CoreGetTime().GetNow();
                _list[0].User_LogTime = _now;
                _list[0].User_LogIp = NetUnitity.GetLannIP();

                int retVal = _CoreUser_MST.UpdateEntityBySomeColums(_list[0], t => new { t.User_LogIp, t.User_LogTime });

                return _list[0];
            }
            else
            {
                return null;
            }

        }


        private void LogInFrm_Load(object sender, EventArgs e)
        {
            this.checkEdit2.Checked = true;
            System.Threading.Thread _mthread = new System.Threading.Thread(AutoLogin);
            _mthread.IsBackground = true;
            _mthread.Start();
        }

        private void LoadLoginUserPwd()
        {
            var _mlist = _CoreLoginUserPwd.LoadEntities(null).ToList();

            if (_mlist.Count > 0)//已经存在用户名密码
            {
                this.textBox1.Text = _mlist[0].Login_UserName;
                this.textBox2.Text = SecurityUnitity.AES_Decrypt(_mlist[0].Login_Pwd, ConstKeyUnitity.AESKEY);
                this.checkEdit1.Checked = true;

            }
            else
            {
                this.textBox1.Text = string.Empty;
                this.textBox2.Text = string.Empty;
                this.checkEdit1.Checked = false;
            }

        }

        private void AutoLogin()
        {
            System.Threading.Thread.Sleep(500);
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    simpleButton1_Click(null, null);
                }));
            }


        }


    }
}