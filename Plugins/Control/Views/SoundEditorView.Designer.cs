namespace Rwm.Studio.Plugins.Control.Views
{
   partial class SoundEditorView
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
         this.tabBlock = new DevExpress.XtraTab.XtraTabControl();
         this.tabBlockGeneral = new DevExpress.XtraTab.XtraTabPage();
         this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
         this.lblFilename = new DevExpress.XtraEditors.LabelControl();
         this.txtFilename = new DevExpress.XtraEditors.ButtonEdit();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.tabBlock)).BeginInit();
         this.tabBlock.SuspendLayout();
         this.tabBlockGeneral.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
         this.groupControl2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtFilename.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
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
         this.tabBlock.Size = new System.Drawing.Size(387, 141);
         this.tabBlock.TabIndex = 0;
         this.tabBlock.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabBlockGeneral});
         // 
         // tabBlockGeneral
         // 
         this.tabBlockGeneral.Controls.Add(this.groupControl2);
         this.tabBlockGeneral.Name = "tabBlockGeneral";
         this.tabBlockGeneral.Padding = new System.Windows.Forms.Padding(10);
         this.tabBlockGeneral.Size = new System.Drawing.Size(381, 113);
         this.tabBlockGeneral.Text = "General";
         // 
         // groupControl2
         // 
         this.groupControl2.Controls.Add(this.lblFilename);
         this.groupControl2.Controls.Add(this.txtFilename);
         this.groupControl2.Controls.Add(this.txtName);
         this.groupControl2.Controls.Add(this.lblName);
         this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupControl2.Location = new System.Drawing.Point(10, 10);
         this.groupControl2.Name = "groupControl2";
         this.groupControl2.Padding = new System.Windows.Forms.Padding(10);
         this.groupControl2.Size = new System.Drawing.Size(361, 93);
         this.groupControl2.TabIndex = 5;
         this.groupControl2.Text = "Properties";
         // 
         // lblFilename
         // 
         this.lblFilename.Location = new System.Drawing.Point(15, 63);
         this.lblFilename.Name = "lblFilename";
         this.lblFilename.Size = new System.Drawing.Size(47, 13);
         this.lblFilename.TabIndex = 3;
         this.lblFilename.Text = "Sound file";
         // 
         // txtFilename
         // 
         this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtFilename.Location = new System.Drawing.Point(79, 60);
         this.txtFilename.Name = "txtFilename";
         this.txtFilename.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.txtFilename.Size = new System.Drawing.Size(267, 20);
         this.txtFilename.TabIndex = 2;
         this.txtFilename.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFilename_ButtonClick);
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(79, 34);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(267, 20);
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
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(324, 159);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 1;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(243, 159);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 2;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
         // 
         // FrmSoundEditor
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(411, 194);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.tabBlock);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmSoundEditor";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Sound properties";
         ((System.ComponentModel.ISupportInitialize)(this.tabBlock)).EndInit();
         this.tabBlock.ResumeLayout(false);
         this.tabBlockGeneral.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
         this.groupControl2.ResumeLayout(false);
         this.groupControl2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtFilename.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraTab.XtraTabControl tabBlock;
      private DevExpress.XtraTab.XtraTabPage tabBlockGeneral;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.GroupControl groupControl2;
      private DevExpress.XtraEditors.LabelControl lblFilename;
      private DevExpress.XtraEditors.ButtonEdit txtFilename;
   }
}