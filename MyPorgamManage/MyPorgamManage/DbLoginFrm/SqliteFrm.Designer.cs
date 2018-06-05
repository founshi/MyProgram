namespace MyPorgamManage.DbLoginFrm
{
    partial class SqliteFrm
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(41, 208);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(478, 138);
            this.textBox2.TabIndex = 26;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Blue;
            this.checkBox1.Location = new System.Drawing.Point(41, 178);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 24);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "自写连接字符串";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(411, 380);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(108, 40);
            this.simpleButton3.TabIndex = 30;
            this.simpleButton3.Text = "取 消";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(215, 380);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(108, 40);
            this.simpleButton2.TabIndex = 29;
            this.simpleButton2.Text = "确 定";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(41, 380);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(108, 40);
            this.simpleButton1.TabIndex = 28;
            this.simpleButton1.Text = "测试连接";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(41, 67);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(478, 105);
            this.textBox1.TabIndex = 32;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new System.Drawing.Point(41, 21);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(171, 40);
            this.simpleButton4.TabIndex = 33;
            this.simpleButton4.Text = "请选数据库文件";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // SqliteFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(564, 490);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqliteFrm";
            this.Text = "SqliteFrm";
            this.Load += new System.EventHandler(this.SqliteFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
    }
}