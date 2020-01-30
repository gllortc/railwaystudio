using DevExpress.XtraGrid.Columns;
using RailwayStudio.Common;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Control.Views;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class ActionManagerControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      public ActionManagerControl()
      {
         InitializeComponent();
         Initialize();
      }

      public ActionManagerControl(Element ownerBlock)
      {
         InitializeComponent();
         Initialize();

         this.OwnerElement = ownerBlock;

         Refresh();
      }

      #endregion

      #region Properties

      internal Element OwnerElement { get; private set; }

      #endregion

      #region Methods

      public override void Refresh()
      {
         try
         {
            grdData.BeginUpdate();
            grdDataView.Columns.Clear();
            grdDataView.OptionsBehavior.AutoPopulateColumns = false;
            grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Description", Width = 200 });
            grdDataView.Columns.Add(new GridColumn() { Caption = "Type", Visible = true, FieldName = "Type", Width = 130 });
            grdData.DataSource = this.OwnerElement.Actions;
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
            ElementAction action = grdDataView.GetRow(e.RowHandle) as ElementAction;
            if (action != null)
            {
               StudioContext.UI.DrawRowIcon(action.Icon, e);
            }
         }
      }

      private void grdDataView_DoubleClick(object sender, System.EventArgs e)
      {
         this.EditAction();
      }

      private void cmdActionRoute_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.AddRouteAction();
      }

      private void cmdActionSound_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.AddSoundAction();
      }

      private void cmdActionStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.AddAccessoryAction();
      }

      private void cmdActionEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.EditAction();
      }

      private void cmdActionDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.DeleteAction();
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         this.OwnerElement = null;
      }

      private void AddRouteAction()
      {
         ElementAction action = new ElementAction();
         action.Element = this.OwnerElement;
         action.Type = ElementAction.ActionTypes.ActivateRoute;

         ActionEditorView form = new ActionEditorView(this.OwnerElement, action);
         form.ShowDialog(this);

         if (form.DialogResult == DialogResult.OK)
         {
            this.Refresh();
         }
      }

      private void AddSoundAction()
      {
         ElementAction action = new ElementAction();
         action.Element = this.OwnerElement;
         action.Type = ElementAction.ActionTypes.PlaySound;

         ActionEditorView form = new ActionEditorView(this.OwnerElement, action);
         form.ShowDialog(this);

         if (form.DialogResult == DialogResult.OK)
         {
            this.Refresh();
         }
      }

      private void AddAccessoryAction()
      {
         ElementAction action = new ElementAction();
         action.Element = this.OwnerElement;
         action.Type = ElementAction.ActionTypes.SetAccessoryStatus;

         ActionEditorView form = new ActionEditorView(this.OwnerElement, action);
         form.ShowDialog(this);

         if (form.DialogResult == DialogResult.OK)
         {
            this.Refresh();
         }
      }

      private void EditAction()
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the action you want to edit.", 
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            ElementAction action = grdDataView.GetRow(grdDataView.GetSelectedRows()[0]) as ElementAction;
            if (action != null)
            {
               ActionEditorView form = new ActionEditorView(this.OwnerElement, action);
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

      private void DeleteAction()
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the action you want to delete.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            ElementAction action = grdDataView.GetRow(grdDataView.GetSelectedRows()[0]) as ElementAction;
            if (action != null)
            {
               if (MessageBox.Show("Are you sure you want to delete the action " + action.Description + "?",
                               Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                  return;
               }

               ElementAction.Delete(action.ID);
               this.OwnerElement.Actions.Remove(action);

               this.Refresh();
            }
         }
         catch (System.Exception ex)
         {
            MessageBox.Show("ERROR removing data: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}
