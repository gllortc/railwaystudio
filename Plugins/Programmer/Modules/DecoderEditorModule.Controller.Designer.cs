using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Designer.Views;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public partial class DecoderEditorModule
   {

      #region Enumerations

      public enum FileType : int
      {
         Unknown = -1,
         Manufacturers = 0,
         Stores = 1,
         Gauges = 2,
         Administrations = 3,
         Decoders = 4,
         Categories = 5
      }

      #endregion

      #region Properties

      public FileType CurrentFileType { get; private set; }

      public Category CurrentCategory { get; private set; }

      #endregion

      #region Methods

      internal void AddItem()
      {
         
      }

      internal void EditItem()
      {
         
      }

      internal void DeleteItem()
      {
         
      }

      internal void ReportsDigitalAddresses()
      {

      }

      internal void DecoderProgram()
      {
         DecoderBuildView form = new DecoderBuildView();
         form.ShowDialog(this);
      }

      #endregion

      #region Private Members

      

      #endregion

   }
}
