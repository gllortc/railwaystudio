using System;
using System.Windows.Forms;
using Rwm.Otc.Trains;
using Rwm.Otc.Utils;

namespace Rwm.Studio.Plugins.Collection.Views
{
   public partial class GaugeEditorView : DevExpress.XtraEditors.XtraForm
   {
      public GaugeEditorView()
      {
         InitializeComponent();

         this.Gauge = new Gauge();
      }

      public GaugeEditorView(Gauge gauge)
      {
         InitializeComponent();

         this.Gauge = gauge;

         txtName.Text = this.Gauge.Name;
         txtRatio.Text = this.Gauge.Notation;
         txtTrackWidth.Text = this.Gauge.TrackWidthScale.ToString();
         txtRealTrackWidth.Text = this.Gauge.TrackWidthReal.ToString();
      }

      public Gauge Gauge { get; private set; }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void CmdAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the scale.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.SelectAll();
            txtName.Focus();
            return;
         }
         else if (string.IsNullOrWhiteSpace(txtRatio.Text))
         {
            MessageBox.Show("You must provide a valid scale ratio.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtRatio.SelectAll();
            txtRatio.Focus();
            return;
         }

         this.Gauge.Name = txtName.Text.Trim();
         this.Gauge.Notation = txtRatio.Text.Trim();
         this.Gauge.TrackWidthScale = NumericUtils.ToInteger(txtTrackWidth.Text.Trim());
         this.Gauge.TrackWidthReal = NumericUtils.ToInteger(txtRealTrackWidth.Text.Trim());

         try
         {
            Gauge.Save(this.Gauge);

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR storing data:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}