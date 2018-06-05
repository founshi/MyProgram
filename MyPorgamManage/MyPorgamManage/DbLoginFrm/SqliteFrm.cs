using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SqlSugar;
using System.Threading.Tasks;

namespace MyPorgamManage.DbLoginFrm
{
    public partial class SqliteFrm : DevExpress.XtraEditors.XtraForm
    {
        [DefaultValue(null)]
        public Entity.DbLoginFor MyDbLoginFor { get; set; }
        public SqliteFrm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.textBox1.Enabled = false;
                this.textBox2.ReadOnly = false;
            }
            else
            {
                this.textBox1.Enabled = true;
                this.textBox2.ReadOnly = true;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = Repository.DialogUnitity.DialogSqliteFile(Repository.ConstKeyUnitity.CAPTIONTEXT);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string connstring = CreateConnString();
            this.textBox2.Text = connstring;
            Task.Factory.StartNew(new Action(() =>
            {
                SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = connstring, //必填
                    DbType = SqlSugar.DbType.Sqlite, //必填
                    IsAutoCloseConnection = true, //默认false
                    InitKeyType = InitKeyType.Attribute
                }); //默认SystemTable
                try
                {
                    DateTime _dst = db.Ado.GetDateTime("select datetime('now','localtime')", new List<SugarParameter>());
                    Repository.MsgBox.Infor("测试成功");
                }
                catch (Exception ex)
                {
                    Repository.MsgBox.Warning("测试失败:" + ex.Message);
                }
            }));
        }
        private string CreateConnString()
        {
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                Repository.MsgBox.Warning("请选择对应的数据库文件....");
                return null;
            }
            StringBuilder _StringBuilder = new StringBuilder();
            _StringBuilder.Append("Data Source=");
            _StringBuilder.Append(this.textBox1.Text.Trim());
            return _StringBuilder.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Entity.DbLoginFor _DbLoginFor = new Entity.DbLoginFor();
            _DbLoginFor.ConnString = this.textBox2.Text.Trim();
            _DbLoginFor.Db_Type = 1;
            _DbLoginFor.DBName = string.Empty;
            _DbLoginFor.LoginDb_Descp = "SQLite_"+System.IO.Path.GetFileName(this.textBox1.Text.Trim());
            _DbLoginFor.LoginDb_Id = Repository.StringUnitity.GetNewGUID();
            _DbLoginFor.PassWord = string.Empty;
            _DbLoginFor.ServerIP = this.textBox1.Text.Trim();
            _DbLoginFor.ServerName = string.Empty;
            _DbLoginFor.ServerPort = 0;
            _DbLoginFor.UserName = string.Empty;
            try
            {
                Core.CoreDbLoginFor _CoreDbLoginFor = new Core.CoreDbLoginFor();
                _CoreDbLoginFor.AddEntity(_DbLoginFor);
                this.Close();
            }

            catch (Exception ex)
            {
                Repository.MsgBox.Warning("新增失败:" + ex.Message);
            }
        }

        private void SqliteFrm_Load(object sender, EventArgs e)
        {
            if (this.MyDbLoginFor != null)
            {
                this.textBox1.Text = this.MyDbLoginFor.ServerIP;
                this.textBox2.Text = this.MyDbLoginFor.ConnString;
            }
        }


    }
}