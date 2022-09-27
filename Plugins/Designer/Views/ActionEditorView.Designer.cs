namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class ActionEditorView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionEditorView));
         this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
         this.lblStatus = new DevExpress.XtraEditors.LabelControl();
         this.cboStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.cboEvent = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.lblDescription = new DevExpress.XtraEditors.LabelControl();
         this.txtDescription = new DevExpress.XtraEditors.TextEdit();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.pnlSep1 = new DevExpress.XtraEditors.PanelControl();
         this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
         this.pumBlock = new DevExpress.XtraBars.PopupMenu(this.components);
         this.cmdBlockAssign = new DevExpress.XtraBars.BarButtonItem();
         this.cmdBlockUnassign = new DevExpress.XtraBars.BarButtonItem();
         this.cmdBlockDepart = new DevExpress.XtraBars.BarButtonItem();
         this.barManager = new DevExpress.XtraBars.BarManager(this.components);
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
         this.groupControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboEvent.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlSep1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pumBlock)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
         this.SuspendLayout();
         // 
         // groupControl1
         // 
         this.groupControl1.Controls.Add(this.lblStatus);
         this.groupControl1.Controls.Add(this.cboStatus);
         this.groupControl1.Controls.Add(this.cboEvent);
         this.groupControl1.Controls.Add(this.labelControl1);
         this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.groupControl1.Location = new System.Drawing.Point(10, 96);
         this.groupControl1.Name = "groupControl1";
         this.groupControl1.Padding = new System.Windows.Forms.Padding(10);
         this.groupControl1.Size = new System.Drawing.Size(368, 95);
         this.groupControl1.TabIndex = 4;
         this.groupControl1.Text = "Event";
         // 
         // lblStatus
         // 
         this.lblStatus.Location = new System.Drawing.Point(15, 62);
         this.lblStatus.Name = "lblStatus";
         this.lblStatus.Size = new System.Drawing.Size(27, 13);
         this.lblStatus.TabIndex = 4;
         this.lblStatus.Text = "Satus";
         // 
         // cboStatus
         // 
         this.cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboStatus.Location = new System.Drawing.Point(117, 59);
         this.cboStatus.Name = "cboStatus";
         this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboStatus.Properties.SmallImages = this.imageList;
         this.cboStatus.Size = new System.Drawing.Size(236, 20);
         this.cboStatus.TabIndex = 5;
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "ICO_EVENT");
         this.imageList.Images.SetKeyName(1, "ICO_SOUND");
         this.imageList.Images.SetKeyName(2, "ICO_FILTER");
         this.imageList.Images.SetKeyName(3, "ICO_NO_FILTER");
         // 
         // cboEvent
         // 
         this.cboEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboEvent.Location = new System.Drawing.Point(117, 33);
         this.cboEvent.Name = "cboEvent";
         this.cboEvent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboEvent.Properties.SmallImages = this.imageList;
         this.cboEvent.Size = new System.Drawing.Size(236, 20);
         this.cboEvent.TabIndex = 3;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(15, 36);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(85, 13);
         this.labelControl1.TabIndex = 2;
         this.labelControl1.Text = "Execute on event";
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(219, 359);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 100;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.Location = new System.Drawing.Point(300, 359);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // lblDescription
         // 
         this.lblDescription.Location = new System.Drawing.Point(15, 36);
         this.lblDescription.Name = "lblDescription";
         this.lblDescription.Size = new System.Drawing.Size(27, 13);
         this.lblDescription.TabIndex = 0;
         this.lblDescription.Text = "Name";
         // 
         // txtDescription
         // 
         this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtDescription.Location = new System.Drawing.Point(64, 33);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Size = new System.Drawing.Size(289, 20);
         this.txtDescription.TabIndex = 1;
         // 
         // grpGeneral
         // 
         this.grpGeneral.Controls.Add(this.txtDescription);
         this.grpGeneral.Controls.Add(this.lblDescription);
         this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top;
         this.grpGeneral.Location = new System.Drawing.Point(10, 10);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.grpGeneral.Size = new System.Drawing.Size(368, 76);
         this.grpGeneral.TabIndex = 201;
         this.grpGeneral.Text = "General";
         // 
         // pnlSep1
         // 
         this.pnlSep1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.pnlSep1.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnlSep1.Location = new System.Drawing.Point(10, 86);
         this.pnlSep1.Name = "pnlSep1";
         this.pnlSep1.Size = new System.Drawing.Size(368, 10);
         this.pnlSep1.TabIndex = 202;
         // 
         // panelControl1
         // 
         this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panelControl1.Location = new System.Drawing.Point(10, 191);
         this.panelControl1.Name = "panelControl1";
         this.panelControl1.Size = new System.Drawing.Size(368, 10);
         this.panelControl1.TabIndex = 203;
         // 
         // pumBlock
         // 
         this.pumBlock.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdBlockAssign),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdBlockUnassign),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdBlockDepart, true)});
         this.pumBlock.Manager = this.barManager;
         this.pumBlock.Name = "pumBlock";
         // 
         // cmdBlockAssign
         // 
         this.cmdBlockAssign.Caption = "Assign train...";
         this.cmdBlockAssign.Glyph = Properties.Resources.ICO_BLOCK_GO_16;
         this.cmdBlockAssign.Id = 0;
         this.cmdBlockAssign.Name = "cmdBlockAssign";
         // 
         // cmdBlockUnassign
         // 
         this.cmdBlockUnassign.Caption = "Unassign train (remove)";
         this.cmdBlockUnassign.Glyph = Properties.Resources.ICO_BLOCK_CLEAR_16;
         this.cmdBlockUnassign.Id = 1;
         this.cmdBlockUnassign.Name = "cmdBlockUnassign";
         // 
         // cmdBlockDepart
         // 
         this.cmdBlockDepart.Caption = "Depart to...";
         this.cmdBlockDepart.Id = 2;
         this.cmdBlockDepart.Name = "cmdBlockDepart";
         // 
         // barManager
         // 
         this.barManager.DockControls.Add(this.barDockControlTop);
         this.barManager.DockControls.Add(this.barDockControlBottom);
         this.barManager.DockControls.Add(this.barDockControlLeft);
         this.barManager.DockControls.Add(this.barDockControlRight);
         this.barManager.Form = this;
         this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdBlockAssign,
            this.cmdBlockUnassign,
            this.cmdBlockDepart});
         this.barManager.MaxItemId = 3;
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(10, 10);
         this.barDockControlTop.Size = new System.Drawing.Size(368, 0);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(10, 385);
         this.barDockControlBottom.Size = new System.Drawing.Size(368, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(10, 10);
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 375);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(378, 10);
         this.barDockControlRight.Size = new System.Drawing.Size(0, 375);
         // 
         // FrmActionEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(388, 395);
         this.Controls.Add(this.panelControl1);
         this.Controls.Add(this.groupControl1);
         this.Controls.Add(this.pnlSep1);
         this.Controls.Add(this.grpGeneral);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmActionEditor";
         this.Padding = new System.Windows.Forms.Padding(10);
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Action properties: Play Sound";
         this.Load += new System.EventHandler(this.FrmActionEditor_Load);
         ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
         this.groupControl1.ResumeLayout(false);
         this.groupControl1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboEvent.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlSep1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pumBlock)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.GroupControl groupControl1;
      private DevExpress.XtraEditors.LabelControl lblStatus;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboStatus;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboEvent;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraEditors.LabelControl lblDescription;
      private DevExpress.XtraEditors.TextEdit txtDescription;
      private DevExpress.XtraEditors.GroupControl grpGeneral;
      private DevExpress.XtraEditors.PanelControl pnlSep1;
      private DevExpress.XtraEditors.PanelControl panelControl1;
      private DevExpress.XtraBars.PopupMenu pumBlock;
      private DevExpress.XtraBars.BarButtonItem cmdBlockAssign;
      private DevExpress.XtraBars.BarButtonItem cmdBlockUnassign;
      private DevExpress.XtraBars.BarButtonItem cmdBlockDepart;
      private DevExpress.XtraBars.BarManager barManager;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
   }
}