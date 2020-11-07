using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class AreasManagerView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public AreasManagerView()
      {
         InitializeComponent();

         this.ListObjects();
      }

      #endregion

      #region Event Handlers

      private void GrdAreasView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Section.SmallIcon, e);
      }

      private void GrdAreasView_DoubleClick(object sender, EventArgs e)
      {
         this.EditObject();
      }

      private void CmdAreaAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         AreaEditorView form = new AreaEditorView();
         if (form.ShowDialog(this) == DialogResult.OK)
         {
            this.ListObjects();
         }
      }

      private void CmdAreaEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         this.EditObject();
      }

      private void CmdAreaDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdAreasView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No layout area has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] selRows = grdAreasView.GetSelectedRows();
            Section section = grdAreasView.GetRow(selRows[0]) as Section;

            if (section != null)
            {
               if (MessageBox.Show("Are you sure you want to remove the selected layout area?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               {
                  Section.Delete(section);
                  this.ListObjects();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void CmdClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      #endregion

      #region Private Members

      private void EditObject()
      {
         if (grdAreasView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No layout area has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            int[] selRows = grdAreasView.GetSelectedRows();
            Section section = grdAreasView.GetRow(selRows[0]) as Section;

            AreaEditorView form = new AreaEditorView(section);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               this.ListObjects();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void ListObjects()
      {
         try
         {
            grdAreas.BeginUpdate();

            grdAreasView.OptionsBehavior.AutoPopulateColumns = false;
            grdAreasView.Columns.Clear();
            grdAreasView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
            grdAreasView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
            grdAreasView.Columns.Add(new GridColumn() { Caption = "Acc. start", Visible = true, FieldName = "AccessoryStartAddress", Width = 35 });
            grdAreasView.Columns.Add(new GridColumn() { Caption = "Acc. end",   Visible = true, FieldName = "AccessoryEndAddress", Width = 35 });
            grdAreasView.Columns.Add(new GridColumn() { Caption = "Fb. start", Visible = true, FieldName = "FeedbackStartAddress", Width = 35 });
            grdAreasView.Columns.Add(new GridColumn() { Caption = "Fb. end", Visible = true, FieldName = "FeedbackEndAddress", Width = 35 });
            grdAreasView.Columns[1].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            grdAreas.DataSource = Otc.Layout.Section.FindAll();

            grdAreas.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}