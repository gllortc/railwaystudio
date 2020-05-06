namespace Rwm.Studio.Plugins.Designer.Controls
{
   partial class AccessoryConnectionsControl
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
         this.grdConnect = new DevExpress.XtraGrid.GridControl();
         this.grdConnectView = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).BeginInit();
         this.SuspendLayout();
         // 
         // grdConnect
         // 
         this.grdConnect.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdConnect.Location = new System.Drawing.Point(0, 0);
         this.grdConnect.MainView = this.grdConnectView;
         this.grdConnect.Name = "grdConnect";
         this.grdConnect.Size = new System.Drawing.Size(386, 252);
         this.grdConnect.TabIndex = 0;
         this.grdConnect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdConnectView});
         // 
         // grdConnectView
         // 
         this.grdConnectView.GridControl = this.grdConnect;
         this.grdConnectView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
         this.grdConnectView.Name = "grdConnectView";
         this.grdConnectView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdConnectView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
         this.grdConnectView.OptionsCustomization.AllowColumnMoving = false;
         this.grdConnectView.OptionsCustomization.AllowFilter = false;
         this.grdConnectView.OptionsCustomization.AllowGroup = false;
         this.grdConnectView.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
         this.grdConnectView.OptionsCustomization.AllowQuickHideColumns = false;
         this.grdConnectView.OptionsCustomization.AllowSort = false;
         this.grdConnectView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
         this.grdConnectView.OptionsFilter.AllowFilterEditor = false;
         this.grdConnectView.OptionsFind.AllowFindPanel = false;
         this.grdConnectView.OptionsMenu.EnableColumnMenu = false;
         this.grdConnectView.OptionsMenu.EnableFooterMenu = false;
         this.grdConnectView.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdConnectView.OptionsView.ColumnAutoWidth = false;
         this.grdConnectView.OptionsView.ShowDetailButtons = false;
         this.grdConnectView.OptionsView.ShowGroupExpandCollapseButtons = false;
         this.grdConnectView.OptionsView.ShowGroupPanel = false;
         this.grdConnectView.OptionsView.ShowIndicator = false;
         // 
         // ElementConnectionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grdConnect);
         this.Name = "ElementConnectionsControl";
         this.Size = new System.Drawing.Size(386, 252);
         ((System.ComponentModel.ISupportInitialize)(this.grdConnect)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdConnectView)).EndInit();
         this.ResumeLayout(false);

      }

        #endregion

        private DevExpress.XtraGrid.GridControl grdConnect;
        private DevExpress.XtraGrid.Views.Grid.GridView grdConnectView;
    }
}
