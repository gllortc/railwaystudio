namespace Rwm.Studio.Plugins.Control.Views
{
   partial class SwitchboardEditorView
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
         this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.lblName = new DevExpress.XtraEditors.LabelControl();
         this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.txtWidth = new DevExpress.XtraEditors.SpinEdit();
         this.txtHeight = new DevExpress.XtraEditors.SpinEdit();
         this.lblWidth = new DevExpress.XtraEditors.LabelControl();
         this.lblHeight = new DevExpress.XtraEditors.LabelControl();
         this.lblColumns = new DevExpress.XtraEditors.LabelControl();
         this.lblRows = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtWidth.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtHeight.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdOk
         // 
         this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOk.Location = new System.Drawing.Point(218, 274);
         this.cmdOk.Name = "cmdOk";
         this.cmdOk.Size = new System.Drawing.Size(75, 23);
         this.cmdOk.TabIndex = 100;
         this.cmdOk.Text = "OK";
         this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(299, 274);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 200;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // txtName
         // 
         this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtName.Location = new System.Drawing.Point(60, 12);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(314, 20);
         this.txtName.TabIndex = 1;
         // 
         // lblName
         // 
         this.lblName.Location = new System.Drawing.Point(12, 15);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(27, 13);
         this.lblName.TabIndex = 0;
         this.lblName.Text = "Name";
         // 
         // txtNotes
         // 
         this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtNotes.Location = new System.Drawing.Point(60, 38);
         this.txtNotes.Name = "txtNotes";
         this.txtNotes.Size = new System.Drawing.Size(314, 178);
         this.txtNotes.TabIndex = 3;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(12, 40);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(28, 13);
         this.labelControl1.TabIndex = 2;
         this.labelControl1.Text = "Notes";
         // 
         // txtWidth
         // 
         this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.txtWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtWidth.Location = new System.Drawing.Point(60, 222);
         this.txtWidth.Name = "txtWidth";
         this.txtWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtWidth.Size = new System.Drawing.Size(71, 20);
         this.txtWidth.TabIndex = 5;
         // 
         // txtHeight
         // 
         this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.txtHeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtHeight.Location = new System.Drawing.Point(60, 248);
         this.txtHeight.Name = "txtHeight";
         this.txtHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.txtHeight.Size = new System.Drawing.Size(71, 20);
         this.txtHeight.TabIndex = 8;
         // 
         // lblWidth
         // 
         this.lblWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.lblWidth.Location = new System.Drawing.Point(12, 225);
         this.lblWidth.Name = "lblWidth";
         this.lblWidth.Size = new System.Drawing.Size(28, 13);
         this.lblWidth.TabIndex = 4;
         this.lblWidth.Text = "Width";
         // 
         // lblHeight
         // 
         this.lblHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.lblHeight.Location = new System.Drawing.Point(12, 251);
         this.lblHeight.Name = "lblHeight";
         this.lblHeight.Size = new System.Drawing.Size(31, 13);
         this.lblHeight.TabIndex = 7;
         this.lblHeight.Text = "Height";
         // 
         // lblColumns
         // 
         this.lblColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.lblColumns.Location = new System.Drawing.Point(137, 225);
         this.lblColumns.Name = "lblColumns";
         this.lblColumns.Size = new System.Drawing.Size(38, 13);
         this.lblColumns.TabIndex = 6;
         this.lblColumns.Text = "columns";
         // 
         // lblRows
         // 
         this.lblRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.lblRows.Location = new System.Drawing.Point(137, 251);
         this.lblRows.Name = "lblRows";
         this.lblRows.Size = new System.Drawing.Size(23, 13);
         this.lblRows.TabIndex = 9;
         this.lblRows.Text = "rows";
         // 
         // SwitchboardEditorView
         // 
         this.AcceptButton = this.cmdOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(386, 309);
         this.Controls.Add(this.lblRows);
         this.Controls.Add(this.lblColumns);
         this.Controls.Add(this.lblHeight);
         this.Controls.Add(this.lblWidth);
         this.Controls.Add(this.txtHeight);
         this.Controls.Add(this.txtWidth);
         this.Controls.Add(this.labelControl1);
         this.Controls.Add(this.txtNotes);
         this.Controls.Add(this.lblName);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.cmdOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SwitchboardEditorView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Switchboard editor";
         this.Activated += new System.EventHandler(this.FrmPanelEditor_Activated);
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtWidth.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtHeight.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdOk;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl lblName;
      private DevExpress.XtraEditors.MemoEdit txtNotes;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.SpinEdit txtWidth;
      private DevExpress.XtraEditors.SpinEdit txtHeight;
      private DevExpress.XtraEditors.LabelControl lblWidth;
      private DevExpress.XtraEditors.LabelControl lblHeight;
      private DevExpress.XtraEditors.LabelControl lblColumns;
      private DevExpress.XtraEditors.LabelControl lblRows;
   }
}