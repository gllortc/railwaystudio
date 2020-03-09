namespace Rwm.Studio.Plugins.Control.Views
{
   partial class AccesoryConnectionFindView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccesoryConnectionFindView));
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.grpDigital = new DevExpress.XtraEditors.GroupControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.lblAddress = new DevExpress.XtraEditors.LabelControl();
         this.txtAddress = new DevExpress.XtraEditors.SpinEdit();
         this.lblOutputs = new DevExpress.XtraEditors.LabelControl();
         this.txtSwitchTime = new DevExpress.XtraEditors.SpinEdit();
         this.grdDecoders = new DevExpress.XtraGrid.GridControl();
         this.grdDecodersView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.grdOutputs = new DevExpress.XtraGrid.GridControl();
         this.grdOutputsView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.grpDigital)).BeginInit();
         this.grpDigital.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSwitchTime.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDecoders)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDecodersView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdOutputs)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdOutputsView)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(517, 394);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 0;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Enabled = false;
         this.cmdOK.Location = new System.Drawing.Point(436, 394);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 1;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "drive_lightning_16.png");
         this.imageList.Images.SetKeyName(1, "drive_light_16.png");
         this.imageList.Images.SetKeyName(2, "arrow_right_16.png");
         this.imageList.Images.SetKeyName(3, "arrow_right_occupied_16.png");
         this.imageList.Images.SetKeyName(4, "folder_16.png");
         // 
         // grpDigital
         // 
         this.grpDigital.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpDigital.Controls.Add(this.labelControl1);
         this.grpDigital.Controls.Add(this.lblAddress);
         this.grpDigital.Controls.Add(this.txtAddress);
         this.grpDigital.Controls.Add(this.lblOutputs);
         this.grpDigital.Controls.Add(this.txtSwitchTime);
         this.grpDigital.Enabled = false;
         this.grpDigital.Location = new System.Drawing.Point(187, 319);
         this.grpDigital.Name = "grpDigital";
         this.grpDigital.Padding = new System.Windows.Forms.Padding(10);
         this.grpDigital.Size = new System.Drawing.Size(405, 69);
         this.grpDigital.TabIndex = 216;
         this.grpDigital.Text = "Digital properties";
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(297, 36);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(25, 13);
         this.labelControl1.TabIndex = 14;
         this.labelControl1.Text = "mSec";
         // 
         // lblAddress
         // 
         this.lblAddress.Location = new System.Drawing.Point(15, 36);
         this.lblAddress.Name = "lblAddress";
         this.lblAddress.Size = new System.Drawing.Size(39, 13);
         this.lblAddress.TabIndex = 12;
         this.lblAddress.Text = "Address";
         // 
         // txtAddress
         // 
         this.txtAddress.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtAddress.Location = new System.Drawing.Point(60, 33);
         this.txtAddress.Name = "txtAddress";
         this.txtAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtAddress.Properties.IsFloatValue = false;
         this.txtAddress.Properties.Mask.EditMask = "N00";
         this.txtAddress.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.txtAddress.Size = new System.Drawing.Size(71, 20);
         this.txtAddress.TabIndex = 13;
         // 
         // lblOutputs
         // 
         this.lblOutputs.Location = new System.Drawing.Point(160, 36);
         this.lblOutputs.Name = "lblOutputs";
         this.lblOutputs.Size = new System.Drawing.Size(54, 13);
         this.lblOutputs.TabIndex = 6;
         this.lblOutputs.Text = "Switch time";
         // 
         // txtSwitchTime
         // 
         this.txtSwitchTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtSwitchTime.Location = new System.Drawing.Point(220, 33);
         this.txtSwitchTime.Name = "txtSwitchTime";
         this.txtSwitchTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtSwitchTime.Properties.IsFloatValue = false;
         this.txtSwitchTime.Properties.Mask.EditMask = "N00";
         this.txtSwitchTime.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.txtSwitchTime.Size = new System.Drawing.Size(71, 20);
         this.txtSwitchTime.TabIndex = 7;
         // 
         // grdDecoders
         // 
         this.grdDecoders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.grdDecoders.Location = new System.Drawing.Point(12, 12);
         this.grdDecoders.MainView = this.grdDecodersView;
         this.grdDecoders.Name = "grdDecoders";
         this.grdDecoders.Size = new System.Drawing.Size(169, 376);
         this.grdDecoders.TabIndex = 217;
         this.grdDecoders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDecodersView});
         // 
         // grdDecodersView
         // 
         this.grdDecodersView.GridControl = this.grdDecoders;
         this.grdDecodersView.Name = "grdDecodersView";
         this.grdDecodersView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdDecodersView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdDecodersView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
         this.grdDecodersView.OptionsBehavior.AllowPartialGroups = DevExpress.Utils.DefaultBoolean.False;
         this.grdDecodersView.OptionsBehavior.Editable = false;
         this.grdDecodersView.OptionsBehavior.ReadOnly = true;
         this.grdDecodersView.OptionsCustomization.AllowColumnMoving = false;
         this.grdDecodersView.OptionsCustomization.AllowColumnResizing = false;
         this.grdDecodersView.OptionsCustomization.AllowFilter = false;
         this.grdDecodersView.OptionsCustomization.AllowGroup = false;
         this.grdDecodersView.OptionsCustomization.AllowSort = false;
         this.grdDecodersView.OptionsDetail.AllowZoomDetail = false;
         this.grdDecodersView.OptionsDetail.EnableMasterViewMode = false;
         this.grdDecodersView.OptionsDetail.SmartDetailExpand = false;
         this.grdDecodersView.OptionsFilter.AllowFilterEditor = false;
         this.grdDecodersView.OptionsMenu.EnableColumnMenu = false;
         this.grdDecodersView.OptionsMenu.EnableFooterMenu = false;
         this.grdDecodersView.OptionsMenu.EnableGroupPanelMenu = false;
         this.grdDecodersView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdDecodersView.OptionsSelection.EnableAppearanceHideSelection = false;
         this.grdDecodersView.OptionsSelection.UseIndicatorForSelection = false;
         this.grdDecodersView.OptionsView.ShowGroupExpandCollapseButtons = false;
         this.grdDecodersView.OptionsView.ShowGroupPanel = false;
         this.grdDecodersView.OptionsView.ShowIndicator = false;
         this.grdDecodersView.OptionsView.ShowViewCaption = true;
         this.grdDecodersView.ViewCaption = "Decoders";
         this.grdDecodersView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GrdDecodersView_RowClick);
         // 
         // grdOutputs
         // 
         this.grdOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grdOutputs.Location = new System.Drawing.Point(187, 12);
         this.grdOutputs.MainView = this.grdOutputsView;
         this.grdOutputs.Name = "grdOutputs";
         this.grdOutputs.Size = new System.Drawing.Size(405, 301);
         this.grdOutputs.TabIndex = 218;
         this.grdOutputs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdOutputsView});
         // 
         // grdOutputsView
         // 
         this.grdOutputsView.GridControl = this.grdOutputs;
         this.grdOutputsView.Name = "grdOutputsView";
         this.grdOutputsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdOutputsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdOutputsView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
         this.grdOutputsView.OptionsBehavior.Editable = false;
         this.grdOutputsView.OptionsBehavior.ReadOnly = true;
         this.grdOutputsView.OptionsCustomization.AllowColumnMoving = false;
         this.grdOutputsView.OptionsCustomization.AllowColumnResizing = false;
         this.grdOutputsView.OptionsCustomization.AllowFilter = false;
         this.grdOutputsView.OptionsCustomization.AllowGroup = false;
         this.grdOutputsView.OptionsCustomization.AllowSort = false;
         this.grdOutputsView.OptionsFilter.AllowFilterEditor = false;
         this.grdOutputsView.OptionsMenu.EnableColumnMenu = false;
         this.grdOutputsView.OptionsMenu.EnableFooterMenu = false;
         this.grdOutputsView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdOutputsView.OptionsSelection.EnableAppearanceHideSelection = false;
         this.grdOutputsView.OptionsView.ShowGroupPanel = false;
         this.grdOutputsView.OptionsView.ShowIndicator = false;
         this.grdOutputsView.OptionsView.ShowViewCaption = true;
         this.grdOutputsView.ViewCaption = "No decoder selected";
         this.grdOutputsView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrdOutputsView_FocusedRowChanged);
         // 
         // AccesoryConnectionFindView
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(604, 429);
         this.Controls.Add(this.grdOutputs);
         this.Controls.Add(this.grdDecoders);
         this.Controls.Add(this.grpDigital);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AccesoryConnectionFindView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Connect element to accessory decoder";
         ((System.ComponentModel.ISupportInitialize)(this.grpDigital)).EndInit();
         this.grpDigital.ResumeLayout(false);
         this.grpDigital.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSwitchTime.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDecoders)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdDecodersView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdOutputs)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdOutputsView)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraEditors.GroupControl grpDigital;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.LabelControl lblAddress;
      private DevExpress.XtraEditors.SpinEdit txtAddress;
      private DevExpress.XtraEditors.LabelControl lblOutputs;
      private DevExpress.XtraEditors.SpinEdit txtSwitchTime;
        private DevExpress.XtraGrid.GridControl grdDecoders;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDecodersView;
        private DevExpress.XtraGrid.GridControl grdOutputs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdOutputsView;
    }
}