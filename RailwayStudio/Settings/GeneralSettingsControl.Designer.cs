namespace Rwm.Studio.Settings
{
   partial class GeneralSettingsControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSettingsControl));
         this.grpGui = new DevExpress.XtraEditors.GroupControl();
         this.cboSkin = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.imlIcons = new DevExpress.Utils.ImageCollection(this.components);
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.lblTitle = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.grpGui)).BeginInit();
         this.grpGui.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboSkin.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.imlIcons)).BeginInit();
         this.SuspendLayout();
         // 
         // grpGui
         // 
         this.grpGui.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grpGui.Controls.Add(this.cboSkin);
         this.grpGui.Controls.Add(this.labelControl1);
         this.grpGui.Location = new System.Drawing.Point(13, 52);
         this.grpGui.Name = "grpGui";
         this.grpGui.Padding = new System.Windows.Forms.Padding(15);
         this.grpGui.Size = new System.Drawing.Size(609, 74);
         this.grpGui.TabIndex = 0;
         this.grpGui.Text = "Visual themes";
         // 
         // cboSkin
         // 
         this.cboSkin.Location = new System.Drawing.Point(97, 35);
         this.cboSkin.Name = "cboSkin";
         this.cboSkin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboSkin.Properties.SmallImages = this.imlIcons;
         this.cboSkin.Size = new System.Drawing.Size(301, 20);
         this.cboSkin.TabIndex = 1;
         this.cboSkin.SelectedIndexChanged += new System.EventHandler(this.cboSkin_SelectedIndexChanged);
         // 
         // imlIcons
         // 
         this.imlIcons.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imlIcons.ImageStream")));
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(20, 38);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(60, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Visual theme";
         // 
         // lblTitle
         // 
         this.lblTitle.Appearance.FontSizeDelta = 3;
         this.lblTitle.Location = new System.Drawing.Point(13, 13);
         this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
         this.lblTitle.Name = "lblTitle";
         this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
         this.lblTitle.Size = new System.Drawing.Size(105, 33);
         this.lblTitle.TabIndex = 1;
         this.lblTitle.Text = "General Settings";
         // 
         // GeneralSettingsControl
         // 
         this.Appearance.BackColor = System.Drawing.Color.Transparent;
         this.Appearance.Options.UseBackColor = true;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.lblTitle);
         this.Controls.Add(this.grpGui);
         this.Name = "GeneralSettingsControl";
         this.Padding = new System.Windows.Forms.Padding(10);
         this.Size = new System.Drawing.Size(635, 525);
         ((System.ComponentModel.ISupportInitialize)(this.grpGui)).EndInit();
         this.grpGui.ResumeLayout(false);
         this.grpGui.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboSkin.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.imlIcons)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.GroupControl grpGui;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboSkin;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.Utils.ImageCollection imlIcons;
      private DevExpress.XtraEditors.LabelControl lblTitle;
   }
}
