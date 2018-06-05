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
namespace MyPorgamManage.Frm
{
    public partial class CodeTempletAddFrm : DevExpress.XtraEditors.XtraForm
    {
        CoreCodeTemplet _CoreCodeTemplet = new CoreCodeTemplet();
        CodeTemplet _CurrentCodeTemplet = null;
        public CodeTempletAddFrm()
        {
            InitializeComponent();
        }

        private void CodeTempletAddFrm_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("-----------");
            this.comboBox1.Items.Add("Sqlite");
            this.comboBox1.Items.Add("MySql");
            this.comboBox1.Items.Add("Oracle");
            this.comboBox1.Items.Add("SqlServer");
            this.comboBox1.SelectedIndex = 4;
            LoadListBox();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CodeTemplet _CodeTemplet = new CodeTemplet();
            _CodeTemplet.CTemplet_Id = StringUnitity.GetNewGUID();
            _CodeTemplet.CTemplet_Name = this.textBox1.Text.Trim();
            _CodeTemplet.CTemplet_Context = this.fastColoredTextBox1.Text;
            _CodeTemplet.CTemplet_CPrefix = this.textBox3.Text.Trim();
            _CodeTemplet.CTemplet_DbType = this.comboBox1.Text;
            _CodeTemplet.CTemplet_NameSP = this.textBox2.Text.Trim();
            try
            {
                _CoreCodeTemplet.AddEntity(_CodeTemplet);
                LoadListBox();
                ClearContol();
            }
            catch (Exception ex)
            {
                MsgBox.Warning("新增失败,原因:" + ex.Message);
            }

        }

        private void LoadListBox()
        {
            this.listBoxControl1.DataSource = null;
            var _mlist = _CoreCodeTemplet.LoadEntities(null,it=>it.CTemplet_Name).ToList();
            this.listBoxControl1.DataSource = _mlist;
            this.listBoxControl1.DisplayMember = "CTemplet_Name";
            this.listBoxControl1.ValueMember = "CTemplet_Id";

        }

        private void listBoxControl1_MouseUp(object sender, MouseEventArgs e)
        {
            _CurrentCodeTemplet = null;
            _CurrentCodeTemplet = this.listBoxControl1.SelectedItem as CodeTemplet;
            this.fastColoredTextBox1.Text = _CurrentCodeTemplet.CTemplet_Context;

            switch (_CurrentCodeTemplet.CTemplet_DbType)
            {
                case "Sqlite":
                    this.comboBox1.SelectedIndex = 1;
                    break;
                case "MySql":
                    this.comboBox1.SelectedIndex = 2;
                    break;
                case "Oracle":
                    this.comboBox1.SelectedIndex = 3;
                    break;
                case "SqlServer":
                    this.comboBox1.SelectedIndex = 4;
                    break;
                default:
                    this.comboBox1.SelectedIndex = 0;
                    break;
            }
            this.textBox1.Text = _CurrentCodeTemplet.CTemplet_Name;
            this.textBox2.Text = _CurrentCodeTemplet.CTemplet_NameSP;
            this.textBox3.Text = _CurrentCodeTemplet.CTemplet_CPrefix;

            //string _idString = this.listBoxControl1.SelectedItem as string;
            //var _mlist = _CoreCodeTemplet.LoadEntities(t => t.CTemplet_Id == _idString).ToList();
            //if (_mlist.Count > 0)
            //{
            //    this.fastColoredTextBox1.Text = _mlist[0].CTemplet_Context;
            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            _CurrentCodeTemplet.CTemplet_Context = this.fastColoredTextBox1.Text;
            _CurrentCodeTemplet.CTemplet_Name = this.textBox1.Text;
            _CurrentCodeTemplet.CTemplet_NameSP = this.textBox2.Text;
            _CurrentCodeTemplet.CTemplet_DbType = this.comboBox1.Text;
            _CurrentCodeTemplet.CTemplet_CPrefix = this.textBox3.Text;
            try
            {
                _CoreCodeTemplet.UpdateEntity(_CurrentCodeTemplet);
                LoadListBox();
                ClearContol();
            }
            catch (Exception ex)
            {
                MsgBox.Warning("更新失败,原因:" + ex.Message);
            }
        }

        private void ClearContol()
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.fastColoredTextBox1.Text = string.Empty;
            this.comboBox1.SelectedIndex = 0;

        }
    }
}