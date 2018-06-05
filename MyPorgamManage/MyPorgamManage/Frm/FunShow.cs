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
namespace MyPorgamManage
{
    public partial class FunShow : DevExpress.XtraEditors.XtraForm
    {
        LoadTree _LoadTree = new LoadTree();
        DevComponents.AdvTree.Node _SelectNode = null;
        CoreFunctionContext _CoreFunctionContext = new CoreFunctionContext();
        public FunShow()
        {
            InitializeComponent();
        }

        private void FunShow_Load(object sender, EventArgs e)
        {
            _LoadTree.CreateFunTree(this.advTree1);
        }

        private void advTree1_NodeMouseUp(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            _SelectNode = null;
            _SelectNode = e.Node;

            LoadFuncontent();

        }

        private void LoadFuncontent()
        {
            this.fastColoredTextBox1.Text = string.Empty;
            if (null == _SelectNode)
            {
                return;
            }
            var _list = _CoreFunctionContext.LoadEntities(t => t.Fun_Id == _SelectNode.Name).ToList();
            if (_list.Count <= 0) return;
            this.fastColoredTextBox1.Text = _list[0].Fun_Context;

        }

    }
}