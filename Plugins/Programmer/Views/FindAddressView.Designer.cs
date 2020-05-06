namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class FindAddressView
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
         this.grdAddress = new DevExpress.XtraGrid.GridControl();
         this.grdAddressView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.grdAddress)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAddressView)).BeginInit();
         this.SuspendLayout();
         // 
         // grdAddress
         // 
         this.grdAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.grdAddress.Location = new System.Drawing.Point(12, 12);
         this.grdAddress.MainView = this.grdAddressView;
         this.grdAddress.Name = "grdAddress";
         this.grdAddress.Size = new System.Drawing.Size(412, 397);
         this.grdAddress.TabIndex = 0;
         this.grdAddress.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAddressView});
         // 
         // grdAddressView
         // 
         this.grdAddressView.GridControl = this.grdAddress;
         this.grdAddressView.Name = "grdAddressView";
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.Location = new System.Drawing.Point(349, 415);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 1;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(268, 415);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 2;
         this.cmdAccept.Text = "OK";
         this.cmdAccept.Click += new System.EventHandler(this.CmdAccept_Click);
         // 
         // FindAddressView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(436, 450);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.Controls.Add(this.grdAddress);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FindAddressView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "FindAddressView";
         ((System.ComponentModel.ISupportInitialize)(this.grdAddress)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdAddressView)).EndInit();
         this.ResumeLayout(false);

      }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAddress;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAddressView;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.SimpleButton cmdAccept;
    }
}