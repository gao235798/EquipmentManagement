namespace EquipmentManagement.page.production.错误选择页面
{
    partial class workErr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(workErr));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.write = new DevExpress.XtraEditors.SimpleButton();
            this.errControl = new DevExpress.XtraGrid.GridControl();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.错误id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.错误名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.selectErrControl = new DevExpress.XtraGrid.GridControl();
            this.cardView2 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectErrControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.write);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(973, 80);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(827, 22);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(99, 39);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "取消";
            // 
            // write
            // 
            this.write.Location = new System.Drawing.Point(701, 22);
            this.write.Name = "write";
            this.write.Size = new System.Drawing.Size(99, 39);
            this.write.TabIndex = 0;
            this.write.Text = "写入";
            this.write.Click += new System.EventHandler(this.write_Click);
            // 
            // errControl
            // 
            this.errControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errControl.Location = new System.Drawing.Point(0, 188);
            this.errControl.MainView = this.cardView1;
            this.errControl.Name = "errControl";
            this.errControl.Size = new System.Drawing.Size(973, 594);
            this.errControl.TabIndex = 1;
            this.errControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1});
            this.errControl.Click += new System.EventHandler(this.errControl_Click);
            // 
            // cardView1
            // 
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.错误id,
            this.错误名称,
            this.gridColumn3});
            this.cardView1.GridControl = this.errControl;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsBehavior.AllowExpandCollapse = false;
            this.cardView1.OptionsFilter.ShowCustomFunctions = DevExpress.Utils.DefaultBoolean.False;
            this.cardView1.OptionsSelection.MultiSelect = true;
            this.cardView1.OptionsView.ShowQuickCustomizeButton = false;
            // 
            // 错误id
            // 
            this.错误id.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.错误id.AppearanceCell.Options.UseFont = true;
            this.错误id.AppearanceCell.Options.UseTextOptions = true;
            this.错误id.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.错误id.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.错误id.AppearanceHeader.Options.UseFont = true;
            this.错误id.Caption = "错误id";
            this.错误id.FieldName = "err_id";
            this.错误id.Name = "错误id";
            this.错误id.OptionsColumn.AllowEdit = false;
            this.错误id.Visible = true;
            this.错误id.VisibleIndex = 0;
            // 
            // 错误名称
            // 
            this.错误名称.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.错误名称.AppearanceCell.Options.UseFont = true;
            this.错误名称.AppearanceCell.Options.UseTextOptions = true;
            this.错误名称.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.错误名称.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.错误名称.AppearanceHeader.Options.UseFont = true;
            this.错误名称.Caption = "错误名称";
            this.错误名称.FieldName = "err_name";
            this.错误名称.Name = "错误名称";
            this.错误名称.OptionsColumn.AllowEdit = false;
            this.错误名称.Visible = true;
            this.错误名称.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "车型";
            this.gridColumn3.FieldName = "model";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // selectErrControl
            // 
            this.selectErrControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectErrControl.Location = new System.Drawing.Point(0, 80);
            this.selectErrControl.MainView = this.cardView2;
            this.selectErrControl.Name = "selectErrControl";
            this.selectErrControl.Size = new System.Drawing.Size(973, 108);
            this.selectErrControl.TabIndex = 2;
            this.selectErrControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView2});
            this.selectErrControl.Click += new System.EventHandler(this.selectErrControl_Click);
            // 
            // cardView2
            // 
            this.cardView2.CardWidth = 150;
            this.cardView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4});
            this.cardView2.GridControl = this.selectErrControl;
            this.cardView2.Name = "cardView2";
            this.cardView2.OptionsBehavior.ReadOnly = true;
            this.cardView2.OptionsView.ShowCardExpandButton = false;
            this.cardView2.OptionsView.ShowQuickCustomizeButton = false;
            this.cardView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "错误id";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "错误名称";
            this.gridColumn2.FieldName = "err_name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "车型";
            this.gridColumn4.FieldName = "model";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // workErr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 782);
            this.Controls.Add(this.errControl);
            this.Controls.Add(this.selectErrControl);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("workErr.IconOptions.LargeImage")));
            this.Name = "workErr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "错误记录页面";
            this.Load += new System.EventHandler(this.workErr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectErrControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl errControl;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn 错误id;
        private DevExpress.XtraGrid.Columns.GridColumn 错误名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl selectErrControl;
        private DevExpress.XtraGrid.Views.Card.CardView cardView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton write;
    }
}