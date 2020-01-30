using Rwm.Otc.TrainControl;
using Rwm.Otc.Utils;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Collection.Views
{
   public partial class ScaleEditorView : DevExpress.XtraEditors.XtraForm
   {
      public ScaleEditorView()
      {
         InitializeComponent();

         this.Scale = new Gauge();
      }

      public ScaleEditorView(Gauge scale)
      {
         InitializeComponent();

         this.Scale = scale;

         txtName.Text = this.Scale.Name;
         txtRatio.Text = this.Scale.ScaleNotation;
         txtTrackWidth.Text = this.Scale.TrackWidthScale.ToString();
         txtRealTrackWidth.Text = this.Scale.TrackWidthReal.ToString();
      }

      public Gauge Scale { get; private set; }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void cmdAccept_Click(object sender, EventArgs e)
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

         this.Scale.Name = txtName.Text.Trim();
         this.Scale.ScaleNotation = txtRatio.Text.Trim();
         this.Scale.TrackWidthScale = NumericUtils.ToInteger(txtTrackWidth.Text.Trim());
         this.Scale.TrackWidthReal = NumericUtils.ToInteger(txtRealTrackWidth.Text.Trim());

         try
         {
            Rwm.Otc.TrainControl.Gauge.Save(this.Scale);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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