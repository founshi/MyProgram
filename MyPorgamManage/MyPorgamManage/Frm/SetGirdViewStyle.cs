using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyPorgamManage
{
    public partial class SetGirdViewStyle : Form
    {
        string _WriteString = string.Empty;//生成保存文本
        string _CodeString = string.Empty;//生成代码
        public SetGirdViewStyle()
        {
            InitializeComponent();
            this.radioButton1.Checked = true;
            this.checkBox1.Checked = true;
            this.checkBox2.Checked = true;
            this.checkBox5.Checked = true;
            InitCombox();
        }
        private void IniData()
        {
            List<Student> _list = new List<Student>() { 
            new Student(){ Age=18, Gender="男", Name="张三1", StuId=1},
            new Student(){ Age=18, Gender="女", Name="张三2", StuId=2},
            new Student(){ Age=18, Gender="男", Name="张三3", StuId=3},
            new Student(){ Age=18, Gender="女", Name="张三4", StuId=4},
            new Student(){ Age=18, Gender="男", Name="张三5", StuId=5},
            new Student(){ Age=18, Gender="女", Name="张三6", StuId=6},
            new Student(){ Age=18, Gender="男", Name="张三7", StuId=7},
            new Student(){ Age=18, Gender="女", Name="张三8", StuId=8},
            new Student(){ Age=18, Gender="男", Name="张三9", StuId=9},
            new Student(){ Age=18, Gender="女", Name="张三10", StuId=10},
            new Student(){ Age=18, Gender="男", Name="张三11", StuId=11},
            new Student(){ Age=18, Gender="女", Name="张三12", StuId=12},
            new Student(){ Age=18, Gender="男", Name="张三13", StuId=13}            
            };
            this.dataGridView1.DataSource = _list;
        }
        private void Frm_SetDataGridStyle_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetDataGridStyle();
            IniData();
        }

        #region 设置样式
        private void SetDataGridStyle()
        {
            _WriteString = string.Empty;
            _CodeString = string.Empty;
            StringBuilder _Context = new StringBuilder();
            StringBuilder _ContextCode = new StringBuilder();
            _ContextCode.AppendLine("private void SetDataGridStyle(DataGridView _DataGridView)");
            _ContextCode.AppendLine("{");
            if (this.checkBox1.Checked)
            {
                this.dataGridView1.ColumnHeadersVisible = true;
                _Context.AppendLine("ColumnHeadersVisible:True;");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersVisible=true;");
            }
            else
            {
                this.dataGridView1.ColumnHeadersVisible = false;
                _Context.AppendLine("ColumnHeadersVisible:False;");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersVisible=false;");
            }
            if (this.checkBox2.Checked)
            {
                this.dataGridView1.RowHeadersVisible = true;
                _Context.AppendLine("RowHeadersVisible:True;");
                _ContextCode.AppendLine("_DataGridView.RowHeadersVisible=true;");
            }
            else
            {
                this.dataGridView1.RowHeadersVisible = false;
                _Context.AppendLine("RowHeadersVisible:False;");
                _ContextCode.AppendLine("_DataGridView.RowHeadersVisible=false;");
            }
            if (this.checkBox3.Checked)
            {
                this.dataGridView1.ReadOnly = true;
                _Context.AppendLine("ReadOnly:True;");
                _ContextCode.AppendLine("_DataGridView.ReadOnly=true;");
            }
            else
            {
                this.dataGridView1.ReadOnly = false;
                _Context.AppendLine("ReadOnly:False;");
                _ContextCode.AppendLine("_DataGridView.ReadOnly=false;");
            }
            if (this.checkBox4.Checked)
            {
                this.dataGridView1.MultiSelect = true;
                _Context.AppendLine("MultiSelect:True;");
                _ContextCode.AppendLine("_DataGridView.MultiSelect=true;");
            }
            else
            {
                this.dataGridView1.MultiSelect = false;
                _Context.AppendLine("MultiSelect:False;");
                _ContextCode.AppendLine("_DataGridView.MultiSelect=false;");
            }
            if (this.radioButton1.Checked)
            {
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                _Context.AppendLine("SelectionMode:FullRowSelect;");
                _ContextCode.AppendLine("_DataGridView.SelectionMode=DataGridViewSelectionMode.FullRowSelect;");
            }
            else
            {
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                _Context.AppendLine("SelectionMode:CellSelect;");
                _ContextCode.AppendLine("_DataGridView.SelectionMode=DataGridViewSelectionMode.CellSelect;");
            }
            if (this.button4.BackColor == Color.Yellow)
            {
                this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                _Context.AppendLine("DefaultCellStyle.Alignment:MiddleLeft;");
                _ContextCode.AppendLine("_DataGridView.DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleLeft;");
            }

            if (this.button5.BackColor == Color.Yellow)
            {
                this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Context.AppendLine("DefaultCellStyle.Alignment:MiddleCenter;");
                _ContextCode.AppendLine("_DataGridView.DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;");
            }

            if (this.button6.BackColor == Color.Yellow)
            {
                this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Context.AppendLine("DefaultCellStyle.Alignment:MiddleRight;");
                _ContextCode.AppendLine("_DataGridView.DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleRight;");
            }
            if (this.checkBox5.Checked)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                _Context.AppendLine("AutoSizeColumnsMode:Fill;");
                _ContextCode.AppendLine("_DataGridView.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;");
            }
            else
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                _Context.AppendLine("AutoSizeColumnsMode:DisplayedCells;");
                _ContextCode.AppendLine("_DataGridView.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.DisplayedCells;");
            }
            if (this.checkBox6.Checked)//行高 是否可用改变
            {
                this.dataGridView1.AllowUserToResizeRows = false;
                _Context.AppendLine("AllowUserToResizeRows:False;");
                _ContextCode.AppendLine("_DataGridView.AllowUserToResizeRows=false;");
            }
            else
            {
                this.dataGridView1.AllowUserToResizeRows = true;
                _Context.AppendLine("AllowUserToResizeRows:True;");
                _ContextCode.AppendLine("_DataGridView.AllowUserToResizeRows=true;");
            }
            if (this.checkBox7.Checked)//列宽 是否可用改变
            {
                this.dataGridView1.AllowUserToResizeColumns = false;
                _Context.AppendLine("AllowUserToResizeColumns:False;");
                _ContextCode.AppendLine("_DataGridView.AllowUserToResizeColumns=false;");
            }
            else
            {
                this.dataGridView1.AllowUserToResizeColumns = true;
                _Context.AppendLine("AllowUserToResizeColumns:True;");
                _ContextCode.AppendLine("_DataGridView.AllowUserToResizeColumns=true;");
            }
            //if (this.checkBox8.Checked)//禁止自动生成列
            //{
            //    this.dataGridView1.AutoGenerateColumns = true;
            //    _Context.AppendLine("AutoGenerateColumns:True;");
            //}
            //else
            //{
            //    this.dataGridView1.AutoGenerateColumns = false;
            //    _Context.AppendLine("AutoGenerateColumns:False;");
            //}
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                this.textBox1.Text = "White";
                this.textBox1.BackColor = Color.White;
            }
            this.dataGridView1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(this.textBox1.Text.Trim());
            _Context.AppendLine("RowsDefaultCellStyle.BackColor:" + this.textBox1.Text.Trim() + ";");
            this.dataGridView1.BackgroundColor = ColorTranslator.FromHtml(this.textBox1.Text.Trim());
            _Context.AppendLine("BackgroundColor:" + this.textBox1.Text.Trim() + ";");
            _ContextCode.AppendLine("_DataGridView.BackgroundColor=ColorTranslator.FromHtml(\"" + this.textBox1.Text.Trim() + "\");");

            if (string.IsNullOrEmpty(this.textBox2.Text.Trim()))
            {
                this.textBox2.Text = "White";
                this.textBox2.BackColor = Color.White;
            }
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(this.textBox2.Text.Trim());
            _Context.AppendLine("AlternatingRowsDefaultCellStyle.BackColor:" + this.textBox2.Text.Trim() + ";");
            _ContextCode.AppendLine("_DataGridView.AlternatingRowsDefaultCellStyle.BackColor=ColorTranslator.FromHtml(\"" + this.textBox2.Text.Trim() + "\");");


            if (!string.IsNullOrEmpty(this.textBox3.Text.Trim()))
            {
                this.dataGridView1.GridColor = ColorTranslator.FromHtml(this.textBox3.Text.Trim());
                _Context.AppendLine("GridColor:" + this.textBox3.Text.Trim() + ";");
                _ContextCode.AppendLine("_DataGridView.GridColor=ColorTranslator.FromHtml(\"" + this.textBox3.Text.Trim() + "\");");
            }

            if (string.IsNullOrEmpty(this.textBox4.Text.Trim()))
            {
                this.textBox4.Text = "Black";
                this.textBox4.BackColor = Color.Black;
            }
            this.dataGridView1.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(this.textBox4.Text.Trim());
            _Context.AppendLine("DefaultCellStyle.ForeColor:" + this.textBox4.Text.Trim() + ";");
            _ContextCode.AppendLine("_DataGridView.ForeColor=ColorTranslator.FromHtml(\"" + this.textBox4.Text.Trim() + "\");");

            if (!string.IsNullOrEmpty(this.textBox5.Text.Trim()))
            {
                this.dataGridView1.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(this.textBox5.Text.Trim());
                _Context.AppendLine("RowsDefaultCellStyle.SelectionBackColor:" + this.textBox5.Text.Trim() + ";");
                _ContextCode.AppendLine("_DataGridView.RowsDefaultCellStyle.SelectionBackColor=ColorTranslator.FromHtml(\"" + this.textBox5.Text.Trim() + "\");");
            }


            if (this.checkBox8.Checked)//列头 高
            {
                this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                _Context.AppendLine("ColumnHeadersHeightSizeMode:EnableResizing;");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.EnableResizing;");
                if (string.IsNullOrEmpty(this.textBox6.Text.Trim())) this.textBox6.Text = "20";
                this.dataGridView1.ColumnHeadersHeight = Convert.ToInt32(this.textBox6.Text.Trim());
                _Context.AppendLine("ColumnHeadersHeight:" + this.textBox6.Text.Trim() + ";");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersHeight=" + this.textBox6.Text.Trim() + ";");
            }
            else
            {
                this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                _Context.AppendLine("ColumnHeadersHeightSizeMode:AutoSize;");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;");
            }
            if (!string.IsNullOrEmpty(this.textBox7.Text.Trim()))
            {
                this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(this.textBox7.Text.Trim());
                _Context.AppendLine("ColumnHeadersDefaultCellStyle.BackColor:" + this.textBox7.Text.Trim() + ";");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersDefaultCellStyle.BackColor=ColorTranslator.FromHtml(\"" + this.textBox7.Text.Trim() + "\");");
            }

            if (this.button7.BackColor == Color.Yellow)
            {
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Context.AppendLine("ColumnHeadersDefaultCellStyle.Alignment:MiddleRight;");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleRight;");
            }
            if (this.button8.BackColor == Color.Yellow)
            {
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Context.AppendLine("ColumnHeadersDefaultCellStyle.Alignment:MiddleCenter;");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;");
            }
            if (this.button9.BackColor == Color.Yellow)
            {
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                _Context.AppendLine("ColumnHeadersDefaultCellStyle.Alignment:MiddleLeft;");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleLeft;");
            }
            //列头字体颜色
            if (string.IsNullOrEmpty(this.textBox8.Text.Trim()))
            {
                this.textBox8.Text = "Black";
                this.textBox8.BackColor = Color.Black;
            }
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(this.textBox8.Text.Trim());
            _Context.AppendLine("ColumnHeadersDefaultCellStyle.ForeColor:" + this.textBox8.Text.Trim() + ";");
            _ContextCode.AppendLine("_DataGridView.ColumnHeadersDefaultCellStyle.ForeColor=ColorTranslator.FromHtml(\"" + this.textBox8.Text.Trim() + "\");");

            //列头选中时 背景色
            if (string.IsNullOrEmpty(this.textBox9.Text.Trim()))
            {
                this.textBox9.Text = "Black";
                this.textBox9.BackColor = Color.Black;
            }
            this.dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(this.textBox9.Text.Trim());
            _Context.AppendLine("ColumnHeadersDefaultCellStyle.SelectionBackColor:" + this.textBox9.Text.Trim() + ";");
            _ContextCode.AppendLine("_DataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor=ColorTranslator.FromHtml(\"" + this.textBox9.Text.Trim() + "\");");


            //列头选中时 字体颜色
            if (string.IsNullOrEmpty(this.textBox10.Text.Trim()))
            {
                this.textBox10.Text = "Black";
                this.textBox10.BackColor = Color.Black;
            }
            this.dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml(this.textBox10.Text.Trim());
            _Context.AppendLine("ColumnHeadersDefaultCellStyle.SelectionForeColor:" + this.textBox10.Text.Trim() + ";");
            _ContextCode.AppendLine("_DataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor=ColorTranslator.FromHtml(\"" + this.textBox10.Text.Trim() + "\");");

            //选中时 字体
            if (!string.IsNullOrEmpty(this.textBox11.Text.Trim()))
            {
                string[] nfont = this.textBox11.Text.Trim().Split(':');
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(nfont[0], Convert.ToSingle(nfont[1]));
                _Context.AppendLine("ColumnHeadersDefaultCellStyle.Font:" + this.textBox11.Text.Trim() + ";");
                _ContextCode.AppendLine("_DataGridView.ColumnHeadersDefaultCellStyle.Font=new Font(\"" + nfont[0] + "\", Convert.ToSingle(" + nfont[1] + "));");
            }

            //单元格边框样式
            string cellstyle = this.comboBox2.SelectedItem.ToString();
            if (cellstyle == "--------") cellstyle = "Single";
            if (cellstyle == "Custom") cellstyle = "Single";
            DataGridViewCellBorderStyle cellBorderStyle = (DataGridViewCellBorderStyle)Enum.Parse(typeof(DataGridViewCellBorderStyle), cellstyle);
            this.dataGridView1.CellBorderStyle = cellBorderStyle;
            _Context.AppendLine("CellBorderStyle:" + cellstyle + ";");
            _ContextCode.AppendLine("DataGridViewCellBorderStyle cellBorderStyle = (DataGridViewCellBorderStyle)Enum.Parse(typeof(DataGridViewCellBorderStyle), \"" + cellstyle + "\");");
            _ContextCode.AppendLine("_DataGridView.CellBorderStyle=cellBorderStyle;");

            //列头边框样式
            string headstyle = this.comboBox1.SelectedItem.ToString();
            if (headstyle == "--------") headstyle = "Single";
            if (headstyle == "Custom") headstyle = "Single";
            DataGridViewHeaderBorderStyle columnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)Enum.Parse(typeof(DataGridViewHeaderBorderStyle), headstyle);
            this.dataGridView1.ColumnHeadersBorderStyle = columnHeadersBorderStyle;
            _ContextCode.AppendLine("DataGridViewHeaderBorderStyle columnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)Enum.Parse(typeof(DataGridViewHeaderBorderStyle), \"" + headstyle + "\");");
            _ContextCode.AppendLine("_DataGridView.ColumnHeadersBorderStyle=columnHeadersBorderStyle;");


            if (this.button12.BackColor == Color.Yellow)
            {
                this.dataGridView1.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                _Context.AppendLine("RowHeadersDefaultCellStyle.Alignment:MiddleLeft;");
                _ContextCode.AppendLine("_DataGridView.RowHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleLeft;");
            }
            if (this.button11.BackColor == Color.Yellow)
            {
                this.dataGridView1.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                _Context.AppendLine("RowHeadersDefaultCellStyle.Alignment:MiddleCenter;");
                _ContextCode.AppendLine("_DataGridView.RowHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;");
            }
            if (this.button10.BackColor == Color.Yellow)
            {
                this.dataGridView1.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _Context.AppendLine("RowHeadersDefaultCellStyle.Alignment:MiddleRight;");
                _ContextCode.AppendLine("_DataGridView.RowHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleRight;");
            }
            //行高  27
            if (string.IsNullOrEmpty(this.textBox12.Text.Trim())) this.textBox12.Text = "27";
            int val2 = 0;
            if (!int.TryParse(this.textBox12.Text.Trim(), out val2)) val2 = 27;
            this.dataGridView1.RowTemplate.Height = val2;
            _Context.AppendLine("RowTemplate.Height:" + val2.ToString() + ";");
            _ContextCode.AppendLine("_DataGridView.RowTemplate.Height=" + val2.ToString() + ";");

            //行宽度 42
            if (string.IsNullOrEmpty(this.textBox13.Text.Trim())) this.textBox13.Text = "42";
            int val1 = 0;
            if (!int.TryParse(this.textBox13.Text.Trim(), out val1)) val1 = 42;
            this.dataGridView1.RowHeadersWidth = val1;
            _Context.AppendLine("RowHeadersWidth:" + val1.ToString() + ";");
            _ContextCode.AppendLine("_DataGridView.RowHeadersWidth=" + val1.ToString() + ";");

            // 选中时 背景颜色
            if (!string.IsNullOrEmpty(this.textBox16.Text.Trim()))
            {
                this.dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(this.textBox16.Text.Trim());
                _Context.AppendLine("RowHeadersDefaultCellStyle.SelectionBackColor:" + this.textBox16.Text.Trim() + ";");
                _ContextCode.AppendLine("_DataGridView.RowHeadersDefaultCellStyle.SelectionBackColor=ColorTranslator.FromHtml(\"" + this.textBox16.Text.Trim() + "\");");
            }
            //行头字体颜色
            if (string.IsNullOrEmpty(this.textBox14.Text.Trim()))
            {
                this.textBox14.Text = "Black";
                this.textBox14.BackColor = Color.Black;
            }
            this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(this.textBox14.Text.Trim());
            _Context.AppendLine("RowHeadersDefaultCellStyle.ForeColor:" + this.textBox14.Text.Trim() + ";");
            _ContextCode.AppendLine("_DataGridView.RowHeadersDefaultCellStyle.ForeColor= ColorTranslator.FromHtml(\"" + this.textBox14.Text.Trim() + "\");");
            //行头 背景色
            if (!string.IsNullOrEmpty(this.textBox15.Text.Trim()))
            {
                this.dataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(this.textBox15.Text.Trim());
                _Context.AppendLine("RowHeadersDefaultCellStyle.BackColor:" + this.textBox15.Text.Trim() + ";");
                _ContextCode.AppendLine("_DataGridView.RowHeadersDefaultCellStyle.BackColor= ColorTranslator.FromHtml(\"" + this.textBox15.Text.Trim() + "\");");
            }

            dataGridView1.EnableHeadersVisualStyles = false;
            _Context.AppendLine("EnableHeadersVisualStyles:False;");
            _ContextCode.AppendLine("_DataGridView.EnableHeadersVisualStyles = false;");


            string rowheadstyle = this.comboBox3.SelectedItem.ToString();
            if (rowheadstyle == "--------") rowheadstyle = "Single";
            if (rowheadstyle == "Custom") rowheadstyle = "Single";
            DataGridViewHeaderBorderStyle rowHeadersBorderStyle = (DataGridViewHeaderBorderStyle)Enum.Parse(typeof(DataGridViewHeaderBorderStyle), rowheadstyle);
            this.dataGridView1.RowHeadersBorderStyle = rowHeadersBorderStyle;
            _Context.AppendLine("RowHeadersBorderStyle:" + rowheadstyle + ";");
            _ContextCode.AppendLine("DataGridViewHeaderBorderStyle rowHeadersBorderStyle = (DataGridViewHeaderBorderStyle)Enum.Parse(typeof(DataGridViewHeaderBorderStyle), \"" + rowheadstyle + "\");");
            _ContextCode.AppendLine("_DataGridView.RowHeadersBorderStyle = rowHeadersBorderStyle;");

            if (!string.IsNullOrEmpty(this.textBox17.Text.Trim()))
            {
                string[] nfont = this.textBox17.Text.Trim().Split(':');
                this.dataGridView1.DefaultCellStyle.Font = new Font(nfont[0], Convert.ToSingle(nfont[1]));
                _Context.AppendLine("DefaultCellStyle.Font:" + this.textBox17.Text.Trim() + ";");
                _ContextCode.AppendLine("_DataGridView.DefaultCellStyle.Font = new Font(\"" + nfont[0] + "\", Convert.ToSingle(" + nfont[1] + "));");
            }
            if (!string.IsNullOrEmpty(this.textBox18.Text.Trim()))
            {
                string[] nfont = this.textBox18.Text.Trim().Split(':');
                this.dataGridView1.RowHeadersDefaultCellStyle.Font = new Font(nfont[0], Convert.ToSingle(nfont[1]));
                _Context.AppendLine("RowHeadersDefaultCellStyle.Font:" + this.textBox18.Text.Trim() + ";");
                _ContextCode.AppendLine("_DataGridView.RowHeadersDefaultCellStyle.Font = new Font(\"" + nfont[0] + "\", Convert.ToSingle(" + nfont[1] + "));");
            }
            _ContextCode.AppendLine("_DataGridView.RowStateChanged += new DataGridViewRowStateChangedEventHandler(RowStateChanged);");
            _ContextCode.AppendLine("}");

            _ContextCode.AppendLine("private void RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)");
            _ContextCode.AppendLine("{");
            _ContextCode.AppendLine("    e.Row.HeaderCell.Value = string.Format(\"{0}\", e.Row.Index + 1);");
            _ContextCode.AppendLine("}");



            _WriteString = _Context.ToString();

            _CodeString = _ContextCode.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.BackColor = Color.Yellow;
            this.button5.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button6.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.button5.BackColor = Color.Yellow;
            this.button4.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button6.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.button6.BackColor = Color.Yellow;
            this.button4.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button5.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox1.Text = text;
            }
            if (this.textBox1.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox1.Text.Trim());
            }
        }
        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox2.Text = text;
            }
            if (this.textBox2.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox2.Text.Trim());
            }
        }
        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox3.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox3.Text = text;
            }
            if (this.textBox3.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox3.Text.Trim());
            }
        }
        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox4.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox4.Text = text;
            }
            if (this.textBox4.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox4.Text.Trim());
            }
        }
        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox5.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox5.Text = text;
            }
            if (this.textBox5.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox5.Text.Trim());
            }
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox8.Checked)
            {
                this.textBox6.ReadOnly = false;
            }
            else
            {
                this.textBox6.ReadOnly = true;
            }

        }
        private void textBox7_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox7.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox7.Text = text;
            }
            if (this.textBox7.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox7.Text.Trim());
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            this.button9.BackColor = Color.Yellow;
            this.button8.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button7.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            this.button8.BackColor = Color.Yellow;
            this.button9.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button7.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.button7.BackColor = Color.Yellow;
            this.button8.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button9.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void textBox8_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox8.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox8.Text = text;
            }
            if (this.textBox8.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox8.Text.Trim());
            }
        }
        private void textBox9_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox9.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox9.Text = text;
            }
            if (this.textBox9.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox9.Text.Trim());
            }

        }
        private void textBox10_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox10.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox10.Text = text;
            }
            if (this.textBox10.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox10.Text.Trim());
            }
        }
        private void textBox11_DoubleClick(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            //fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox11.Text = string.Format("{0}:{1}", fontDialog.Font.Name.ToString(), fontDialog.Font.Size);//, fontDialog.Font.Style.ToString()
            }
        }
        private void InitCombox()
        {
            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();
            this.comboBox3.Items.Clear();
            foreach (DataGridViewHeaderBorderStyle dataGridViewHeaderBorderStyle in Enum.GetValues(typeof(DataGridViewHeaderBorderStyle)))
            {
                this.comboBox1.Items.Add(dataGridViewHeaderBorderStyle);
                this.comboBox3.Items.Add(dataGridViewHeaderBorderStyle);
            }
            foreach (DataGridViewCellBorderStyle dataGridViewCellBorderStyle in Enum.GetValues(typeof(DataGridViewCellBorderStyle)))
            {
                this.comboBox2.Items.Add(dataGridViewCellBorderStyle);
            }

            this.comboBox1.Items.Insert(0, "--------");
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.Items.Insert(0, "--------");
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.Items.Insert(0, "--------");
            this.comboBox3.SelectedIndex = 0;

        }
        private void button12_Click(object sender, EventArgs e)
        {
            this.button12.BackColor = Color.Yellow;
            this.button10.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button11.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            this.button11.BackColor = Color.Yellow;
            this.button10.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button12.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            this.button10.BackColor = Color.Yellow;
            this.button12.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button11.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void textBox16_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox16.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox16.Text = text;
            }
            if (this.textBox16.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox16.Text.Trim());
            }
        }
        private void textBox14_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox14.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox14.Text = text;
            }
            if (this.textBox14.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox14.Text.Trim());
            }
        }
        private void textBox15_DoubleClick(object sender, EventArgs e)
        {

            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox15.BackColor = colorDialog.Color;
                string text = ColorTranslator.ToHtml(colorDialog.Color);
                this.textBox15.Text = text;
            }
            if (this.textBox15.Text.Trim().Length > 0)
            {
                colorDialog.Color = ColorTranslator.FromHtml(this.textBox15.Text.Trim());
            }
        }
        private void RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void textBox17_DoubleClick(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            //fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox17.Text = string.Format("{0}:{1}", fontDialog.Font.Name.ToString(), fontDialog.Font.Size);//, fontDialog.Font.Style.ToString()
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SetDataGridStyle();
            IniData();
            string _name = DialogUnitity.DialogSaveDvgFile(ConstKeyUnitity.CAPTIONTEXT);
            if (string.IsNullOrEmpty(_name))
            {
                MsgBox.Warning("文件名称不能为空....");
                return;
            }
            if (FileUnitity.FileExist(_name))
            {
                if (MsgBox.Question("文件已经存在,是否替换文件???") == DialogResult.Yes)
                {
                    FileUnitity.StringToNewFile(_name, _CodeString, Encoding.UTF8);
                }
                else
                {
                    MsgBox.Confirm("文件为保存.......");
                }
            }
            else
            {
                FileUnitity.StringToNewFile(_name, _WriteString, Encoding.UTF8);
            }
            this.fastColoredTextBox1.Text = _CodeString;
        }
        private void textBox18_DoubleClick(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            //fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox18.Text = string.Format("{0}:{1}", fontDialog.Font.Name.ToString(), fontDialog.Font.Size);//, fontDialog.Font.Style.ToString()
            }
        }
        #endregion
        #region 恢复样式
        private void button3_Click(object sender, EventArgs e)
        {
            //读取文件
            string _name = DialogUnitity.DialogDvgFile(ConstKeyUnitity.CAPTIONTEXT);
            if (string.IsNullOrEmpty(_name))
            {
                MsgBox.Warning("文件不存在.....");
                return;
            }
            if (!FileUnitity.FileExist(_name))
            {
                MsgBox.Warning("文件不存在.....");
                return;
            }

            string _styleText = FileUnitity.FileToString(_name, Encoding.UTF8);

            SetDGStyle(_styleText, this.dataGridView1);
            IniData();

        }

        private void SetDGStyle(string _Style, DataGridView _DataGridView)
        {
            _Style = _Style.Replace('\r', ' ').Replace('\n', ' ');
            string[] One = _Style.Split(';');
            for (int i = 0; i < One.Length; i++)
            {
                string[] Two = One[i].Split(':');
                if (Two == null) continue;
                if (Two.Length < 2) continue;
                switch (Two[0].Trim())
                {
                    case "RowsDefaultCellStyle.BackColor"://背景颜色
                        _DataGridView.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox1.Text = Two[1].Trim();
                        this.textBox1.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    case "RowHeadersDefaultCellStyle.ForeColor"://字体颜色
                        _DataGridView.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox14.Text = Two[1].Trim();
                        this.textBox14.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    case "RowStateChanged"://显示行号
                        if (Two[1].Trim() == "True")
                        {
                            _DataGridView.RowStateChanged += new DataGridViewRowStateChangedEventHandler(RowStateChanged);
                        }
                        else
                        {
                            _DataGridView.RowStateChanged -= new DataGridViewRowStateChangedEventHandler(RowStateChanged);
                        }
                        break;
                    case "GridColor"://Grid颜色
                        _DataGridView.GridColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox3.Text = Two[1].Trim();
                        this.textBox3.BackColor = ColorTranslator.FromHtml(Two[1]);

                        break;
                    case "ColumnHeadersVisible"://表头可见
                        if (Two[1].Trim() == "True")
                        {
                            _DataGridView.ColumnHeadersVisible = true;
                            this.checkBox1.Checked = true;
                        }
                        else
                        {
                            _DataGridView.ColumnHeadersVisible = false;
                            this.checkBox1.Checked = false;
                        }
                        break;
                    case "RowHeadersVisible"://行头可见
                        if (Two[1].Trim() == "True")
                        {
                            _DataGridView.RowHeadersVisible = true;
                            this.checkBox2.Checked = true;
                        }
                        else
                        {
                            _DataGridView.RowHeadersVisible = false;
                            this.checkBox2.Checked = false;
                        }
                        break;
                    #region AutoSizeColumnsMode
                    case "AutoSizeColumnsMode":
                        switch (Two[1].Trim())
                        {
                            case "AllCells":
                                _DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                this.checkBox5.Checked = false;
                                break;
                            case "AllCellsExceptHeader":
                                _DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                                this.checkBox5.Checked = false;
                                break;
                            case "ColumnHeader":
                                _DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                                this.checkBox5.Checked = false;
                                break;
                            case "DisplayedCells":
                                _DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                                this.checkBox5.Checked = false;
                                break;
                            case "DisplayedCellsExceptHeader":
                                _DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
                                this.checkBox5.Checked = false;
                                break;
                            case "Fill":
                                _DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                this.checkBox5.Checked = true;
                                break;
                            default://None
                                _DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                                this.checkBox5.Checked = false;
                                break;
                        }
                        break;
                    #endregion
                    #region 选中模式
                    case "SelectionMode":
                        switch (Two[1].Trim())
                        {
                            case "CellSelect":
                                _DataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                                this.radioButton2.Checked = true;
                                break;
                            case "ColumnHeaderSelect":
                                _DataGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                                this.radioButton2.Checked = true;
                                break;
                            case "FullColumnSelect":
                                _DataGridView.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                                this.radioButton2.Checked = true;
                                break;
                            case "RowHeaderSelect":
                                _DataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                                this.radioButton2.Checked = true;
                                break;
                            default:
                                _DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                this.radioButton1.Checked = true;
                                break;
                        }
                        break;
                    #endregion
                    case "RowHeadersWidth":
                        _DataGridView.RowHeadersWidth = Convert.ToInt32(Two[1].Trim());
                        this.textBox13.Text = Two[1].Trim();
                        break;
                    case "RowTemplate.Height":
                        _DataGridView.RowTemplate.Height = Convert.ToInt32(Two[1].Trim());
                        this.textBox12.Text = Two[1].Trim();
                        break;
                    #region 单元格对齐方式
                    case "DefaultCellStyle.Alignment":
                        switch (Two[1].Trim())
                        {
                            case "BottomCenter":
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                                Clear1();
                                break;
                            case "BottomLeft":
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                                Clear1();
                                break;
                            case "BottomRight":
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                                Clear1();
                                break;
                            case "MiddleCenter":
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                this.button5.BackColor = Color.Yellow;
                                this.button4.BackColor = Color.FromKnownColor(KnownColor.Control);
                                this.button6.BackColor = Color.FromKnownColor(KnownColor.Control);
                                break;
                            case "MiddleLeft":
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                this.button4.BackColor = Color.Yellow;
                                this.button5.BackColor = Color.FromKnownColor(KnownColor.Control);
                                this.button6.BackColor = Color.FromKnownColor(KnownColor.Control);
                                break;
                            case "MiddleRight":
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                this.button6.BackColor = Color.Yellow;
                                this.button4.BackColor = Color.FromKnownColor(KnownColor.Control);
                                this.button5.BackColor = Color.FromKnownColor(KnownColor.Control);
                                break;
                            case "TopCenter":
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                                Clear1();
                                break;
                            case "TopLeft":
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                                Clear1();
                                break;
                            case "TopRight":
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                                Clear1();
                                break;
                            default:
                                _DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                                Clear1();
                                break;
                        }
                        break;
                    #endregion
                    case "DefaultCellStyle.ForeColor":
                        _DataGridView.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox4.Text = Two[1];
                        this.textBox4.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    #region 列头对齐方式
                    case "ColumnHeadersDefaultCellStyle.Alignment":
                        switch (Two[1].Trim())
                        {
                            case "BottomCenter":
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                                Clear2();
                                break;
                            case "BottomLeft":
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                                Clear2();
                                break;
                            case "BottomRight":
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                                Clear2();
                                break;
                            case "MiddleCenter":
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                this.button8.BackColor = Color.Yellow;
                                this.button7.BackColor = Color.FromKnownColor(KnownColor.Control);
                                this.button9.BackColor = Color.FromKnownColor(KnownColor.Control);
                                break;
                            case "MiddleLeft":
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                this.button9.BackColor = Color.Yellow;
                                this.button7.BackColor = Color.FromKnownColor(KnownColor.Control);
                                this.button8.BackColor = Color.FromKnownColor(KnownColor.Control);
                                break;
                            case "MiddleRight":
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                this.button7.BackColor = Color.Yellow;
                                this.button9.BackColor = Color.FromKnownColor(KnownColor.Control);
                                this.button8.BackColor = Color.FromKnownColor(KnownColor.Control);
                                break;
                            case "TopCenter":
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                                Clear2();
                                break;
                            case "TopLeft":
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                                Clear2();
                                break;
                            case "TopRight":
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                                Clear2();
                                break;
                            default:
                                _DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                                Clear2();
                                break;
                        }
                        break;
                    #endregion
                    case "ColumnHeadersDefaultCellStyle.ForeColor":
                        _DataGridView.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox8.Text = Two[1];
                        this.textBox8.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    case "ColumnHeadersDefaultCellStyle.Font":
                        _DataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(Two[1].Trim(), Convert.ToSingle(Two[2].Trim()));
                        this.textBox11.Text = Two[1].Trim() + ":" + Convert.ToSingle(Two[2].Trim());
                        break;
                    #region 行标题对齐方式
                    case "RowHeadersDefaultCellStyle.Alignment":

                        switch (Two[1].Trim())
                        {//12,11,10
                            case "BottomCenter":
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                                Clear3();
                                break;
                            case "BottomLeft":
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                                Clear3();
                                break;
                            case "BottomRight":
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                                Clear3();
                                break;
                            case "MiddleCenter":
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                this.button11.BackColor = Color.Yellow;
                                this.button12.BackColor = Color.FromKnownColor(KnownColor.Control);
                                this.button10.BackColor = Color.FromKnownColor(KnownColor.Control);
                                break;
                            case "MiddleLeft":
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                this.button12.BackColor = Color.Yellow;
                                this.button11.BackColor = Color.FromKnownColor(KnownColor.Control);
                                this.button10.BackColor = Color.FromKnownColor(KnownColor.Control);
                                break;
                            case "MiddleRight":
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                this.button10.BackColor = Color.Yellow;
                                this.button11.BackColor = Color.FromKnownColor(KnownColor.Control);
                                this.button12.BackColor = Color.FromKnownColor(KnownColor.Control);
                                break;
                            case "TopCenter":
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                                Clear3();
                                break;
                            case "TopLeft":
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                                Clear3();
                                break;
                            case "TopRight":
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                                Clear3();
                                break;
                            default:
                                _DataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                                Clear3();
                                break;
                        }
                        break;
                    #endregion
                    #region 行标题边框类型
                    case "RowHeadersBorderStyle":
                        switch (Two[1].Trim())
                        {
                            case "Custom":
                                _DataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Custom;
                                SetCombox3("Custom");
                                break;
                            case "Raised":
                                _DataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                                SetCombox3("Raised");
                                break;
                            case "Single":
                                _DataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                                SetCombox3("Single");
                                break;
                            case "Sunken":
                                _DataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
                                SetCombox3("Sunken");
                                break;
                            default:
                                _DataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                                SetCombox3("None");
                                break;
                        }
                        break;
                    #endregion
                    #region 单元格边框样式
                    case "CellBorderStyle":
                        switch (Two[1].Trim())
                        {
                            case "Custom":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Custom;
                                SetCombox2("Custom");
                                break;
                            case "Raised":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
                                SetCombox2("Raised");
                                break;
                            case "RaisedHorizontal":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
                                SetCombox2("RaisedHorizontal");
                                break;
                            case "RaisedVertical":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
                                SetCombox2("RaisedVertical");
                                break;
                            case "Single":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                                SetCombox2("Single");
                                break;
                            case "SingleHorizontal":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                                SetCombox2("SingleHorizontal");
                                break;
                            case "SingleVertical":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
                                SetCombox2("SingleVertical");
                                break;
                            case "Sunken":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
                                SetCombox2("Sunken");
                                break;
                            case "SunkenHorizontal":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
                                SetCombox2("SunkenHorizontal");
                                break;
                            case "SunkenVertical":
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
                                SetCombox2("SunkenVertical");
                                break;
                            default:
                                _DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
                                SetCombox2("None");
                                break;
                        }

                        break;
                    #endregion
                    case "ReadOnly":
                        if (Two[1].Trim() == "True")
                        {
                            _DataGridView.ReadOnly = true;
                            this.checkBox3.Checked = true;
                        }
                        else
                        {
                            _DataGridView.ReadOnly = false;
                            this.checkBox3.Checked = false;
                        }
                        break;
                    case "AllowUserToResizeRows"://是否可用改变 行高
                        if (Two[1].Trim() == "True")
                        {
                            _DataGridView.AllowUserToResizeRows = true;
                            this.checkBox6.Checked = false;
                        }
                        else
                        {
                            _DataGridView.AllowUserToResizeRows = false;
                            this.checkBox6.Checked = true;
                        }
                        break;
                    case "AllowUserToResizeColumns"://是否可用改变 列宽

                        if (Two[1].Trim() == "True")
                        {
                            _DataGridView.AllowUserToResizeColumns = true;
                            this.checkBox7.Checked = false;
                        }
                        else
                        {
                            _DataGridView.AllowUserToResizeColumns = false;
                            this.checkBox7.Checked = true;
                        }
                        break;
                    case "AutoGenerateColumns"://禁止自动生成列

                        if (Two[1].Trim() == "True")
                        {
                            _DataGridView.AutoGenerateColumns = true;
                        }
                        else
                        {
                            _DataGridView.AutoGenerateColumns = false;
                        }
                        break;
                    case "RowsDefaultCellStyle.SelectionBackColor":
                        _DataGridView.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox5.Text = Two[1];
                        this.textBox5.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    #region 列头对齐方式
                    case "ColumnHeadersHeightSizeMode":
                        switch (Two[1].Trim())
                        {
                            case "EnableResizing":
                                _DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                                this.checkBox8.Checked = true;
                                break;
                            case "DisableResizing":
                                _DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                                this.checkBox8.Checked = false;
                                break;
                            default:
                                _DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                                this.checkBox8.Checked = false;
                                break;
                        }
                        break;
                    #endregion
                    case "ColumnHeadersHeight":
                        _DataGridView.ColumnHeadersHeight = Convert.ToInt32(Two[1].Trim());
                        this.textBox6.Text = Two[1].Trim();
                        break;
                    case "ColumnHeadersDefaultCellStyle.BackColor":
                        _DataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox7.Text = Two[1];
                        this.textBox7.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    case "ColumnHeadersDefaultCellStyle.SelectionForeColor":
                        _DataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox10.Text = Two[1];
                        this.textBox10.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    case "RowHeadersDefaultCellStyle.SelectionBackColor":
                        _DataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox16.Text = Two[1];
                        this.textBox16.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    case "EnableHeadersVisualStyles":
                        if (Two[1].Trim() == "True")
                        {
                            _DataGridView.EnableHeadersVisualStyles = true;
                        }
                        else
                        {
                            _DataGridView.EnableHeadersVisualStyles = false;
                        }
                        break;
                    case "DefaultCellStyle.Font":
                        _DataGridView.DefaultCellStyle.Font = new Font(Two[1].Trim(), Convert.ToSingle(Two[2].Trim()));
                        this.textBox17.Text = Two[1].Trim() + ":" + Two[2].Trim();
                        break;
                    case "BackgroundColor":
                        _DataGridView.BackgroundColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox1.Text = Two[1];
                        this.textBox1.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    case "RowHeadersDefaultCellStyle.BackColor":
                        _DataGridView.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(Two[1]);
                        this.textBox15.Text = Two[1];
                        this.textBox15.BackColor = ColorTranslator.FromHtml(Two[1]);
                        break;
                    case "RowHeadersDefaultCellStyle.Font":
                        _DataGridView.RowHeadersDefaultCellStyle.Font = new Font(Two[1].Trim(), Convert.ToSingle(Two[2].Trim()));
                        this.textBox18.Text = Two[1] + ":" + Two[2];
                        break;
                    case "MultiSelect":
                        if (Two[1].Trim() == "True")
                        {
                            _DataGridView.MultiSelect = true;
                            this.checkBox4.Checked = true;
                        }
                        else
                        {
                            _DataGridView.MultiSelect = false;
                            this.checkBox4.Checked = false;
                        }
                        break;
                    default:
                        break;
                }
                Two = null;
            }




        }
        private void Clear1()
        {
            this.button5.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button4.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button6.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
        private void Clear2()
        {
            this.button7.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button8.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button9.BackColor = Color.FromKnownColor(KnownColor.Control);

        }
        private void Clear3()
        {
            this.button10.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button11.BackColor = Color.FromKnownColor(KnownColor.Control);
            this.button12.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void SetCombox3(string _str)
        {
            for (int i = 0; i < this.comboBox3.Items.Count; i++)
            {
                if (this.comboBox3.Items[i].ToString() == _str)
                {
                    this.comboBox3.SelectedIndex = i;
                    break;
                }

            }
        }
        private void SetCombox2(string _str)
        {
            for (int i = 0; i < this.comboBox2.Items.Count; i++)
            {
                if (this.comboBox2.Items[i].ToString() == _str)
                {
                    this.comboBox2.SelectedIndex = i;
                    break;
                }
            }
        }
        private void SetCombox1(string _str)
        {
            for (int i = 0; i < this.comboBox1.Items.Count; i++)
            {
                if (this.comboBox1.Items[i].ToString() == _str)
                {
                    this.comboBox1.SelectedIndex = i;
                    break;
                }
            }
        }
        #endregion

        private void button13_Click(object sender, EventArgs e)
        {
             SetDataGridStyle();
             IniData();

             this.fastColoredTextBox1.Text = _CodeString;
            
        }
    }



     class Student
    {
        public int StuId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Gender { get; set; }

    }



}
