using System;
using System.Windows.Forms;
using otc.forms;

namespace otc.help
{
   /// <summary>
   /// Formulario para mostrar la ayuda estándar de OTC.
   /// </summary>
   public partial class frmHelp : Form
   {
      private OTCHelp _help = null;

      /// <summary>
      /// Devuelve una instancia de frmHelp.
      /// </summary>
      public frmHelp(string filename)
      {
         InitializeComponent();
         // this. .Icon = OTCForms.Icon;

         lblTitle.Text = "";
         webContent.Url = new Uri("about:blank");

         try
         {
            _help = new OTCHelp(filename);
            _help.LoadIndex(this.tvwTree);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// Devuelve una instancia de frmHelp.
      /// </summary>
      public frmHelp(string filename, string title)
      {
         InitializeComponent();
         this.Icon = OTCForms.Icon;

         lblTitle.Text = title;
         webContent.Url = new Uri("about:blank");

         try
         {
            _help = new OTCHelp(filename);
            _help.LoadIndex(this.tvwTree);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void frmHelp_Load(object sender, EventArgs e)
      {
         if (this.tvwTree.Nodes.Count <= 0) return;

         // Simula un clic en el primer nodo del árbol
         this.tvwTree_AfterSelect(sender, new TreeViewEventArgs(this.tvwTree.Nodes[0]));
      }

      private void tbrExit_Click(object sender, EventArgs e)
      {
         this.webContent.Dispose();
         this.Close();
      }

      private void webContent_Navigating(object sender, WebBrowserNavigatingEventArgs e)
      {
         this.stbActivity.Text = "Descargando contenido...";
      }

      private void webContent_Navigated(object sender, WebBrowserNavigatedEventArgs e)
      {
         this.stbActivity.Text = "Listo";
         this.stbURL.Text = this.webContent.Url.ToString();
      }

      private void tbrPrint_Click(object sender, EventArgs e)
      {
         this.webContent.ShowPrintPreviewDialog();
      }

      private void tbrBrowserPrev_Click(object sender, EventArgs e)
      {
         this.webContent.GoBack();
      }

      private void tbrBrowseNext_Click(object sender, EventArgs e)
      {
         this.webContent.GoForward();
      }

      /// <summary>
      /// Actualiza el estado de los botones de navegación
      /// </summary>
      private void clkStatus_Tick(object sender, EventArgs e)
      {
         this.tbrBrowseNext.Enabled = this.webContent.CanGoForward;
         this.tbrBrowserPrev.Enabled = this.webContent.CanGoBack;
      }

      private void tvwTree_AfterSelect(object sender, TreeViewEventArgs e)
      {
         if (e.Node.Tag == null)
         {
            this.webContent.Navigate("about:blank");
            return;
         }

         // Si tiene hijos, mantiene expandido el nodo
         if ((e.Node.Nodes.Count > 0) && (!e.Node.IsExpanded)) e.Node.Expand();

         // Navega a la ubicación definida
         if (!e.Node.Tag.ToString().Equals(""))
            this.webContent.Navigate(e.Node.Tag.ToString());
      }
   }
}