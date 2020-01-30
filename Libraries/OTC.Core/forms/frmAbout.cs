using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace otc.forms
{
   /// <summary>
   /// Formulario estandarizado Acerca de...
   /// </summary>
   public partial class frmAbout : Form
   {
      /// <summary>
      /// Devuelve una instancia de frmAbout.
      /// </summary>
      public frmAbout(string name, string version, string copyright)
      {
         InitializeComponent();

         this.Text = "Acerca de " + name;
         this.lblProductName.Text = name;
         this.lblVersion.Text = "Versión " + version;
         this.lblCopyright.Text = copyright;
         this.lblFramework.Text = "Framework .NET " + RuntimeEnvironment.GetSystemVersion();

         this.Icon = OTCForms.Icon;
      }

      private void btnAccept_Click(object sender, EventArgs e)
      {
         this.Close();
      }

   }
}