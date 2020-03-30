namespace EquipmentManagement.page.production.BeginProduction
{
    partial class PdfView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfView));
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.SuspendLayout();
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.AutoSize = true;
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.DocumentFilePath = "G:\\pc项目\\设备上位机\\开发文档\\B1907060002YL-B08九芯电机线LN-F0910AM-019 910AM X3（控制器端） Model (1)(" +
    "1).pdf";
            this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPaneWidth = 198;
            this.pdfViewer1.Size = new System.Drawing.Size(993, 844);
            this.pdfViewer1.TabIndex = 0;
            // 
            // PdfView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 844);
            this.Controls.Add(this.pdfViewer1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("PdfView.IconOptions.LargeImage")));
            this.Name = "PdfView";
            this.Text = "工艺pdf";
            this.Load += new System.EventHandler(this.PdfView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
    }
}