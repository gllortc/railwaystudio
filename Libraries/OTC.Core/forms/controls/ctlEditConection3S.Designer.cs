namespace otc
{
   partial class ctlEditConection3S
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlEditConection3S));
         this.label1 = new System.Windows.Forms.Label();
         this.lstOptions = new DevExpress.XtraEditors.ImageListBoxControl();
         this.imlIcons = new System.Windows.Forms.ImageList(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.lstOptions)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(2, 3);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(152, 30);
         this.label1.TabIndex = 3;
         this.label1.Text = "Conexión a las dos salidas del decoder de accesorios:";
         // 
         // lstOptions
         // 
         this.lstOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.lstOptions.ImageList = this.imlIcons;
         this.lstOptions.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Conexión 1", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Conexión 2", 1),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Conexión 3", 2),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Conexión 4", 3)});
         this.lstOptions.Location = new System.Drawing.Point(5, 36);
         this.lstOptions.Name = "lstOptions";
         this.lstOptions.Size = new System.Drawing.Size(149, 100);
         this.lstOptions.TabIndex = 2;
         // 
         // imlIcons
         // 
         this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
         this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
         this.imlIcons.Images.SetKeyName(0, "signal_3s_connection1.png");
         this.imlIcons.Images.SetKeyName(1, "signal_3s_connection2.png");
         this.imlIcons.Images.SetKeyName(2, "signal_3s_connection3.png");
         this.imlIcons.Images.SetKeyName(3, "signal_3s_connection4.png");
         // 
         // ctlEditConection3S
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.label1);
         this.Controls.Add(this.lstOptions);
         this.Name = "ctlEditConection3S";
         this.Padding = new System.Windows.Forms.Padding(5);
         this.Size = new System.Drawing.Size(159, 141);
         ((System.ComponentModel.ISupportInitialize)(this.lstOptions)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private DevExpress.XtraEditors.ImageListBoxControl lstOptions;
      private System.Windows.Forms.ImageList imlIcons;
   }
}
