using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Core;
using Entity;
using Repository;
namespace MyPorgamManage
{
    public partial class FunAdd : DevExpress.XtraEditors.XtraForm
    {
        LoadTree _LoadTree = new LoadTree();
        DevComponents.AdvTree.Node _SelectNode = null;
        CoreFunctionRepository _CoreFunctionRepository = new CoreFunctionRepository();
        CoreFunctionContext _CoreFunctionContext = new CoreFunctionContext();
        public FunAdd()
        {
            InitializeComponent();
        }
        private void FunAdd_Load(object sender, EventArgs e)
        {
            _LoadTree.CreateFunTree(this.advTree1);
        }

        private void advTree1_NodeMouseUp(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            _SelectNode = null;
            _SelectNode = e.Node;
            this.textBox4.Text = (_SelectNode.Tag as FunctionRepository).Fun_Id;
            this.textBox5.Text = _SelectNode.Text;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveFunctionText();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string fileName = DialogUnitity.DialogTextFile(ConstKeyUnitity.CAPTIONTEXT);
            if (string.IsNullOrEmpty(fileName))
            {
                MsgBox.Infor("未选中文件.....");
                return;
            }
            if (!FileUnitity.FileExist(fileName))
            {
                MsgBox.Warning("你选择的文件不存在....");
                return;
            }
            this.fastColoredTextBox1.Text = FileUnitity.FileToString(fileName);
            SaveFunctionText();
        }
        private void SaveFunctionText()
        {
            if (string.IsNullOrEmpty(this.textBox3.Text.Trim()))
            {
                MsgBox.Warning("函数描述不可为空.....");
                return;
            }
            if (string.IsNullOrEmpty(this.textBox4.Text.Trim()))
            {
                MsgBox.Warning("请选择需新增节点的父亲节点....");
                return;
            }
            if (string.IsNullOrEmpty(this.textBox5.Text.Trim()))
            {
                MsgBox.Warning("请选择需新增节点的父亲节点....");
                return;
            }
            FunctionRepository _FunctionRepository = new FunctionRepository();
            _FunctionRepository.Fun_CLSF = this.textBox2.Text.Trim();
            _FunctionRepository.Fun_Id = StringUnitity.GetNewGUID();
            _FunctionRepository.Fun_Name = this.textBox1.Text.Trim();
            _FunctionRepository.Fun_ParantId = this.textBox4.Text.Trim();
            _FunctionRepository.Func_Descpt = this.textBox3.Text.Trim();

            FunctionContext _FunctionContext = new FunctionContext();
            _FunctionContext.Fun_Id = _FunctionRepository.Fun_Id;
            _FunctionContext.Fun_Context = this.fastColoredTextBox1.Text;

            try
            {
                _CoreFunctionRepository.AddEntity(_FunctionRepository);
                if (!string.IsNullOrEmpty(_FunctionContext.Fun_Context))
                {
                    _CoreFunctionContext.AddEntity(_FunctionContext);
                }

                _LoadTree.CreateFunTree(this.advTree1);
                this.textBox1.Text = string.Empty;
                this.textBox2.Text = string.Empty;
                this.textBox3.Text = string.Empty;
                this.textBox4.Text = string.Empty;
                this.textBox5.Text = string.Empty;
                this.fastColoredTextBox1.Text = string.Empty;

                MsgBox.Infor("添加函数成功....");
            }
            catch (Exception ex)
            {
                _CoreFunctionRepository.DeleteEntity(_FunctionRepository);
                _CoreFunctionContext.DeleteEntity(_FunctionContext);
                MsgBox.Warning("添加函数失败:" + ex.Message);
            }

        }

    }
}