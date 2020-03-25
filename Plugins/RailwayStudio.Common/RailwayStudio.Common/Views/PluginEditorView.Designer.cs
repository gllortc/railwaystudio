namespace RailwayStudio.Common.Views
{
   partial class PluginEditorView
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
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.lblModule = new DevExpress.XtraEditors.LabelControl();
         this.picIcon = new System.Windows.Forms.PictureBox();
         this.grdModules = new DevExpress.XtraGrid.GridControl();
         this.grdModulesView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModules)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModulesView)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(427, 280);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 0;
         this.cmdCancel.Text = "Cancelar";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(346, 280);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 1;
         this.cmdOK.Text = "Install";
         this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
         // 
         // lblName
         // 
         this.lblName.Appearance.FontSizeDelta = 2;
         this.lblName.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
         this.lblName.Location = new System.Drawing.Point(53, 20);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(40, 17);
         this.lblName.TabIndex = 2;
         this.lblName.Text = "Name";
         // 
         // lblModule
         // 
         this.lblModule.Location = new System.Drawing.Point(10, 60);
         this.lblModule.Name = "lblModule";
         this.lblModule.Size = new System.Drawing.Size(83, 13);
         this.lblModule.TabIndex = 7;
         this.lblModule.Text = "Included modules";
         // 
         // picIcon
         // 
         this.picIcon.ErrorImage = null;
         this.picIcon.InitialImage = null;
         this.picIcon.Location = new System.Drawing.Point(12, 12);
         this.picIcon.Name = "picIcon";
         this.picIcon.Size = new System.Drawing.Size(32, 32);
         this.picIcon.TabIndex = 11;
         this.picIcon.TabStop = false;
         // 
         // grdModules
         // 
         this.grdModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grdModules.Location = new System.Drawing.Point(12, 79);
         this.grdModules.MainView = this.grdModulesView;
         this.grdModules.Name = "grdModules";
         this.grdModules.Size = new System.Drawing.Size(490, 195);
         this.grdModules.TabIndex = 10;
         this.grdModules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdModulesView});
         // 
         // grdModulesView
         // 
         this.grdModulesView.GridControl = this.grdModules;
         this.grdModulesView.Name = "grdModulesView";
         this.grdModulesView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdModulesView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdModulesView.OptionsBehavior.Editable = false;
         this.grdModulesView.OptionsBehavior.ReadOnly = true;
         this.grdModulesView.OptionsCustomization.AllowColumnMoving = false;
         this.grdModulesView.OptionsCustomization.AllowGroup = false;
         this.grdModulesView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdModulesView.OptionsView.ShowGroupPanel = false;
         this.grdModulesView.OptionsView.ShowIndicator = false;
         this.grdModulesView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdModulesView_CustomDrawCell);
         // 
         // FrmPluginEditor
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(514, 315);
         this.Controls.Add(this.lblModule);
         this.Controls.Add(this.grdModules);
         this.Controls.Add(this.picIcon);
         this.Controls.Add(this.lblName);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmPluginEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Plugin properties";
         ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModules)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdModulesView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.LabelControl lblModule;
      private DevExpress.XtraGrid.GridControl grdModules;
      private DevExpress.XtraGrid.Views.Grid.GridView grdModulesView;
      private System.Windows.Forms.PictureBox picIcon;
   }
}