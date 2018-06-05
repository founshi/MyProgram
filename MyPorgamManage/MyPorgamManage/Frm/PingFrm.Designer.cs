namespace MyPorgamManage
{
    partial class PingFrm
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Magenta;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseBorderColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(1282, 764);
            this.simpleButton1.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(108, 40);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "启动Ping";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // PingFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1392, 816);
            this.Controls.Add(this.simpleButton1);
            this.Name = "PingFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XtraForm1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PingFrm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}