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

namespace MyPorgamManage.DbLoginFrm
{
    public partial class SqlServerFrm : DevExpress.XtraEditors.XtraForm
    {
        [DefaultValue(null)]
        public Entity.DbLoginFor MyDbLoginFor { get; set; } 
        
        public SqlServerFrm()
        {
            InitializeComponent();
        }

        private void SqlServerFrm_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("SQL Server身份认证");
            this.comboBox1.Items.Add("Windows 身份认证");

            if (MyDbLoginFor == null)
            {
                this.comboBox1.SelectedIndex = 0;
            }
            else
            {
                if (string.IsNullOrEmpty(MyDbLoginFor.UserName.Trim()))
                {
                    this.comboBox1.SelectedIndex = 1;
                    this.textBox1.Text = MyDbLoginFor.ServerIP;
                    this.textBox4.Text = MyDbLoginFor.ConnString;
                }
                else
                {
                    this.comboBox1.SelectedIndex = 0;
                    this.textBox1.Text = MyDbLoginFor.ServerIP;
                    this.textBox4.Text = MyDbLoginFor.ConnString;
                    this.textBox2.Text = MyDbLoginFor.UserName;
                    this.textBox3.Text = MyDbLoginFor.PassWord;
                }
                this.textBox4.Text = MyDbLoginFor.ConnString;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string connstring = CreateConnString();
            this.textBox4.Text = connstring;
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connstring, //必填
                DbType = SqlSugar.DbType.SqlServer, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }); //默认SystemTable
            try
            {
                if (this.comboBox2.Items.Count <= 0)
                {
                    this.comboBox2.Items.Clear();
                    DataTable _dbTable = db.Ado.GetDataTable("select name,user_name() cuser,'DB' type,crdate dates from sysdatabases  order by name", new List<SugarParameter>());
                    for (int i = 0; i < _dbTable.Rows.Count; i++)
                    {
                        this.comboBox2.Items.Add(_dbTable.Rows[i][0].ToString());
                    }
                }
                else
                {
                    DateTime _dst = db.Ado.GetDateTime("select GETDATE()", new List<SugarParameter>());
                }
                Repository.MsgBox.Infor("测试成功");
            }
            catch (Exception ex)
            {
                Repository.MsgBox.Warning("测试失败:" + ex.Message);
            }


        }

        private string CreateConnString()
        {
            StringBuilder _StringBuilder = new StringBuilder();
            if (this.comboBox1.SelectedIndex == 0)//SQL Server身份认证
            {
                //"saYfywms2012";
                _StringBuilder.Append("Data Source=");
                _StringBuilder.Append(this.textBox1.Text.Trim());
                _StringBuilder.Append(";Initial Catalog=");

                if (this.comboBox2.Items.Count <= 0)
                {
                    _StringBuilder.Append("master");
                }
                else
                {
                    if (string.IsNullOrEmpty(this.comboBox2.Text.Trim()))
                    {
                        Repository.MsgBox.Warning("请您选择数据库....");
                        return null;
                    }
                    else
                    {
                        _StringBuilder.Append(this.comboBox2.Text.Trim());
                    }
                }


                _StringBuilder.Append(";Persist Security Info=True;User ID=");
                _StringBuilder.Append(this.textBox2.Text.Trim());
                _StringBuilder.Append(";Password=");
                _StringBuilder.Append(this.textBox3.Text.Trim());
                return _StringBuilder.ToString();
            }
            else//Windows 身份认证
            {
                //"server=127.0.0.1;database=Erric;integrated security=SSPI";
                _StringBuilder.Append("server=");
                _StringBuilder.Append(this.textBox1.Text.Trim());
                _StringBuilder.Append(";database=");
                if (this.comboBox2.Items.Count <= 0)
                {
                    _StringBuilder.Append("master");
                }
                else
                {
                    if (string.IsNullOrEmpty(this.comboBox2.Text.Trim()))
                    {
                        Repository.MsgBox.Warning("请您选择数据库....");
                        return null;
                    }
                    else
                    {
                        _StringBuilder.Append(this.comboBox2.Text.Trim());
                    }
                }
                _StringBuilder.Append(";integrated security=SSPI");
                return _StringBuilder.ToString();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                this.textBox2.Enabled = true;
                this.textBox3.Enabled = true;
            }
            else
            {
                this.textBox2.Enabled = false;
                this.textBox3.Enabled = false;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //保存
            Entity.DbLoginFor _DbLoginFor = new Entity.DbLoginFor();
            _DbLoginFor.ConnString = CreateConnString();
            _DbLoginFor.Db_Type = 2;
            _DbLoginFor.DBName = this.comboBox2.Text.Trim();
            _DbLoginFor.LoginDb_Descp = "MSSQL_"+this.textBox1.Text.Trim() +"_"+ _DbLoginFor.DBName;
            _DbLoginFor.LoginDb_Id = Repository.StringUnitity.GetNewGUID();
            _DbLoginFor.ServerIP = this.textBox1.Text.Trim();
            _DbLoginFor.ServerName = string.Empty;
            _DbLoginFor.ServerPort = 0;
            if (this.comboBox1.SelectedIndex == 0)
            {
                _DbLoginFor.PassWord = this.textBox3.Text.Trim();
                _DbLoginFor.UserName = this.textBox2.Text.Trim();
            }
            else
            {
                _DbLoginFor.PassWord = string.Empty;
                _DbLoginFor.UserName = string.Empty;
            }
            Core.CoreDbLoginFor _CoreDbLoginFor = new Core.CoreDbLoginFor();
            try
            {
                _CoreDbLoginFor.AddEntity(_DbLoginFor);
                this.Close();
            }
            catch (Exception ex)
            {
                Repository.MsgBox.Warning("新增失败:" + ex.Message);
            }

        }




    }
}