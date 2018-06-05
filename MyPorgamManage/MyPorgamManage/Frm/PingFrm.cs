using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Repository;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace MyPorgamManage
{
    public partial class PingFrm : DevExpress.XtraEditors.XtraForm
    {
        Label[] _ArrayLable = new Label[255];
        Pen newPen = new Pen(Color.Green, 2f);//定义一个画笔，黄色
        const int ArrayLength = 20;//长度
        Point[] LinePoint = new Point[ArrayLength];

        int intx = 35;
        int intDistinct = 3;
        int labelX = 35;
        string Ips = string.Empty;

        protected override bool GetAllowSkin()
        {
            //return base.GetAllowSkin();
            if (this.DesignMode) return false;
            return true;
        }
        public PingFrm()
        {
            InitializeComponent();
            InitLable();
            

        }
        private void InitLable()
        {
            //画线的点 的位置
            int _count = 0;
            for (int j = 1; j < ArrayLength + 1; j += 2)
            {
                _count++;
                LinePoint[j - 1].X = intx * 3 * _count - intDistinct;
                LinePoint[j - 1].Y = 0;
                LinePoint[j].X = intx * 3 * _count - intDistinct;
                LinePoint[j].Y = 20000;
            }
            //加载Lable
            
            Ips = NetUnitity.GetLannIP().Substring(0, NetUnitity.GetLannIP().LastIndexOf('.') + 1);
            
            for (int i = 0; i < 255; i++)//256
            {
                _ArrayLable[i] = new Label();
                _ArrayLable[i].AutoSize = true;
                _ArrayLable[i].BackColor = System.Drawing.Color.Black;
                _ArrayLable[i].Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                _ArrayLable[i].ForeColor = System.Drawing.Color.White;
                _ArrayLable[i].Name = "label" + (i + 1).ToString();
                _ArrayLable[i].TabIndex = 1;
                _ArrayLable[i].Text = Ips + (i + 1).ToString();
                _ArrayLable[i].Location = new System.Drawing.Point(labelX * 3 * (i / 25), 25 * (i - (i / 25) * 25));
                this.Controls.Add(_ArrayLable[i]);
            }
            //让控件一直保持在右下角
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 255; i++)
            {
                _ArrayLable[i].BackColor = Color.Black;
            }
            

            ////////一般线程来PING
            //for (int i = 0; i < 255; i++)
            //{
            //    string mval = Ips + (i+1).ToString();
            //    Thread threadm = new Thread(new ParameterizedThreadStart(ThreadPing));
            //    threadm.Name = "threadm" + (i+1).ToString();
            //    threadm.Start(mval);
            //}
            //使用线程池来PING
            ThreadPool.SetMinThreads(64, 64);//修改线程池的 线程数
            ThreadPool.SetMaxThreads(64, 64);//修改线程池的 线程数
            

            List<Task> _TaskList = new List<Task>();
            for (int i = 0; i < 255; i++)
            {
                string mval = Ips + (i+1).ToString();
                _TaskList.Add(
                    Task.Factory.StartNew(new Action<object>(
                        (it) =>
                        {
                            Ping pingif = new Ping();
                            string myip = mval.ToString();
                            int lableIndex = Convert.ToInt32(myip.Substring(myip.LastIndexOf('.') + 1)) - 1;
                            PingReply pingRet = pingif.Send(myip);
                            try
                            {
                                
                                if (pingRet.Status == IPStatus.Success)
                                {
                                    _ArrayLable[lableIndex].BackColor = Color.Blue;
                                }
                                else
                                {
                                    _ArrayLable[lableIndex].BackColor = Color.Red;
                                }
                                pingif.Dispose();
                            }
                            catch (Exception ex)
                            {
                                _ArrayLable[lableIndex].BackColor = Color.Yellow;
                                MsgBox.Warning(lableIndex.ToString() + "--" + ex.Message);
                            }
                            
                            
                        }
                        ), mval)

                    );
            }
            _TaskList = null;
        }

        private void PingFrm_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < ArrayLength; i += 2)
            {
                e.Graphics.DrawLine(newPen, LinePoint[i], LinePoint[i + 1]);
            }
        }
        private void ThreadPing(Object Param)
        {
            Ping pingif = new Ping();
            string myip = Param.ToString();
            int lableIndex = Convert.ToInt32(myip.Substring(myip.LastIndexOf('.') + 1)) - 1;
            PingReply pingRet = pingif.Send(myip);
            if (pingRet.Status == IPStatus.Success)
            {
                _ArrayLable[lableIndex-1].BackColor = Color.Blue;
            }
            else
            {
                _ArrayLable[lableIndex-1].BackColor = Color.Red;
            }
        }
    }
}