namespace EquipmentManagement.page.production.BeginProduction
{
    partial class ScrewErr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScrewErr));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.misinformation = new DevExpress.XtraEditors.SimpleButton();
            this.finish = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(73, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(291, 46);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "浮牙";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(125, 92);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(216, 89);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "1.继续操作请按继续按钮\n2.错误上报请按误报\n3.终止操作请按结束按钮";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(27, 221);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(90, 35);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "继续";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // misinformation
            // 
            this.misinformation.Location = new System.Drawing.Point(183, 221);
            this.misinformation.Name = "misinformation";
            this.misinformation.Size = new System.Drawing.Size(90, 35);
            this.misinformation.TabIndex = 2;
            this.misinformation.Text = "误报";
            this.misinformation.Click += new System.EventHandler(this.misinformation_Click);
            // 
            // finish
            // 
            this.finish.Location = new System.Drawing.Point(350, 221);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(90, 35);
            this.finish.TabIndex = 2;
            this.finish.Text = "结束";
            this.finish.Click += new System.EventHandler(this.finish_Click);
            // 
            // ScrewErr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 311);
            this.Controls.Add(this.finish);
            this.Controls.Add(this.misinformation);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ScrewErr.IconOptions.LargeImage")));
            this.Name = "ScrewErr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "螺丝故障";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton misinformation;
        private DevExpress.XtraEditors.SimpleButton finish;
    }
}