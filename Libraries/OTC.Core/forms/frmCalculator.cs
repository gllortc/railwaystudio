using System;
using System.Windows.Forms;
using otc.forms.controls;

namespace otc.forms
{
   /// <summary>
   /// Conversor de medidas según escala.
   /// </summary>
   public partial class frmCalculator : Form
   {
      /// <summary>
      /// Devuelve una instancia de frmCalculator.
      /// </summary>
      public frmCalculator()
      {
         InitializeComponent();

         cboSourceScale.Items.Add(new ImageComboBoxItem("1/220 (Z)", 220, imlIcons.Images[0]));
         cboSourceScale.Items.Add(new ImageComboBoxItem("1/160 (N)", 160, imlIcons.Images[0]));
         cboSourceScale.Items.Add(new ImageComboBoxItem("1/120 (TT)", 120, imlIcons.Images[0]));
         cboSourceScale.Items.Add(new ImageComboBoxItem("1/87 (H0)", 87, imlIcons.Images[0]));
         cboSourceScale.Items.Add(new ImageComboBoxItem("1/76 (00)", 76, imlIcons.Images[0]));
         cboSourceScale.Items.Add(new ImageComboBoxItem("1/64 (S)", 64, imlIcons.Images[0]));
         cboSourceScale.Items.Add(new ImageComboBoxItem("1/48 (0)", 48, imlIcons.Images[0]));
         cboSourceScale.Items.Add(new ImageComboBoxItem("1/32 (I)", 32, imlIcons.Images[0]));
         cboSourceScale.Items.Add(new ImageComboBoxItem("1/22,5 (II / G)", 22, imlIcons.Images[0]));
         cboSourceScale.Items.Add(new ImageComboBoxItem("1/1 (real)", 1, imlIcons.Images[0]));

         cboDestScale.Items.Add(new ImageComboBoxItem("1/220 (Z)", 220, imlIcons.Images[0]));
         cboDestScale.Items.Add(new ImageComboBoxItem("1/160 (N)", 160, imlIcons.Images[0]));
         cboDestScale.Items.Add(new ImageComboBoxItem("1/120 (TT)", 120, imlIcons.Images[0]));
         cboDestScale.Items.Add(new ImageComboBoxItem("1/87 (H0)", 87, imlIcons.Images[0]));
         cboDestScale.Items.Add(new ImageComboBoxItem("1/76 (00)", 76, imlIcons.Images[0]));
         cboDestScale.Items.Add(new ImageComboBoxItem("1/64 (S)", 64, imlIcons.Images[0]));
         cboDestScale.Items.Add(new ImageComboBoxItem("1/48 (0)", 48, imlIcons.Images[0]));
         cboDestScale.Items.Add(new ImageComboBoxItem("1/32 (I)", 32, imlIcons.Images[0]));
         cboDestScale.Items.Add(new ImageComboBoxItem("1/22,5 (II / G)", 22, imlIcons.Images[0]));
         cboDestScale.Items.Add(new ImageComboBoxItem("1/1 (real)", 1, imlIcons.Images[0]));
         lblMeasureResult.Text = "";
         lblRealMeasure.Text = "";

         this.Icon = OTCForms.Icon;
      }

      private void btnMeasureCalc_Click(object sender, EventArgs e)
      {
         this.txtSourceMeasure.Text = this.txtSourceMeasure.Text.Trim();

         this.lblMeasureResult.Text = "";
         this.lblRealMeasure.Text = "";

         if (this.txtSourceMeasure.Text.Equals(""))
         {
            MessageBox.Show("Debe especificar la medida a convertir.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.txtSourceMeasure.Focus();
            return;
         }

         try
         {
            double real = 0;
            double dest = 0;
            int mms = Convert.ToInt32(this.txtSourceMeasure.Text);

            // Pasa la medida a 1/1
            real = mms * (int)((ImageComboBoxItem)this.cboSourceScale.SelectedItem).Value;

            // Pasa la medida real a la conversión
            dest = real / (int)((ImageComboBoxItem)this.cboDestScale.SelectedItem).Value;

            // Muestra el resultado
            this.lblMeasureResult.Text = "Medida a 1/" + ((ImageComboBoxItem)this.cboDestScale.SelectedItem).Value + ": " + dest.ToString("#,##0.00") + " mm";
            if (real != dest)
               this.lblRealMeasure.Text = "Medida real: " + real.ToString("#,##0.00") + " mm";
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void label1_Click(object sender, EventArgs e)
      {

      }
   }
}