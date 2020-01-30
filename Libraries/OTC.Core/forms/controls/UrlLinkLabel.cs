using System;
using System.Windows.Forms;

namespace otc.Controls
{
   /// <summary>
   /// Implementa un control que implementa un enlace web.
   /// </summary>
   public class UrlLinkLabel : LinkLabel
   {
      private Uri _url = new Uri("http://www.railwaymania.com/");

      /// <summary>
      /// Url de destino del enlace.
      /// </summary>
      public Uri Url
      {
         get { return _url; }
         set { _url = value; }
      }

      /// <summary>
      /// Evento que se dispara cuando el usuario hace clic encimna del enlace. El evento se dispara justo antes de abrir el navegador.
      /// </summary>
      protected override void OnClick(EventArgs e)
      {
         base.OnClick(e);

         // Navega a la URL indicada
         System.Diagnostics.Process.Start(_url.OriginalString); 
      }
   }
}
