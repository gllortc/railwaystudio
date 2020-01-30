namespace RailwayStudio.Common.Views
{
   partial class FindTrainView
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
         this.cmdAccept = new DevExpress.XtraEditors.SimpleButton();
         this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
         this.grdTrain = new DevExpress.XtraGrid.GridControl();
         this.grdTrainView = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.chkShowAll = new DevExpress.XtraEditors.CheckEdit();
         ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdTrainView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkShowAll.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // cmdAccept
         // 
         this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdAccept.Location = new System.Drawing.Point(259, 315);
         this.cmdAccept.Name = "cmdAccept";
         this.cmdAccept.Size = new System.Drawing.Size(75, 23);
         this.cmdAccept.TabIndex = 202;
         this.cmdAccept.Text = "Accept";
         this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
         // 
         // cmdCancel
         // 
         this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cmdCancel.Location = new System.Drawing.Point(340, 315);
         this.cmdCancel.Name = "cmdCancel";
         this.cmdCancel.Size = new System.Drawing.Size(75, 23);
         this.cmdCancel.TabIndex = 203;
         this.cmdCancel.Text = "Cancel";
         this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
         // 
         // grdTrain
         // 
         this.grdTrain.Dock = System.Windows.Forms.DockStyle.Top;
         this.grdTrain.Location = new System.Drawing.Point(0, 0);
         this.grdTrain.MainView = this.grdTrainView;
         this.grdTrain.Name = "grdTrain";
         this.grdTrain.Size = new System.Drawing.Size(427, 309);
         this.grdTrain.TabIndex = 204;
         this.grdTrain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdTrainView});
         // 
         // grdTrainView
         // 
         this.grdTrainView.GridControl = this.grdTrain;
         this.grdTrainView.Name = "grdTrainView";
         this.grdTrainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdTrainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdTrainView.OptionsBehavior.Editable = false;
         this.grdTrainView.OptionsBehavior.ReadOnly = true;
         this.grdTrainView.OptionsCustomization.AllowColumnMoving = false;
         this.grdTrainView.OptionsCustomization.AllowGroup = false;
         this.grdTrainView.OptionsFind.AlwaysVisible = true;
         this.grdTrainView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdTrainView.OptionsSelection.EnableAppearanceFocusedRow = false;
         this.grdTrainView.OptionsView.ShowGroupPanel = false;
         this.grdTrainView.OptionsView.ShowIndicator = false;
         this.grdTrainView.RowHeight = 45;
         this.grdTrainView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdTrainView_RowStyle);
         // 
         // chkShowAll
         // 
         this.chkShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.chkShowAll.Location = new System.Drawing.Point(12, 319);
         this.chkShowAll.Name = "chkShowAll";
         this.chkShowAll.Properties.Caption = "Show assigned trains";
         this.chkShowAll.Size = new System.Drawing.Size(241, 19);
         this.chkShowAll.TabIndex = 205;
         this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
         // 
         // FindTrainView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(427, 350);
         this.Controls.Add(this.chkShowAll);
         this.Controls.Add(this.grdTrain);
         this.Controls.Add(this.cmdAccept);
         this.Controls.Add(this.cmdCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FindTrainView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Find train";
         this.Load += new System.EventHandler(this.FindTrainView_Load);
         ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdTrainView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkShowAll.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton cmdAccept;
      private DevExpress.XtraEditors.SimpleButton cmdCancel;
      private DevExpress.XtraGrid.GridControl grdTrain;
      private DevExpress.XtraGrid.Views.Grid.GridView grdTrainView;
      private DevExpress.XtraEditors.CheckEdit chkShowAll;
   }
}