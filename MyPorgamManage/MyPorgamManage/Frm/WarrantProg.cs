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
using Core;
using Repository;
namespace MyPorgamManage
{
    public partial class WarrantProg : DevExpress.XtraEditors.XtraForm
    {
        LoadTree _LoadTree = new LoadTree();
        Prog_WRT _Prog_WRT = new Prog_WRT();        
        CoreUser_MST _CoreUser_MST = new CoreUser_MST();
        string _userid = string.Empty;
        DevComponents.AdvTree.Node _SelectNode = null;

        public WarrantProg()
        {
            InitializeComponent();
        }
        protected override bool GetAllowSkin()
        {
                //return base.GetAllowSkin();
            if (this.DesignMode) return false;
            return true;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //授权
            try
            {
                if (_SelectNode == null) return;
                List<DevComponents.AdvTree.Node> _list = new List<DevComponents.AdvTree.Node>();
                _list.Add(_SelectNode);
                DevComponents.AdvTree.Node _node = _SelectNode;
                List<Prog_WRT> _Prog_WRTlist = new List<Prog_WRT>();

                do
                {
                    _node = _node.Parent;
                    if (_node == null) break;
                    _list.Add(_node);

                } while (true);//加载需要授权的当前节点及其所有的父节点

                foreach (var item in _list)
                {
                    Prog_WRT _tmp = null;
                    if (item.Tag == null)
                    {
                        _tmp = new Prog_WRT();
                        _tmp.ProgWrt_Id = Repository.StringUnitity.GetNewGUID();
                        _tmp.Prog_Id = item.Name;
                        _tmp.User_Id = _userid;
                    }
                    else
                    {
                        _tmp = item.Tag as Prog_WRT;
                    }
                    _Prog_WRTlist.Add(_tmp);
                }
                Core.CoreProg_WRT _CoreProg_WRT = new CoreProg_WRT();
                _CoreProg_WRT.DeleteEntitys(_Prog_WRTlist);
                _CoreProg_WRT.AddEntitys(_Prog_WRTlist);
                LoadTree();
            }
            catch (Exception ex)
            {

                MsgBox.Warning("授权失败....."+ex.Message);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //取消授权
            try
            {
                if (_SelectNode == null) return;
                Prog_WRT _progwrt = _SelectNode.Tag as Prog_WRT;
                Core.CoreProg_WRT _CoreProg_WRT = new CoreProg_WRT();
                _CoreProg_WRT.DeleteEntity(_progwrt);
                MsgBox.Infor("取消授权成功....");
                LoadTree();
            }
            catch (Exception ex)
            {
                MsgBox.Warning("取消授权失败...."+ ex.Message);
            }
            

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadTree();
        }

        private void LoadTree()
        {
            this.advTree1.Nodes.Clear();
            _userid = this.textBox1.Text.Trim();
            if (string.IsNullOrEmpty(_userid))
            {
                MsgBox.Warning("请输入用户编号...");
                _userid = string.Empty;
                return;
            }

            //验证用户是否存在
            try
            {
                var _mlist = _CoreUser_MST.LoadEntities(t => t.User_Id == _userid && t.User_Status == 1).ToList();
                if (_mlist.Count <= 0)
                {
                    MsgBox.Warning("用户不存在...");
                    _userid = string.Empty;
                    return;
                }
                _LoadTree.CreateRightTree(this.advTree1, _userid);
            }
            catch (Exception ex)
            {
                _userid = string.Empty;
                MsgBox.Warning("加载权限出错:" + ex.Message);
            }
        }

        private void advTree1_NodeMouseUp(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _Prog_WRT = e.Node.Tag as Prog_WRT;
                _SelectNode = e.Node;
            }
            else
            {
                _Prog_WRT = e.Node.Tag as Prog_WRT;
                _SelectNode = e.Node;
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadTree();
            }
        }

    }
}