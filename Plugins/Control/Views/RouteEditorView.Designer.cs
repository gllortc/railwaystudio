namespace Rwm.Studio.Plugins.Control.Views
{
   partial class RouteEditorView
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
         this.tabDecoder = new DevExpress.XtraTab.XtraTabControl();
         this.tabRouteGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.grpGeneralProperties = new DevExpress.XtraEditors.GroupControl();
         this.lblSwitchTimeUnits = new DevExpress.XtraEditors.LabelControl();
         this.spnSwitchTime = new DevExpress.XtraEditors.SpinEdit();
         this.lblSwitchTime = new DevExpress.XtraEditors.LabelControl();
         this.grpGeneral = new DevExpress.XtraEditors.GroupControl();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.tabRouteBlock = new DevExpress.XtraTab.XtraTabPage();
         this.chkIsBlock = new DevExpress.XtraEditors.CheckEdit();
         this.grpBlockBehaviour = new DevExpress.XtraEditors.GroupControl();
         this.cboAction = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.lblAction = new DevExpress.XtraEditors.LabelControl();
         this.grpBlockConnections = new DevExpress.XtraEditors.GroupControl();
         this.chkBidirectional = new DevExpress.XtraEditors.CheckEdit();
         this.txtBlockTo = new DevExpress.XtraEditors.LabelControl();
         this.cboBlockTo = new Rwm.Studio.Plugins.Control.Controls.ElementImageComboBoxEdit();
         this.txtBlockFrom = new DevExpress.XtraEditors.LabelControl();
         this.cboBlockFrom = new Rwm.Studio.Plugins.Control.Controls.ElementImageComboBoxEdit();
         this.tabRouteConnections = new DevExpress.XtraTab.XtraTabPage();
         this.grdConnect = new DevExpress.XtraGrid.GridControl();
         this.grdConnectView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.tabRouteNotes = new DevExpress.XtraTab.XtraTabPage();
         this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).BeginInit();
         this.tabDecoder.SuspendLayout();
         this.tabRouteGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneralProperties)).BeginInit();
         this.grpGeneralProperties.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spnSwitchTime.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).BeginInit();
         this.grpGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         this.tabRouteBlock.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkIsBlock.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpBlockBehaviour)).BeginInit();
         this.grpBlockBehaviour.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboAction.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpBlockConnections)).BeginInit();
         this.grpBlockConnections.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkBidirectional.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBlockTo.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBlockFrom.Properties)).BeginInit();
         this.tabRouteConnections.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).BeginInit();
         this.tabRouteNotes.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // tabDecoder
         // 
         this.tabDecoder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabDecoder.Location = new System.Drawing.Point(12, 12);
         this.tabDecoder.Name = "tabDecoder";
         this.tabDecoder.SelectedTabPage = this.tabRouteGeneral;
         this.tabDecoder.Size = new System.Drawing.Size(413, 397);
         this.tabDecoder.TabIndex = 5;
         this.tabDecoder.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabRouteGeneral,
            this.tabRouteBlock,
            this.tabRouteConnections,
            this.tabRouteNotes});
         // 
         // tabRouteGeneral
         // 
         this.tabRouteGeneral.Controls.Add(this.grpGeneralProperties);
         this.tabRouteGeneral.Controls.Add(this.grpGeneral);
         this.tabRouteGeneral.Name = "tabRouteGeneral";
         this.tabRouteGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabRouteGeneral.Size = new System.Drawing.Size(407, 369);
         this.tabRouteGeneral.Text = "General";
         // 
         // grpGeneralProperties
         // 
         this.grpGeneralProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneralProperties.Controls.Add(this.lblSwitchTimeUnits);
         this.grpGeneralProperties.Controls.Add(this.spnSwitchTime);
         this.grpGeneralProperties.Controls.Add(this.lblSwitchTime);
         this.grpGeneralProperties.Location = new System.Drawing.Point(13, 111);
         this.grpGeneralProperties.Name = "grpGeneralProperties";
         this.grpGeneralProperties.Padding = new System.Windows.Forms.Padding(10);
         this.grpGeneralProperties.Size = new System.Drawing.Size(381, 74);
         this.grpGeneralProperties.TabIndex = 218;
         this.grpGeneralProperties.Text = "Properties";
         // 
         // lblSwitchTimeUnits
         // 
         this.lblSwitchTimeUnits.Location = new System.Drawing.Point(178, 36);
         this.lblSwitchTimeUnits.Name = "lblSwitchTimeUnits";
         this.lblSwitchTimeUnits.Size = new System.Drawing.Size(55, 13);
         this.lblSwitchTimeUnits.TabIndex = 4;
         this.lblSwitchTimeUnits.Text = "milliseconds";
         // 
         // spnSwitchTime
         // 
         this.spnSwitchTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spnSwitchTime.Location = new System.Drawing.Point(102, 33);
         this.spnSwitchTime.Name = "spnSwitchTime";
         this.spnSwitchTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnSwitchTime.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.spnSwitchTime.Size = new System.Drawing.Size(70, 20);
         this.spnSwitchTime.TabIndex = 3;
         // 
         // lblSwitchTime
         // 
         this.lblSwitchTime.Location = new System.Drawing.Point(15, 36);
         this.lblSwitchTime.Name = "lblSwitchTime";
         this.lblSwitchTime.Size = new System.Drawing.Size(70, 13);
         this.lblSwitchTime.TabIndex = 2;
         this.lblSwitchTime.Text = "Switch interval";
         // 
         // grpGeneral
         // 
         this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGeneral.Controls.Add(this.lblName);
         this.grpGeneral.Controls.Add(this.txtName);
         this.grpGeneral.Location = new System.Drawing.Point(13, 13);
         this.grpGeneral.Name = "grpGeneral";
         this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.grpGeneral.Size = new System.Drawing.Size(381, 92);
         this.grpGeneral.TabIndex = 216;
         this.grpGeneral.Text = "General";
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(15, 33);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(15, 52);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(351, 20);
         this.txtName.TabIndex = 1;
         // 
         // tabRouteBlock
         // 
         this.tabRouteBlock.Controls.Add(this.chkIsBlock);
         this.tabRouteBlock.Controls.Add(this.grpBlockBehaviour);
         this.tabRouteBlock.Controls.Add(this.grpBlockConnections);
         this.tabRouteBlock.Name = "tabRouteBlock";
         this.tabRouteBlock.Padding = new System.Windows.Forms.Padding(10);
         this.tabRouteBlock.Size = new System.Drawing.Size(407, 369);
         this.tabRouteBlock.Text = "Block";
         // 
         // chkIsBlock
         // 
         this.chkIsBlock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkIsBlock.Location = new System.Drawing.Point(13, 13);
         this.chkIsBlock.Name = "chkIsBlock";
         this.chkIsBlock.Properties.Caption = "This route corresponds to a block";
         this.chkIsBlock.Size = new System.Drawing.Size(353, 19);
         this.chkIsBlock.TabIndex = 6;
         this.chkIsBlock.CheckedChanged += new System.EventHandler(this.ChkIsBlock_CheckedChanged);
         // 
         // grpBlockBehaviour
         // 
         this.grpBlockBehaviour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpBlockBehaviour.Controls.Add(this.cboAction);
         this.grpBlockBehaviour.Controls.Add(this.lblAction);
         this.grpBlockBehaviour.Enabled = false;
         this.grpBlockBehaviour.Location = new System.Drawing.Point(13, 203);
         this.grpBlockBehaviour.Name = "grpBlockBehaviour";
         this.grpBlockBehaviour.Padding = new System.Windows.Forms.Padding(10);
         this.grpBlockBehaviour.Size = new System.Drawing.Size(383, 93);
         this.grpBlockBehaviour.TabIndex = 217;
         this.grpBlockBehaviour.Text = "Behaviour";
         // 
         // cboAction
         // 
         this.cboAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboAction.Location = new System.Drawing.Point(15, 52);
         this.cboAction.Name = "cboAction";
         this.cboAction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboAction.Size = new System.Drawing.Size(353, 20);
         this.cboAction.TabIndex = 13;
         // 
         // lblAction
         // 
         this.lblAction.Location = new System.Drawing.Point(15, 33);
         this.lblAction.Name = "lblAction";
         this.lblAction.Size = new System.Drawing.Size(107, 13);
         this.lblAction.TabIndex = 12;
         this.lblAction.Text = "When block is reached";
         // 
         // grpBlockConnections
         // 
         this.grpBlockConnections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpBlockConnections.Controls.Add(this.chkBidirectional);
         this.grpBlockConnections.Controls.Add(this.txtBlockTo);
         this.grpBlockConnections.Controls.Add(this.cboBlockTo);
         this.grpBlockConnections.Controls.Add(this.txtBlockFrom);
         this.grpBlockConnections.Controls.Add(this.cboBlockFrom);
         this.grpBlockConnections.Enabled = false;
         this.grpBlockConnections.Location = new System.Drawing.Point(13, 38);
         this.grpBlockConnections.Name = "grpBlockConnections";
         this.grpBlockConnections.Padding = new System.Windows.Forms.Padding(10);
         this.grpBlockConnections.Size = new System.Drawing.Size(383, 159);
         this.grpBlockConnections.TabIndex = 217;
         this.grpBlockConnections.Text = "AccessoryConnections";
         // 
         // chkBidirectional
         // 
         this.chkBidirectional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkBidirectional.Location = new System.Drawing.Point(15, 127);
         this.chkBidirectional.Name = "chkBidirectional";
         this.chkBidirectional.Properties.Caption = "Bidirectional route";
         this.chkBidirectional.Size = new System.Drawing.Size(353, 19);
         this.chkBidirectional.TabIndex = 11;
         // 
         // txtBlockTo
         // 
         this.txtBlockTo.Location = new System.Drawing.Point(15, 78);
         this.txtBlockTo.Name = "txtBlockTo";
         this.txtBlockTo.Size = new System.Drawing.Size(39, 13);
         this.txtBlockTo.TabIndex = 9;
         this.txtBlockTo.Text = "To block";
         // 
         // cboBlockTo
         // 
         this.cboBlockTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboBlockTo.ElementType = null;
         this.cboBlockTo.Location = new System.Drawing.Point(15, 97);
         this.cboBlockTo.Name = "cboBlockTo";
         this.cboBlockTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboBlockTo.Size = new System.Drawing.Size(353, 20);
         this.cboBlockTo.TabIndex = 10;
         // 
         // txtBlockFrom
         // 
         this.txtBlockFrom.Location = new System.Drawing.Point(15, 33);
         this.txtBlockFrom.Name = "txtBlockFrom";
         this.txtBlockFrom.Size = new System.Drawing.Size(51, 13);
         this.txtBlockFrom.TabIndex = 7;
         this.txtBlockFrom.Text = "From block";
         // 
         // cboBlockFrom
         // 
         this.cboBlockFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboBlockFrom.ElementType = null;
         this.cboBlockFrom.Location = new System.Drawing.Point(15, 52);
         this.cboBlockFrom.Name = "cboBlockFrom";
         this.cboBlockFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboBlockFrom.Size = new System.Drawing.Size(353, 20);
         this.cboBlockFrom.TabIndex = 8;
         // 
         // tabRouteConnections
         // 
         this.tabRouteConnections.Controls.Add(this.grdConnect);
         this.tabRouteConnections.Name = "tabRouteConnections";
         this.tabRouteConnections.Padding = new System.Windows.Forms.Padding(5);
         this.tabRouteConnections.Size = new System.Drawing.Size(407, 369);
         this.tabRouteConnections.Text = "AccessoryConnections";
         // 
         // grdConnect
         // 
         this.grdConnect.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdConnect.Location = new System.Drawing.Point(5, 5);
         this.grdConnect.MainView = this.grdConnectView;
         this.grdConnect.Name = "grdConnect";
         this.grdConnect.Size = new System.Drawing.Size(397, 359);
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
         this.grdConnectView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.GrdConnectView_RowStyle);
         // 
         // tabRouteNotes
         // 
         this.tabRouteNotes.Controls.Add(this.txtNotes);
         this.tabRouteNotes.Name = "tabRouteNotes";
         this.tabRouteNotes.Padding = new System.Windows.Forms.Padding(5);
         this.tabRouteNotes.Size = new System.Drawing.Size(407, 369);
         this.tabRouteNotes.Text = "Notes";
         // 
         // txtNotes
         // 
         this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtNotes.Location = new System.Drawing.Point(5, 5);
         this.txtNotes.Name = "txtNotes";
         this.txtNotes.Size = new System.Drawing.Size(397, 359);
         this.txtNotes.TabIndex = 204;
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(350, 415);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOk
         // 
         this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOk.Location = new System.Drawing.Point(269, 415);
         this.cmdOk.Name = "cmdOk";
         this.cmdOk.Size = new System.Drawing.Size(75, 23);
         this.cmdOk.TabIndex = 100;
         this.cmdOk.Text = "OK";
         this.cmdOk.Click += new System.EventHandler(this.CmdOk_Click);
         // 
         // RouteEditorView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(437, 450);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.cmdOk);
         this.Controls.Add(this.tabDecoder);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RouteEditorView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Route properties";
         this.Shown += new System.EventHandler(this.RouteEditorView_Shown);
         ((System.ComponentModel.ISupportInitialize)(this.tabDecoder)).EndInit();
         this.tabDecoder.ResumeLayout(false);
         this.tabRouteGeneral.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneralProperties)).EndInit();
         this.grpGeneralProperties.ResumeLayout(false);
         this.grpGeneralProperties.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spnSwitchTime.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpGeneral)).EndInit();
         this.grpGeneral.ResumeLayout(false);
         this.grpGeneral.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         this.tabRouteBlock.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chkIsBlock.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpBlockBehaviour)).EndInit();
         this.grpBlockBehaviour.ResumeLayout(false);
         this.grpBlockBehaviour.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboAction.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpBlockConnections)).EndInit();
         this.grpBlockConnections.ResumeLayout(false);
         this.grpBlockConnections.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkBidirectional.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBlockTo.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboBlockFrom.Properties)).EndInit();
         this.tabRouteConnections.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).EndInit();
         this.tabRouteNotes.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
         this.ResumeLayout(false);

      }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabDecoder;
        private DevExpress.XtraTab.XtraTabPage tabRouteGeneral;
        private DevExpress.XtraEditors.GroupControl grpBlockBehaviour;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboAction;
        private DevExpress.XtraEditors.LabelControl lblAction;
        private DevExpress.XtraEditors.GroupControl grpGeneral;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraTab.XtraTabPage tabRouteConnections;
        private DevExpress.XtraGrid.GridControl grdConnect;
        private DevExpress.XtraGrid.Views.Grid.GridView grdConnectView;
        private DevExpress.XtraTab.XtraTabPage tabRouteNotes;
        private DevExpress.XtraEditors.MemoEdit txtNotes;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.SimpleButton cmdOk;
        private DevExpress.XtraTab.XtraTabPage tabRouteBlock;
        private DevExpress.XtraEditors.GroupControl grpBlockConnections;
        private DevExpress.XtraEditors.CheckEdit chkBidirectional;
        private DevExpress.XtraEditors.LabelControl txtBlockTo;
        private Controls.ElementImageComboBoxEdit cboBlockTo;
        private DevExpress.XtraEditors.LabelControl txtBlockFrom;
        private Controls.ElementImageComboBoxEdit cboBlockFrom;
        private DevExpress.XtraEditors.CheckEdit chkIsBlock;
        private DevExpress.XtraEditors.GroupControl grpGeneralProperties;
        private DevExpress.XtraEditors.LabelControl lblSwitchTimeUnits;
        private DevExpress.XtraEditors.SpinEdit spnSwitchTime;
        private DevExpress.XtraEditors.LabelControl lblSwitchTime;
    }
}