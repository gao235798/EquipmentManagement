namespace EquipmentManagement.page.production.BeginProduction
{
    partial class ProcessVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessVideo));
            this.ProcessVideoPlay = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessVideoPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessVideoPlay
            // 
            this.ProcessVideoPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessVideoPlay.Enabled = true;
            this.ProcessVideoPlay.Location = new System.Drawing.Point(0, 0);
            this.ProcessVideoPlay.Name = "ProcessVideoPlay";
            this.ProcessVideoPlay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ProcessVideoPlay.OcxState")));
            this.ProcessVideoPlay.Size = new System.Drawing.Size(849, 671);
            this.ProcessVideoPlay.TabIndex = 0;
            // 
            // ProcessVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 671);
            this.Controls.Add(this.ProcessVideoPlay);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ProcessVideo.IconOptions.LargeImage")));
            this.Name = "ProcessVideo";
            this.Text = "工艺视频";
            this.Load += new System.EventHandler(this.ProcessVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessVideoPlay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer ProcessVideoPlay;
    }
}