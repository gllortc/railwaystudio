namespace Rwm.Studio.Plugins.Control.Views
{
   partial class FrmRouteEditor
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRouteEditor));
         this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
         this.tabDecoder = new DevExpress.XtraTab.XtraTabControl();
         this.tabDecoderGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.chkBidirectional = new DevExpress.XtraEditors.CheckEdit();
         this.txtBlockTo = new DevExpress.XtraEditors.LabelControl();
         this.cboBlockTo = new Rwm.Studio.Plugins.Control.Controls.ElementImageComboBoxEdit();
         this.txtBlockFrom = new DevExpress.XtraEditors.LabelControl();
         this.cboBlockFrom = new Rwm.Studio.Plugins.Control.Controls.ElementImageComboBoxEdit();
         this.tabDecoderOutputs = new DevExpress.XtraTab.XtraTabPage();
         this.grdConnect = new DevExpress.XtraGrid.GridControl();
         this.grdConnectView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.tabDecoderNotes = new DevExpress.XtraTab.XtraTabPage();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
         this.tabPanels = new DevExpress.XtraTab.XtraTabControl();
         this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
         this.grpActions = new DevExpress.XtraEditors.GroupControl();
         this.lblAction = new DevExpress.XtraEditors.LabelControl();
         this.cboAction = new DevExpress.XtraEditors.ImageComboBoxEdit();
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).BeginInit();
         this.tabDecoder.SuspendLayout();
         this.tabDecoderGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkBidirectional.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBlockTo.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBlockFrom.Properties)).BeginInit();
         this.tabDecoderOutputs.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).BeginInit();
         this.tabDecoderNotes.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
         this.splitContainerControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tabPanels)).BeginInit();
         this.tabPanels.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grpActions)).BeginInit();
         this.grpActions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboAction.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // txtNotes
         // 
         this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtNotes.Location = new System.Drawing.Point(5, 5);
         this.txtNotes.Name = "txtNotes";
         this.txtNotes.Size = new System.Drawing.Size(231, 636);
         this.txtNotes.TabIndex = 204;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(20, 38);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(20, 57);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(175, 20);
         this.txtName.TabIndex = 1;
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(153, 610);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdOk
         // 
         this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOk.Location = new System.Drawing.Point(72, 610);
         this.cmdOk.Name = "cmdOk";
         this.cmdOk.Size = new System.Drawing.Size(75, 23);
         this.cmdOk.TabIndex = 100;
         this.cmdOk.Text = "OK";
         this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
         // 
         // tabDecoder
         // 
         this.tabDecoder.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabDecoder.Location = new System.Drawing.Point(0, 0);
         this.tabDecoder.Name = "tabDecoder";
         this.tabDecoder.SelectedTabPage = this.tabDecoderGeneral;
         this.tabDecoder.Size = new System.Drawing.Size(247, 674);
         this.tabDecoder.TabIndex = 8;
         this.tabDecoder.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDecoderGeneral,
            this.tabDecoderOutputs,
            this.tabDecoderNotes});
         // 
         // tabDecoderGeneral
         // 
         this.tabDecoderGeneral.Controls.Add(this.grpActions);
         this.tabDecoderGeneral.Controls.Add(this.grpGeneral);
         this.tabDecoderGeneral.Controls.Add(this.cmdCancel);
         this.tabDecoderGeneral.Controls.Add(this.cmdOk);
         this.tabDecoderGeneral.Name = "tabDecoderGeneral";
         this.tabDecoderGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabDecoderGeneral.Size = new System.Drawing.Size(241, 646);
         this.tabDecoderGeneral.Text = "Properties";
         // 
         // grpGeneral
         // 
         this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneral.Controls.Add(this.chkBidirectional);
         this.grpGeneral.Controls.Add(this.lblName);
         this.grpGeneral.Controls.Add(this.txtBlockTo);
         this.grpGeneral.Controls.Add(this.cboBlockTo);
         this.grpGeneral.Controls.Add(this.txtName);
         this.grpGeneral.Controls.Add(this.txtBlockFrom);
         this.grpGeneral.Controls.Add(this.cboBlockFrom);
         this.grpGeneral.Location = new System.Drawing.Point(13, 13);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(15);
         this.grpGeneral.Size = new System.Drawing.Size(215, 221);
         this.grpGeneral.TabIndex = 216;
         this.grpGeneral.Text = "General";
         // 
         // chkBidirectional
         // 
         this.chkBidirectional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkBidirectional.Location = new System.Drawing.Point(20, 183);
         this.chkBidirectional.Name = "chkBidirectional";
         this.chkBidirectional.Properties.Caption = "Bidirectional route";
         this.chkBidirectional.Size = new System.Drawing.Size(175, 19);
         this.chkBidirectional.TabIndex = 4;
         // 
         // txtBlockTo
         // 
         this.txtBlockTo.Location = new System.Drawing.Point(20, 128);
         this.txtBlockTo.Name = "txtBlockTo";
         this.txtBlockTo.Size = new System.Drawing.Size(39, 13);
         this.txtBlockTo.TabIndex = 3;
         this.txtBlockTo.Text = "To block";
         // 
         // cboBlockTo
         // 
         this.cboBlockTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboBlockTo.ElementType = Rwm.Otc.Layout.ElementType.Get(40);
         this.cboBlockTo.Location = new System.Drawing.Point(20, 147);
         this.cboBlockTo.Name = "cboBlockTo";
         this.cboBlockTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboBlockTo.Size = new System.Drawing.Size(175, 20);
         this.cboBlockTo.TabIndex = 1;
         // 
         // txtBlockFrom
         // 
         this.txtBlockFrom.Location = new System.Drawing.Point(20, 83);
         this.txtBlockFrom.Name = "txtBlockFrom";
         this.txtBlockFrom.Size = new System.Drawing.Size(51, 13);
         this.txtBlockFrom.TabIndex = 2;
         this.txtBlockFrom.Text = "From block";
         // 
         // cboBlockFrom
         // 
         this.cboBlockFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboBlockFrom.ElementType = Rwm.Otc.Layout.ElementType.Get(40);
         this.cboBlockFrom.Location = new System.Drawing.Point(20, 102);
         this.cboBlockFrom.Name = "cboBlockFrom";
         this.cboBlockFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboBlockFrom.Size = new System.Drawing.Size(175, 20);
         this.cboBlockFrom.TabIndex = 0;
         // 
         // tabDecoderOutputs
         // 
         this.tabDecoderOutputs.Controls.Add(this.grdConnect);
         this.tabDecoderOutputs.Name = "tabDecoderOutputs";
         this.tabDecoderOutputs.Padding = new System.Windows.Forms.Padding(5);
         this.tabDecoderOutputs.Size = new System.Drawing.Size(241, 646);
         this.tabDecoderOutputs.Text = "Connections";
         // 
         // grdConnect
         // 
         this.grdConnect.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdConnect.Location = new System.Drawing.Point(5, 5);
         this.grdConnect.MainView = this.grdConnectView;
         this.grdConnect.Name = "grdConnect";
         this.grdConnect.Size = new System.Drawing.Size(231, 636);
         this.grdConnect.TabIndex = 5;
         this.grdConnect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdConnectView});
         // 
         // grdConnectView
         // 
         this.grdConnectView.GridControl = this.grdConnect;
         this.grdConnectView.Name = "grdConnectView";
         this.grdConnectView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdConnectView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdConnectView.OptionsBehavior.Editable = false;
         this.grdConnectView.OptionsBehavior.ReadOnly = true;
         this.grdConnectView.OptionsCustomization.AllowColumnMoving = false;
         this.grdConnectView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdConnectView.OptionsSelection.EnableAppearanceFocusedRow = false;
         this.grdConnectView.OptionsView.ShowGroupPanel = false;
         this.grdConnectView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdConnectView_CustomDrawCell);
         this.grdConnectView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdConnectView_RowStyle);
         // 
         // tabDecoderNotes
         // 
         this.tabDecoderNotes.Controls.Add(this.txtNotes);
         this.tabDecoderNotes.Name = "tabDecoderNotes";
         this.tabDecoderNotes.Padding = new System.Windows.Forms.Padding(5);
         this.tabDecoderNotes.Size = new System.Drawing.Size(241, 646);
         this.tabDecoderNotes.Text = "Notes";
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "ICO_OUTPUT");
         this.imageList.Images.SetKeyName(1, "ICO_MANUFACTURER");
         this.imageList.Images.SetKeyName(2, "ICO_MODEL");
         this.imageList.Images.SetKeyName(3, "ICO_NOTHING");
         this.imageList.Images.SetKeyName(4, "ICO_STOP");
         this.imageList.Images.SetKeyName(5, "ICO_BREAK");
         // 
         // splitContainerControl1
         // 
         this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
         this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
         this.splitContainerControl1.Name = "splitContainerControl1";
         this.splitContainerControl1.Padding = new System.Windows.Forms.Padding(5);
         this.splitContainerControl1.Panel1.Controls.Add(this.tabPanels);
         this.splitContainerControl1.Panel1.Text = "Panel1";
         this.splitContainerControl1.Panel2.Controls.Add(this.tabDecoder);
         this.splitContainerControl1.Panel2.Text = "Panel2";
         this.splitContainerControl1.Size = new System.Drawing.Size(1121, 684);
         this.splitContainerControl1.SplitterPosition = 247;
         this.splitContainerControl1.TabIndex = 9;
         this.splitContainerControl1.Text = "splitContainerControl1";
         // 
         // tabPanels
         // 
         this.tabPanels.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabPanels.Location = new System.Drawing.Point(0, 0);
         this.tabPanels.Name = "tabPanels";
         this.tabPanels.SelectedTabPage = this.xtraTabPage1;
         this.tabPanels.Size = new System.Drawing.Size(859, 674);
         this.tabPanels.TabIndex = 0;
         this.tabPanels.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
         // 
         // xtraTabPage1
         // 
         this.xtraTabPage1.Name = "xtraTabPage1";
         this.xtraTabPage1.Size = new System.Drawing.Size(853, 646);
         this.xtraTabPage1.Text = "xtraTabPage1";
         // 
         // grpActions
         // 
         this.grpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpActions.Controls.Add(this.cboAction);
         this.grpActions.Controls.Add(this.lblAction);
         this.grpActions.Location = new System.Drawing.Point(13, 240);
         this.grpActions.Name = "grpActions";
         this.grpActions.Padding = new System.Windows.Forms.Padding(10);
         this.grpActions.Size = new System.Drawing.Size(215, 93);
         this.grpActions.TabIndex = 217;
         this.grpActions.Text = "Behaviour";
         // 
         // lblAction
         // 
         this.lblAction.Location = new System.Drawing.Point(15, 33);
         this.lblAction.Name = "lblAction";
         this.lblAction.Size = new System.Drawing.Size(107, 13);
         this.lblAction.TabIndex = 4;
         this.lblAction.Text = "When block is reached";
         // 
         // cboAction
         // 
         this.cboAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboAction.Location = new System.Drawing.Point(15, 52);
         this.cboAction.Name = "cboAction";
         this.cboAction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboAction.Properties.SmallImages = this.imageList;
         this.cboAction.Size = new System.Drawing.Size(185, 20);
         this.cboAction.TabIndex = 5;
         // 
         // FrmRouteEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1121, 684);
         this.Controls.Add(this.splitContainerControl1);
         this.Name = "FrmRouteEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Route editor";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRouteEditor_FormClosed);
         this.Load += new System.EventHandler(this.FrmRouteEditor_Load);
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).EndInit();
         this.tabDecoder.ResumeLayout(false);
         this.tabDecoderGeneral.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkBidirectional.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBlockTo.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBlockFrom.Properties)).EndInit();
         this.tabDecoderOutputs.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).EndInit();
         this.tabDecoderNotes.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
         this.splitContainerControl1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.tabPanels)).EndInit();
         this.tabPanels.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grpActions)).EndInit();
         this.grpActions.ResumeLayout(false);
         this.grpActions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboAction.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.MemoEdit txtNotes;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOk;
      private DevExpress.XtraTab.XtraTabControl tabDecoder;
      private DevExpress.XtraTab.XtraTabPage tabDecoderGeneral;
      private DevExpress.XtraTab.XtraTabPage tabDecoderNotes;
      private DevExpress.XtraEditors.GroupControl grpGeneral;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraTab.XtraTabPage tabDecoderOutputs;
      private DevExpress.XtraGrid.GridControl grdConnect;
      private DevExpress.XtraGrid.Views.Grid.GridView grdConnectView;
      private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
      private DevExpress.XtraTab.XtraTabControl tabPanels;
      private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
      private Controls.ElementImageComboBoxEdit cboBlockFrom;
      private DevExpress.XtraEditors.LabelControl txtBlockFrom;
      private Controls.ElementImageComboBoxEdit cboBlockTo;
      private DevExpress.XtraEditors.LabelControl txtBlockTo;
      private DevExpress.XtraEditors.CheckEdit chkBidirectional;
      private DevExpress.XtraEditors.GroupControl grpActions;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboAction;
      private DevExpress.XtraEditors.LabelControl lblAction;
   }
}