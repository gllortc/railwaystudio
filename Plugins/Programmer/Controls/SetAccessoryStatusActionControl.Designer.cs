namespace Rwm.Studio.Plugins.Designer.Controls
{
   partial class SetAccessoryStatusActionControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetAccessoryStatusActionControl));
         this.grpProperties = new DevExpress.XtraEditors.GroupControl();
         this.cboElement = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.imlElements = new System.Windows.Forms.ImageList(this.components);
         this.lblElement = new DevExpress.XtraEditors.LabelControl();
         this.cboStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.lblStatus = new DevExpress.XtraEditors.LabelControl();
         this.imlStatus = new System.Windows.Forms.ImageList(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.grpProperties)).BeginInit();
         this.grpProperties.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboElement.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // grpProperties
         // 
         this.grpProperties.Controls.Add(this.cboStatus);
         this.grpProperties.Controls.Add(this.lblStatus);
         this.grpProperties.Controls.Add(this.cboElement);
         this.grpProperties.Controls.Add(this.lblElement);
         this.grpProperties.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grpProperties.Location = new System.Drawing.Point(0, 0);
         this.grpProperties.Name = "grpProperties";
         this.grpProperties.Padding = new System.Windows.Forms.Padding(10);
         this.grpProperties.Size = new System.Drawing.Size(347, 99);
         this.grpProperties.TabIndex = 0;
         this.grpProperties.Text = "Action parameters";
         // 
         // cboBlock
         // 
         this.cboElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboElement.Location = new System.Drawing.Point(88, 33);
         this.cboElement.Name = "cboElement";
         this.cboElement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboElement.Properties.SmallImages = this.imlElements;
         this.cboElement.Size = new System.Drawing.Size(244, 20);
         this.cboElement.TabIndex = 1;
         this.cboElement.SelectedIndexChanged += new System.EventHandler(this.cboSound_SelectedIndexChanged);
         // 
         // imlBlocks
         // 
         this.imlElements.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
         this.imlElements.ImageSize = new System.Drawing.Size(16, 16);
         this.imlElements.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // lblBlock
         // 
         this.lblElement.Location = new System.Drawing.Point(15, 36);
         this.lblElement.Name = "lblElement";
         this.lblElement.Size = new System.Drawing.Size(24, 13);
         this.lblElement.TabIndex = 0;
         this.lblElement.Text = "Element";
         // 
         // cboStatus
         // 
         this.cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboStatus.Location = new System.Drawing.Point(88, 59);
         this.cboStatus.Name = "cboStatus";
         this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboStatus.Properties.SmallImages = this.imlStatus;
         this.cboStatus.Size = new System.Drawing.Size(244, 20);
         this.cboStatus.TabIndex = 3;
         // 
         // lblStatus
         // 
         this.lblStatus.Location = new System.Drawing.Point(15, 62);
         this.lblStatus.Name = "lblStatus";
         this.lblStatus.Size = new System.Drawing.Size(62, 13);
         this.lblStatus.TabIndex = 2;
         this.lblStatus.Text = "Set to status";
         // 
         // imlStatus
         // 
         this.imlStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlStatus.ImageStream")));
         this.imlStatus.TransparentColor = System.Drawing.Color.Transparent;
         this.imlStatus.Images.SetKeyName(0, "ICO_SOUND");
         // 
         // SetAccessoryStatusActionControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpProperties);
         this.Name = "SetAccessoryStatusActionControl";
         this.Size = new System.Drawing.Size(347, 99);
         ((System.ComponentModel.ISupportInitialize)(this.grpProperties)).EndInit();
         this.grpProperties.ResumeLayout(false);
         this.grpProperties.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboElement.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.GroupControl grpProperties;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboElement;
      private DevExpress.XtraEditors.LabelControl lblElement;
      private System.Windows.Forms.ImageList imlElements;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboStatus;
      private DevExpress.XtraEditors.LabelControl lblStatus;
      private System.Windows.Forms.ImageList imlStatus;
   }
}
