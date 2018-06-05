using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
//using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using Entity;
using Repository;
using Core;

namespace MyPorgamManage
{
    public partial class AddProgram : DevExpress.XtraEditors.XtraForm
    {
        ProgList _SelectNode = null;
        DevComponents.AdvTree.Node _SelectAdvNode = null;
        CoreProgList _CoreProgList = new CoreProgList();
        LoadTree _LoadTree = new LoadTree();
        public AddProgram()
        {
            InitializeComponent();
        }

        private void AddProgram_Load(object sender, EventArgs e)
        {
            _LoadTree.CreateTree(this.advTree1);
            _SelectNode = null;
            _SelectAdvNode = null;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (_SelectNode == null) return;

            if (CheckProgExist())
            {
                MsgBox.Warning("程序已经存在,请勿重复添加!!!");
                return;
            }
            if (string.IsNullOrEmpty(this.textBox4.Text.Trim()))
            {
                MsgBox.Warning("程序描述不能为空!!!");
                return ;
            }
            ProgList _ProgList = new ProgList();
            _ProgList.Prog_Id = StringUnitity.GetNewGUID();
            _ProgList.Prog_Assmbly = this.textBox1.Text.Trim();
            _ProgList.Prog_CLS = this.textBox3.Text.Trim();
            _ProgList.Prog_Descp = this.textBox4.Text.Trim();
            _ProgList.Prog_NameSp = this.textBox2.Text.Trim();
            _ProgList.Prog_ParantId = _SelectNode.Prog_Id;
            if (this.checkEdit1.Checked)
            {
                _ProgList.Prog_Status = 1;
            }
            else
            {
                _ProgList.Prog_Status = 9;
            }
            _ProgList.Prog_Type = "Application";
            try
            {
                _CoreProgList.AddEntity(_ProgList);

                MsgBox.Infor("程序新增完成");
                _LoadTree.CreateTree(this.advTree1);
            }
            catch (Exception ex)
            {
                MsgBox.Warning("程序新增失败:"+ex.Message);
            }

           
        }
        private void advTree1_NodeMouseUp(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if(e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                _SelectNode = null;
                _SelectAdvNode = null;
                _SelectAdvNode = e.Node;
                _SelectNode = e.Node.Tag as ProgList;
                this.textBox5.Text = _SelectNode.Prog_Id;
                this.textBox6.Text = _SelectNode.Prog_Descp;
            }
            else
            {
                _SelectNode = null;
                _SelectAdvNode = null;
                _SelectAdvNode = e.Node;
                _SelectNode = e.Node.Tag as ProgList;
                this.textBox5.Text = _SelectNode.Prog_Id;
                this.textBox6.Text = _SelectNode.Prog_Descp;                
                popupMenu1.ShowPopup(MousePosition);
            }           
        }
        private bool CheckProgExist()
        {
            string progAssm = this.textBox1.Text.Trim();
            string progNSP = this.textBox2.Text.Trim();
            string progCLS = this.textBox3.Text.Trim();
            var _mlist = _CoreProgList.LoadEntities(t => t.Prog_Assmbly == progAssm && t.Prog_NameSp == progNSP && t.Prog_CLS == progCLS).ToList();
            if (_mlist.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //启用
            _SelectNode.Prog_Status = 1;
            try
            {
                _CoreProgList.UpdateEntityBySomeColums(_SelectNode, t => t.Prog_Status);
                _LoadTree.CreateTree(this.advTree1);
            }
            catch (Exception ex)
            {
                MsgBox.Warning("启用失败:"+ex.Message);
            }
            

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //禁用
            _SelectNode.Prog_Status = 9;
            try
            {
                _CoreProgList.UpdateEntityBySomeColums(_SelectNode, t => t.Prog_Status);
                _LoadTree.CreateTree(this.advTree1);
            }
            catch (Exception ex)
            {
                MsgBox.Warning("禁用失败:"+ex.Message);
            }

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_SelectAdvNode.HasChildNodes)
                {
                    MsgBox.Warning("此节点下有子节点,故无法删除...");
                    return;
                }
                _CoreProgList.DeleteEntity(_SelectNode);
                MsgBox.Infor("节点删除完成....");
                _LoadTree.CreateTree(this.advTree1);
            }
            catch (Exception ex)
            {
                MsgBox.Warning("删除失败:"+ex.Message);
            }


        }

      
    }
}