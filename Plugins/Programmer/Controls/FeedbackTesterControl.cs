using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using Rwm.Otc;
using Rwm.Otc.Systems;

namespace Rwm.Studio.Plugins.Designer.Controls
{
   public partial class FeedbackTesterControl : UserControl
   {

      #region Constructors

      public FeedbackTesterControl()
      {
         InitializeComponent();
         DrawControl();
      }

      #endregion

      #region Properties

      private DataTable Data { get; set; }

      #endregion

      #region Methods

      public void FeedbackReceived(List<FeedbackPointAddressStatus> reportedStatuses)
      {
         if (grdFeedback.InvokeRequired)
         {
            grdFeedback.Invoke((Action)delegate
            {
               foreach (FeedbackPointAddressStatus status in reportedStatuses)
               {
                  this.Data.Rows[status.Address - 1]["Point" + status.PointAddress] = status.Active;
               }
            });
         }
         else
         {
            foreach (FeedbackPointAddressStatus status in reportedStatuses)
            {
               this.Data.Rows[status.Address - 1]["Point" + status.PointAddress] = status.Active;
            }
         }
      }

      #endregion

      #region Private members

      private void DrawControl()
      {
         if (OTCContext.Project == null || OTCContext.Project.DigitalSystem == null) 
            return;

         RepositoryItemCheckEdit reposCheckEdit = new RepositoryItemCheckEdit();
         reposCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
         reposCheckEdit.PictureChecked = Properties.Resources.ICO_TESTER_RED_16;
         reposCheckEdit.PictureUnchecked = Properties.Resources.ICO_TESTER_WHITE_16;

         // Generate the data table
         this.Data = new DataTable("Feedback");
         this.Data.Columns.Add("Address", typeof(int));
         for (int pointadr = 1; pointadr <= OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress; pointadr++)
         {
            this.Data.Columns.Add("Point" + pointadr, typeof(bool));
         }
         for (int adr = OTCContext.Project.DigitalSystem.FeedbackAddressRange.Minimum; adr <= OTCContext.Project.DigitalSystem.FeedbackAddressRange.Maximum; adr++)
         {
            object[] row = new object[OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress + 1];
            row[0] = adr;
            for (int pointadr = 1; pointadr <= OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress; pointadr++)
            {
               row[pointadr] = false;
            }

            this.Data.Rows.Add(row);
         }

         grdFeedback.BeginUpdate();

         grdFeedbackView.Columns.Clear();
         grdFeedbackView.OptionsView.ColumnAutoWidth = false;
         grdFeedbackView.OptionsBehavior.AutoPopulateColumns = true;
         grdFeedback.DataSource = null;
         grdFeedback.DataSource = this.Data;

         grdFeedbackView.Columns[0].Width = 70;
         grdFeedbackView.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdFeedbackView.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         grdFeedbackView.Columns[0].AppearanceCell.FontSizeDelta = 1;
         grdFeedbackView.Columns[0].AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
         grdFeedbackView.Columns[0].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         grdFeedbackView.Columns[0].DisplayFormat.FormatString = "d4";

         for (int pointadr = 1; pointadr <= OTCContext.Project.DigitalSystem.PointAddressesByFeedbackAddress; pointadr++)
         {
            grdFeedbackView.Columns[pointadr].Caption = "Point " + pointadr;
            grdFeedbackView.Columns[pointadr].Width = 50;
            grdFeedbackView.Columns[pointadr].ColumnEdit = reposCheckEdit;
            grdFeedbackView.Columns[pointadr].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdFeedbackView.Columns[pointadr].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }

         grdFeedback.EndUpdate();
      }

      #endregion

   }
}
