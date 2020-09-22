namespace Rwm.Studio.Plugins.Designer.Controls
{
   partial class FeedbackTesterControl
   {
      /// <summary> 
      /// Variable del diseñador necesaria.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Limpiar los recursos que se estén usando.
      /// </summary>
      /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Código generado por el Diseñador de componentes

      /// <summary> 
      /// Método necesario para admitir el Diseñador. No se puede modificar
      /// el contenido de este método con el editor de código.
      /// </summary>
      private void InitializeComponent()
      {
         this.grdFeedback = new DevExpress.XtraGrid.GridControl();
         this.grdFeedbackView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.grdFeedback)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdFeedbackView)).BeginInit();
         this.SuspendLayout();
         // 
         // grdFeedback
         // 
         this.grdFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdFeedback.Location = new System.Drawing.Point(0, 0);
         this.grdFeedback.MainView = this.grdFeedbackView;
         this.grdFeedback.Name = "grdFeedback";
         this.grdFeedback.Size = new System.Drawing.Size(665, 474);
         this.grdFeedback.TabIndex = 1;
         this.grdFeedback.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdFeedbackView});
         // 
         // grdFeedbackView
         // 
         this.grdFeedbackView.GridControl = this.grdFeedback;
         this.grdFeedbackView.Name = "grdFeedbackView";
         this.grdFeedbackView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdFeedbackView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdFeedbackView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
         this.grdFeedbackView.OptionsBehavior.AutoPopulateColumns = false;
         this.grdFeedbackView.OptionsBehavior.Editable = false;
         this.grdFeedbackView.OptionsBehavior.ReadOnly = true;
         this.grdFeedbackView.OptionsCustomization.AllowColumnMoving = false;
         this.grdFeedbackView.OptionsCustomization.AllowColumnResizing = false;
         this.grdFeedbackView.OptionsCustomization.AllowFilter = false;
         this.grdFeedbackView.OptionsCustomization.AllowGroup = false;
         this.grdFeedbackView.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
         this.grdFeedbackView.OptionsCustomization.AllowQuickHideColumns = false;
         this.grdFeedbackView.OptionsCustomization.AllowSort = false;
         this.grdFeedbackView.OptionsDetail.AllowZoomDetail = false;
         this.grdFeedbackView.OptionsDetail.EnableMasterViewMode = false;
         this.grdFeedbackView.OptionsDetail.ShowDetailTabs = false;
         this.grdFeedbackView.OptionsDetail.SmartDetailExpand = false;
         this.grdFeedbackView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
         this.grdFeedbackView.OptionsFilter.AllowColumnMRUFilterList = false;
         this.grdFeedbackView.OptionsFilter.AllowFilterEditor = false;
         this.grdFeedbackView.OptionsFilter.AllowFilterIncrementalSearch = false;
         this.grdFeedbackView.OptionsFilter.AllowMRUFilterList = false;
         this.grdFeedbackView.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
         this.grdFeedbackView.OptionsFind.AllowFindPanel = false;
         this.grdFeedbackView.OptionsMenu.EnableColumnMenu = false;
         this.grdFeedbackView.OptionsMenu.EnableFooterMenu = false;
         this.grdFeedbackView.OptionsMenu.EnableGroupPanelMenu = false;
         this.grdFeedbackView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdFeedbackView.OptionsView.ShowDetailButtons = false;
         this.grdFeedbackView.OptionsView.ShowGroupExpandCollapseButtons = false;
         this.grdFeedbackView.OptionsView.ShowGroupPanel = false;
         this.grdFeedbackView.OptionsView.ShowIndicator = false;
         // 
         // FeedbackTesterControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grdFeedback);
         this.Name = "FeedbackTesterControl";
         this.Size = new System.Drawing.Size(665, 474);
         ((System.ComponentModel.ISupportInitialize)(this.grdFeedback)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdFeedbackView)).EndInit();
         this.ResumeLayout(false);

      }

        #endregion

        private DevExpress.XtraGrid.GridControl grdFeedback;
        private DevExpress.XtraGrid.Views.Grid.GridView grdFeedbackView;
    }
}
