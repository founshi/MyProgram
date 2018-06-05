using System;
using System.Collections.Generic;
using Aspose.Words;
using Repository;
using Server.DbFrameWork;
using SqlSugar;
using Entity;
using RazorEngine;
using RazorEngine.Templating;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace MyPorgamManage
{
    public partial class TableToWord : DevExpress.XtraEditors.XtraForm
    {
        Dictionary<string, string> CSDBDic = new Dictionary<string, string>();

        ImageList treeListImageList = null;
        DevExpress.XtraTreeList.Nodes.TreeListNode _CurrentSelectNode = null;
        LoadTreeDev _LoadTreeDev = new LoadTreeDev();
        private string _CodeClassPref = string.Empty;//保存文件的前缀
        private string _CodeClassName = string.Empty;//保存文件的类名

        public TableToWord()
        {
            InitializeComponent();
            this.treeList1.BackColor = Color.FromArgb(207, 221, 238);// Color.Transparent;
            treeList1.Appearance.Empty.BackColor = Color.FromArgb(207, 221, 238);
            treeList1.Appearance.Row.BackColor = Color.FromArgb(207, 221, 238);
            this.splitContainer1.BackColor = Color.FromArgb(207, 221, 238);
            this.splitContainer2.BackColor = Color.FromArgb(207, 221, 238);
        }
 
        #region 创建数据库对应的Word文档
        
        private void CreateColumInfoToWord(DbLoginFor _DbLoginFor,bool _isTable = true)
        {
            IFrameWorkDb _IFrameWorkDb = null;
            _IFrameWorkDb = FrameWorkDbFactory.CreateNewFrameWorkDb(_DbLoginFor.ConnString, _DbLoginFor.Db_Type);
            if (_IFrameWorkDb == null)
            {
                MsgBox.Warning("您选中的表或者视图节点数据类型存在问题,请前去确认.......");
                return;
            }

            List<DbTableInfo> _tableList = _IFrameWorkDb.GetTables();//获取所的表

            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);
            bool _isSqlite = _DbLoginFor.Db_Type == 1 ? true : false;

            if (_isTable)//生成表的数据字典
            {
                CreateCellStyle(builder);
                for (int i = 0; i < _tableList.Count; i++)
                {
                    CreateTitleCell(builder, _tableList[i].Name);
                    List<ColumnInfo> _columList = _IFrameWorkDb.GetColumsFromTable(_tableList[i].Name);
                    CreateCell(builder, _columList, _isSqlite);
                }
            }
            else//生成视图的数据字典
            {
                //下面加载视图
                List<DbTableInfo> _viewList = _IFrameWorkDb.GetViews();//获取所有的视图
                CreateCellStyle(builder);
                for (int i = 0; i < _viewList.Count; i++)
                {
                    CreateTitleCell(builder, _tableList[i].Name, 2);
                    //获取视图的每列信息
                    List<ColumnInfo> _columList = _IFrameWorkDb.GetColumsFromView(_viewList[i].Name);
                    CreateCell(builder, _columList, _isSqlite);
                }
            }

            string _name = DialogUnitity.DialogSaveWordFile(ConstKeyUnitity.CAPTIONTEXT);
            if (string.IsNullOrEmpty(_name))
            {
                MsgBox.Warning("保存文件名不可以为空...");
                return;
            }
            doc.Save(_name);
            MsgBox.Infor("数据字典导出完成....");
        
        
        }
        private void CreateCell(DocumentBuilder builder, List<ColumnInfo> _columList, bool IsSqlite)
        {
            for (int j = 0; j < _columList.Count; j++)
            {

                Aspose.Words.Tables.Cell _cell = null;
                _cell = builder.InsertCell();//主键的时候 添加背景色为黄色

                if (_columList[j].IsPK)
                {
                    _cell.CellFormat.Shading.BackgroundPatternColor = Color.Yellow;
                }
                else
                {
                    _cell.CellFormat.Shading.BackgroundPatternColor = Color.Transparent;
                }
                builder.Write((j + 1).ToString());//SEQ
                builder.InsertCell();
                builder.Write(_columList[j].ColumnName);//ColumName
                builder.InsertCell();
                builder.Write(_columList[j].TypeName);//Type
                builder.InsertCell();
                switch (_columList[j].TypeName.Trim().ToUpper())
                {
                    case "NVARCHAR":
                    case "NVARCHAR2":
                        if (IsSqlite)
                        {
                            builder.Write(_columList[j].Length.Trim());//Length                                    
                        }
                        else
                        {
                            builder.Write((Convert.ToInt32(_columList[j].Length.Trim()) / 2).ToString());//Length
                        }
                        break;
                    case "NUMBER":
                    case "NUMERIC":
                        if ((string.IsNullOrEmpty(_columList[j].Preci.Trim())) && (string.IsNullOrEmpty(_columList[j].Scale.Trim())))
                        {
                            builder.Write("");
                        }
                        else if ((_columList[j].Preci.Trim() == "0") && (_columList[j].Scale.Trim() == "0"))
                        {
                            builder.Write("");
                        }
                        else
                        {
                            builder.Write("(" + (_columList[j].Preci + "," + _columList[j].Scale + ")"));
                        }
                        break;
                    case "SMALLMONEY":
                    case "BIGINT":
                    case "SMALLINT":
                    case "DATETIME":
                    case "INT":
                    case "TEXT":
                        builder.Write("");
                        break;
                    default:
                        builder.Write((_columList[j].Length).ToString());
                        break;
                }

                builder.InsertCell();
                if (_columList[j].DefaultVal == null)
                {
                    builder.Write("");
                }
                else
                {
                    builder.Write(_columList[j].DefaultVal);
                }
                builder.InsertCell();
                if (_columList[j].cisNull)//NULL
                {
                    builder.Write("√");
                }
                else
                {
                    builder.Write("");
                }
                builder.InsertCell();
                if (_columList[j].DeText == null)
                {
                    builder.Write("");
                }
                else
                {
                    builder.Write(_columList[j].DeText);//DESCRIPTION    
                }
                builder.InsertCell();
                builder.Write("");//REMARK                 
                builder.EndRow();
            }
            builder.InsertBreak(BreakType.LineBreak);
            
        
        }

       
        /// <summary>
        /// 设置 表的格式
        /// </summary>
        /// <param name="builder"></param>
        private void CreateCellStyle(DocumentBuilder builder)
        {

            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = System.Drawing.Color.Red;
            builder.CellFormat.WrapText = true;
            builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;//垂直居中对齐


            builder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Title;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        }
        /// <summary>
        /// 添加表格每列表头
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="tableViewName"></param>
        /// <param name="tv"></param>
        private void CreateTitleCell(DocumentBuilder builder, string tableViewName, int tv = 1)
        {
            if (tv == 1)
            {
                builder.Write("主档表描述后期修改(" + tableViewName + ")");
            }
            else
            {
                builder.Write("主档视图描述后期修改(" + tableViewName + ")");
            }
            builder.ParagraphFormat.Style.Font.Bold = false;
            builder.ParagraphFormat.Style.Font.Size = 13f;

            builder.InsertCell(); builder.Write("SEQ");
            builder.InsertCell(); builder.Write("ColumName");
            builder.InsertCell(); builder.Write("Type");
            builder.InsertCell(); builder.Write("Length");
            builder.InsertCell(); builder.Write("Default");
            builder.InsertCell(); builder.Write("NULL");
            builder.InsertCell(); builder.Write("DESCRIPTION");
            builder.InsertCell(); builder.Write("REMARK");
            builder.EndRow();
        }
        #endregion

        private void TableToWord_Load(object sender, EventArgs e)
        {
            treeListImageList = new ImageList();
            treeListImageList.ImageSize = new Size(32, 32);
            treeListImageList.TransparentColor = System.Drawing.Color.Transparent;
            treeListImageList.Images.Add("0", MyPorgamManage.Properties.Resources.viewonweb_32x32);
            treeListImageList.Images.Add("1", MyPorgamManage.Properties.Resources.database_32x32);
            treeListImageList.Images.Add("2", MyPorgamManage.Properties.Resources.cards_32x32);
            treeListImageList.Images.Add("3", MyPorgamManage.Properties.Resources.palette_32x32);

            treeList1.SelectImageList = treeListImageList;
            LoadDbLoginFor();
            //加载
            LoadCombox();
            //Core.CoreCodeTemplet _CoreCodeTemplet = new Core.CoreCodeTemplet();
            //var _codelist = _CoreCodeTemplet.LoadEntities(null).ToList();
            //_codelist.Insert(0, new CodeTemplet() { CTemplet_Id = "-1", CTemplet_Name = "请选择模板名称" });
            //if (_codelist.Count != 0)
            //{
            //    this.comboBox1.DataSource = _codelist;
            //    this.comboBox1.ValueMember = "CTemplet_Id";
            //    this.comboBox1.DisplayMember = "CTemplet_Name";
            //}
            //this.comboBox1.SelectedIndex = 0;
            //加载 DB 数据类型和 C# 数据类型对照表
            Core.CoreDBCSTypeChange _CoreDBCSTypeChange = new Core.CoreDBCSTypeChange();
            var _mmlist = _CoreDBCSTypeChange.LoadEntities(null).ToList();
            foreach (var item in _mmlist)
            {
                if (!CSDBDic.ContainsKey(item.DbType.Trim().ToUpper())) CSDBDic.Add(item.DbType.Trim().ToUpper(), item.CsType);
            }
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DbLoginFrm.SqlServerFrm _SqlServerFrm = new DbLoginFrm.SqlServerFrm();
            _SqlServerFrm.ShowDialog();
            LoadDbLoginFor();
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DbLoginFrm.OracleFrm _OracleFrm = new DbLoginFrm.OracleFrm();
            _OracleFrm.ShowDialog();
            LoadDbLoginFor();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DbLoginFrm.SqliteFrm _SqliteFrm = new DbLoginFrm.SqliteFrm();
            _SqliteFrm.ShowDialog();
            LoadDbLoginFor();
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {

            _CurrentSelectNode = null;
            if ((this.treeList1.Selection.Count == 1)
                && (0 == this.treeList1.Selection[0].Id)
                && (e.Button == MouseButtons.Right))
            {
                popupMenu1.ShowPopup(MousePosition);
                return;
            }
            if ((this.treeList1.Selection.Count == 1)
                && (e.Button == MouseButtons.Right)
                && (null != this.treeList1.Selection[0].Tag)
                )
            {
                _CurrentSelectNode = this.treeList1.Selection[0];
                string TabViewString = this.treeList1.Selection[0].Tag as string;
                if (null == TabViewString)
                {
                    popupMenu2.ShowPopup(MousePosition);
                }
                else
                {
                    if (TabViewString == "表")
                    {
                        popupMenu3.ShowPopup(MousePosition);
                        return;
                    }
                    if (TabViewString == "视图")
                    {
                        popupMenu4.ShowPopup(MousePosition);
                        return;
                    }
                }
            }
            if ((this.treeList1.Selection.Count == 1)
               && (e.Button == MouseButtons.Left)
               && (null != this.treeList1.Selection[0].Tag)
               )
            {
                _CurrentSelectNode = this.treeList1.Selection[0];
                string TabViewString = this.treeList1.Selection[0].Tag as string;
                if ((TabViewString == "视图") || (TabViewString == "表"))
                {
                    this.textBox2.Text = string.Empty;
                }
                else
                {
                    this.textBox2.Text = TabViewString;
                }
            }


        }

        private void LoadDbLoginFor()
        {
            Core.CoreDbLoginFor _CoreDbLoginFor = new Core.CoreDbLoginFor();
            var _mlist = _CoreDbLoginFor.LoadEntities(null).ToList();


            var node1 = _LoadTreeDev.CreateDbCodeTreeHead(this.treeList1);

            _LoadTreeDev.CreateDBTreeNode(_mlist, node1);


        }

        private void LoadTableAndView()
        {
            if (_CurrentSelectNode == null) return;
            IFrameWorkDb _IFrameWorkDb = null;
            DbLoginFor _DbLoginFor = _CurrentSelectNode.Tag as DbLoginFor;
            if (_DbLoginFor == null)
            {
                MsgBox.Infor("您为选择数据库节点");
                return;
            }

            switch (_DbLoginFor.Db_Type)
            {
                case 1://sqlite
                    _IFrameWorkDb = new FrameWorkSqliteDb(_DbLoginFor.ConnString);
                    break;
                case 2://sql server
                    _IFrameWorkDb = new FrameWorkSqlServer2008Db(_DbLoginFor.ConnString);
                    break;
                case 3://oracle
                    _IFrameWorkDb = new FrameWorkOracleDb(_DbLoginFor.ConnString);
                    break;
                case 4://mysql
                    _IFrameWorkDb = new FrameWorkMySqlDb(_DbLoginFor.ConnString);
                    break;
                default:
                    MsgBox.Warning("未知数据量类型...");
                    return;
            }
            List<DbTableInfo> _tableList = _IFrameWorkDb.GetTables();

            List<DbTableInfo> _viewList = _IFrameWorkDb.GetViews();

            _LoadTreeDev.CreateTableAndViewNode(_CurrentSelectNode, _tableList, _viewList);

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadTableAndView();

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //表生成数据字典
            if (_CurrentSelectNode == null)
            {
                MsgBox.Infor("请先选中需要生成的'表'节点");
                return;
            }
            DevExpress.XtraTreeList.Nodes.TreeListNode _ParantNode = _CurrentSelectNode.ParentNode;
            if (_ParantNode == null)
            {
                MsgBox.Warning("'表'节点无父节点....");
                return;
            }
            DbLoginFor _DbLoginFor = _ParantNode.Tag as DbLoginFor;
            if (_DbLoginFor == null)
            {
                MsgBox.Warning("'表'节点的连接信息错误....");
                return;
            }
            CreateColumInfoToWord(_DbLoginFor);
            
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //表生成数据字典
            if (_CurrentSelectNode == null)
            {
                MsgBox.Infor("请先选中需要生成的'视图'节点");
                return;
            }
            DevExpress.XtraTreeList.Nodes.TreeListNode _ParantNode = _CurrentSelectNode.ParentNode;
            if (_ParantNode == null)
            {
                MsgBox.Warning("'视图'节点无父节点....");
                return;
            }
            DbLoginFor _DbLoginFor = _ParantNode.Tag as DbLoginFor;
            if (_DbLoginFor == null)
            {
                MsgBox.Warning("'视图'节点的连接信息错误....");
                return;
            }
            CreateColumInfoToWord(_DbLoginFor, false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex != 0)
            {
                CodeTemplet __CodeTemplet = this.comboBox1.SelectedItem as CodeTemplet;
                if (null == __CodeTemplet) return;
                this.textBox1.Text = __CodeTemplet.CTemplet_NameSP;
                this.textBox3.Text = __CodeTemplet.CTemplet_CPrefix;
            }
            else
            {
                this.textBox1.Text = string.Empty;
                this.textBox3.Text = string.Empty;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DbLoginFor __DbLoginFor = _CurrentSelectNode.Tag as DbLoginFor;
            if (null == __DbLoginFor) return;
            Core.CoreDbLoginFor __CoreDbLoginFor = new Core.CoreDbLoginFor();
            try
            {
                __CoreDbLoginFor.DeleteEntity(__DbLoginFor);
                this.treeList1.Nodes.Remove(_CurrentSelectNode);
                _CurrentSelectNode = null;
            }
            catch (Exception ex)
            {
                MsgBox.Warning("删除失败,原因:" + ex.Message);
            }


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _CodeClassPref = string.Empty;
            _CodeClassName = string.Empty;
            DevExpress.XtraTreeList.Nodes.TreeListNode __TempNode = _CurrentSelectNode;
            if (this.comboBox1.SelectedIndex == 0)
            {
                MsgBox.Warning("请您先选中生成代码的模板......");
                return;
            }
            //生成代码
            if (string.IsNullOrEmpty(this.textBox2.Text.Trim()))
            {
                MsgBox.Warning("请您先选中表或者视图......");
                return;
            }

            //1.0 获取选中的模板文件的内容

            CodeTemplet __CodeTemplet = this.comboBox1.SelectedItem as CodeTemplet;
            if (null == __CodeTemplet)
            {
                MsgBox.Warning("您选中的模板有问题,请前去确认.......");
                return;
            }

            string compText = __CodeTemplet.CTemplet_Context;
            //数据库节点
            DevExpress.XtraTreeList.Nodes.TreeListNode _rootNode = __TempNode.ParentNode.ParentNode;
            if (_rootNode == null)
            {
                MsgBox.Warning("您选中的表或者视图节点数据存在问题,请前去确认.......");
                return;
            }

            DbLoginFor __DbLoginFor = _rootNode.Tag as DbLoginFor;
            IFrameWorkDb _IFrameWorkDb = null;
            _IFrameWorkDb = FrameWorkDbFactory.CreateNewFrameWorkDb(__DbLoginFor.ConnString, __DbLoginFor.Db_Type);
            if (_IFrameWorkDb == null)
            {
                MsgBox.Warning("您选中的表或者视图节点数据类型存在问题,请前去确认.......");
                return;
            }
            
           
            string _ClassName = this.textBox2.Text.Trim();
            string _TableName = this.textBox2.Text.Trim();
            string _NameSpace = this.textBox1.Text.Trim();
            string _SqlName = __CodeTemplet.CTemplet_DbType;
            _CodeClassPref = this.textBox3.Text.Trim();
            _CodeClassName = this.textBox2.Text.Trim();

            Task.Factory.StartNew(new Action(() =>
            {

                string _tvstring = __TempNode.ParentNode.Tag as string;
                List<ColumnInfo> _ColumnInfoList = null;
                if (_tvstring.Trim() == "表")
                {
                    _ColumnInfoList = _IFrameWorkDb.GetColumsFromTable(_TableName);
                }
                else if (_tvstring.Trim() == "视图")
                {
                    _ColumnInfoList = _IFrameWorkDb.GetColumsFromView(_TableName);
                }

                foreach (var item in _ColumnInfoList)
                {
                    if (CSDBDic.ContainsKey(item.TypeName.Trim().ToUpper())) item.TypeName = CSDBDic[item.TypeName.ToUpper()];
                }
                //templateKey
                string _GenerdString = Engine.Razor.RunCompile(__CodeTemplet.CTemplet_Context, StringUnitity.GetNewGUID(), null, new
                {
                    ClassName = _ClassName,//类名
                    TableName = _TableName,//表名
                    Columns = _ColumnInfoList,//表的列信息
                    NameSpace = _NameSpace,//命名空间
                    SqlName = _SqlName//数据库类型                        
                });
                
                this.Invoke(new MethodInvoker(() =>
                {
                    this.fastColoredTextBox1.Text = _GenerdString;
                }));
            }));

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Frm.CodeTempletAddFrm __CodeTempletAddFrm = new Frm.CodeTempletAddFrm();
            __CodeTempletAddFrm.ShowDialog();
            LoadCombox();
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;
            this.fastColoredTextBox1.Text = string.Empty;
        }

        private void LoadCombox()
        {
            this.comboBox1.DataSource = null;
            Core.CoreCodeTemplet _CoreCodeTemplet = new Core.CoreCodeTemplet();
            var _codelist = _CoreCodeTemplet.LoadEntities(null,it=>it.CTemplet_Name).ToList();
            _codelist.Insert(0, new CodeTemplet() { CTemplet_Id = "-1", CTemplet_Name = "请选择模板名称" });
            if (_codelist.Count != 0)
            {
                this.comboBox1.DataSource = _codelist;
                this.comboBox1.ValueMember = "CTemplet_Id";
                this.comboBox1.DisplayMember = "CTemplet_Name";
            }
            this.comboBox1.SelectedIndex = 0;

        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string _FileName = DialogUnitity.DialogFolderBrowser();
            if (string.IsNullOrEmpty(_FileName.Trim()))
            {
                MsgBox.Infor("没有您选中的文件夹....");
                return;
            }
            _FileName += @"\" + _CodeClassPref + _CodeClassName + ".cs";
            FileUnitity.StringToNewFile(_FileName, this.fastColoredTextBox1.Text, System.Text.Encoding.UTF8);

            MsgBox.Infor("文件保存完成....");
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CreateCSFiles(1);
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CreateCSFiles(2);
        }

        private void CreateCSFiles(int _dbtype = 1)
        {
            string _tableViewShowStr = string.Empty;
            if (_dbtype == 1)
            {
                _tableViewShowStr = "表";
            }
            if (_dbtype == 2)
            {
                _tableViewShowStr = "视图";
            }
            if (_CurrentSelectNode == null)
            {
                MsgBox.Infor("请先选中需要生成的'" + _tableViewShowStr + "'节点");
                return;
            }
            DevExpress.XtraTreeList.Nodes.TreeListNode _ParantNode = _CurrentSelectNode.ParentNode;
            if (_ParantNode == null)
            {
                MsgBox.Warning("'" + _tableViewShowStr + "'节点无父节点....");
                return;
            }
            DbLoginFor _DbLoginFor = _ParantNode.Tag as DbLoginFor;
            if (_DbLoginFor == null)
            {
                MsgBox.Warning("'" + _tableViewShowStr + "'节点的连接信息错误....");
                return;
            }
            if (this.comboBox1.SelectedIndex == 0)
            {
                MsgBox.Warning("您选中的模板有问题,请前去确认.......");
                return;
            }
            CodeTemplet __CodeTemplet = this.comboBox1.SelectedItem as CodeTemplet;
            if (null == __CodeTemplet)
            {
                MsgBox.Warning("您选中的模板有问题,请前去确认.......");
                return;
            }
            string _FolderName = DialogUnitity.DialogFolderBrowser();
            if (string.IsNullOrEmpty(_FolderName.Trim()))
            {
                MsgBox.Infor("没有您选中的文件夹....");
                return;
            }

            string _Conn = _DbLoginFor.ConnString;
            CreateCSFileOneByOne(_DbLoginFor, __CodeTemplet, _FolderName, _dbtype);
            MsgBox.Infor("文件保存完成....");
        }

        private void CreateCSFileOneByOne(DbLoginFor _DbLoginFor,
            CodeTemplet __CodeTemplet, string _FolderPath,
            int _tableType = 1)
        {
            //加载所有的表
            IFrameWorkDb _IFrameWorkDb = null;
            List<DbTableInfo> _tableList = null;

            _IFrameWorkDb = FrameWorkDbFactory.CreateNewFrameWorkDb(_DbLoginFor.ConnString, _DbLoginFor.Db_Type);
            if (_IFrameWorkDb == null)
            {
                MsgBox.Warning("您配置的数据库节点存在问题.....");
                return;
            }

            if (_tableType == 1)//表
            {
                //System.Diagnostics.Stopwatch _stp=   System.Diagnostics.Stopwatch.StartNew();
                //_stp.Start();
                _tableList = _IFrameWorkDb.GetTables();//获取所的表
                List<Task> _TaskList = new List<Task>();
                for (int i = 0; i < _tableList.Count; i++)
                {
                    _TaskList.Add(Task.Factory.StartNew(new Func<object, int>(it =>
                      {
                    int val1 =  (int)it;
                          IFrameWorkDb _IFrameWorkDbTheard = null;
                          _IFrameWorkDbTheard = FrameWorkDbFactory.CreateNewFrameWorkDb(_DbLoginFor.ConnString, _DbLoginFor.Db_Type);
                          
                          List<ColumnInfo> _columnList = _IFrameWorkDbTheard.GetColumsFromTable(_tableList[val1].Name);
                          foreach (var item in _columnList)
                          {
                              if (CSDBDic.ContainsKey(item.TypeName.Trim().ToUpper())) item.TypeName = CSDBDic[item.TypeName.ToUpper()];
                          }
                          string CodeString = CreareRazorString(__CodeTemplet.CTemplet_Context, _tableList[val1].Name, __CodeTemplet.CTemplet_NameSP, __CodeTemplet.CTemplet_DbType, _columnList);
                          string _fileName = _FolderPath + @"\" + __CodeTemplet.CTemplet_CPrefix.Trim() + _tableList[val1].Name + ".cs";
                          FileUnitity.StringToNewFile(_fileName, CodeString, System.Text.Encoding.UTF8);

                          return 1;
                      }), i));
                    if (i % 5 == 0)
                    {
                        Task.WaitAll(_TaskList.ToArray());
                    }

                } //_stp.Stop(); MsgBox.Infor(_stp.ElapsedMilliseconds.ToString());
            }
            else//视图
            {
                _tableList = _IFrameWorkDb.GetViews();//获取所的视图
                List<Task> _TaskList = new List<Task>();
                for (int i = 0; i < _tableList.Count; i++)
                {
                   _TaskList.Add( Task.Factory.StartNew(new Func<object, int>(it => {
                        int val1 = (int)it;
                        List<ColumnInfo> _columnList = _IFrameWorkDb.GetColumsFromView(_tableList[val1].Name);
                        foreach (var item in _columnList)
                        {
                            if (CSDBDic.ContainsKey(item.TypeName.Trim().ToUpper())) item.TypeName = CSDBDic[item.TypeName.ToUpper()];
                        }
                        string CodeString = CreareRazorString(__CodeTemplet.CTemplet_Context, _tableList[val1].Name, __CodeTemplet.CTemplet_NameSP, __CodeTemplet.CTemplet_DbType, _columnList);
                        string _fileName = _FolderPath + @"\" + __CodeTemplet.CTemplet_CPrefix.Trim() + _tableList[val1].Name + ".cs";
                        FileUnitity.StringToNewFile(_fileName, CodeString, System.Text.Encoding.UTF8);
                

                        return 1;
                    }), i));

                   if (i % 5 == 0)
                   {
                       Task.WaitAll(_TaskList.ToArray());
                   }
                    
                }
            }
        }

        private string CreareRazorString(string CTemplet_Context, string _ClassName,
             string _NameSpace, string _SqlName,
            List<ColumnInfo> _ColumnInfoList)
        {//"templateKey"
            string _GenerdString = Engine.Razor.RunCompile(CTemplet_Context, StringUnitity.GetNewGUID(), null, new
            {
                ClassName = _ClassName,//类名
                TableName = _ClassName,//表名
                Columns = _ColumnInfoList,//表的列信息
                NameSpace = _NameSpace,//命名空间
                SqlName = _SqlName//数据库类型                        
            });
            return _GenerdString;
        }
    }
    static class FrameWorkDbFactory
    {
        public static IFrameWorkDb CreateNewFrameWorkDb(string connstring, int dbtype = 1)
        {
            switch (dbtype)
            {
                case 1: return new FrameWorkSqliteDb(connstring);
                case 2: return new FrameWorkSqlServer2008Db(connstring);
                case 3: return new FrameWorkOracleDb(connstring);
                case 4: return new FrameWorkMySqlDb(connstring);
                default: return null;
            }
        }

    }


}