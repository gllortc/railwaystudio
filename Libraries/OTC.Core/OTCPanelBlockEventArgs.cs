using System;
using System.Drawing;
using otc.panels;

namespace otc
{

   #region class OTCPanelBlockEventArgs : EventArgs

   /// <summary>
   /// Argumento para el evento OnInformation
   /// </summary>
   public class OTCPanelBlockEventArgs : EventArgs
   {
      private OTCPanelBlock _block;
      private Bitmap _image;

      /// <summary>
      /// Devuelve una instancia de OTCInformationEventArgs.
      /// </summary>
      public OTCPanelBlockEventArgs(OTCPanelBlock Block, Bitmap Image)
      {
         _block = Block;
         _image = Image;
      }

      /// <summary>
      /// Bloque que ha cambiado sus propiedades.
      /// </summary>
      public OTCPanelBlock Block
      {
         get { return _block; }
      }

      /// <summary>
      /// Imagen a representar para el bloque.
      /// </summary>
      public Bitmap Image
      {
         get { return _image; }
      }
   }

   #endregion

}
