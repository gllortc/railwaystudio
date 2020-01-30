namespace Rwm.Studio.Views
{
   partial class FrmPluginEditorOld
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
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.tabPlugin = new DevExpress.XtraTab.XtraTabControl();
         this.tabPluginGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.lblID = new DevExpress.XtraEditors.LabelControl();
         this.txtID = new DevExpress.XtraEditors.TextEdit();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.lblFile = new DevExpress.XtraEditors.LabelControl();
         this.txtFile = new DevExpress.XtraEditors.ButtonEdit();
         this.cboModule = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.lblModule = new DevExpress.XtraEditors.LabelControl();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.tabPlugin)).BeginInit();
         this.tabPlugin.SuspendLayout();
         this.tabPluginGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(278, 354);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 0;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(197, 354);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 1;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
         // 
         // tabPlugin
         // 
         this.tabPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabPlugin.Location = new System.Drawing.Point(12, 12);
         this.tabPlugin.Name = "tabPlugin";
         this.tabPlugin.SelectedTabPage = this.tabPluginGeneral;
         this.tabPlugin.Size = new System.Drawing.Size(341, 336);
         this.tabPlugin.TabIndex = 2;
         this.tabPlugin.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPluginGeneral});
         // 
         // tabPluginGeneral
         // 
         this.tabPluginGeneral.Controls.Add(this.lblModule);
         this.tabPluginGeneral.Controls.Add(this.cboModule);
         this.tabPluginGeneral.Controls.Add(this.txtFile);
         this.tabPluginGeneral.Controls.Add(this.lblFile);
         this.tabPluginGeneral.Controls.Add(this.txtName);
         this.tabPluginGeneral.Controls.Add(this.lblName);
         this.tabPluginGeneral.Controls.Add(this.txtID);
         this.tabPluginGeneral.Controls.Add(this.lblID);
         this.tabPluginGeneral.Name = "tabPluginGeneral";
         this.tabPluginGeneral.Padding = new System.Windows.Forms.Padding(15);
         this.tabPluginGeneral.Size = new System.Drawing.Size(335, 308);
         this.tabPluginGeneral.Text = "General";
         // 
         // lblID
         // 
         this.lblID.Location = new System.Drawing.Point(18, 31);
         this.lblID.Name = "lblID";
         this.lblID.Size = new System.Drawing.Size(11, 13);
         this.lblID.TabIndex = 0;
         this.lblID.Text = "ID";
         // 
         // txtID
         // 
         this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtID.Enabled = false;
         this.txtID.Location = new System.Drawing.Point(69, 28);
         this.txtID.Name = "txtID";
         this.txtID.Size = new System.Drawing.Size(248, 20);
         this.txtID.TabIndex = 1;
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Enabled = false;
         this.txtName.Location = new System.Drawing.Point(69, 54);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(248, 20);
         this.txtName.TabIndex = 3;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(18, 57);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 2;
         this.lblName.Text = "Name";
         // 
         // lblFile
         // 
         this.lblFile.Location = new System.Drawing.Point(18, 83);
         this.lblFile.Name = "lblFile";
         this.lblFile.Size = new System.Drawing.Size(33, 13);
         this.lblFile.TabIndex = 4;
         this.lblFile.Text = "Library";
         // 
         // txtFile
         // 
         this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtFile.Location = new System.Drawing.Point(69, 80);
         this.txtFile.Name = "txtFile";
         this.txtFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.txtFile.Size = new System.Drawing.Size(248, 20);
         this.txtFile.TabIndex = 5;
         // 
         // cboModule
         // 
         this.cboModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboModule.Location = new System.Drawing.Point(69, 106);
         this.cboModule.Name = "cboModule";
         this.cboModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboModule.Properties.SmallImages = this.imageList;
         this.cboModule.Size = new System.Drawing.Size(248, 20);
         this.cboModule.TabIndex = 6;
         // 
         // lblModule
         // 
         this.lblModule.Location = new System.Drawing.Point(18, 109);
         this.lblModule.Name = "lblModule";
         this.lblModule.Size = new System.Drawing.Size(34, 13);
         this.lblModule.TabIndex = 7;
         this.lblModule.Text = "Module";
         // 
         // imageList
         // 
         this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
         this.imageList.ImageSize = new System.Drawing.Size(16, 16);
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // FrmPluginEditor
         // 
         this.AcceptButton = this.cmdAccept;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(365, 389);
         this.Controls.Add(this.tabPlugin);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmPluginEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Plugin editor";
         ((System.ComponentModel.ISupportInitialize)(this.tabPlugin)).EndInit();
         this.tabPlugin.ResumeLayout(false);
         this.tabPluginGeneral.ResumeLayout(false);
         this.tabPluginGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraTab.XtraTabControl tabPlugin;
      private DevExpress.XtraTab.XtraTabPage tabPluginGeneral;
      private DevExpress.XtraEditors.LabelControl lblModule;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboModule;
      private DevExpress.XtraEditors.ButtonEdit txtFile;
      private DevExpress.XtraEditors.LabelControl lblFile;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.TextEdit txtID;
      private DevExpress.XtraEditors.LabelControl lblID;
      private System.Windows.Forms.ImageList imageList;
   }
}