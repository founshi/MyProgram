namespace MyPorgamManage.Frm
{
    partial class LogInFrm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(179, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "登录用户";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "登录密码";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(179, 118);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(273, 29);
            this.textBox2.TabIndex = 3;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(344, 158);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "记住用户";
            this.checkEdit1.Size = new System.Drawing.Size(108, 28);
            this.checkEdit1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(213, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "用户不存在";
            this.label3.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(65, 194);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(108, 40);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "登  录";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(344, 194);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(108, 40);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "取  消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(65, 157);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit2.Properties.Appearance.Options.UseFont = true;
            this.checkEdit2.Properties.Caption = "记住用户";
            this.checkEdit2.Size = new System.Drawing.Size(108, 28);
            this.checkEdit2.TabIndex = 8;
            // 
            // LogInFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(554, 286);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogInFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.Load += new System.EventHandler(this.LogInFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
    }
}