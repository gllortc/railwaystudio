namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class FeedbackConnectionFindView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackConnectionFindView));
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.chkShowAll = new DevExpress.XtraEditors.CheckEdit();
         this.tvwOutputs = new DevExpress.XtraTreeList.TreeList();
         ((System.ComponentModel.ISupportInitialize)(this.chkShowAll.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tvwOutputs)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(460, 413);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 0;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdOK
         // 
         this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdOK.Enabled = false;
         this.cmdOK.Location = new System.Drawing.Point(379, 413);
         this.cmdOK.Name = "cmdOK";
         this.cmdOK.Size = new System.Drawing.Size(75, 23);
         this.cmdOK.TabIndex = 1;
         this.cmdOK.Text = "OK";
         this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
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
         // chkShowAll
         // 
         this.chkShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.chkShowAll.Location = new System.Drawing.Point(12, 417);
         this.chkShowAll.Name = "chkShowAll";
         this.chkShowAll.Properties.Caption = "Show all otputs";
         this.chkShowAll.Size = new System.Drawing.Size(124, 19);
         this.chkShowAll.TabIndex = 219;
         this.chkShowAll.CheckedChanged += new System.EventHandler(this.ChkShowAll_CheckedChanged);
         // 
         // tvwOutputs
         // 
         this.tvwOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tvwOutputs.Location = new System.Drawing.Point(12, 12);
         this.tvwOutputs.Name = "tvwOutputs";
         this.tvwOutputs.OptionsBehavior.Editable = false;
         this.tvwOutputs.OptionsBehavior.ReadOnly = true;
         this.tvwOutputs.OptionsFind.AlwaysVisible = true;
         this.tvwOutputs.OptionsMenu.EnableColumnMenu = false;
         this.tvwOutputs.OptionsMenu.EnableFooterMenu = false;
         this.tvwOutputs.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.tvwOutputs.OptionsView.ShowIndicator = false;
         this.tvwOutputs.Size = new System.Drawing.Size(523, 395);
         this.tvwOutputs.TabIndex = 220;
         this.tvwOutputs.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.TvwOutputs_NodeCellStyle);
         this.tvwOutputs.Click += new System.EventHandler(this.TvwOutputs_Click);
         // 
         // AccesoryConnectionFindView
         // 
         this.AcceptButton = this.cmdOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cmdCancel;
         this.ClientSize = new System.Drawing.Size(547, 448);
         this.Controls.Add(this.tvwOutputs);
         this.Controls.Add(this.chkShowAll);
         this.Controls.Add(this.cmdOK);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AccesoryConnectionFindView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Connect accessory input to a decoder output";
         ((System.ComponentModel.ISupportInitialize)(this.chkShowAll.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tvwOutputs)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraEditors.SimpleButton cmdOK;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraEditors.CheckEdit chkShowAll;
      private DevExpress.XtraTreeList.TreeList tvwOutputs;
   }
}