namespace Rwm.Studio.Plugins.Designer.Controls
{
   partial class PlaySoundActionControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaySoundActionControl));
         this.grpProperties = new DevExpress.XtraEditors.GroupControl();
         this.cboSound = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.lblSound = new DevExpress.XtraEditors.LabelControl();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.grpProperties)).BeginInit();
         this.grpProperties.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboSound.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // grpProperties
         // 
         this.grpProperties.Controls.Add(this.cboSound);
         this.grpProperties.Controls.Add(this.lblSound);
         this.grpProperties.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grpProperties.Location = new System.Drawing.Point(0, 0);
         this.grpProperties.Name = "grpProperties";
         this.grpProperties.Padding = new System.Windows.Forms.Padding(10);
         this.grpProperties.Size = new System.Drawing.Size(347, 74);
         this.grpProperties.TabIndex = 0;
         this.grpProperties.Text = "Action parameters";
         // 
         // cboSound
         // 
         this.cboSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboSound.Location = new System.Drawing.Point(64, 33);
         this.cboSound.Name = "cboSound";
         this.cboSound.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboSound.Properties.SmallImages = this.imageList;
         this.cboSound.Size = new System.Drawing.Size(268, 20);
         this.cboSound.TabIndex = 1;
         // 
         // lblSound
         // 
         this.lblSound.Location = new System.Drawing.Point(15, 36);
         this.lblSound.Name = "lblSound";
         this.lblSound.Size = new System.Drawing.Size(30, 13);
         this.lblSound.TabIndex = 0;
         this.lblSound.Text = "Sound";
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "ICO_SOUND");
         // 
         // PlaySoundActionControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpProperties);
         this.Name = "PlaySoundActionControl";
         this.Size = new System.Drawing.Size(347, 74);
         ((System.ComponentModel.ISupportInitialize)(this.grpProperties)).EndInit();
         this.grpProperties.ResumeLayout(false);
         this.grpProperties.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboSound.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.GroupControl grpProperties;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboSound;
      private DevExpress.XtraEditors.LabelControl lblSound;
      private System.Windows.Forms.ImageList imageList;
   }
}
