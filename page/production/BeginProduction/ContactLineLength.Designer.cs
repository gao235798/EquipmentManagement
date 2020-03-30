namespace EquipmentManagement.page.production.BeginProduction
{
    partial class ContactLineLength
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.secach = new System.Windows.Forms.Timer(this.components);
            this.icidT = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.icidT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(191, 160);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(168, 28);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "呼叫线长等待指示";
            // 
            // secach
            // 
            this.secach.Tick += new System.EventHandler(this.secach_Tick);
            // 
            // icidT
            // 
            this.icidT.Location = new System.Drawing.Point(132, 226);
            this.icidT.Name = "icidT";
            this.icidT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icidT.Properties.Appearance.Options.UseFont = true;
            this.icidT.Properties.PasswordChar = '*';
            this.icidT.Size = new System.Drawing.Size(284, 30);
            this.icidT.TabIndex = 1;
            this.icidT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.icidT_KeyDown);
            // 
            // ContactLineLength
            // 
            this.Appearance.BackColor = System.Drawing.Color.Red;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 399);
            this.Controls.Add(this.icidT);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContactLineLength";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContactLineLength";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContactLineLength_FormClosed);
            this.Load += new System.EventHandler(this.ContactLineLength_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icidT.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Timer secach;
        private DevExpress.XtraEditors.TextEdit icidT;
    }
}