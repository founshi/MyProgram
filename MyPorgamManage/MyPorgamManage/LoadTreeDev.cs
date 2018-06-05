using DevExpress.XtraTreeList.Nodes;
using Entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyPorgamManage
{
    public class LoadTreeDev
    {
       
        public TreeListNode CreateDbCodeTreeHead(DevExpress.XtraTreeList.TreeList treeList)
        {
            if (treeList.Nodes.Count > 0) return treeList.Nodes.FirstNode.RootNode;


            treeList.Appearance.Row.Font = new System.Drawing.Font("宋体", 15f, System.Drawing.FontStyle.Bold);
            treeList.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            treeList.Appearance.SelectedRow.Font = new System.Drawing.Font("宋体", 15f);
            treeList.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Blue;
            treeList.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Blue;
            treeList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;

            DevExpress.XtraTreeList.Columns.TreeListColumn colo = treeList.Columns.Add();
            colo.Caption = "DB服务器";
            colo.Visible = true;
            treeList.OptionsView.ShowColumns = false;//隐藏列头
            treeList.OptionsView.ShowVertLines = false; //去掉列边框线
            treeList.OptionsView.ShowIndicator = false; //是否隐藏行号列

            treeList.OptionsView.AutoWidth = true; //设置是否自动调节列宽

            treeList.Columns[0].OptionsColumn.AllowEdit = false; //设置是否编辑

            treeList.EndSort();//禁止排序
            treeList.OptionsBehavior.Editable = false;//禁止编辑

            TreeListNode _node = treeList.Nodes.Add("DB服务器", 0);

            //为添加下文的Node做准备
            DbLoginFor _DbLoginFor = new DbLoginFor();
            _DbLoginFor.LoginDb_Id = "0";
            _DbLoginFor.LoginDb_Descp = "DB服务器";
            _node.Tag = _DbLoginFor;
            _node.ImageIndex = 0;
            _node.SelectImageIndex = 0;
            _node.ExpandAll();

            return _node;

        }

        public void CreateDBTreeNode(List<DbLoginFor> _mlsit, TreeListNode _node)
        {

            for (int i = 0; i < _mlsit.Count; i++)
            {
                var _tmp = _node.Nodes.FirstOrDefault(t => (t.Tag as DbLoginFor).LoginDb_Id == _mlsit[i].LoginDb_Id);
                if (_tmp == null)
                {
                    var nodetmp = _node.Nodes.Add(_mlsit[i].LoginDb_Descp, 0);
                    nodetmp.ImageIndex = 1;
                    nodetmp.SelectImageIndex = 1;
                    nodetmp.Tag = _mlsit[i];
                }
            }
            _node.ExpandAll();
        }

        public void CreateTableAndViewNode(TreeListNode _node, List<DbTableInfo> _tableViewList, List<DbTableInfo> _viewTableList)
        {
            
            _node.Nodes.Clear();
            var _tableNode = _node.Nodes.Add("表", 0);
            _tableNode.Tag = "表";
            _tableNode.ImageIndex = 3;
            _tableNode.SelectImageIndex = 3;

            
            
            for (int i = 0; i < _tableViewList.Count; i++)
            {

                var _tabletmp = _tableNode.Nodes.Add(_tableViewList[i].Name, 0);
                _tabletmp.ImageIndex = 2;
                _tabletmp.SelectImageIndex = 2;
                _tabletmp.Tag = _tableViewList[i].Name;

            }
            var _viewNode = _node.Nodes.Add("视图", 0);
            _viewNode.ImageIndex = 3;
            _viewNode.SelectImageIndex = 3;
            _viewNode.Tag = "视图";

            for (int i = 0; i < _viewTableList.Count; i++)
            {

                var _viewtmp = _viewNode.Nodes.Add(_viewTableList[i].Name, 0);
                _viewtmp.Tag = _viewTableList[i].Name;
                _viewtmp.ImageIndex = 2;
                _viewtmp.SelectImageIndex = 2;
            }


        }



    }
}





