using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MyPorgamManage
{
    public partial class Frm_Main : DevExpress.XtraEditors.XtraForm
    {
        Color[] TabColor = new Color[]{
            Color.FromArgb(35,83,194),
            Color.FromArgb(64,168,19),
            Color.FromArgb(245,121,10),
            Color.FromArgb(141,62,168),
            Color.FromArgb(70,155,183),
            Color.FromArgb(196,19,19)
        };
        int formCount = 0;
        LoadTree _LoadTree = new LoadTree();
        public Frm_Main()
        {
            InitializeComponent();
            this.splitContainerControl1.Width = (int)(this.Width * 0.4);
            Repository.MsgBox.MyTextBox = this.textBox1;
            this.toolStripStatusLabel1.Text = "登陆者:" + Program.UserMST.User_Name;
            this.toolStripStatusLabel3.Text = "IP地址:" + Repository.NetUnitity.GetLannIP();
            this.toolStripStatusLabel5.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
            Repository.ChineseCalendar _ChineseCalendar = new Repository.ChineseCalendar(DateTime.Now);
            this.toolStripStatusLabel7.Text = _ChineseCalendar.ChineseDateString;
            this.toolStripStatusLabel8.Text = "    " + _ChineseCalendar.WeekDayString;
            this.notifyIcon1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateTree();
            System.Threading.Thread _thread = new System.Threading.Thread(ThreadTime);
            _thread.IsBackground = true;
            _thread.Start();
        }

        private void CreateTree()
        {
            _LoadTree.CreateUsableRightTree(this.advTree1, Program.UserMST.User_Id);
        }

        private void advTree1_NodeMouseUp(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            ProgList _mproglist = e.Node.Tag as ProgList;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                string _FrmName = string.Empty;
                if (!string.IsNullOrEmpty(_mproglist.Prog_Assmbly.Trim()))//程序集
                    _FrmName = _mproglist.Prog_Assmbly.Trim() + ".";
                if (!string.IsNullOrEmpty(_mproglist.Prog_NameSp.Trim()))//命名空间
                {
                    _FrmName += _mproglist.Prog_NameSp.Trim() + ".";
                }
                else
                {
                    _FrmName += this.GetType().Namespace + ".";
                }

                if (string.IsNullOrEmpty(_mproglist.Prog_CLS.Trim()))
                {
                    return;
                }
                else
                {
                    _FrmName += _mproglist.Prog_CLS.Trim();
                }

                bool CanNew = true;
                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    if (this.MdiChildren[i].Name == _FrmName)
                    {
                        CanNew = false;
                        //this.MdiChildren[i].Focus();
                        this.MdiChildren[i].Activate();
                        break;
                    }
                }
                if (!CanNew) return;
                Assembly assembly = Assembly.GetExecutingAssembly();

                Form _frm = assembly.CreateInstance(_FrmName) as Form;
                _frm.Name = _FrmName;
                formCount++;
                _frm.MdiParent = this;
                _frm.Text = _mproglist.Prog_Descp;
                _frm.Show();

                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.BackColor = TabColor[(formCount - 1) % 6];
            }
        }

        private void ThreadTime()
        {
            while (true)
            {
                if (this.InvokeRequired)
                {
                    try
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.toolStripStatusLabel5.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
                        }));
                    }
                    catch
                    { }
                }
                System.Threading.Thread.Sleep(500);
            }
        }


        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//当用户点击窗体右上角X按钮或(Alt + F4)时 发生          
            {
                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    this.MdiChildren[i].Close();
                }
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                popupMenu1.ShowPopup(Cursor.Position);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //for (int i = 0; i < this.MdiChildren.Length; i++)
            //{
            //    this.MdiChildren[i].Visible = true;
            //}

            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
        }



        //private void treeList1_Click(object sender, EventArgs e)
        //{
        //    formCount++;
        //    XtraForm1 frm = new XtraForm1();
        //    frm.Text = string.Format("Form {0}", formCount);
        //    frm.MdiParent = this;
        //    frm.Show();
        //    xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.BackColor = TabColor[(formCount - 1) % 6];

        //}
    }
}
