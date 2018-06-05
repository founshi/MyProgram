using Core;
using DevComponents.AdvTree;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPorgamManage
{
    internal class LoadTree
    {
        CoreProgList _CoreProgList = new CoreProgList();
        CoreProg_WRT _CoreProg_WRT = new CoreProg_WRT();
        CoreFunctionRepository _CoreFunctionRepository = new CoreFunctionRepository();
        #region 权限相关
        public void CreateTree(AdvTree advTree)
        {
            if (advTree == null) return;
            advTree.Nodes.Clear();
            var _lsit = _CoreProgList.LoadEntities(null,t=>t.Prog_Descp).ToList();
            this.AddSonNode(_lsit, advTree.Nodes, "-1");

        }

        private void AddSonNode(List<ProgList> _list, NodeCollection _nodes, string parentid)
        {

            var _nodestyleBlue = new DevComponents.DotNetBar.ElementStyle();
            _nodestyleBlue.TextColor = System.Drawing.Color.Blue;
            _nodestyleBlue.Font = new System.Drawing.Font("宋体", 14);
            _nodestyleBlue.BackColor = System.Drawing.Color.FromArgb(207, 221, 238);

            var _nodestyleRed = new DevComponents.DotNetBar.ElementStyle();
            _nodestyleRed.TextColor = System.Drawing.Color.Red;
            _nodestyleRed.Font = new System.Drawing.Font("宋体", 14);
            _nodestyleRed.BackColor = System.Drawing.Color.FromArgb(207, 221, 238);

            var _mlist = _list.FindAll(t => t.Prog_ParantId == parentid);
            for (int i = 0; i < _mlist.Count; i++)
            {
                Node _node = new Node();
                _node.Text = _mlist[i].Prog_Descp;
                _node.Name = _mlist[i].Prog_CLS;
                _node.Tag = _mlist[i];
                if (_mlist[i].Prog_Status == 9)
                {
                    _node.Style = _nodestyleRed;
                    _node.StyleSelected = _nodestyleRed;
                }
                else
                {
                    _node.Style = _nodestyleBlue;
                    _node.StyleSelected = _nodestyleBlue;
                }
                _nodes.Add(_node);
                _node.EnsureVisible();

                this.AddSonNode(_list, _node.Nodes, _mlist[i].Prog_Id);
            }
        }

        public void CreateRightTree(AdvTree advTree, string userId)
        {
            if (advTree == null) return;
            advTree.Nodes.Clear();

            var _listprog = _CoreProgList.LoadEntities(null,t=>t.Prog_Descp).ToList();
            var _listwrt = _CoreProg_WRT.LoadEntities(t => t.User_Id == userId).ToList();

            this.AddSonNodeByUserid(_listprog, _listwrt, advTree.Nodes, "-1");
        }

        private void AddSonNodeByUserid(List<ProgList> _list, List<Prog_WRT> _pgwrtlist, NodeCollection _nodes, string parentid)
        {
            var _nodestyleBlue = new DevComponents.DotNetBar.ElementStyle();
            _nodestyleBlue.TextColor = System.Drawing.Color.Blue;
            _nodestyleBlue.Font = new System.Drawing.Font("宋体", 14);
            _nodestyleBlue.BackColor = System.Drawing.Color.FromArgb(207, 221, 238);

            var _nodestyleRed = new DevComponents.DotNetBar.ElementStyle();
            _nodestyleRed.TextColor = System.Drawing.Color.Red;
            _nodestyleRed.Font = new System.Drawing.Font("宋体", 14);
            _nodestyleRed.BackColor = System.Drawing.Color.FromArgb(207, 221, 238);


            var _mlist = _list.FindAll(t => t.Prog_ParantId == parentid);
            for (int i = 0; i < _mlist.Count; i++)
            {
                Node _node = new Node();
                _node.Text = _mlist[i].Prog_Descp;
                _node.Name = _mlist[i].Prog_Id;

                //_node.Tag = _mlist[i];

                var _wrtlist = _pgwrtlist.FindAll(t => t.Prog_Id == _mlist[i].Prog_Id);
                if (_wrtlist.Count <= 0)//不存在
                {
                    _node.Style = _nodestyleRed;
                    _node.StyleSelected = _nodestyleRed;
                    _node.Tag = null;
                }
                else
                {
                    _node.Style = _nodestyleBlue;
                    _node.StyleSelected = _nodestyleBlue;
                    _node.Tag = _wrtlist[0];
                }

                _nodes.Add(_node);
                _node.EnsureVisible();

                this.AddSonNodeByUserid(_list, _pgwrtlist, _node.Nodes, _mlist[i].Prog_Id);

            }
        }

        public void CreateUsableRightTree(AdvTree advTree, string _useid)
        {
            //加载所有的权限
            if (string.IsNullOrEmpty(_useid)) throw new Exception("登录员工编号有误....");
            var _progmst = _CoreProg_WRT.LoadEntities(t => t.User_Id == _useid).ToList();
            List<string> _mlist = new List<string>();
            _progmst.ForEach(t => _mlist.Add(t.Prog_Id));//将所有的程序id放入集合中

            var _mproglist = _CoreProgList.LoadEntities(t => _mlist.Contains(t.Prog_Id),p=>p.Prog_Descp).ToList();

            this.AddSonNode(_mproglist, advTree.Nodes, "-1");

        }
        #endregion

        public void CreateFunTree(AdvTree advTree)
        {
            if (advTree == null) return;
            advTree.Nodes.Clear();
            var _lsit = _CoreFunctionRepository.LoadEntities(null,t=>t.Func_Descpt).ToList();
            this.AddFunSonNode(_lsit, advTree.Nodes, "-1");

        }
        private void AddFunSonNode(List<FunctionRepository> _list, NodeCollection _nodes, string parentid)
        {
            var _nodestyleBlue = new DevComponents.DotNetBar.ElementStyle();
            _nodestyleBlue.TextColor = System.Drawing.Color.Blue;
            _nodestyleBlue.Font = new System.Drawing.Font("宋体", 14);
            _nodestyleBlue.BackColor = System.Drawing.Color.FromArgb(207, 221, 238);

            var _nodestyleRed = new DevComponents.DotNetBar.ElementStyle();
            _nodestyleRed.TextColor = System.Drawing.Color.Red;
            _nodestyleRed.Font = new System.Drawing.Font("宋体", 14);
            _nodestyleRed.BackColor = System.Drawing.Color.FromArgb(207, 221, 238);



            var _mlist = _list.FindAll(t => t.Fun_ParantId == parentid);
            for (int i = 0; i < _mlist.Count; i++)
            {
                Node _node = new Node();
                _node.Text = _mlist[i].Func_Descpt;
                
                _node.Name = _mlist[i].Fun_Id;
                _node.Tag = _mlist[i];
                
                _nodes.Add(_node);
                //_node.EnsureVisible();

                if (string.IsNullOrEmpty(_mlist[i].Fun_Name.Trim()) && (string.IsNullOrEmpty(_mlist[i].Fun_CLSF.Trim())))
                {
                    _node.Image = global::MyPorgamManage.Properties.Resources.feature_16x16;
                    _node.Style = _nodestyleRed;
                    _node.StyleSelected = _nodestyleRed;
                
                }
                else
                {
                    _node.Image = global::MyPorgamManage.Properties.Resources.csharp_16x16;
                    _node.Style = _nodestyleBlue;
                    _node.StyleSelected = _nodestyleBlue;
                }
                
                this.AddFunSonNode(_list, _node.Nodes, _mlist[i].Fun_Id);
            }
        }

    }
}
