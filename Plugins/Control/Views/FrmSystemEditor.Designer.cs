namespace Rwm.Studio.Plugins.Control.Views
{
   partial class FrmSystemEditor
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
         this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
         this.tabSystemGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.grpDriver = new DevExpress.XtraEditors.GroupControl();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
         this.lblDescription = new DevExpress.XtraEditors.LabelControl();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.tabSystemSetup = new DevExpress.XtraTab.XtraTabPage();
         this.grdSettings = new DevExpress.XtraGrid.GridControl();
         this.grdSettingsView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.cmdSetup = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
         this.xtraTabControl1.SuspendLayout();
         this.tabSystemGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grpDriver)).BeginInit();
         this.grpDriver.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
         this.groupControl1.SuspendLayout();
         this.tabSystemSetup.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdSettings)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSettingsView)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.Location = new System.Drawing.Point(292, 323);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 0;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(211, 323);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 1;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
         // 
         // xtraTabControl1
         // 
         this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.xtraTabControl1.Location = new System.Drawing.Point(12, 12);
         this.xtraTabControl1.Name = "xtraTabControl1";
         this.xtraTabControl1.SelectedTabPage = this.tabSystemGeneral;
         this.xtraTabControl1.Size = new System.Drawing.Size(355, 305);
         this.xtraTabControl1.TabIndex = 2;
         this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabSystemGeneral,
            this.tabSystemSetup});
         // 
         // tabSystemGeneral
         // 
         this.tabSystemGeneral.Controls.Add(this.grpDriver);
         this.tabSystemGeneral.Controls.Add(this.groupControl1);
         this.tabSystemGeneral.Name = "tabSystemGeneral";
         this.tabSystemGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabSystemGeneral.Size = new System.Drawing.Size(349, 277);
         this.tabSystemGeneral.Text = "General";
         // 
         // grpDriver
         // 
         this.grpDriver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpDriver.Controls.Add(this.labelControl5);
         this.grpDriver.Controls.Add(this.labelControl6);
         this.grpDriver.Controls.Add(this.labelControl3);
         this.grpDriver.Controls.Add(this.labelControl4);
         this.grpDriver.Controls.Add(this.labelControl2);
         this.grpDriver.Controls.Add(this.labelControl1);
         this.grpDriver.Location = new System.Drawing.Point(13, 108);
         this.grpDriver.Name = "grpDriver";
         this.grpDriver.Padding = new System.Windows.Forms.Padding(10);
         this.grpDriver.Size = new System.Drawing.Size(323, 100);
         this.grpDriver.TabIndex = 1;
         this.grpDriver.Text = "Driver";
         // 
         // labelControl5
         // 
         this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelControl5.AutoEllipsis = true;
         this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
         this.labelControl5.Location = new System.Drawing.Point(58, 72);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(250, 13);
         this.labelControl5.TabIndex = 5;
         this.labelControl5.Text = "<driver version>";
         // 
         // labelControl6
         // 
         this.labelControl6.Location = new System.Drawing.Point(15, 72);
         this.labelControl6.Name = "labelControl6";
         this.labelControl6.Size = new System.Drawing.Size(35, 13);
         this.labelControl6.TabIndex = 4;
         this.labelControl6.Text = "Version";
         // 
         // labelControl3
         // 
         this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelControl3.AutoEllipsis = true;
         this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
         this.labelControl3.Location = new System.Drawing.Point(58, 52);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(250, 13);
         this.labelControl3.TabIndex = 3;
         this.labelControl3.Text = "<driver class name>";
         // 
         // labelControl4
         // 
         this.labelControl4.Location = new System.Drawing.Point(15, 52);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(25, 13);
         this.labelControl4.TabIndex = 2;
         this.labelControl4.Text = "Class";
         // 
         // labelControl2
         // 
         this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelControl2.AutoEllipsis = true;
         this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
         this.labelControl2.Location = new System.Drawing.Point(58, 33);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(250, 13);
         this.labelControl2.TabIndex = 1;
         this.labelControl2.Text = "<file and path>";
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(15, 33);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(16, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "File";
         // 
         // groupControl1
         // 
         this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupControl1.Controls.Add(this.lblDescription);
         this.groupControl1.Controls.Add(this.lblName);
         this.groupControl1.Location = new System.Drawing.Point(13, 13);
         this.groupControl1.Name = "groupControl1";
         this.groupControl1.Padding = new System.Windows.Forms.Padding(10);
         this.groupControl1.ShowCaption = false;
         this.groupControl1.Size = new System.Drawing.Size(323, 89);
         this.groupControl1.TabIndex = 0;
         this.groupControl1.Text = "groupControl1";
         // 
         // lblDescription
         // 
         this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.lblDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
         this.lblDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.lblDescription.Location = new System.Drawing.Point(15, 38);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(293, 36);
         this.lblDescription.TabIndex = 1;
         this.lblDescription.Text = "<description>";
         // 
         // lblName
         // 
         this.lblName.Appearance.FontSizeDelta = 2;
         this.lblName.Location = new System.Drawing.Point(15, 15);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(105, 17);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "<System Name>";
         // 
         // tabSystemSetup
         // 
         this.tabSystemSetup.Controls.Add(this.grdSettings);
         this.tabSystemSetup.Controls.Add(this.cmdSetup);
         this.tabSystemSetup.Name = "tabSystemSetup";
         this.tabSystemSetup.Padding = new System.Windows.Forms.Padding(10);
         this.tabSystemSetup.Size = new System.Drawing.Size(349, 277);
         this.tabSystemSetup.Text = "Configuration";
         // 
         // grdSettings
         // 
         this.grdSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grdSettings.Location = new System.Drawing.Point(13, 13);
         this.grdSettings.MainView = this.grdSettingsView;
         this.grdSettings.Name = "grdSettings";
         this.grdSettings.Size = new System.Drawing.Size(323, 222);
         this.grdSettings.TabIndex = 1;
         this.grdSettings.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSettingsView});
         // 
         // grdSettingsView
         // 
         this.grdSettingsView.GridControl = this.grdSettings;
         this.grdSettingsView.Name = "grdSettingsView";
         // 
         // cmdSetup
         // 
         this.cmdSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.cmdSetup.Location = new System.Drawing.Point(13, 241);
         this.cmdSetup.Name = "cmdSetup";
         this.cmdSetup.Size = new System.Drawing.Size(75, 23);
         this.cmdSetup.TabIndex = 0;
         this.cmdSetup.Text = "Configure";
         // 
         // FrmSystemEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(379, 358);
         this.Controls.Add(this.xtraTabControl1);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmSystemEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Digital System Properties";
         ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
         this.xtraTabControl1.ResumeLayout(false);
         this.tabSystemGeneral.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grpDriver)).EndInit();
         this.grpDriver.ResumeLayout(false);
         this.grpDriver.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
         this.groupControl1.ResumeLayout(false);
         this.groupControl1.PerformLayout();
         this.tabSystemSetup.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdSettings)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSettingsView)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
      private DevExpress.XtraTab.XtraTabPage tabSystemGeneral;
      private DevExpress.XtraEditors.GroupControl groupControl1;
      private DevExpress.XtraEditors.LabelControl lblDescription;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.GroupControl grpDriver;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.LabelControl labelControl6;
      private DevExpress.XtraTab.XtraTabPage tabSystemSetup;
      private DevExpress.XtraGrid.GridControl grdSettings;
      private DevExpress.XtraGrid.Views.Grid.GridView grdSettingsView;
      private DevExpress.XtraEditors.SimpleButton cmdSetup;

   }
}