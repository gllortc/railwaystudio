using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common;

namespace Rwm.Studio.Plugins.Designer.Views
{
   public partial class DecodersManagerView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public DecodersManagerView()
      {
         InitializeComponent();

         this.ListAccessoryDecoders();
         this.ListFeedbackEncoders();
      }

      #endregion

      #region Event Handlers

      private void GrdAccView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_DEVICE_ACC_16, e);
      }

      private void GrdFbView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_DEVICE_FB_16, e);
      }

      private void CmdDecoderAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (tabDecoder.SelectedTabPage == tabDecoderAcc)
         {
            AccessoryDecoderEditorView form = new AccessoryDecoderEditorView();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               this.ListAccessoryDecoders();
            }
         }
         else
         {
            FeedbackEncoderEditorView form = new FeedbackEncoderEditorView();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               this.ListFeedbackEncoders();
            }
         }
      }

      private void CmdDecoderEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         try
         {
            if (tabDecoder.SelectedTabPage == tabDecoderAcc)
            {
               if (!(this.GetSelectedResource() is AccessoryDecoder accDecoder)) return;

               AccessoryDecoderEditorView form = new AccessoryDecoderEditorView(accDecoder);
               if (form.ShowDialog(this) == DialogResult.OK)
               {
                  this.ListAccessoryDecoders();
               }
            }
            else
            {
               if (!(this.GetSelectedResource() is FeedbackEncoder fbEncoder)) return;

               FeedbackEncoderEditorView form = new FeedbackEncoderEditorView(fbEncoder);
               if (form.ShowDialog(this) == DialogResult.OK)
               {
                  this.ListFeedbackEncoders();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void CmdDecoderDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         try
         {
            if (tabDecoder.SelectedTabPage == tabDecoderAcc)
            {
               if (!(this.GetSelectedResource() is AccessoryDecoder accDecoder)) return;

               if (MessageBox.Show("Are you sure you want to remove the selected decoder?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               {
                  AccessoryDecoder.Delete(accDecoder);
                  this.ListAccessoryDecoders();
               }
            }
            else
            {
               if (!(this.GetSelectedResource() is FeedbackEncoder fbEncoder)) return;

               if (MessageBox.Show("Are you sure you want to remove the selected decoder?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               {
                  FeedbackEncoder.Delete(fbEncoder);
                  this.ListFeedbackEncoders();
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

      private void ListAccessoryDecoders()
      {
         try
         {
            grdAcc.BeginUpdate();

            grdAccView.OptionsBehavior.AutoPopulateColumns = false;
            grdAccView.Columns.Clear();

            grdAccView.Columns.Add(new GridColumn() { Caption = "Device", Visible = true, FieldName = "Name" });
            grdAccView.Columns.Add(new GridColumn() { Caption = "Connections", Visible = true, FieldName = "ConnectionsCount", Width = 45 });

            grdAccView.Columns["ConnectionsCount"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdAccView.Columns["ConnectionsCount"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grdAcc.DataSource = AccessoryDecoder.FindAll();

            grdAcc.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void ListFeedbackEncoders()
      {
         try
         {
            grdFb.BeginUpdate();

            grdFbView.OptionsBehavior.AutoPopulateColumns = false;
            grdFbView.Columns.Clear();

            grdFbView.Columns.Add(new GridColumn() { Caption = "Device", Visible = true, FieldName = "Name" });
            grdFbView.Columns.Add(new GridColumn() { Caption = "Connections", Visible = true, FieldName = "ConnectionsCount", Width = 45 });

            grdFbView.Columns["ConnectionsCount"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdFbView.Columns["ConnectionsCount"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grdFb.DataSource = FeedbackEncoder.FindAll();

            grdFb.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private object GetSelectedResource()
      {
         if (tabDecoder.SelectedTabPage == tabDecoderAcc)
         {
            if (grdAccView.SelectedRowsCount <= 0)
            {
               MessageBox.Show("No accessory decoder has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return null;
            }

            int[] selRows = grdAccView.GetSelectedRows();
            return grdAccView.GetRow(selRows[0]) as AccessoryDecoder;
         }
         else
         {
            if (grdFbView.SelectedRowsCount <= 0)
            {
               MessageBox.Show("No feedback encoder has been selected from list.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return null;
            }

            int[] selRows = grdFbView.GetSelectedRows();
            return grdFbView.GetRow(selRows[0]) as FeedbackEncoder;
         }
      }

      #endregion

   }
}