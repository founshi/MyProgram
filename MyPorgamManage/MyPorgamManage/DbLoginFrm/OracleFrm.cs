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
    public partial class OracleFrm : DevExpress.XtraEditors.XtraForm
    {
        [DefaultValue(null)]
        public Entity.DbLoginFor MyDbLoginFor { get; set; }
        public OracleFrm()
        {
            InitializeComponent();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.textBox1.Enabled = false;
                this.textBox2.Enabled = false;
                this.textBox3.Enabled = false;
                this.textBox4.Enabled = false;
                this.textBox5.Enabled = false;
                this.textBox6.ReadOnly = false;
            }
            else
            {
                this.textBox1.Enabled = true;
                this.textBox2.Enabled = true;
                this.textBox3.Enabled = true;
                this.textBox4.Enabled = true;
                this.textBox5.Enabled = true;
                this.textBox6.ReadOnly = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string connstring = CreateConnString();
            this.textBox6.Text = connstring;
            Task.Factory.StartNew(new Action(() =>
            {
                SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = connstring, //必填
                    DbType = SqlSugar.DbType.Oracle, //必填
                    IsAutoCloseConnection = true, //默认false
                    InitKeyType = InitKeyType.Attribute
                }); //默认SystemTable
                try
                {
                    DateTime _dst = db.Ado.GetDateTime("select sysdate from dual", new List<SugarParameter>());
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
            StringBuilder _StringBuilder = new StringBuilder();
            _StringBuilder.Append("User Id=");
            _StringBuilder.Append(this.textBox3.Text.Trim());
            _StringBuilder.Append("; password=");
            _StringBuilder.Append(this.textBox4.Text.Trim());
            _StringBuilder.Append(";Data Source=");
            _StringBuilder.Append(this.textBox1.Text.Trim());
            _StringBuilder.Append(":");
            _StringBuilder.Append(this.textBox5.Text.Trim());
            _StringBuilder.Append("/");
            _StringBuilder.Append(this.textBox2.Text.Trim());
            _StringBuilder.Append(";");
            return _StringBuilder.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Entity.DbLoginFor _DbLoginFor = new Entity.DbLoginFor();
            _DbLoginFor.ConnString = this.textBox6.Text.Trim();
            _DbLoginFor.Db_Type = 3;
            _DbLoginFor.DBName = string.Empty;
            _DbLoginFor.LoginDb_Descp = "Oracle_"+this.textBox1.Text.Trim() + "_" + this.textBox3.Text.Trim();
            _DbLoginFor.LoginDb_Id = Repository.StringUnitity.GetNewGUID();
            _DbLoginFor.PassWord = this.textBox4.Text.Trim();
            _DbLoginFor.ServerIP = this.textBox1.Text.Trim();
            _DbLoginFor.ServerName = this.textBox2.Text.Trim();
            _DbLoginFor.ServerPort = Convert.ToInt32(this.textBox5.Text.Trim());
            _DbLoginFor.UserName = this.textBox3.Text.Trim();
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

        private void OracleFrm_Load(object sender, EventArgs e)
        {

            if(this.MyDbLoginFor!=null)
            {
                this.textBox1.Text = MyDbLoginFor.ServerIP;
                this.textBox2.Text = MyDbLoginFor.ServerName;
                this.textBox3.Text = MyDbLoginFor.UserName;
                this.textBox4.Text = MyDbLoginFor.PassWord;
                this.textBox5.Text = MyDbLoginFor.ServerPort.ToString();
                this.textBox6.Text = MyDbLoginFor.ConnString;
            }
            
        }
    }
}