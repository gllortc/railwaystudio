namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class DesignToolboxControl
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
         this.tabControl = new DevExpress.XtraTab.XtraTabControl();
         this.tabControlAccessories = new DevExpress.XtraTab.XtraTabPage();
         this.tabControlSound = new DevExpress.XtraTab.XtraTabPage();
         this.tabControlFeedback = new DevExpress.XtraTab.XtraTabPage();
         ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
         this.tabControl.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl
         // 
         this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
         this.tabControl.Location = new System.Drawing.Point(0, 0);
         this.tabControl.Name = "tabControl";
         this.tabControl.SelectedTabPage = this.tabControlAccessories;
         this.tabControl.Size = new System.Drawing.Size(311, 477);
         this.tabControl.TabIndex = 0;
         this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabControlAccessories,
            this.tabControlFeedback,
            this.tabControlSound});
         // 
         // tabControlModules
         // 
         this.tabControlAccessories.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_ACC_16;
         this.tabControlAccessories.Name = "tabControlModules";
         this.tabControlAccessories.Size = new System.Drawing.Size(305, 446);
         // 
         // tabControlSound
         // 
         this.tabControlSound.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_SOUND_16;
         this.tabControlSound.Name = "tabControlSound";
         this.tabControlSound.Size = new System.Drawing.Size(305, 446);
         // 
         // tabControlFeedback
         // 
         this.tabControlFeedback.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_MODULE_SENSOR_16;
         this.tabControlFeedback.Name = "tabControlFeedback";
         this.tabControlFeedback.Size = new System.Drawing.Size(0, 0);
         // 
         // DesignToolboxControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tabControl);
         this.Name = "DesignToolboxControl";
         this.Size = new System.Drawing.Size(311, 477);
         ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
         this.tabControl.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraTab.XtraTabControl tabControl;
      private DevExpress.XtraTab.XtraTabPage tabControlAccessories;
      private DevExpress.XtraTab.XtraTabPage tabControlSound;
        private DevExpress.XtraTab.XtraTabPage tabControlFeedback;
    }
}
