using Rwm.Otc.TrainControl;
using System;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Collection.Views
{
   public partial class DecoderEditorView : DevExpress.XtraEditors.XtraForm
   {
      public DecoderEditorView()
      {
         InitializeComponent();

         this.Decoder = new TrainDecoder();
      }

      public DecoderEditorView(TrainDecoder store)
      {
         InitializeComponent();

         this.Decoder = store;

         txtName.Text = this.Decoder.Name;
         txtDescription.Text = this.Decoder.Description;
         txtUrl.Text = this.Decoder.URL;
         txtManual.Text = ""; //this.Decoder.File;
      }

      public TrainDecoder Decoder { get; private set; }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      private void cmdAccept_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must provide a valid name for the decoder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.SelectAll();
            txtName.Focus();
            return;
         }

         this.Decoder.Name = txtName.Text.Trim();
         this.Decoder.Description = txtDescription.Text.Trim();
         this.Decoder.URL = txtUrl.Text.Trim();
         // this.Decoder.File = File.ReadAllBytes(txtManual.Text.Trim());

         try
         {
            TrainDecoder.Save(this.Decoder);

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