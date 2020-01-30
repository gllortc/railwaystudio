using RailwayStudio.Common;
using Rwm.Otc.LayoutControl;
using Rwm.Otc.LayoutControl.Actions;
using Rwm.Otc.LayoutControl.Blocks;
using Rwm.Studio.Plugins.Control.Views;
using System.Data;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class AccessoryConnectionManagerControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryConnectionManagerControl"/>.
      /// </summary>
      /// <remarks>Constructor used only for design pourposes. Do not use in production.</remarks>
      public AccessoryConnectionManagerControl()
      {
         InitializeComponent();
         Initialize();
      }

      /// <summary>
      /// Returns a new instance of <see cref="AccessoryConnectionManagerControl"/>.
      /// </summary>
      /// <param name="ownerBlock">Owner block.</param>
      public AccessoryConnectionManagerControl(BlockBase ownerBlock)
      {
         InitializeComponent();
         Initialize();

         this.OwnerBlock = ownerBlock;

         this.Refresh();
      }

      #endregion

      #region Properties

      internal BlockBase OwnerBlock { get; private set; }

      #endregion

      #region Methods

      public override void Refresh()
      {
         try
         {
            grdData.BeginUpdate();
            grdData.DataSource = null;
            grdData.DataSource = Project.ControlModuleConnectionManager.FindByBlock(this.OwnerBlock, ControlModule.ModuleType.Accessory);
            grdDataView.Columns[0].Visible = false;
            grdDataView.Columns[1].Visible = false;
            grdData.EndUpdate();
         }
         catch (System.Exception ex)
         {
            MessageBox.Show("ERROR laoding data: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         base.Refresh();
      }

      #endregion

      #region Event Handlers

      private void grdDataView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         if (e.Column == grdDataView.Columns[1])
         {
            DataRowView drv = grdDataView.GetRow(e.RowHandle) as DataRowView;
            if (drv != null)
            {
               BlockAction action = BlockAction.CreateActionInstance(drv[4].ToString());
               StudioContext.UI.DrawRowIcon(action.Icon, e);
            }
         }
      }

      private void cmdConnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.Connect();
      }

      private void cmdDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.Disconnect();
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         this.OwnerBlock = null;
      }


      private void Connect()
      {
         ControlModuleConnection connection = null;
         FrmConnectionEditor form = null;

         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the connection you want to connect.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            DataRowView drv = grdDataView.GetRow(grdDataView.GetSelectedRows()[0]) as DataRowView;
            if (drv != null)
            {
               connection = Project.ControlModuleConnectionManager.GetByID((System.Int32)drv[0]);
               if (connection != null)
               {
                  form = new FrmConnectionEditor((System.Int32)drv[1], this.OwnerBlock, connection);
               }
               else
               {
                  form = new FrmConnectionEditor((System.Int32)drv[1], this.OwnerBlock);
               }

               form.ShowDialog(this);
               if (form.DialogResult == DialogResult.OK)
               {
                  this.Refresh();
               }
            }
         }
         catch (System.Exception ex)
         {
            MessageBox.Show("ERROR loading data: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void Disconnect()
      {
         ControlModuleConnection connection = null;

         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the connection you want to disconnect.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            DataRowView drv = grdDataView.GetRow(grdDataView.GetSelectedRows()[0]) as DataRowView;
            if (drv != null)
            {
               connection = Project.ControlModuleConnectionManager.GetByID((System.Int32)drv[0]);
               if (connection != null)
               {
                  if (MessageBox.Show("Are you sure you want to disconnect the selected connection?",
                                  Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                  {
                     return;
                  }

                  Project.ControlModuleConnectionManager.Unassign(connection.ID);

                  this.Refresh();
               }
               else
               {
                  MessageBox.Show("The connection cannot be read from current project and cannot be disconnected.",
                                  Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }
         catch (System.Exception ex)
         {
            MessageBox.Show("ERROR storing data: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}
