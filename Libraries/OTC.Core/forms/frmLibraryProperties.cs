using System;
using System.Windows.Forms;
using otc.panels;

namespace otc.forms
{
   /// <summary>
   /// Implementa un formulario para mostrar las propiedades de un controlador de sistema digital.
   /// </summary>
   public partial class frmLibraryProperties : Form
   {
      /// <summary>
      /// Devuelve una instancia de frmSystemProperties.
      /// </summary>
      public frmLibraryProperties(OTCLibrary library)
      {
         InitializeComponent();

         lblName.Text = library.Name;
         lblDescription.Text = library.Description;

         txtFile.Text = library.Filename;
         lblElements.Text = library.Blocks.Count.ToString();
         lblVersion.Text = library.Version;

         lblWidth.Text = library.BlockWidth.ToString();
         lblHeight.Text = library.BlockHeight.ToString();
         lblBgColor.Text = "#" + library.BgColor.R + library.BgColor.G + library.BgColor.B;
         lblBgColor.BackColor = library.BgColor;

         lblAuthor.Text = library.Author;
         lblLicence.Text = library.Licence;
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
