namespace Rwm.Studio.Plugins.Designer.Controls
{
   partial class ActivateRouteActionControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivateRouteActionControl));
         this.grpProperties = new DevExpress.XtraEditors.GroupControl();
         this.cboRoute = new DevExpress.XtraEditors.ImageComboBoxEdit();
         this.lblRoute = new DevExpress.XtraEditors.LabelControl();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.grpProperties)).BeginInit();
         this.grpProperties.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboRoute.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // grpProperties
         // 
         this.grpProperties.Controls.Add(this.cboRoute);
         this.grpProperties.Controls.Add(this.lblRoute);
         this.grpProperties.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grpProperties.Location = new System.Drawing.Point(0, 0);
         this.grpProperties.Name = "grpProperties";
         this.grpProperties.Padding = new System.Windows.Forms.Padding(10);
         this.grpProperties.Size = new System.Drawing.Size(347, 74);
         this.grpProperties.TabIndex = 0;
         this.grpProperties.Text = "Properties";
         // 
         // cboRoute
         // 
         this.cboRoute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.cboRoute.Location = new System.Drawing.Point(64, 33);
         this.cboRoute.Name = "cboRoute";
         this.cboRoute.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboRoute.Properties.SmallImages = this.imageList;
         this.cboRoute.Size = new System.Drawing.Size(268, 20);
         this.cboRoute.TabIndex = 1;
         // 
         // lblRoute
         // 
         this.lblRoute.Location = new System.Drawing.Point(15, 36);
         this.lblRoute.Name = "lblRoute";
         this.lblRoute.Size = new System.Drawing.Size(29, 13);
         this.lblRoute.TabIndex = 0;
         this.lblRoute.Text = "Route";
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "ICO_ROUTE");
         // 
         // ActivateRouteActionControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpProperties);
         this.Name = "ActivateRouteActionControl";
         this.Size = new System.Drawing.Size(347, 74);
         ((System.ComponentModel.ISupportInitialize)(this.grpProperties)).EndInit();
         this.grpProperties.ResumeLayout(false);
         this.grpProperties.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboRoute.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.GroupControl grpProperties;
      private DevExpress.XtraEditors.ImageComboBoxEdit cboRoute;
      private DevExpress.XtraEditors.LabelControl lblRoute;
      private System.Windows.Forms.ImageList imageList;
   }
}
