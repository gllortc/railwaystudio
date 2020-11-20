namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class ElementEditorViews
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementEditorViews));
         this.tabBlock = new DevExpress.XtraTab.XtraTabControl();
         this.tabBlockGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.grpInfo = new DevExpress.XtraEditors.GroupControl();
         this.picBlock = new System.Windows.Forms.PictureBox();
         this.lblID = new DevExpress.XtraEditors.LabelControl();
         this.lblIDLabel = new DevExpress.XtraEditors.LabelControl();
         this.lblStatus = new DevExpress.XtraEditors.LabelControl();
         this.lblStatusLabel = new DevExpress.XtraEditors.LabelControl();
         this.lblType = new DevExpress.XtraEditors.LabelControl();
         this.lblTypeLabel = new DevExpress.XtraEditors.LabelControl();
         this.lblPosition = new DevExpress.XtraEditors.LabelControl();
         this.lblPositionLabel = new DevExpress.XtraEditors.LabelControl();
         this.pnlSep1 = new System.Windows.Forms.Panel();
         this.grpProperties = new DevExpress.XtraEditors.GroupControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.tabAccessoryConnections = new DevExpress.XtraTab.XtraTabPage();
         this.eccAccessoryConnections = new Rwm.Studio.Plugins.Designer.Controls.AccessoryConnectionsControl();
         this.tabFeedbackConnections = new DevExpress.XtraTab.XtraTabPage();
         this.fccFeedbackConnections = new Rwm.Studio.Plugins.Designer.Controls.FeedbackConnectionsControl();
         this.tabBlockActions = new DevExpress.XtraTab.XtraTabPage();
         this.amcActions = new Rwm.Studio.Plugins.Designer.Controls.ActionManagerControl();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.tabBlock)).BeginInit();
         this.tabBlock.SuspendLayout();
         this.tabBlockGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grpInfo)).BeginInit();
         this.grpInfo.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picBlock)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpProperties)).BeginInit();
         this.grpProperties.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         this.tabAccessoryConnections.SuspendLayout();
         this.tabFeedbackConnections.SuspendLayout();
         this.tabBlockActions.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabBlock
         // 
         this.tabBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabBlock.Location = new System.Drawing.Point(12, 12);
         this.tabBlock.Name = "tabBlock";
         this.tabBlock.SelectedTabPage = this.tabBlockGeneral;
         this.tabBlock.Size = new System.Drawing.Size(447, 401);
         this.tabBlock.TabIndex = 0;
         this.tabBlock.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBlockGeneral,
            this.tabAccessoryConnections,
            this.tabFeedbackConnections,
            this.tabBlockActions});
         // 
         // tabBlockGeneral
         // 
         this.tabBlockGeneral.Controls.Add(this.grpInfo);
         this.tabBlockGeneral.Controls.Add(this.pnlSep1);
         this.tabBlockGeneral.Controls.Add(this.grpProperties);
         this.tabBlockGeneral.Name = "tabBlockGeneral";
         this.tabBlockGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabBlockGeneral.Size = new System.Drawing.Size(441, 370);
         this.tabBlockGeneral.Text = "General";
         // 
         // grpInfo
         // 
         this.grpInfo.Controls.Add(this.picBlock);
         this.grpInfo.Controls.Add(this.lblID);
         this.grpInfo.Controls.Add(this.lblIDLabel);
         this.grpInfo.Controls.Add(this.lblStatus);
         this.grpInfo.Controls.Add(this.lblStatusLabel);
         this.grpInfo.Controls.Add(this.lblType);
         this.grpInfo.Controls.Add(this.lblTypeLabel);
         this.grpInfo.Controls.Add(this.lblPosition);
         this.grpInfo.Controls.Add(this.lblPositionLabel);
         this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grpInfo.Location = new System.Drawing.Point(10, 96);
         this.grpInfo.Name = "grpInfo";
         this.grpInfo.Padding = new System.Windows.Forms.Padding(10);
         this.grpInfo.Size = new System.Drawing.Size(421, 264);
         this.grpInfo.TabIndex = 2;
         this.grpInfo.Text = "Information";
         // 
         // picBlock
         // 
         this.picBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.picBlock.Location = new System.Drawing.Point(15, 33);
         this.picBlock.Name = "picBlock";
         this.picBlock.Size = new System.Drawing.Size(50, 50);
         this.picBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.picBlock.TabIndex = 8;
         this.picBlock.TabStop = false;
         // 
         // lblID
         // 
         this.lblID.Location = new System.Drawing.Point(164, 90);
         this.lblID.Name = "lblID";
         this.lblID.Size = new System.Drawing.Size(24, 13);
         this.lblID.TabIndex = 7;
         this.lblID.Text = "<id>";
         // 
         // lblIDLabel
         // 
         this.lblIDLabel.Location = new System.Drawing.Point(79, 90);
         this.lblIDLabel.Name = "lblIDLabel";
         this.lblIDLabel.Size = new System.Drawing.Size(19, 13);
         this.lblIDLabel.TabIndex = 6;
         this.lblIDLabel.Text = "OID";
         // 
         // lblStatus
         // 
         this.lblStatus.Location = new System.Drawing.Point(164, 71);
         this.lblStatus.Name = "lblStatus";
         this.lblStatus.Size = new System.Drawing.Size(46, 13);
         this.lblStatus.TabIndex = 5;
         this.lblStatus.Text = "<status>";
         // 
         // lblStatusLabel
         // 
         this.lblStatusLabel.Location = new System.Drawing.Point(79, 71);
         this.lblStatusLabel.Name = "lblStatusLabel";
         this.lblStatusLabel.Size = new System.Drawing.Size(70, 13);
         this.lblStatusLabel.TabIndex = 4;
         this.lblStatusLabel.Text = "Current status";
         // 
         // lblType
         // 
         this.lblType.Location = new System.Drawing.Point(164, 52);
         this.lblType.Name = "lblType";
         this.lblType.Size = new System.Drawing.Size(38, 13);
         this.lblType.TabIndex = 3;
         this.lblType.Text = "<type>";
         // 
         // lblTypeLabel
         // 
         this.lblTypeLabel.Location = new System.Drawing.Point(79, 52);
         this.lblTypeLabel.Name = "lblTypeLabel";
         this.lblTypeLabel.Size = new System.Drawing.Size(24, 13);
         this.lblTypeLabel.TabIndex = 2;
         this.lblTypeLabel.Text = "Type";
         // 
         // lblPosition
         // 
         this.lblPosition.Location = new System.Drawing.Point(164, 33);
         this.lblPosition.Name = "lblPosition";
         this.lblPosition.Size = new System.Drawing.Size(53, 13);
         this.lblPosition.TabIndex = 1;
         this.lblPosition.Text = "<position>";
         // 
         // lblPositionLabel
         // 
         this.lblPositionLabel.Location = new System.Drawing.Point(79, 33);
         this.lblPositionLabel.Name = "lblPositionLabel";
         this.lblPositionLabel.Size = new System.Drawing.Size(37, 13);
         this.lblPositionLabel.TabIndex = 0;
         this.lblPositionLabel.Text = "Position";
         // 
         // pnlSep1
         // 
         this.pnlSep1.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnlSep1.Location = new System.Drawing.Point(10, 85);
         this.pnlSep1.Name = "pnlSep1";
         this.pnlSep1.Size = new System.Drawing.Size(421, 11);
         this.pnlSep1.TabIndex = 4;
         // 
         // grpProperties
         // 
         this.grpProperties.Controls.Add(this.txtName);
         this.grpProperties.Controls.Add(this.lblName);
         this.grpProperties.Dock = System.Windows.Forms.DockStyle.Top;
         this.grpProperties.Location = new System.Drawing.Point(10, 10);
         this.grpProperties.Name = "grpProperties";
         this.grpProperties.Padding = new System.Windows.Forms.Padding(10);
         this.grpProperties.Size = new System.Drawing.Size(421, 75);
         this.grpProperties.TabIndex = 5;
         this.grpProperties.Text = "Properties";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(79, 34);
         this.txtName.Name = "txtName";
         this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtName.Properties.Appearance.Options.UseFont = true;
         this.txtName.Size = new System.Drawing.Size(327, 20);
         this.txtName.TabIndex = 1;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(15, 37);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // tabAccessoryConnections
         // 
         this.tabAccessoryConnections.Controls.Add(this.eccAccessoryConnections);
         this.tabAccessoryConnections.Image = ((System.Drawing.Image)(resources.GetObject("tabAccessoryConnections.Image")));
         this.tabAccessoryConnections.Name = "tabAccessoryConnections";
         this.tabAccessoryConnections.Padding = new System.Windows.Forms.Padding(10);
         this.tabAccessoryConnections.Size = new System.Drawing.Size(441, 370);
         this.tabAccessoryConnections.Text = "Accessory";
         // 
         // eccAccessoryConnections
         // 
         this.eccAccessoryConnections.Dock = System.Windows.Forms.DockStyle.Fill;
         this.eccAccessoryConnections.Location = new System.Drawing.Point(10, 10);
         this.eccAccessoryConnections.Name = "eccAccessoryConnections";
         this.eccAccessoryConnections.Size = new System.Drawing.Size(421, 350);
         this.eccAccessoryConnections.TabIndex = 0;
         // 
         // tabFeedbackConnections
         // 
         this.tabFeedbackConnections.Controls.Add(this.fccFeedbackConnections);
         this.tabFeedbackConnections.Image = ((System.Drawing.Image)(resources.GetObject("tabFeedbackConnections.Image")));
         this.tabFeedbackConnections.Name = "tabFeedbackConnections";
         this.tabFeedbackConnections.Padding = new System.Windows.Forms.Padding(10);
         this.tabFeedbackConnections.Size = new System.Drawing.Size(441, 370);
         this.tabFeedbackConnections.Text = "Feedback";
         // 
         // fccFeedbackConnections
         // 
         this.fccFeedbackConnections.AllowManageConnections = false;
         this.fccFeedbackConnections.Dock = System.Windows.Forms.DockStyle.Fill;
         this.fccFeedbackConnections.Location = new System.Drawing.Point(10, 10);
         this.fccFeedbackConnections.Name = "fccFeedbackConnections";
         this.fccFeedbackConnections.Size = new System.Drawing.Size(421, 350);
         this.fccFeedbackConnections.TabIndex = 0;
         // 
         // tabBlockActions
         // 
         this.tabBlockActions.Controls.Add(this.amcActions);
         this.tabBlockActions.Image = ((System.Drawing.Image)(resources.GetObject("tabBlockActions.Image")));
         this.tabBlockActions.Name = "tabBlockActions";
         this.tabBlockActions.Padding = new System.Windows.Forms.Padding(10);
         this.tabBlockActions.Size = new System.Drawing.Size(441, 370);
         this.tabBlockActions.Text = "Actions";
         // 
         // amcActions
         // 
         this.amcActions.Dock = System.Windows.Forms.DockStyle.Fill;
         this.amcActions.Location = new System.Drawing.Point(10, 10);
         this.amcActions.Name = "amcActions";
         this.amcActions.Size = new System.Drawing.Size(421, 350);
         this.amcActions.TabIndex = 0;
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(384, 419);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 1;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(303, 419);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 2;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
         // 
         // ElementEditorViews
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(471, 454);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.tabBlock);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ElementEditorViews";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Element properties";
         ((System.ComponentModel.ISupportInitialize)(this.tabBlock)).EndInit();
         this.tabBlock.ResumeLayout(false);
         this.tabBlockGeneral.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grpInfo)).EndInit();
         this.grpInfo.ResumeLayout(false);
         this.grpInfo.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picBlock)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpProperties)).EndInit();
         this.grpProperties.ResumeLayout(false);
         this.grpProperties.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         this.tabAccessoryConnections.ResumeLayout(false);
         this.tabFeedbackConnections.ResumeLayout(false);
         this.tabBlockActions.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraTab.XtraTabControl tabBlock;
      private DevExpress.XtraTab.XtraTabPage tabBlockGeneral;
      private DevExpress.XtraTab.XtraTabPage tabAccessoryConnections;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.GroupControl grpInfo;
      private System.Windows.Forms.Panel pnlSep1;
      private DevExpress.XtraEditors.GroupControl grpProperties;
      private DevExpress.XtraEditors.LabelControl lblStatus;
      private DevExpress.XtraEditors.LabelControl lblStatusLabel;
      private DevExpress.XtraEditors.LabelControl lblType;
      private DevExpress.XtraEditors.LabelControl lblTypeLabel;
      private DevExpress.XtraEditors.LabelControl lblPosition;
      private DevExpress.XtraEditors.LabelControl lblPositionLabel;
      private DevExpress.XtraEditors.LabelControl lblID;
      private DevExpress.XtraEditors.LabelControl lblIDLabel;
      private System.Windows.Forms.PictureBox picBlock;
      private DevExpress.XtraTab.XtraTabPage tabBlockActions;
      private DevExpress.XtraTab.XtraTabPage tabFeedbackConnections;
        private Controls.AccessoryConnectionsControl eccAccessoryConnections;
        private Controls.FeedbackConnectionsControl fccFeedbackConnections;
        private Controls.ActionManagerControl amcActions;
    }
}