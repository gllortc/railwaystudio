namespace Rwm.Studio.Plugins.Control.Views
{
   partial class FrmConnectionFinder
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConnectionFinder));
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         this.tvwConnections = new DevExpress.XtraTreeList.TreeList();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.chkShowUnused = new DevExpress.XtraEditors.CheckEdit();
         ((System.ComponentModel.ISupportInitialize)(this.tvwConnections)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkShowUnused.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(274, 312);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 0;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Location = new System.Drawing.Point(193, 312);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 1;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
         // 
         // tvwConnections
         // 
         this.tvwConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tvwConnections.Location = new System.Drawing.Point(12, 12);
         this.tvwConnections.Name = "tvwConnections";
         this.tvwConnections.OptionsBehavior.Editable = false;
         this.tvwConnections.OptionsBehavior.ReadOnly = true;
         this.tvwConnections.OptionsCustomization.AllowBandMoving = false;
         this.tvwConnections.OptionsCustomization.AllowBandResizing = false;
         this.tvwConnections.OptionsCustomization.AllowColumnMoving = false;
         this.tvwConnections.OptionsCustomization.AllowQuickHideColumns = false;
         this.tvwConnections.OptionsCustomization.ShowBandsInCustomizationForm = false;
         this.tvwConnections.OptionsMenu.EnableColumnMenu = false;
         this.tvwConnections.OptionsMenu.EnableFooterMenu = false;
         this.tvwConnections.OptionsMenu.ShowAutoFilterRowItem = false;
         this.tvwConnections.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.tvwConnections.OptionsView.ShowHorzLines = false;
         this.tvwConnections.OptionsView.ShowIndicator = false;
         this.tvwConnections.OptionsView.ShowVertLines = false;
         this.tvwConnections.Size = new System.Drawing.Size(337, 294);
         this.tvwConnections.StateImageList = this.imageList;
         this.tvwConnections.TabIndex = 2;
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "drive_lightning_16.png");
         this.imageList.Images.SetKeyName(1, "drive_light_16.png");
         this.imageList.Images.SetKeyName(2, "arrow_right_16.png");
         this.imageList.Images.SetKeyName(3, "arrow_right_occupied_16.png");
         this.imageList.Images.SetKeyName(4, "folder_16.png");
         // 
         // chkShowUnused
         // 
         this.chkShowUnused.Location = new System.Drawing.Point(12, 312);
         this.chkShowUnused.Name = "chkShowUnused";
         this.chkShowUnused.Properties.Caption = "Show unused connections only";
         this.chkShowUnused.Size = new System.Drawing.Size(175, 19);
         this.chkShowUnused.TabIndex = 3;
         this.chkShowUnused.CheckedChanged += new System.EventHandler(this.chkShowUnused_CheckedChanged);
         // 
         // FrmConnectionFinder
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(361, 347);
         this.Controls.Add(this.chkShowUnused);
         this.Controls.Add(this.tvwConnections);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmConnectionFinder";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Select module connection";
         ((System.ComponentModel.ISupportInitialize)(this.tvwConnections)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkShowUnused.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private DevExpress.XtraTreeList.TreeList tvwConnections;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraEditors.CheckEdit chkShowUnused;
   }
}