namespace MyPorgamManage
{
    partial class FunShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunShow));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.advTree1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.fastColoredTextBox1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1087, 623);
            this.splitContainerControl1.SplitterPosition = 281;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.GridLinesColor = System.Drawing.Color.Blue;
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeSpacing = 12;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(1087, 281);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 2;
            this.advTree1.Text = "advTree1";
            this.advTree1.NodeMouseUp += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree1_NodeMouseUp);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(35, 22);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.fastColoredTextBox1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fastColoredTextBox1.CharHeight = 22;
            this.fastColoredTextBox1.CharWidth = 12;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBox1.Font = new System.Drawing.Font("Courier New", 12F);
            this.fastColoredTextBox1.ForeColor = System.Drawing.Color.Blue;
            this.fastColoredTextBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fastColoredTextBox1.LeftBracket = '(';
            this.fastColoredTextBox1.LeftBracket2 = '{';
            this.fastColoredTextBox1.LineNumberColor = System.Drawing.Color.Red;
            this.fastColoredTextBox1.Location = new System.Drawing.Point(0, 0);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.ReadOnly = true;
            this.fastColoredTextBox1.RightBracket = ')';
            this.fastColoredTextBox1.RightBracket2 = '}';
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox1.ServiceColors")));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(1087, 334);
            this.fastColoredTextBox1.TabIndex = 1;
            this.fastColoredTextBox1.Zoom = 100;
            // 
            // FunShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 623);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FunShow";
            this.Text = "FunShow";
            this.Load += new System.EventHandler(this.FunShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        //private FastColoredTextBoxNS.Ruler ruler1;
    }
}