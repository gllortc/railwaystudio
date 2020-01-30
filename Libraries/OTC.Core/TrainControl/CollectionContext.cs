using RailwayStudio.Common;

namespace Rwm.Otc.TrainControl
{
   public class CollectionContext
   {

      #region Fields

      private static AdministrationDAO administrationField = null;
      private static CategoryDAO categoryField = null;
      private static DecoderDAO decoderField = null;
      private static ManufacturerDAO manufacturerField = null;
      private static ModelDAO modelField = null;
      private static ScaleDAO scaleField = null;
      private static StoreDAO storeField = null;

      #endregion

      #region Properties

      public static AdministrationDAO AdministrationDAO
      {
         get
         {
            if (CollectionContext.administrationField == null)
            {
               CollectionContext.administrationField = new AdministrationDAO(StudioContext.Settings);
            }

            return CollectionContext.administrationField;
         }
      }

      public static CategoryDAO CategoryDAO
      {
         get
         {
            if (CollectionContext.categoryField == null)
            {
               CollectionContext.categoryField = new CategoryDAO(StudioContext.Settings);
            }

            return CollectionContext.categoryField;
         }
      }

      public static DecoderDAO DecoderDAO
      {
         get
         {
            if (CollectionContext.decoderField == null)
            {
               CollectionContext.decoderField = new DecoderDAO(StudioContext.Settings);
            }

            return CollectionContext.decoderField;
         }
      }

      public static ManufacturerDAO ManufacturerDAO
      {
         get
         {
            if (CollectionContext.manufacturerField == null)
            {
               CollectionContext.manufacturerField = new ManufacturerDAO(StudioContext.Settings);
            }

            return CollectionContext.manufacturerField;
         }
      }

      public static ModelDAO ModelDAO
      {
         get
         {
            if (CollectionContext.modelField == null)
            {
               CollectionContext.modelField = new ModelDAO(StudioContext.Settings);
            }

            return CollectionContext.modelField;
         }
      }

      public static ScaleDAO ScaleDAO
      {
         get
         {
            if (CollectionContext.scaleField == null)
            {
               CollectionContext.scaleField = new ScaleDAO(StudioContext.Settings);
            }

            return CollectionContext.scaleField;
         }
      }

      public static StoreDAO StoreDAO
      {
         get
         {
            if (CollectionContext.storeField == null)
            {
               CollectionContext.storeField = new StoreDAO(StudioContext.Settings);
            }

            return CollectionContext.storeField;
         }
      }

      #endregion

      #region Methods
      #endregion

   }
}
