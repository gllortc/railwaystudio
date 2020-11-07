using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Studio.Plugins.Collection.Data;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Collection.Model
{
   public class ModelDAO : CollectionDataEntity
   {

      #region Constants

      // SQL declarations
      internal static string SQL_TABLE = @"models";

      internal static string SQL_SELECT = @"modid, modadminid, modstoreid, modtypeid, modname, modpaint, modepoche,
                                            modref, modbuilderid, modscaleid, modcatprice, modbuyprice, modbuydate,
                                            modbuypending, modcouplers, modpant, modsound, modlim, modlimyear,
                                            modlength, modframe, moddecointerior, modlightfront, modlightinterior,
                                            modlightrear, modoriginalbox, modaxisdisp, modaxistraction, modaxistires,
                                            moddesc, modpicturefilename, modunits, moddigitaladd,
                                            moddigitaldecoderid, moddigitalconn, modregnumber, modtype, modtypeuic,
                                            modenginetype, modsrvrevhours, modsrvtotalhours";

      internal static string SQL_INSERT = @"modadminid, modstoreid, modtypeid, modname, modpaint, modepoche,
                                            modref, modbuilderid, modscaleid, modcatprice, modbuyprice, modbuydate,
                                            modbuypending, modcouplers, modpant, modsound, modlim, modlimyear,
                                            modlength, modframe, moddecointerior, modlightfront, modlightinterior,
                                            modlightrear, modoriginalbox, modaxisdisp, modaxistraction, modaxistires,
                                            moddesc, modpicture, modpicturefilename, modunits, moddigitaladd,
                                            moddigitaldecoderid, moddigitalconn, modregnumber, modtype, modtypeuic,
                                            modenginetype, modsrvrevhours, modsrvtotalhours";

      #endregion

      #region Enumerations

      /// <summary>
      /// Describe los distintos formatos de exportación soportados.
      /// </summary>
      public enum ExportFormats
      {
         Excel,
         CSV,
         XML
      }

      /// <summary>
      /// Describe los distintos tipos de exportación soportados.
      /// </summary>
      public enum ExportTypes
      {
         OnePages,
         MultiplePages
      }

      /// <summary>
      /// Describe los distintos tipos de listado de la colección.
      /// </summary>
      public enum ReportTypes : int
      {
         Nothing = -1,
         All = 0,
         Manufacturer = 1,
         Administration = 2,
         Type = 3,
         BuyPending = 4,
         Digitalized = 5,
         SearchResults = 6,
         ModelsWithMaintenance = 7
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Constructor de la clase.
      /// </summary>
      /// <param name="app">Una instáncia de RCApplication.</param>
      public ModelDAO(XmlSettingsManager settings)
         : base(settings)
      {
         // Asegura la existencia de la carpeta de imágenes
         DirectoryInfo directory = new DirectoryInfo(ModelDAO.ImagesPath);
         if (!directory.Exists) directory.Create();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Nombre de la carpeta que contiene imágenes
      /// </summary>
      public static string ImagesFolderName
      {
         get { return "images"; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Agrega un nuevo modelo a la colección.
      /// </summary>
      /// <param name="model">Una instáncia de RCModel que representa los datos del nuevo modelo.</param>
      public void Add(CollectionModel model)
      {
         string sql = string.Empty;
         byte[] data = null;

         try
         {
            Connect();

            // Prepare picture data
            if (model.Picture != null)
            {
               using (var ms = new MemoryStream())
               {
                  model.Picture.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                  data = ms.ToArray();
               }
            }
            else
            {
               data = null;
            }

            // Store model data
            sql = @"INSERT INTO 
                        " + ModelDAO.SQL_TABLE + @" (" + ModelDAO.SQL_INSERT + @") 
                    VALUES 
                        (@modadminid, @modstoreid, @modtypeid, @modname, @modpaint, @modepoche,
                         @modref, @modbuilderid, @modscaleid, @modcatprice, @modbuyprice, @modbuydate,
                         @modbuypending, @modcouplers, @modpant, @modsound, @modlim, @modlimyear,
                         @modlength, @modframe, @moddecointerior, @modlightfront, @modlightinterior,
                         @modlightrear, @modoriginalbox, @modaxisdisp, @modaxistraction, @modaxistires,
                         @moddesc, @modpicture, @modpicturefilename, @modunits, @moddigitaladd,
                         @moddigitaldecoderid, @moddigitalconn, @modregnumber, @modtype, @modtypeuic,
                         @modenginetype, @modsrvrevhours, @modsrvtotalhours)";

            SetParameter("modadminid", model.AdminID);
            SetParameter("modstoreid", model.StoreID);
            SetParameter("modtypeid", model.CategoryID);
            SetParameter("modname", model.Name);
            SetParameter("modpaint", model.PaintScheme);
            SetParameter("modepoche", (int)model.Era);
            SetParameter("modref", model.Reference);
            SetParameter("modbuilderid", model.ManufacturerID);
            SetParameter("modscaleid", model.ScaleID);
            SetParameter("modcatprice", model.BuyPriceCatalogue);
            SetParameter("modbuyprice", model.BuyPricePurchase);
            SetParameter("modbuydate", (model.BuyDate.Year <= 1900) ? DateTime.MinValue : model.BuyDate);
            SetParameter("modbuypending", model.BuyIsPending);
            SetParameter("modcouplers", (int)model.CouplersType);
            SetParameter("modpant", model.HaveFunctionalPantos);
            SetParameter("modsound", model.HaveSound);
            SetParameter("modlim", model.IsLimited);
            SetParameter("modlimyear", model.LimitedYear);
            SetParameter("modlength", model.Length);
            SetParameter("modframe", (int)model.Frame);
            SetParameter("moddecointerior", (int)model.InteriorEquipment);
            SetParameter("modlightfront", (int)model.LightFront);
            SetParameter("modlightinterior", (int)model.LightInterior);
            SetParameter("modlightrear", (int)model.LightRear);
            SetParameter("modoriginalbox", model.HaveOriginalBox);
            SetParameter("modaxisdisp", model.WheelDisposition);
            SetParameter("modaxistraction", model.AxisWithTraction);
            SetParameter("modaxistires", model.AxisWithTractionTires);
            SetParameter("moddesc", model.Description);
            SetParameter("modpicture", data);
            SetParameter("modpicturefilename", model.PictureFileName);
            SetParameter("modunits", model.Units);
            SetParameter("moddigitaladd", model.DigitalAddress);
            SetParameter("moddigitaldecoderid", model.DigitalDecoderID);
            SetParameter("moddigitalconn", (int)model.DigitalConnector);
            SetParameter("modregnumber", model.RegistrationNumber);
            SetParameter("modtype", model.Type);
            SetParameter("modtypeuic", model.TypeUIC);
            SetParameter("modenginetype", model.EngineType);
            SetParameter("modsrvrevhours", model.MaintenanceRevisionHours);
            SetParameter("modsrvtotalhours", model.MaintenanceServiceHours);

            ExecuteNonQuery(sql);

            // Obtiene el nuevo ID
            sql = @"SELECT 
                        Max(modid) As id 
                    FROM 
                        " + ModelDAO.SQL_TABLE;

            model.ID = (int)ExecuteScalar(sql);

            Disconnect();

            // Update the digital functions
            //ModelDigitalFunctionDAO dfmanager = new ModelDigitalFunctionDAO(this.Settings);
            //dfmanager.Add(model);

            // Update maintenance information
            //ModelRevisionDAO revmanager = new ModelRevisionDAO(this.Settings);
            //revmanager.Add(model);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Actualiza los datos de un modelo.
      /// </summary>
      /// <param name="model">Una instáncia de RCModel que representa los datos del nuevo modelo.</param>
      public void Update(CollectionModel model, bool updatePicture)
      {
         string sql = string.Empty;
         byte[] data = null;

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + ModelDAO.SQL_TABLE + @" 
                    SET 
                        modadminid           = @modadminid,
                        modstoreid           = @modstoreid,
                        modtypeid            = @modtypeid,
                        modname              = @modname,
                        modpaint             = @modpaint,
                        modepoche            = @modepoche,
                        modref               = @modref,
                        modbuilderid         = @modbuilderid, 
                        modscaleid           = @modscaleid, 
                        modcatprice          = @modcatprice, 
                        modbuyprice          = @modbuyprice, 
                        modbuydate           = @modbuydate,
                        modbuypending        = @modbuypending, 
                        modcouplers          = @modcouplers, 
                        modpant              = @modpant, 
                        modsound             = @modsound, 
                        modlim               = @modlim, 
                        modlimyear           = @modlimyear,
                        modlength            = @modlength, 
                        modframe             = @modframe, 
                        moddecointerior      = @moddecointerior, 
                        modlightfront        = @modlightfront, 
                        modlightinterior     = @modlightinterior,
                        modlightrear         = @modlightrear, 
                        modoriginalbox       = @modoriginalbox, 
                        modaxisdisp          = @modaxisdisp, 
                        modaxistraction      = @modaxistraction, 
                        modaxistires         = @modaxistires,
                        moddesc              = @moddesc, 
                        {0}
                        modpicturefilename   = @modpicturefilename, 
                        modunits             = @modunits, 
                        moddigitaladd        = @moddigitaladd,
                        moddigitaldecoderid  = @moddigitaldecoderid, 
                        moddigitalconn       = @moddigitalconn, 
                        modregnumber         = @modregnumber, 
                        modtype              = @modtype, 
                        modtypeuic           = @modtypeuic,
                        modenginetype        = @modenginetype, 
                        modsrvrevhours       = @modsrvrevhours, 
                        modsrvtotalhours     = @modsrvtotalhours
                    WHERE 
                        modid = @modid";

            SetParameter("modadminid", model.AdminID);
            SetParameter("modstoreid", model.StoreID);
            SetParameter("modtypeid", model.CategoryID);
            SetParameter("modname", model.Name);
            SetParameter("modpaint", model.PaintScheme);
            SetParameter("modepoche", (int)model.Era);
            SetParameter("modref", model.Reference);
            SetParameter("modbuilderid", model.ManufacturerID);
            SetParameter("modscaleid", model.ScaleID);
            SetParameter("modcatprice", model.BuyPriceCatalogue);
            SetParameter("modbuyprice", model.BuyPricePurchase);
            SetParameter("modbuydate", (model.BuyDate.Year <= 1900) ? DateTime.MinValue : model.BuyDate);
            SetParameter("modbuypending", model.BuyIsPending);
            SetParameter("modcouplers", (int)model.CouplersType);
            SetParameter("modpant", model.HaveFunctionalPantos);
            SetParameter("modsound", model.HaveSound);
            SetParameter("modlim", model.IsLimited);
            SetParameter("modlimyear", model.LimitedYear);
            SetParameter("modlength", model.Length);
            SetParameter("modframe", (int)model.Frame);
            SetParameter("moddecointerior", (int)model.InteriorEquipment);
            SetParameter("modlightfront", (int)model.LightFront);
            SetParameter("modlightinterior", (int)model.LightInterior);
            SetParameter("modlightrear", (int)model.LightRear);
            SetParameter("modoriginalbox", model.HaveOriginalBox);
            SetParameter("modaxisdisp", model.WheelDisposition);
            SetParameter("modaxistraction", model.AxisWithTraction);
            SetParameter("modaxistires", model.AxisWithTractionTires);
            SetParameter("moddesc", model.Description);
            SetParameter("modpicturefilename", model.PictureFileName);
            SetParameter("modunits", model.Units);
            SetParameter("moddigitaladd", model.DigitalAddress);
            SetParameter("moddigitaldecoderid", model.DigitalDecoderID);
            SetParameter("moddigitalconn", (int)model.DigitalConnector);
            SetParameter("modregnumber", model.RegistrationNumber);
            SetParameter("modtype", model.Type);
            SetParameter("modtypeuic", model.TypeUIC);
            SetParameter("modenginetype", model.EngineType);
            SetParameter("modsrvrevhours", model.MaintenanceRevisionHours);
            SetParameter("modsrvtotalhours", model.MaintenanceServiceHours);
            SetParameter("modid", model.ID);

            sql = string.Format(sql, (updatePicture ? "modpicture = @modpicture, " : string.Empty));

            if (updatePicture)
            {
               data = null;

               // Prepare picture data
               if (model.Picture != null)
               {
                  ImageConverter ic = new ImageConverter();
                  data = (byte[])ic.ConvertTo(model.Picture, typeof(byte[]));

                  using (MemoryStream ms = new MemoryStream())
                  {
                     model.Picture.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                     data = ms.ToArray();
                  }
               }

               SetParameter("modpicture", data);
            }

            ExecuteNonQuery(sql);

            Disconnect();

            // Update the digital functions
            //ModelDigitalFunctionDAO dfmanager = new ModelDigitalFunctionDAO(this.Settings);
            //dfmanager.Add(model);

            // Update maintenance information
            //ModelRevisionDAO revmanager = new ModelRevisionDAO(this.Settings);
            //revmanager.Add(model);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Elimina un modelo (y sus imágenes asociadas)
      /// </summary>
      /// <param name="modelId">Identificador del modelo.</param>
      public void Delete(int modelId)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"DELETE 
                    FROM 
                        " + ModelDAO.SQL_TABLE + @" 
                    WHERE 
                        modid = @modid";

            SetParameter("modid", modelId);
            ExecuteNonQuery(sql);

            Disconnect();

            // Remove digital functions
            ModelDigitalFunctionDAO dfmanager = new ModelDigitalFunctionDAO(this.Settings);
            dfmanager.DeleteByModel(modelId);

            // Remove maintenance information
            ModelRevisionDAO revmanager = new ModelRevisionDAO(this.Settings);
            revmanager.DeleteByModel(modelId);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Recupera un modelo de la colección.
      /// </summary>
      /// <param name="modelId">Identificador del modelo a recuperar.</param>
      /// <returns>Una instáncia de RCModel.</returns>
      /// <remarks>
      /// Los campos <c>modlights</c> y <c>moddigitaldec</c> se recuperan pero ya no son usados en la tabla.
      /// </remarks>
      public CollectionModel GetByID(int modelId)
      {
         return this.GetByID((Int64)modelId);
      }

      /// <summary>
      /// Recupera un modelo de la colección.
      /// </summary>
      /// <param name="modelId">Identificador del modelo a recuperar.</param>
      /// <returns>Una instáncia de RCModel.</returns>
      /// <remarks>
      /// Los campos <c>modlights</c> y <c>moddigitaldec</c> se recuperan pero ya no son usados en la tabla.
      /// </remarks>
      public CollectionModel GetByID(Int64 modelId)
      {
         string sql = string.Empty;
         CollectionModel item = null;

         try
         {
            Connect();

            // Get the model data
            sql = @"SELECT 
                        " + ModelDAO.SQL_SELECT + @"
                    FROM 
                        " + ModelDAO.SQL_TABLE + @" 
                    WHERE 
                        modid = @modid";

            SetParameter("modid", modelId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  item = ModelDAO.ReadEntityObject(reader);

               }
            }

            // Get the picture
            sql = @"SELECT 
                        modpicture
                    FROM 
                        " + ModelDAO.SQL_TABLE + @" 
                    WHERE 
                        modid = @modid";

            SetParameter("modid", modelId);

            try
            {
               byte[] data = ExecuteBlob(sql);
               using (var ms = new MemoryStream(data))
               {
                  item.Picture = Image.FromStream(ms);
               }
            }
            catch
            {
               item.Picture = null;
            }

            Disconnect();

            // Get all associated digital functions
            //ModelDigitalFunctionDAO dfunctions = new ModelDigitalFunctionDAO(this.Settings);
            //item.DigitalFunctions = dfunctions.GetByModel(item.ID);

            // Obtiene las revisiones técnicas asociadas
            //ModelRevisionDAO revmanager = new ModelRevisionDAO(this.Settings);
            //item.MaintenanceRevisions = revmanager.GetByModel(item.ID);

            return item;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Rellena un control ListView con una lista de modelos de la colección.
      /// </summary>
      /// <param name="listView">Control contenedor de la lista.</param>
      /// <param name="reportType">Tipo de listado.</param>
      /// <param name="filterId">Identificador de la carpeta contenedora.</param>
      public System.Data.DataTable Find()
      {
         string sql = string.Empty;
         System.Data.DataTable dt = null;

         try
         {
            Connect();

            // Genera la senténcia SQL que obtiene los elementos
            sql = @"SELECT 
                        models.modid, 
                        models.modpicture    As """", 
                        models.modname       As ""Name"", 
                        models.modref        As ""Article-No."", 
                        admins.adminname     As ""Company"", 
                        builders.buildname   As ""Manufacturer"", 
                        models.modbuydate    As ""BuyDate"", 
                        scales.scname        As ""Scale"", 
                        models.modunits      As ""Units"" 
                    FROM   
                        " + ModelDAO.SQL_TABLE + @" 
                        LEFT OUTER JOIN builders ON (models.modbuilderid = builders.buildid) 
                        LEFT OUTER JOIN scales   ON (models.modscaleid = scales.scid) 
                        LEFT OUTER JOIN admins   ON (models.modadminid = admins.adminid) 
                        LEFT OUTER JOIN types    ON (models.modtypeid = types.typeid)
                        LEFT OUTER JOIN stores   ON (models.modstoreid = stores.storeid)
                    ORDER BY 
                        models.modname ASC";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               dt = new System.Data.DataTable();
               dt.Load(reader);
            }

            return dt;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Rellena un control ListView con una lista de modelos de la colección.
      /// </summary>
      /// <param name="listView">Control contenedor de la lista.</param>
      /// <param name="reportType">Tipo de listado.</param>
      /// <param name="filterId">Identificador de la carpeta contenedora.</param>
      public System.Data.DataTable FindByCategory(Category category)
      {
         string sql = string.Empty;
         System.Data.DataTable dt = null;

         if (category == null || category.ID == 0)
         {
            return this.Find();
         }

         try
         {
            Connect();

            // Genera la senténcia SQL que obtiene los elementos
            sql = @"SELECT 
                        models.modid, 
                        models.modpicture    As """", 
                        models.modname       As ""Name"", 
                        models.modref        As ""Article-No."", 
                        admins.adminname     As ""Company"", 
                        builders.buildname   As ""Manufacturer"", 
                        models.modbuydate    As ""BuyDate"", 
                        scales.scname        As ""Scale"", 
                        models.modunits      As ""Units"" 
                    FROM   
                        " + ModelDAO.SQL_TABLE + @" 
                        LEFT OUTER JOIN builders ON (models.modbuilderid = builders.buildid) 
                        LEFT OUTER JOIN scales   ON (models.modscaleid = scales.scid) 
                        LEFT OUTER JOIN admins   ON (models.modadminid = admins.adminid) 
                        LEFT OUTER JOIN types    ON (models.modtypeid = types.typeid)
                        LEFT OUTER JOIN stores   ON (models.modstoreid = stores.storeid)
                    WHERE 
                        models.modtypeid = @modtypeid 
                    ORDER BY 
                        models.modname ASC";

            SetParameter("modtypeid", category.ID);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               dt = new System.Data.DataTable();
               dt.Load(reader);
            }

            return dt;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Get all paint schemes used in all mkdels.
      /// </summary>
      /// <returns>A list filled with strings.</returns>
      public List<string> GetAllPaintSchemes()
      {
         string sql = string.Empty;
         List<string> paints = new List<string>();

         try
         {
            Connect();

            // Genera la senténcia SQL que obtiene los elementos
            sql = @"SELECT DISTINCT 
                        modpaint 
                    FROM 
                        " + ModelDAO.SQL_TABLE + @" 
                    ORDER BY 
                        modpaint ASC";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  paints.Add(reader.GetString(0));
               }
            }

            return paints;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Registra horas de servicio a un modelo determinado.
      /// </summary>
      /// <param name="modelId">Identificador único del modelo.</param>
      /// <param name="hours">Horas de servicio a agregar.</param>
      public void AddServiceHours(int modelId, int hours)
      {
         string sql = string.Empty;

         if (hours <= 0) return;

         try
         {
            Connect();

            // Genera la senténcia SQL que obtiene los elementos
            sql = @"UPDATE 
                        " + ModelDAO.SQL_TABLE + @" 
                    SET 
                        modsrvtotalhours = modsrvtotalhours + @hours, 
                        modsrvrevhours = modsrvrevhours + @hours 
                    WHERE 
                        modid = @modid";

            SetParameter("hours", hours);
            SetParameter("modid", modelId);
            ExecuteNonQuery(sql);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Genera una imágen miniatura a partir de una imágen de modelo.
      /// </summary>
      /// <param name="lcFilename">Nombre + path del archivo original.</param>
      /// <param name="lnWidth">Ancho deseado para la imágen miniatura.</param>
      /// <param name="lnHeight">Altura deseada para la imágen miniatura.</param>
      /// <returns></returns>
      public System.Drawing.Bitmap CreateThumbnail(string lcFilename, int lnWidth, int lnHeight)
      {
         System.Drawing.Bitmap bmpOut = null;

         try
         {
            System.Drawing.Bitmap loBMP = new System.Drawing.Bitmap(lcFilename);
            System.Drawing.Imaging.ImageFormat loFormat = loBMP.RawFormat;
            FileInfo file = new FileInfo(lcFilename);

            decimal lnRatio;
            int lnNewWidth = 0;
            int lnNewHeight = 0;

            // Controla el caso que la imágen resultante sea mayor que la original
            if (loBMP.Width < lnWidth && loBMP.Height < lnHeight) return loBMP;

            if (loBMP.Width > loBMP.Height)
            {
               lnRatio = (decimal)lnWidth / loBMP.Width;
               lnNewWidth = lnWidth;
               decimal lnTemp = loBMP.Height * lnRatio;
               lnNewHeight = (int)lnTemp;
            }
            else
            {
               lnRatio = (decimal)lnHeight / loBMP.Height;
               lnNewHeight = lnHeight;
               decimal lnTemp = loBMP.Width * lnRatio;
               lnNewWidth = (int)lnTemp;
            }

            // Para los fondos transparentes transforma el negro por defecto a blanco
            bmpOut = new System.Drawing.Bitmap(lnNewWidth, lnNewHeight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmpOut);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.FillRectangle(System.Drawing.Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
            g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

            // Si existe el Thumbnail, lo elimina y lo regenera
            FileInfo thfile = new FileInfo(Path.Combine(ModelDAO.ImagesPath, "th_" + file.Name));
            if (thfile.Exists) thfile.Delete();

            // Guarda la imágen thumbnail
            System.Drawing.Image imgOut = loBMP.GetThumbnailImage(lnNewWidth, lnNewHeight, null, IntPtr.Zero);
            imgOut.Save(Path.Combine(ModelDAO.ImagesPath, "th_" + file.Name));

            loBMP.Dispose();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            return null;
         }

         return bmpOut;
      }

      /// <summary>
      /// Carga las imágenes miniatura de los modelos en un control ImageList.
      /// </summary>
      /// <param name="imagelist">Control contenedor.</param>
      public void LoadImageList(ImageList imagelist)
      {
         string sql = string.Empty;

         try
         {
            // Inicializa el control contenedor
            imagelist.Images.Clear();
            imagelist.ImageSize = new System.Drawing.Size(64, 32);

            Connect();

            sql = @"SELECT DISTINCT modphoto FROM models";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  if (!reader.IsDBNull(0))
                  {
                     try
                     {
                        FileInfo file = new FileInfo(Path.Combine(ModelDAO.ImagesPath, "th_" + reader.GetString(0)));
                        if (file.Exists)
                        {
                           System.Drawing.Image image = (System.Drawing.Image)new System.Drawing.Bitmap(file.FullName);
                           imagelist.Images.Add(reader.GetString(0), image);
                        }
                     }
                     catch
                     {
                        // Si una imagen no se encuentra no se tiene en cuenta (se descarta el error)
                     }
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      #endregion

      #region Attachments Methods

      /// <summary>
      /// Agrega un documento al modelo.
      /// </summary>
      /// <param name="attachment">Una instancia de <see cref="ModelFileAttachment"/> que contiene los detalles del adjunto.</param>
      /// <remarks>
      /// Cuando se añade un documento el atributo <see cref="ModelFileAttachment.Filename"/> debe contener el nombre de archivo con la ruta de origen a fin de copiar
      /// el documento. Una vez adjuntado, esta propiedad quedará sólo con el nombre (sin ruta).
      /// </remarks>
      public void AddAttachment(ModelFileAttachment attachment)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            // Copia el archivo
            FileInfo file = new FileInfo(attachment.Filename);
            file.CopyTo(Path.Combine(DecoderDAO.FilesPath, attachment.ModelID.ToString("00000") + "." + file.Name));

            // Registra el archivo en la base de datos
            sql = @"INSERT INTO 
                        modelfiles (filemodelid, filetitle, filename) 
                    VALUES 
                        (@filemodelid, @filetitle, @filename)";

            SetParameter("filemodelid", attachment.ModelID);
            SetParameter("filetitle", attachment.Name);
            SetParameter("filename", attachment.ModelID.ToString("00000") + "." + file.Name);
            ExecuteNonQuery(sql);

            // Obtiene el nuevo ID
            sql = @"SELECT 
                        Max(fileid) As id 
                    FROM 
                        modelfiles";

            attachment.ID = (int)ExecuteScalar(sql);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Obtiene las propiedades de un documento adjunto.
      /// </summary>
      /// <param name="attachmentId">Identificador único del documento adjunto.</param>
      /// <returns>Una instancia de <see cref="ModelFileAttachment"/> que contiene los datos del documento adjunto.</returns>
      public ModelFileAttachment GetAttachment(int attachmentId)
      {
         string sql = string.Empty;
         ModelFileAttachment file = null;

         try
         {
            Connect();

            // Obtiene los datos del modelo
            sql = @"SELECT 
                        filemodelid, 
                        filetitle, 
                        filename 
                    FROM 
                        modelfiles 
                    WHERE 
                        fileid = @fileid";

            SetParameter("fileid", attachmentId);

            using (SQLiteDataReader read = ExecuteReader(sql))
            {
               if (read.Read())
               {
                  file = new ModelFileAttachment();
                  file.ID = attachmentId;
                  file.ModelID = !read.IsDBNull(0) ? read.GetInt32(0) : 0;
                  file.Name = !read.IsDBNull(1) ? read.GetString(1) : string.Empty;
                  file.Filename = !read.IsDBNull(2) ? read.GetString(2) : string.Empty;
               }
               read.Close();
            }

            return file;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Elimina un documento adjunto.
      /// </summary>
      /// <param name="attachmentId">Identificador del docuemnto a eliminar.</param>
      public void DeleteAttachment(int attachmentId)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            // Obtiene el documento a eliminar
            ModelFileAttachment doc = GetAttachment(attachmentId);

            sql = @"DELETE 
                    FROM 
                        modelfiles 
                    WHERE 
                        fileid = @fileid";

            SetParameter("fileid", attachmentId);
            ExecuteNonQuery(sql);

            // Elimina el archivo asociado
            FileInfo file = new FileInfo(doc.GetFullFilename());
            file.Delete();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      //public void ListAttachments(ListView listView, int modelId)
      //{
      //   string sql = string.Empty;
      //   string ftype = string.Empty;
      //   ModelFileAttachment doc = null;
      //   ListViewItem item = null;

      //   try
      //   {
      //      // Genera la senténcia SQL que obtiene los elementos
      //      sql += "SELECT fileid, filetitle, filename " +
      //             "FROM modelfiles " +
      //             "WHERE filemodelid=@filemodelid " +
      //             "ORDER BY filename Asc";

      //      // Configura el control ListView
      //      listView.Items.Clear();
      //      listView.Columns.Clear();
      //      listView.Columns.Add("Nombre", 300);
      //      listView.Columns.Add("Tipo", 250);
      //      listView.View = System.Windows.Forms.View.Details;
      //      listView.SmallImageList = new ImageList();
      //      listView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;

      //      Connect();

      //      cmd = new OleDbCommand(sql, _app.Connection);

      //      SetParameter("filemodelid", OleDbType.Integer);
      //      param.Value = modelId;


      //      reader = cmd.ExecuteReader();
      //      while (reader.Read())
      //      {
      //         // Obtiene el documento
      //         doc = new ModelFileAttachment();
      //         doc.ID = !reader.IsDBNull(0) ? reader.GetInt32(0) : 0;
      //         doc.ModelID = modelId;
      //         doc.Name = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
      //         doc.Filename = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;

      //         // Obtiene el icono del tipo de documnento
      //         Icon icon = Shell.GetSmallIcon(doc.GetFullFilename(), out ftype);
      //         if (icon != null)
      //            listView.SmallImageList.Images.Add(doc.ID + "_ICO", icon);

      //         // Representa el elemento en la lista
      //         item = new ListViewItem();
      //         item.Tag = doc;
      //         item.Text = doc.Name;
      //         item.ImageKey = doc.ID + "_ICO";
      //         item.SubItems.Add(ftype);

      //         listView.Items.Add(item);
      //      }
      //      reader.Close();
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      reader.Dispose();
      //      cmd.Dispose();
      //   }
      //}

      #endregion

      #region Static Members

      internal static CollectionModel ReadEntityObject(SQLiteDataReader reader)
      {
         CollectionModel item = new CollectionModel();
         item.ID = reader.GetInt32(0);
         item.AdminID = reader.GetInt32(1);
         item.StoreID = reader.GetInt32(2);
         item.CategoryID = reader.GetInt32(3);
         item.Name = reader.GetString(4);
         item.PaintScheme = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
         item.Era = !reader.IsDBNull(6) ? (CollectionModel.Epoche)reader.GetInt32(6) : CollectionModel.Epoche.NotDefined;
         item.Reference = !reader.IsDBNull(7) ? reader.GetString(7) : string.Empty;
         item.ManufacturerID = reader.GetInt32(8);
         item.ScaleID = reader.GetInt32(9);
         item.BuyPriceCatalogue = !reader.IsDBNull(10) ? reader.GetDecimal(10) : 0;
         item.BuyPricePurchase = !reader.IsDBNull(11) ? reader.GetDecimal(11) : 0;
         item.BuyDate = !reader.IsDBNull(12) ? reader.GetDateTime(12) : DateTime.MinValue;
         item.BuyIsPending = reader.GetBoolean(13);
         item.CouplersType = (CollectionModel.CouplerTypes)reader.GetInt32(14);
         item.HaveFunctionalPantos = reader.GetBoolean(15);
         item.HaveSound = reader.GetBoolean(16);
         item.IsLimited = reader.GetBoolean(17);
         item.LimitedYear = !reader.IsDBNull(18) ? reader.GetString(18) : string.Empty;
         item.Length = !reader.IsDBNull(19) ? reader.GetInt32(19) : 0;
         item.Frame = !reader.IsDBNull(20) ? (CollectionModel.FrameType)reader.GetInt32(20) : 0;
         item.InteriorEquipment = !reader.IsDBNull(21) ? (CollectionModel.InteriorEquipmentType)reader.GetInt32(21) : 0;
         item.LightFront = (CollectionModel.LightFrontType)reader.GetInt32(22);
         item.LightInterior = !reader.IsDBNull(23) ? (CollectionModel.LightInteriorType)reader.GetInt32(23) : 0;
         item.LightRear = !reader.IsDBNull(24) ? (CollectionModel.LightRearType)reader.GetInt32(24) : 0;
         item.HaveOriginalBox = !reader.IsDBNull(25) ? reader.GetBoolean(25) : false;
         item.WheelDisposition = !reader.IsDBNull(26) ? reader.GetString(26) : string.Empty;
         item.AxisWithTraction = !reader.IsDBNull(27) ? reader.GetInt32(27) : 0;
         item.AxisWithTractionTires = !reader.IsDBNull(28) ? reader.GetInt32(28) : 0;
         item.Description = !reader.IsDBNull(29) ? reader.GetString(29) : string.Empty;
         item.PictureFileName = !reader.IsDBNull(30) ? reader.GetString(30) : string.Empty;
         item.Units = reader.GetInt32(31);
         item.DigitalAddress = !reader.IsDBNull(32) ? reader.GetInt32(32) : 0;
         item.DigitalDecoderID = !reader.IsDBNull(33) ? reader.GetInt32(33) : 0;
         item.DigitalConnector = !reader.IsDBNull(34) ? (CollectionModel.DigitalConnectorType)reader.GetInt32(34) : 0;
         item.RegistrationNumber = !reader.IsDBNull(35) ? reader.GetString(35) : string.Empty;
         item.Type = !reader.IsDBNull(36) ? reader.GetString(36) : string.Empty;
         item.TypeUIC = !reader.IsDBNull(37) ? reader.GetString(37) : string.Empty;
         item.EngineType = !reader.IsDBNull(38) ? reader.GetString(38) : string.Empty;
         item.MaintenanceRevisionHours = !reader.IsDBNull(39) ? reader.GetInt32(39) : 0;
         item.MaintenanceServiceHours = !reader.IsDBNull(40) ? reader.GetInt32(40) : 0;

         return item;
      }

      /// <summary>
      /// Devuelve la ruta de acceso a la carpeta de imágenes
      /// </summary>
      public static string ImagesPath
      {
         get { return Path.Combine(Application.StartupPath, ModelDAO.ImagesFolderName); }
      }

      /// <summary>
      /// Devuelve la imagen asociada al pictograma de una época.
      /// </summary>
      /// <param name="epoche">Un elemento de la enumeración <c>Model.Epoche</c>.</param>
      /// <returns>Una instancia de <c>System.Drawing.Image</c> que representa la época indicada o <c>null</c> si ésta no tiene pictograma asociado.</returns>
      public static System.Drawing.Image GetEraPictogram(CollectionModel.Epoche epoche)
      {
         switch (epoche)
         {
            case CollectionModel.Epoche.EpocheI:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_EPOCHE_I_16;
            case CollectionModel.Epoche.EpocheII:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_EPOCHE_II_16;
            case CollectionModel.Epoche.EpocheIII:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_EPOCHE_III_16;
            case CollectionModel.Epoche.EpocheIV:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_EPOCHE_IV_16;
            case CollectionModel.Epoche.EpocheV:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_EPOCHE_V_16;
            case CollectionModel.Epoche.EpocheVI:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_EPOCHE_VI_16;
            default:
               return null;
         }
      }

      /// <summary>
      /// Devuelve el nombre asociado al pictograma de una época.
      /// </summary>
      /// <param name="epoche">Un elemento de la enumeración <c>Model.Epoche</c>.</param>
      /// <returns>Una cadena de texto que representa el nombre.</returns>
      public static string GetEraName(CollectionModel.Epoche epoche)
      {
         switch (epoche)
         {
            case CollectionModel.Epoche.EpocheI:
               return "Época I";
            case CollectionModel.Epoche.EpocheII:
               return "Época II";
            case CollectionModel.Epoche.EpocheIII:
               return "Época III";
            case CollectionModel.Epoche.EpocheIV:
               return "Época IV";
            case CollectionModel.Epoche.EpocheV:
               return "Época V";
            case CollectionModel.Epoche.EpocheVI:
               return "Época VI";
            default:
               return "No definida";
         }
      }

      /// <summary>
      /// Devuelve la imagen asociada al pictograma del tipo de carcasa/bastidor del modelo.
      /// </summary>
      /// <param name="frame">Un elemento de la enumeración <c>Model.FrameType</c>.</param>
      /// <returns>Una instancia de <c>System.Drawing.Image</c> que representa el tipo de bastidor/carcasa o <c>null</c> si ésta no tiene pictograma asociado.</returns>
      public static System.Drawing.Image GetFramePictogram(CollectionModel.FrameType frame)
      {
         switch (frame)
         {
            case CollectionModel.FrameType.AllMetall:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_FRAME_3;
            case CollectionModel.FrameType.Metall_Plastic:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_FRAME_1;
            case CollectionModel.FrameType.Metall_PlasticMetall:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_FRAME_2;
            default:
               return null;
         }
      }

      /// <summary>
      /// Devuelve el nombre asociado al tipo de carcasa/bastidor del modelo.
      /// </summary>
      /// <param name="frame">Un elemento de la enumeración <c>Model.FrameType</c>.</param>
      /// <returns>Una cadena de texto que representa el nombre.</returns>
      public static string GetFrameName(CollectionModel.FrameType frame)
      {
         switch (frame)
         {
            case CollectionModel.FrameType.AllMetall:
               return "Bastidor metálico, carcasa de metal";
            case CollectionModel.FrameType.Metall_Plastic:
               return "Bastidor metálico, carcasa de plástico";
            case CollectionModel.FrameType.Metall_PlasticMetall:
               return "Bastidor metálico, carcasa de metal y plástico";
            default:
               return "No especificado";
         }
      }

      public static System.Drawing.Image GetFrontLightsPictogram(CollectionModel.LightFrontType lights)
      {
         switch (lights)
         {
            case CollectionModel.LightFrontType.FixedFrontLights:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_LIGHTS_FRONT1;
            case CollectionModel.LightFrontType.OneLightDependingSense:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_LIGHTS_FRONT2;
            case CollectionModel.LightFrontType.TwoLightDependingSense:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_LIGHTS_FRONT3;
            case CollectionModel.LightFrontType.ThreeLightDependingSense:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_LIGHTS_FRONT4;
            case CollectionModel.LightFrontType.ThreeLightsForwardOneFocusBack:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_LIGHTS_FRONT6;
            case CollectionModel.LightFrontType.WhiteLightsForwardRedFocusBack:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_LIGHTS_FRONT6;
            default:
               return null;
         }
      }

      /// <summary>
      /// Devuelve el nombre asociado al tipo de iluminación frontal del modelo.
      /// </summary>
      /// <param name="lights">Un elemento de la enumeración <c>Model.LightFrontType</c>.</param>
      /// <returns>Una cadena de texto que representa el nombre.</returns>
      public static string GetFrontLightsName(CollectionModel.LightFrontType lights)
      {
         switch (lights)
         {
            case CollectionModel.LightFrontType.FixedFrontLights:
               return "Iluminación fija en un sólo sentido";
            case CollectionModel.LightFrontType.OneLightDependingSense:
               return "Un foco según sentido de la marcha";
            case CollectionModel.LightFrontType.TwoLightDependingSense:
               return "Dos focos según sentido de la marcha";
            case CollectionModel.LightFrontType.ThreeLightDependingSense:
               return "Tres focos según sentido de la marcha";
            case CollectionModel.LightFrontType.ThreeLightsForwardOneFocusBack:
               return "Tres focos hacia adelante y uno hacia atrás";
            case CollectionModel.LightFrontType.WhiteLightsForwardRedFocusBack:
               return "Tres focos hacia adelante y dos rojos hacia atrás";
            default:
               return "Sin iluminación frontal";
         }
      }

      public static System.Drawing.Image GetInteriorLightsPictogram(CollectionModel.LightInteriorType lights)
      {
         switch (lights)
         {
            case CollectionModel.LightInteriorType.NormalLight:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_INTLIGHTS_BULB;
            case CollectionModel.LightInteriorType.LedLight:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_INTLIGHTS_LED;
            default:
               return null;
         }
      }

      /// <summary>
      /// Devuelve el nombre asociado al tipo de iluminación interior del modelo.
      /// </summary>
      /// <param name="lights">Un elemento de la enumeración <c>Model.LightInteriorType</c>.</param>
      /// <returns>Una cadena de texto que representa el nombre.</returns>
      public static string GetInteriorLightsName(CollectionModel.LightInteriorType lights)
      {
         switch (lights)
         {
            case CollectionModel.LightInteriorType.NormalLight:
               return "Iluminación interior";
            case CollectionModel.LightInteriorType.LedLight:
               return "Iluminación interior LED";
            default:
               return "Sin iluminación interior";
         }
      }

      public static System.Drawing.Image GetRearLightsPictogram(CollectionModel.LightRearType lights)
      {
         switch (lights)
         {
            case CollectionModel.LightRearType.WithLight:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_LIGHTS_REAR1;
            default:
               return null;
         }
      }

      /// <summary>
      /// Devuelve el nombre asociado al tipo de iluminación trasera del modelo.
      /// </summary>
      /// <param name="lights">Un elemento de la enumeración <c>Model.LightRearType</c>.</param>
      /// <returns>Una cadena de texto que representa el nombre.</returns>
      public static string GetRearLightsName(CollectionModel.LightRearType lights)
      {
         switch (lights)
         {
            case CollectionModel.LightRearType.WithLight:
               return "Con iluminación trasera";
            default:
               return "Sin iluminación trasera";
         }
      }

      public static System.Drawing.Image GetInteriorEquipmentPictogram(CollectionModel.InteriorEquipmentType equipment)
      {
         switch (equipment)
         {
            case CollectionModel.InteriorEquipmentType.WithDecoration:
               return (System.Drawing.Image)global::Rwm.Studio.Plugins.Collection.Properties.Resources.PICTO_INTERIOR_EQUIPMENT_32;
            default:
               return null;
         }
      }

      /// <summary>
      /// Devuelve un modelo de la tabla y sus datos foráneos.
      /// </summary>
      static public DataTable GetDataTable()
      {
         return GetDataTable(null);
      }

      /// <summary>
      /// Devuelve un modelo de la tabla y sus datos foráneos.
      /// </summary>
      static public DataTable GetDataTable(List<string> columns)
      {
         DataTable table = new DataTable();
         table.Name = "MODELS";
         table.Title = "Modelos de la colección";
         table.ID = "MODELS.MODID";
         table.Icon = "MODELS.MODPHOTO";

         if (columns == null || columns.Contains("MODELS.MODID"))
            table.Fields.Add(new DataColumn("MODELS.MODID", "ID", OleDbType.Integer, "g0"));
         if (columns == null || columns.Contains("MODELS.MODNAME"))
            table.Fields.Add(new DataColumn("MODELS.MODNAME", "Nombre", OleDbType.WChar, "g0", 200));
         if (columns == null || columns.Contains("TYPES.TYPENAME"))
            table.Fields.Add(new DataColumn("TYPES.TYPENAME", "Categoria", OleDbType.WChar, "g0"));
         if (columns == null || columns.Contains("MODELS.MODUNITS"))
            table.Fields.Add(new DataColumn("MODELS.MODUNITS", "Cantidad", OleDbType.Integer, "g0", 60, HorizontalAlignment.Center));

         if (columns == null || columns.Contains("STORES.STORENAME"))
            table.Fields.Add(new DataColumn("STORES.STORENAME", "Comercio", OleDbType.WChar, "g1", 200));
         if (columns == null || columns.Contains("BUILDERS.BUILDNAME"))
            table.Fields.Add(new DataColumn("BUILDERS.BUILDNAME", "Fabricante", OleDbType.WChar, "g1", 170));
         if (columns == null || columns.Contains("MODELS.MODREF"))
            table.Fields.Add(new DataColumn("MODELS.MODREF", "Referencia", OleDbType.WChar, "g1", 80));
         if (columns == null || columns.Contains("SCALES.SCNAME"))
            table.Fields.Add(new DataColumn("SCALES.SCNAME", "Escala", OleDbType.WChar, "g1", 50, HorizontalAlignment.Center));
         if (columns == null || columns.Contains("MODELS.MODCATPRICE"))
            table.Fields.Add(new DataColumn("MODELS.MODCATPRICE", "Precio de catálogo", OleDbType.Currency, "g1", 70, HorizontalAlignment.Right));
         if (columns == null || columns.Contains("MODELS.MODBUYPRICE"))
            table.Fields.Add(new DataColumn("MODELS.MODBUYPRICE", "Precio de compra", OleDbType.Currency, "g1", 70, HorizontalAlignment.Right));
         if (columns == null || columns.Contains("MODELS.MODBUYPENDING"))
            table.Fields.Add(new DataColumn("MODELS.MODBUYPENDING", "Compra pendiente", OleDbType.Boolean, "g1"));
         if (columns == null || columns.Contains("MODELS.MODBUYDATE"))
            table.Fields.Add(new DataColumn("MODELS.MODBUYDATE", "Fecha de compra", OleDbType.Date, "g1", 110, HorizontalAlignment.Center));
         if (columns == null || columns.Contains("MODELS.MODKKK"))
            table.Fields.Add(new DataColumn("MODELS.MODKKK", "Cinemática de enganche corto", OleDbType.Boolean, "g1"));
         if (columns == null || columns.Contains("MODELS.MODNEM"))
            table.Fields.Add(new DataColumn("MODELS.MODNEM", "Cajetines normalizados NEM", OleDbType.Boolean, "g1"));
         if (columns == null || columns.Contains("MODELS.MODPANT"))
            table.Fields.Add(new DataColumn("MODELS.MODPANT", "Pantógrafo funcional", OleDbType.Boolean, "g1"));
         if (columns == null || columns.Contains("MODELS.MODSOUND"))
            table.Fields.Add(new DataColumn("MODELS.MODSOUND", "Sonido digital", OleDbType.Boolean, "g1"));
         if (columns == null || columns.Contains("MODELS.MODLIM"))
            table.Fields.Add(new DataColumn("MODELS.MODLIM", "Serie limitada", OleDbType.Boolean, "g1"));
         if (columns == null || columns.Contains("MODELS.MODLIMYEAR"))
            table.Fields.Add(new DataColumn("MODELS.MODLIMYEAR", "Serie limitada al año", OleDbType.WChar, "g1"));
         if (columns == null || columns.Contains("MODELS.MODLIGHTINTERIOR"))
            table.Fields.Add(new DataColumn("MODELS.MODLIGHTINTERIOR", "Iluminación interior", OleDbType.Integer, "g1"));
         if (columns == null || columns.Contains("MODELS.MODLIGHTREAR"))
            table.Fields.Add(new DataColumn("MODELS.MODLIGHTREAR", "Iluminación trasera", OleDbType.Integer, "g1"));
         if (columns == null || columns.Contains("MODELS.MODFRONTLIGHTS"))
            table.Fields.Add(new DataColumn("MODELS.MODFRONTLIGHTS", "Iluminación frontal", OleDbType.SmallInt, "g1"));
         if (columns == null || columns.Contains("MODELS.MODLENGTH"))
            table.Fields.Add(new DataColumn("MODELS.MODLENGTH", "Longitud", OleDbType.Integer, "g1"));
         if (columns == null || columns.Contains("MODELS.MODDIGITALADD"))
            table.Fields.Add(new DataColumn("MODELS.MODDIGITALADD", "Dirección digital", OleDbType.Integer, "g1"));
         if (columns == null || columns.Contains("MODELS.DECNAME"))
            table.Fields.Add(new DataColumn("DECODERS.DECNAME", "Descodificador", OleDbType.WChar, "g1"));
         if (columns == null || columns.Contains("MODELS.MODFRAME"))
            table.Fields.Add(new DataColumn("MODELS.MODFRAME", "Carcasa", OleDbType.Integer, "g1"));
         if (columns == null || columns.Contains("MODELS.MODDECOINTERIOR"))
            table.Fields.Add(new DataColumn("MODELS.MODDECOINTERIOR", "Decoración interior", OleDbType.Integer, "g1"));
         if (columns == null || columns.Contains("MODELS.MODDIGITALCONNECTOR"))
            table.Fields.Add(new DataColumn("MODELS.MODDIGITALCONNECTOR", "Conector digital", OleDbType.Integer, "g1"));
         if (columns == null || columns.Contains("MODELS.MODORIGINALBOX"))
            table.Fields.Add(new DataColumn("MODELS.MODORIGINALBOX", "Caja original", OleDbType.Boolean, "g1"));
         if (columns == null || columns.Contains("MODELS.MODENGINETYPE"))
            table.Fields.Add(new DataColumn("MODELS.MODENGINETYPE", "Motorización", OleDbType.WChar, "g1"));
         if (columns == null || columns.Contains("MODELS.MODAXISTRACTION"))
            table.Fields.Add(new DataColumn("MODELS.MODAXISTRACTION", "Ejes con tracción", OleDbType.Integer, "g1"));
         if (columns == null || columns.Contains("MODELS.MODAXISTIRES"))
            table.Fields.Add(new DataColumn("MODELS.MODAXISTIRES", "Ejes con aros de adherencia", OleDbType.Integer, "g1"));

         if (columns == null || columns.Contains("MODELS.ADMINNAME"))
            table.Fields.Add(new DataColumn("ADMINS.ADMINNAME", "Administración", OleDbType.WChar, "g2"));
         if (columns == null || columns.Contains("MODELS.MODERA"))
            table.Fields.Add(new DataColumn("MODELS.MODERA", "Época", OleDbType.SmallInt, "g2"));
         if (columns == null || columns.Contains("MODELS.MODPAINT"))
            table.Fields.Add(new DataColumn("MODELS.MODPAINT", "Esquema de pintura", OleDbType.WChar, "g2"));
         if (columns == null || columns.Contains("MODELS.MODREGNUMBER"))
            table.Fields.Add(new DataColumn("MODELS.MODREGNUMBER", "Matrícula", OleDbType.WChar, "g2"));
         if (columns == null || columns.Contains("MODELS.MODTYPE"))
            table.Fields.Add(new DataColumn("MODELS.MODTYPE", "Tipo", OleDbType.WChar, "g2"));
         if (columns == null || columns.Contains("MODELS.MODTYPEUIC"))
            table.Fields.Add(new DataColumn("MODELS.MODTYPEUIC", "Tipo UIC", OleDbType.WChar, "g2"));
         if (columns == null || columns.Contains("MODELS.MODAXISDISP"))
            table.Fields.Add(new DataColumn("MODELS.MODAXISDISP", "Disposición de ejes", OleDbType.WChar, "g2"));

         return table;
      }

      #endregion

      #region Disabled Code

      ///// <summary>
      ///// Rellena un control ListView con una lista de modelos de la colección.
      ///// </summary>
      ///// <param name="listView">Control contenedor de la lista.</param>
      ///// <param name="reportType">Tipo de listado.</param>
      ///// <param name="filterId">Identificador de la carpeta contenedora.</param>
      //public void List(ListView listView, ReportTypes reportType, int filterId)
      //{
      //   string sql = string.Empty;
      //   OleDbCommand cmd = null;

      //   try
      //   {
      //      // Genera la senténcia SQL que obtiene los elementos
      //      sql += "SELECT models.modid, models.modname, models.modbuydate, admins.adminname, builders.buildname, scales.scname, models.modref, models.modunits, types.typeicon, models.modphoto ";
      //      sql += "FROM types RIGHT JOIN (builders RIGHT JOIN (admins RIGHT JOIN (scales RIGHT JOIN models ON scales.scid = models.modscale) ON admins.adminid = models.modadminid) ON builders.buildid = models.modbuilderid) ON types.typeid = models.modtypeid ";
      //      switch (reportType)
      //      {
      //         case ReportTypes.All:
      //            // Do nothing
      //            break;
      //         case ReportTypes.Administration:
      //            sql += "WHERE models.modadminid=" + filterId + " and modbuypending=false ";
      //            break;
      //         case ReportTypes.Manufacturer:
      //            sql += "WHERE models.modbuilderid=" + filterId + " and modbuypending=false ";
      //            break;
      //         case ReportTypes.Type:
      //            sql += "WHERE models.modtypeid=" + filterId + " and modbuypending=false ";
      //            break;
      //         case ReportTypes.BuyPending:
      //            sql += "WHERE models.modbuypending=true ";
      //            break;
      //         case ReportTypes.ModelsWithMaintenance:
      //            sql += "WHERE types.typemaint=true ";
      //            break;
      //      }
      //      sql += "ORDER BY models.modname ASC";

      //      // Configura el control ListView
      //      listView.Items.Clear();
      //      listView.Columns.Clear();
      //      listView.Columns.Add("Nombre", 200);
      //      listView.Columns.Add("Administración", 100);
      //      listView.Columns.Add("Fabricante", 170);
      //      listView.Columns.Add("Escala", 50, HorizontalAlignment.Center);
      //      listView.Columns.Add("Referencia", 80);
      //      listView.Columns.Add("Fecha de compra", 110, HorizontalAlignment.Center);
      //      listView.Columns.Add("Cantidad", 60, HorizontalAlignment.Center);
      //      listView.View = System.Windows.Forms.View.Details;

      //      Connect();
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem();
      //            item.Tag = reader.GetInt32(0);
      //            item.Text = reader.GetString(1);
      //            item.SubItems.Add(!reader.IsDBNull(3) ? reader.GetString(3) : string.Empty);
      //            item.SubItems.Add(!reader.IsDBNull(4) ? reader.GetString(4) : string.Empty);
      //            item.SubItems.Add(!reader.IsDBNull(5) ? reader.GetString(5) : string.Empty);
      //            item.SubItems.Add(!reader.IsDBNull(6) ? reader.GetString(6) : string.Empty);
      //            if (reader.IsDBNull(2) || reader.GetDateTime(2).Year < 1900) item.SubItems.Add("No especificada");
      //            else item.SubItems.Add(reader.GetDateTime(2).ToString(Rwm.Otc.windows.OTCForms.FORMAT_DATE_SIMPLE));
      //            item.SubItems.Add(reader.GetInt32(7).ToString());
      //            if (!reader.IsDBNull(9)) item.ImageKey = reader.GetString(9);

      //            listView.Items.Add(item);
      //         }
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      cmd.Dispose();
      //   }
      //}

      ///// <summary>
      ///// Rellena un control ListView con el listado completo de modelos de la colección.
      ///// </summary>
      ///// <param name="listView">Control contenedor de la lista.</param>
      //public void List(ListView listView)
      //{
      //   this.List(listView, ReportTypes.All, 0);
      //}

      ///// <summary>
      ///// Rellena un control ListView con el listado completo de modelos de la colección.
      ///// </summary>
      ///// <param name="listView">Control contenedor de la lista.</param>
      ///// <param name="loadImages">Indica si de forma transparente se debe asociar un objeto ImageList y cargarlo con las imágenes de los modelos.</param>
      //public void List(ListView listView, ReportTypes reportType, bool loadImages)
      //{
      //   if (loadImages)
      //   {
      //      listView.SmallImageList = new ImageList();
      //      LoadImageList(listView.SmallImageList);
      //   }

      //   this.List(listView, reportType, 0);
      //}

      ///// <summary>
      ///// Rellena un control ListView con el listado completo de modelos de la colección.
      ///// </summary>
      ///// <param name="listView">Control contenedor de la lista.</param>
      ///// <param name="loadImages">Indica si de forma transparente se debe asociar un objeto ImageList y cargarlo con las imágenes de los modelos.</param>
      //public void List(ListView listView, bool loadImages)
      //{
      //   if (loadImages)
      //   {
      //      listView.SmallImageList = new ImageList();
      //      LoadImageList(listView.SmallImageList);
      //   }

      //   this.List(listView, ReportTypes.All, 0);
      //}

      ///// <summary>
      ///// Genera el árbol de carpetas correspondiente a los modelos.
      ///// </summary>
      ///// <param name="treeview">Control TreeView sobre el que se realizará el árbol.</param>
      ///// <param name="parentKey">Identificador del nodo bajo el que se creará el árbol.</param>
      //public void FolderTree(TreeView treeview, string rootName)
      //{
      //   // Inicializa el control
      //   treeview.Nodes.Clear();

      //   // Inicializa los iconos del árbol
      //   treeview.ImageList = new ImageList();
      //   treeview.ImageList.ColorDepth = ColorDepth.Depth32Bit;
      //   treeview.ImageList.ImageSize = new System.Drawing.Size(16, 16);
      //   treeview.ImageList.Images.Add("IMG_BOOK_16", global::Rwm.collection.Properties.Resources.IMG_BOOK_16);
      //   treeview.ImageList.Images.Add("IMG_FOLDER_16", global::Rwm.collection.Properties.Resources.IMG_FOLDER_16);
      //   treeview.ImageList.Images.Add("IMG_SHOP_16", global::Rwm.collection.Properties.Resources.IMG_SHOP_16);
      //   treeview.ImageList.Images.Add("IMG_FOLDER_FIND_16", global::Rwm.collection.Properties.Resources.IMG_FOLDER_FIND_16);
      //   treeview.ImageList.Images.Add("IMG_FOLDER_STAR_16", global::Rwm.collection.Properties.Resources.IMG_FOLDER_STAR_16);
      //   treeview.ImageList.Images.Add("IMG_FOLDER_DIGITAL_16", global::Rwm.collection.Properties.Resources.IMG_FOLDER_DIGITAL_16);

      //   // Agrega el nodo raíz
      //   treeview.Nodes.Add("root", rootName, "IMG_BOOK_16", "IMG_BOOK_16").Expand();
      //   treeview.Nodes["root"].Tag = (int)RCApplication.ObjectTypes.Nothing;

      //   // Genera las carpetas de clasificación de modelos
      //   SubfolderTree(treeview, "root");

      //   // Agrega las carpetas especiales
      //   treeview.Nodes["root"].Nodes.Add("collect_all", "Colección completa", "IMG_FOLDER_STAR_16", "IMG_FOLDER_STAR_16");
      //   treeview.Nodes["root"].Nodes["collect_all"].Tag = (int)ReportTypes.All;

      //   treeview.Nodes["root"].Nodes.Add("collect_buypending", "Compras pendientes", "IMG_SHOP_16", "IMG_SHOP_16");
      //   treeview.Nodes["root"].Nodes["collect_buypending"].Tag = (int)ReportTypes.BuyPending;

      //   treeview.Nodes["root"].Nodes.Add("digital", "Lista de direcciones digitales", "IMG_FOLDER_DIGITAL_16", "IMG_FOLDER_DIGITAL_16").Expand();
      //   treeview.Nodes["root"].Nodes["digital"].Tag = (int)ReportTypes.Digitalized;

      //   treeview.Nodes["root"].Nodes.Add("search", "Resultados de la búsqueda", "IMG_FOLDER_FIND_16", "IMG_FOLDER_FIND_16").Expand();
      //   treeview.Nodes["root"].Nodes["search"].Tag = (int)ReportTypes.SearchResults;

      //   treeview.ExpandAll();
      //}

      ///// <summary>
      ///// Genera el árbol de carpetas correspondiente a los modelos.
      ///// </summary>
      ///// <param name="treeview">Control TreeView sobre el que se realizará el árbol.</param>
      ///// <param name="parentKey">Identificador del nodo bajo el que se creará el árbol.</param>
      //public void FolderTree(RadTreeView treeview, string rootName)
      //{
      //   RadTreeNode node;

      //   // Inicializa el control
      //   treeview.Nodes.Clear();

      //   // Inicializa los iconos del árbol
      //   treeview.ImageList = new ImageList();
      //   treeview.ImageList.ColorDepth = ColorDepth.Depth32Bit;
      //   treeview.ImageList.ImageSize = new System.Drawing.Size(16, 16);
      //   treeview.ImageList.Images.Add("IMG_BOOK_16", global::Rwm.collection.Properties.Resources.IMG_BOOK_16);
      //   treeview.ImageList.Images.Add("IMG_FOLDER_16", global::Rwm.collection.Properties.Resources.IMG_FOLDER_16);
      //   treeview.ImageList.Images.Add("IMG_SHOP_16", global::Rwm.collection.Properties.Resources.IMG_SHOP_16);
      //   treeview.ImageList.Images.Add("IMG_FOLDER_FIND_16", global::Rwm.collection.Properties.Resources.IMG_FOLDER_FIND_16);
      //   treeview.ImageList.Images.Add("IMG_FOLDER_STAR_16", global::Rwm.collection.Properties.Resources.IMG_FOLDER_STAR_16);
      //   treeview.ImageList.Images.Add("IMG_FOLDER_DIGITAL_16", global::Rwm.collection.Properties.Resources.IMG_FOLDER_DIGITAL_16);

      //   // Agrega el nodo raíz
      //   node = new RadTreeNode();
      //   node.Name = "root";
      //   node.Text = rootName;
      //   node.ImageKey = "IMG_BOOK_16";

      //   treeview.Nodes.Add(node);
      //   node.Expand();
      //   treeview.Nodes["root"].Tag = (int)RCApplication.ObjectTypes.Nothing;

      //   // Genera las carpetas de clasificación de modelos
      //   SubfolderTree(treeview, "root");

      //   // Agrega las carpetas especiales
      //   node = new RadTreeNode();
      //   node.Name = "collect_all";
      //   node.Text = "Colección completa";
      //   node.ImageKey = "IMG_FOLDER_STAR_16";

      //   treeview.Nodes["root"].Nodes.Add(node);
      //   treeview.Nodes["root"].Nodes["collect_all"].Tag = (int)ReportTypes.All;

      //   node = new RadTreeNode();
      //   node.Name = "collect_buypending";
      //   node.Text = "Compras pendientes";
      //   node.ImageKey = "IMG_SHOP_16";

      //   treeview.Nodes["root"].Nodes.Add(node);
      //   treeview.Nodes["root"].Nodes["collect_buypending"].Tag = (int)ReportTypes.BuyPending;

      //   node = new RadTreeNode();
      //   node.Name = "digital";
      //   node.Text = "Lista de direcciones digitales";
      //   node.ImageKey = "IMG_FOLDER_DIGITAL_16";

      //   treeview.Nodes["root"].Nodes.Add(node);
      //   treeview.Nodes["root"].Nodes["digital"].Tag = (int)ReportTypes.Digitalized;

      //   node = new RadTreeNode();
      //   node.Name = "search";
      //   node.Text = "Resultados de la búsqueda";
      //   node.ImageKey = "IMG_FOLDER_FIND_16";

      //   treeview.Nodes["root"].Nodes.Add(node);
      //   treeview.Nodes["root"].Nodes["search"].Tag = (int)ReportTypes.SearchResults;

      //   treeview.ExpandAll();
      //}

      ///// <summary>
      ///// Genera el árbol de carpetas correspondiente a los modelos.
      ///// </summary>
      ///// <param name="treeview">Control TreeView sobre el que se realizará el árbol.</param>
      ///// <param name="parentKey">Identificador del nodo bajo el que se creará el árbol.</param>
      //private void SubfolderTree(TreeView treeview, string parentKey)
      //{
      //   string sql = string.Empty;
      //   CollectionModel item = new CollectionModel();
      //   OleDbCommand cmd = null;

      //   try
      //   {
      //      // Si existe la rama "collect" la elimina
      //      /*if (treeview.Nodes[parentKey].Nodes["collect"] != null)
      //         treeview.Nodes[parentKey].Nodes["collect"].Nodes.Clear();
      //      else
      //      {
      //         treeview.Nodes[parentKey].Nodes.Add("collect", rootName, "ID_FOLDER", "ID_FOLDER");
      //         treeview.Nodes[parentKey].Nodes["collect"].Tag = (int)ReportTypes.All;
      //         treeview.Nodes[parentKey].Nodes["collect"].Expand();
      //      }*/

      //      Connect();

      //      // Rama: Marca
      //      treeview.Nodes[parentKey].Nodes.Add("collect_brand", "Por marca", "IMG_FOLDER_16", "IMG_FOLDER_16");
      //      treeview.Nodes[parentKey].Nodes["collect_brand"].Tag = (int)ReportTypes.Nothing;
      //      sql = "SELECT DISTINCT buildid, buildname " +
      //            "FROM builders INNER JOIN models ON (builders.buildid=models.modbuilderid) " +
      //            "ORDER BY buildname";
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            treeview.Nodes[parentKey].Nodes["collect_brand"].Nodes.Add(reader.GetInt32(0) + "_MANUFACTURER", reader.GetString(1), "IMG_FOLDER_STAR_16", "IMG_FOLDER_STAR_16").Expand();
      //            treeview.Nodes[parentKey].Nodes["collect_brand"].Nodes[reader.GetInt32(0) + "_MANUFACTURER"].Tag = (int)ReportTypes.Manufacturer;
      //         }
      //      }
      //      treeview.Nodes[parentKey].Nodes["collect_brand"].Expand();

      //      // Rama: Administración
      //      treeview.Nodes[parentKey].Nodes.Add("collect_admin", "Por administración", "IMG_FOLDER_16", "IMG_FOLDER_16");
      //      treeview.Nodes[parentKey].Nodes["collect_admin"].Tag = (int)ReportTypes.Nothing;
      //      sql = "SELECT DISTINCT adminid, adminname " +
      //            "FROM admins INNER JOIN models ON (admins.adminid=models.modadminid) " +
      //            "ORDER BY adminname";
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            treeview.Nodes[parentKey].Nodes["collect_admin"].Nodes.Add(reader.GetInt32(0) + "_ADMIN", reader.GetString(1), "IMG_FOLDER_STAR_16", "IMG_FOLDER_STAR_16").Expand();
      //            treeview.Nodes[parentKey].Nodes["collect_admin"].Nodes[reader.GetInt32(0) + "_ADMIN"].Tag = (int)ReportTypes.Administration;
      //         }
      //      }
      //      treeview.Nodes[parentKey].Nodes["collect_admin"].Expand();

      //      // Rama: Tipo
      //      treeview.Nodes[parentKey].Nodes.Add("collect_type", "Por tipo", "IMG_FOLDER_16", "IMG_FOLDER_16");
      //      treeview.Nodes[parentKey].Nodes["collect_type"].Tag = (int)ReportTypes.Nothing;
      //      sql = "SELECT DISTINCT typeid, typename " +
      //            "FROM types INNER JOIN models ON (types.typeid=models.modtypeid) " +
      //            "ORDER BY typename";
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            treeview.Nodes[parentKey].Nodes["collect_type"].Nodes.Add(reader.GetInt32(0) + "_TYPE", reader.GetString(1), "IMG_FOLDER_STAR_16", "IMG_FOLDER_STAR_16").Expand();
      //            treeview.Nodes[parentKey].Nodes["collect_type"].Nodes[reader.GetInt32(0) + "_TYPE"].Tag = (int)ReportTypes.Type;
      //         }
      //      }
      //      treeview.Nodes[parentKey].Nodes["collect_type"].Expand();
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      cmd.Dispose();
      //      // _app.Disconnect();
      //   }
      //}

      ///// <summary>
      ///// Genera el árbol de carpetas correspondiente a los modelos.
      ///// </summary>
      ///// <param name="treeview">Control TreeView sobre el que se realizará el árbol.</param>
      ///// <param name="parentKey">Identificador del nodo bajo el que se creará el árbol.</param>
      //private void SubfolderTree(RadTreeView treeview, string parentKey)
      //{
      //   string sql = string.Empty;
      //   CollectionModel item = new CollectionModel();
      //   RadTreeNode node;
      //   OleDbCommand cmd = null;

      //   try
      //   {
      //      Connect();

      //      // Rama: Marca
      //      node = new RadTreeNode();
      //      node.Name = "collect_brand";
      //      node.Text = "Por marca";
      //      node.ImageKey = "IMG_FOLDER_16";

      //      treeview.Nodes[parentKey].Nodes.Add(node);
      //      treeview.Nodes[parentKey].Nodes["collect_brand"].Tag = (int)ReportTypes.Nothing;

      //      sql = "SELECT DISTINCT buildid, buildname " +
      //            "FROM builders INNER JOIN models ON (builders.buildid=models.modbuilderid) " +
      //            "ORDER BY buildname";
      //      cmd = new OleDbCommand(sql, _app.Connection);

      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            node = new RadTreeNode();
      //            node.Name = reader.GetInt32(0) + "_MANUFACTURER";
      //            node.Text = reader.GetString(1);
      //            node.ImageKey = "IMG_FOLDER_STAR_16";

      //            treeview.Nodes[parentKey].Nodes["collect_brand"].Nodes.Add(node);
      //            treeview.Nodes[parentKey].Nodes["collect_brand"].Nodes[reader.GetInt32(0) + "_MANUFACTURER"].Tag = (int)ReportTypes.Manufacturer;
      //         }
      //      }
      //      treeview.Nodes[parentKey].Nodes["collect_brand"].Expand();

      //      // Rama: Administración
      //      node = new RadTreeNode();
      //      node.Name = "collect_admin";
      //      node.Text = "Por administración";
      //      node.ImageKey = "IMG_FOLDER_16";

      //      treeview.Nodes[parentKey].Nodes.Add(node);
      //      treeview.Nodes[parentKey].Nodes["collect_admin"].Tag = (int)ReportTypes.Nothing;

      //      sql = "SELECT DISTINCT adminid, adminname " +
      //            "FROM admins INNER JOIN models ON (admins.adminid=models.modadminid) " +
      //            "ORDER BY adminname";
      //      cmd = new OleDbCommand(sql, _app.Connection);

      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            node = new RadTreeNode();
      //            node.Name = reader.GetInt32(0) + "_ADMIN";
      //            node.Text = reader.GetString(1);
      //            node.ImageKey = "IMG_FOLDER_STAR_16";

      //            treeview.Nodes[parentKey].Nodes["collect_admin"].Nodes.Add(node);
      //            treeview.Nodes[parentKey].Nodes["collect_admin"].Nodes[reader.GetInt32(0) + "_ADMIN"].Tag = (int)ReportTypes.Administration;
      //         }
      //      }
      //      treeview.Nodes[parentKey].Nodes["collect_admin"].Expand();

      //      // Rama: Tipo
      //      node = new RadTreeNode();
      //      node.Name = "collect_type";
      //      node.Text = "Por tipo";
      //      node.ImageKey = "IMG_FOLDER_16";

      //      treeview.Nodes[parentKey].Nodes.Add(node);
      //      treeview.Nodes[parentKey].Nodes["collect_type"].Tag = (int)ReportTypes.Nothing;

      //      sql = "SELECT DISTINCT typeid, typename " +
      //            "FROM types INNER JOIN models ON (types.typeid=models.modtypeid) " +
      //            "ORDER BY typename";
      //      cmd = new OleDbCommand(sql, _app.Connection);

      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            node = new RadTreeNode();
      //            node.Name = reader.GetInt32(0) + "_TYPE";
      //            node.Text = reader.GetString(1);
      //            node.ImageKey = "IMG_FOLDER_STAR_16";

      //            treeview.Nodes[parentKey].Nodes["collect_type"].Nodes.Add(node);
      //            treeview.Nodes[parentKey].Nodes["collect_type"].Nodes[reader.GetInt32(0) + "_TYPE"].Tag = (int)ReportTypes.Type;
      //         }
      //      }
      //      treeview.Nodes[parentKey].Nodes["collect_type"].Expand();
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      cmd.Dispose();
      //      // _app.Disconnect();
      //   }
      //}

      ///// <summary>
      ///// Obtiene el número de modelos que usan un determinado archivo de imagen.
      ///// </summary>
      ///// <param name="filename">Nombre del archivo (sin path).</param>
      ///// <returns>Un valor entero que indica la cantidad de modelos que usan ese mismo archivo.</returns>
      //public int ImageExist(string filename)
      //{
      //   OleDbCommand cmd = null;
      //   OleDbParameter param = null;

      //   try
      //   {
      //      string sql = "SELECT Count(*) As nregs FROM models WHERE UCase(modphoto)=@filename";

      //      Connect();
      //      cmd = new OleDbCommand(sql, _app.Connection);

      //      SetParameter("filename", OleDbType.VarWChar, 255);
      //      param.Value = filename.Trim().ToUpper();


      //      return (int)cmd.ExecuteScalar();
      //   }
      //   catch
      //   {
      //      throw;
      //   }
      //   finally
      //   {
      //      Disconnect();
      //   }
      //}

      ///// <summary>
      ///// Exporta la colección a una hoja de Microsoft Excel.
      ///// Método que usa la Reflection para evitar importar librerías 
      ///// </summary>
      ///// <param name="table">Una instancia de <see cref="DataTable"/> que contiene la lista de columnas y el órden en que se desea exportar.</param>
      ///// <param name="format">Una opción de <see cref="ExportFormats"/> que indica el formato de los datos exportados.</param>
      ///// <param name="filename">Nombre del archivo donde se desea guardar el resultado.</param>
      //public void Export(DataTable table, ExportFormats format, string filename)
      //{
      //   try
      //   {
      //      switch (format)
      //      {
      //         case ExportFormats.XML:
      //            this.SaveToXML(table, filename);
      //            break;

      //         case ExportFormats.Excel:
      //            this.SaveToExcel(table, filename);
      //            break;
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //}

      //private OleDbDataReader GetItems(DataTable table)
      //{
      //   OleDbCommand cmd = null;

      //   // Generación de la senténcia SQL a ejecutar
      //   string sql = "SELECT ";
      //   foreach (DataColumn column in table.Fields)
      //      sql += column.Name + ", ";
      //   sql = sql.Trim().Substring(0, sql.Trim().Length - 1) + " ";

      //   sql += "FROM ((((TYPES RIGHT OUTER JOIN " +
      //          "        (BUILDERS RIGHT OUTER JOIN " +
      //          "        (DECODERS RIGHT OUTER JOIN " +
      //          "        MODELS ON DECODERS.DECID = MODELS.MODDECODERID) ON BUILDERS.BUILDID = MODELS.MODBUILDERID) ON TYPES.TYPEID = MODELS.MODTYPEID) " +
      //          "        LEFT OUTER JOIN " +
      //          "        SCALES ON MODELS.MODSCALE = SCALES.SCID) LEFT OUTER JOIN " +
      //          "        ADMINS ON MODELS.MODADMINID = ADMINS.ADMINID) LEFT OUTER JOIN " +
      //          "        STORES ON MODELS.MODSTOREID = STORES.STOREID)";
      //   sql += "ORDER BY MODELS.MODNAME ASC";

      //   Connect();
      //   cmd = new OleDbCommand(sql, _app.Connection);

      //   return cmd.ExecuteReader();
      //}

      ///// <summary>
      ///// Exporta la colección entera a un archivo XML.
      ///// </summary>
      ///// <param name="table">Una instancia de <see cref="DataTable"/> que contiene la lista de columnas y el órden en que se desea exportar.</param>
      ///// <param name="filename">Nombre y path del archivo de destino. Si el archivo ya existe, se sobreescribe.</param>
      //public void SaveToXML(DataTable table, string filename)
      //{
      //   try
      //   {
      //      // Asegura que no exista el archivo
      //      FileInfo file = new FileInfo(filename);
      //      if (file.Exists) file.Delete();

      //      // Abre el documento
      //      XmlTextWriter writer = new XmlTextWriter(filename, Encoding.UTF8);
      //      writer.WriteStartDocument();

      //      // Abre una cláusula OTC-COLLECTION
      //      writer.WriteStartElement("otc-collection");
      //      writer.WriteAttributeString("version", "1.0");
      //      writer.WriteAttributeString("generator", System.Windows.Forms.Application.ProductName);

      //      // Obtiene los elementos a exportar
      //      writer.WriteStartElement("modelos");

      //      using (OleDbDataReader reader = GetItems(table))
      //      {
      //         while (reader.Read())
      //         {
      //            writer.WriteStartElement("modelo");

      //            int idx = 0;
      //            foreach (DataColumn column in table.Fields)
      //            {
      //               switch (column.Type)
      //               {
      //                  case OleDbType.WChar:
      //                     writer.WriteAttributeString(column.Name.ToLower(), !reader.IsDBNull(idx) ? reader.GetString(idx) : string.Empty);
      //                     break;

      //                  case OleDbType.Boolean:
      //                     writer.WriteAttributeString(column.Name.ToLower(), !reader.IsDBNull(idx) ? (reader.GetBoolean(idx) ? "Sí" : "No") : "No");
      //                     break;

      //                  case OleDbType.Integer:
      //                     writer.WriteAttributeString(column.Name.ToLower(), !reader.IsDBNull(idx) ? reader.GetInt32(idx).ToString() : "0");
      //                     break;

      //                  case OleDbType.SmallInt:
      //                     writer.WriteAttributeString(column.Name.ToLower(), !reader.IsDBNull(idx) ? reader.GetInt16(idx).ToString() : "0");
      //                     break;

      //                  case OleDbType.Date:
      //                     writer.WriteAttributeString(column.Name.ToLower(), !reader.IsDBNull(idx) ? (reader.GetDateTime(idx) == DateTime.MinValue ? string.Empty : reader.GetDateTime(idx).ToString(Rwm.Otc.windows.OTCForms.FORMAT_DATE_SIMPLE)) : string.Empty);
      //                     break;
      //               }
      //               idx++;
      //            }

      //            writer.WriteEndElement();
      //         }
      //         writer.WriteEndElement();
      //      }

      //      // Cierra COLLECTION
      //      writer.WriteEndElement();

      //      // Cierra el documento
      //      writer.WriteEndDocument();
      //      writer.Close();
      //   }
      //   catch (Exception ex)
      //   {
      //      throw ex;
      //   }
      //}

      ///// <summary>
      ///// Exporta la colección entera a un archivo XML.
      ///// </summary>
      ///// <param name="filename">Nombre y path del archivo de destino. Si el archivo ya existe, se sobreescribe.</param>
      //public void SaveToExcel(DataTable table, string filename)
      //{
      //   try
      //   {
      //      using (OleDbDataReader reader = GetItems(table))
      //      {
      //         FileInfo newFile = new FileInfo(filename);
      //         if (newFile.Exists) newFile.Delete();

      //         using (SpreadsheetDocument xlsBook = SpreadsheetDocument.Create(newFile.FullName, SpreadsheetDocumentType.Workbook))
      //         {
      //            // Crea la hoja de cálculo
      //            xlsBook.AddWorkbookPart();
      //            xlsBook.WorkbookPart.Workbook = new Workbook();     // create the worksheet
      //            xlsBook.WorkbookPart.AddNewPart<WorksheetPart>();
      //            xlsBook.WorkbookPart.WorksheetParts.First().Worksheet = new Worksheet();

      //            // Crea la parte de datos de la hoja de cálculo
      //            xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.AppendChild(new SheetData());

      //            // Crea la cabecera
      //            xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.First().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Row());
      //            foreach (DataColumn column in table.Fields)
      //            {
      //               xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.First().First().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Cell() { CellValue = new CellValue(column.Title) });
      //            }

      //            // Rellena la tabla de datos
      //            int row = 2;
      //            int idx = 0;
      //            while (reader.Read())
      //            {
      //               // Agrega una nueva fila
      //               xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.First().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Row());

      //               idx = 0;
      //               foreach (DataColumn column in table.Fields)
      //               {
      //                  switch (column.Type)
      //                  {
      //                     case OleDbType.WChar:
      //                        xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.First().First().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Cell() { CellValue = new CellValue(!reader.IsDBNull(idx) ? reader.GetString(idx) : string.Empty) });
      //                        break;

      //                     case OleDbType.Boolean:
      //                        xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.First().First().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Cell() { CellValue = new CellValue(!reader.IsDBNull(idx) ? (reader.GetBoolean(idx) ? "Sí" : "No") : "No") });
      //                        break;

      //                     case OleDbType.Integer:
      //                        xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.First().First().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Cell() { CellValue = new CellValue(!reader.IsDBNull(idx) ? reader.GetInt32(idx).ToString() : "0") });
      //                        break;

      //                     case OleDbType.SmallInt:
      //                        xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.First().First().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Cell() { CellValue = new CellValue(!reader.IsDBNull(idx) ? reader.GetInt16(idx).ToString() : "0") });
      //                        break;

      //                     case OleDbType.Date:
      //                        xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.First().First().AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Cell() { CellValue = new CellValue(!reader.IsDBNull(idx) ? (reader.GetDateTime(idx) == DateTime.MinValue ? string.Empty : reader.GetDateTime(idx).ToString(Rwm.Otc.windows.OTCForms.FORMAT_DATE_SIMPLE)) : string.Empty) });
      //                        break;
      //                  }
      //                  idx++;
      //               }
      //               row++;
      //            }

      //            // Guarda el libro generado
      //            xlsBook.WorkbookPart.WorksheetParts.First().Worksheet.Save();
      //         }
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw e;
      //   }
      //}

      /*
      /// <summary>
      /// Rellena un control ImageComboBoxItem con una lista de escalas.
      /// </summary>
      /// <param name="comboBox">Control contenedor del listado.</param>
      /// <param name="defaultId">Identificador del elemento preseleccionado.</param>
      public static void LightsModeList(ImageComboBox comboBox, int defaultId)
      {
         comboBox.Items.Add(new ImageComboBoxItem("Sin iluminación", (int)RCModel.LightFrontType.WithoutLight));
         comboBox.Items.Add(new ImageComboBoxItem("Según sentido de marcha", (int)RCModel.LightFrontType.FrontWitheLights));
         comboBox.Items.Add(new ImageComboBoxItem("Conmutación blancas/rojas", (int)RCModel.LightFrontType.FrontWhiteRearRedLights));
         comboBox.Items.Add(new ImageComboBoxItem("Iluminación interior", (int)RCModel.LightFrontType.InteriorLights));

         if (defaultId == (int)RCModel.LightFrontType.WithoutLight) comboBox.SelectedIndex = 0;
         if (defaultId == (int)RCModel.LightFrontType.FrontWitheLights) comboBox.SelectedIndex = 1;
         if (defaultId == (int)RCModel.LightFrontType.FrontWhiteRearRedLights) comboBox.SelectedIndex = 2;
         if (defaultId == (int)RCModel.LightFrontType.InteriorLights) comboBox.SelectedIndex = 3;
      }

      /// <summary>
      /// Rellena un control ImageComboBoxItem con una lista de escalas.
      /// </summary>
      /// <param name="comboBox">Control contenedor del listado.</param>
      public static void LightsModeList(ImageComboBox comboBox)
      {
         ModelDAO.LightsModeList(comboBox, -1);
      }

      /// <summary>
      /// Rellena un control ImageComboBoxItem con una lista de escalas.
      /// </summary>
      /// <param name="comboBox">Control contenedor del listado.</param>
      /// <param name="startImageIndex">Índice inicial de las imágenes para colocar a cada opción de la lista. Las imágenes debe ser contíguas.</param>
      /// <param name="defaultId">Identificador del elemento preseleccionado.</param>
      public static void EpocheList(ImageComboBox comboBox, int startImageIndex, int defaultId)
      {
         comboBox.Items.Add(new ImageComboBoxItem("Época I: hasta 1920", 1, global::RailwayCollection.Properties.Resources.PICTO_EPOCHE_I));
         comboBox.Items.Add(new ImageComboBoxItem("Época II: 1921 a 1949", 2, global::RailwayCollection.Properties.Resources.PICTO_EPOCHE_II));
         comboBox.Items.Add(new ImageComboBoxItem("Época III: 1950 a 1968", 3, global::RailwayCollection.Properties.Resources.PICTO_EPOCHE_III));
         comboBox.Items.Add(new ImageComboBoxItem("Época IV: 1969 a 1990", 4, global::RailwayCollection.Properties.Resources.PICTO_EPOCHE_IV));
         comboBox.Items.Add(new ImageComboBoxItem("Época V: 1991 a 2006", 5, global::RailwayCollection.Properties.Resources.PICTO_EPOCHE_V));
         comboBox.Items.Add(new ImageComboBoxItem("Época VI: desde 2007", 6, global::RailwayCollection.Properties.Resources.PICTO_EPOCHE_VI));

         if (defaultId > 0 && defaultId <= 5)
            comboBox.SelectedIndex = defaultId - 1;
      }

      /// <summary>
      /// Rellena un control ImageComboBoxItem con una lista de épocas.
      /// </summary>
      /// <param name="comboBox">Control contenedor del listado.</param>
      /// <param name="startImageIndex">Índice inicial de las imágenes para colocar a cada opción de la lista. Las imágenes debe ser contíguas.</param>
      public static void EpocheList(ImageComboBox comboBox, int startImageIndex)
      {
         ModelDAO.EpocheList(comboBox, startImageIndex, -1);
      }
      */

      ///// <summary>
      ///// Importa los elementos de bases de datos de las versiones 1.X.
      ///// </summary>
      ///// <param name="path">Path dónde se encuentran los datos de la versión anterior.</param>
      ///// <param name="progress">Barra de progreso.</param>
      ///// <param name="backup">Indica si se desea realizar una copia de seguridad previa.</param>
      //public void ImportItems(string path, System.Windows.Forms.ProgressBar progress, bool backup)
      //{
      //   // Comprueba que la ruta proporcionada contenga los datos de la colección antigua
      //   FileInfo dbsource = new FileInfo(Path.Combine(path, "collection.dat"));
      //   if (!dbsource.Exists)
      //   {
      //      throw new Exception("La ruta proporcionada no contiene los datos de ninguna colección de RailwayCollection.");
      //   }

      //   // Antes de iniciar la acción, efectúa una copia de seguridad
      //   RCApplication.Backup(Path.Combine(RCApplication.AppDataPath, "importbackup-" + DateTime.Now.ToString("ssmmhhyyyyMMdd") + ".zip"));
      //}

      ///// <summary>
      ///// Importa los datos de una instalación de RC2000 (1.x).
      ///// </summary>
      ///// <param name="filename">Nombre y ruta del archivo de datos.</param>
      ///// <remarks>
      ///// Esta importación sólo importa datos y no importa imágenes ni ningún otro tipo de dato adjunto.
      ///// </remarks>
      //public void ImportFrom2000(string filename, System.Windows.Forms.ProgressBar progress)
      //{
      //   int errs = 0;
      //   string sql = string.Empty;
      //   string errdesc = string.Empty;
      //   OleDbConnection sconn = null;
      //   OleDbCommand cmd = null;

      //   // Área de base de datos
      //   try
      //   {
      //      // Abre una conexión a la BBDD orígen
      //      sconn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + filename + "\"");
      //      sconn.Open();

      //      // Genera instáncias usadas en la importación
      //      ModelDAO items = new ModelDAO(_app);
      //      ScaleDAO scales = new ScaleDAO(_app);
      //      AdministrationDAO admins = new AdministrationDAO(_app);
      //      StoreDAO stores = new StoreDAO(_app);
      //      CategoryDAO types = new CategoryDAO(_app);
      //      ManufacturerDAO manufacturers = new ManufacturerDAO(_app);

      //      // Importación de fabricantes
      //      try
      //      {
      //         sql = "SELECT buildname,builddesc,buildaddress,buildurl " +
      //               "FROM builders " +
      //               "ORDER BY buildname ASC";
      //         cmd = new OleDbCommand(sql, sconn);
      //         using (OleDbDataReader reader = cmd.ExecuteReader())
      //         {
      //            while (reader.Read())
      //            {
      //               // Comprueba que la marca no exista en el archivo actual
      //               if (manufacturers.GetByName(reader.GetString(0)) <= 0)
      //               {
      //                  try
      //                  {
      //                     Manufacturer manufacturer = new Manufacturer();
      //                     manufacturer.Name = reader.GetString(0);
      //                     manufacturer.Description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
      //                     manufacturer.Address = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
      //                     manufacturer.URL = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
      //                     manufacturers.Add(manufacturer);
      //                  }
      //                  catch (Exception ex)
      //                  {
      //                     errs++;
      //                     errdesc += "Fabricante: " + reader.GetString(0) + " (" + ex.Message + ")\n";
      //                  }
      //               }
      //            }
      //         }
      //      }
      //      catch (Exception e)
      //      {
      //         DebugLogger.LogError(this, ex);

      //         throw e;
      //      }

      //      // Importación de administraciones
      //      try
      //      {
      //         sql = "SELECT adminname,admindesc,adminurl " +
      //               "FROM admins " +
      //               "ORDER BY adminname ASC";
      //         cmd = new OleDbCommand(sql, sconn);
      //         using (OleDbDataReader reader = cmd.ExecuteReader())
      //         {
      //            while (reader.Read())
      //            {
      //               // Comprueba que la marca no exista en el archivo actual
      //               if (admins.GetByName(reader.GetString(0)) <= 0)
      //               {
      //                  try
      //                  {
      //                     Administration admin = new Administration();
      //                     admin.Name = reader.GetString(0);
      //                     admin.Description = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
      //                     admin.URL = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
      //                     admin.LogoFilename = string.Empty;
      //                     admins.Add(admin);
      //                  }
      //                  catch (Exception ex)
      //                  {
      //                     errs++;
      //                     errdesc += "Administración: " + reader.GetString(0) + " (" + ex.Message + ")\n";
      //                  }
      //               }
      //            }
      //         }
      //      }
      //      catch (Exception e)
      //      {
      //         DebugLogger.LogError(this, ex);

      //         throw e;
      //      }

      //      // Importación de categorias
      //      try
      //      {
      //         sql = "SELECT typename,typeicon " +
      //               "FROM types " +
      //               "ORDER BY typename ASC";
      //         cmd = new OleDbCommand(sql, sconn);
      //         using (OleDbDataReader reader = cmd.ExecuteReader())
      //         {
      //            while (reader.Read())
      //            {
      //               // Comprueba que la marca no exista en el archivo actual
      //               if (types.GetId(reader.GetString(0)) <= 0)
      //               {
      //                  try
      //                  {
      //                     Category type = new Category();
      //                     type.Name = reader.GetString(0);
      //                     type.Icon = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
      //                     types.Add(type);
      //                  }
      //                  catch (Exception ex)
      //                  {
      //                     errs++;
      //                     errdesc += "Categoria: " + reader.GetString(0) + " (" + ex.Message + ")\n";
      //                  }
      //               }
      //            }
      //         }
      //      }
      //      catch (Exception e)
      //      {
      //         DebugLogger.LogError(this, ex);

      //         throw e;
      //      }

      //      // Importación de comercios
      //      try
      //      {
      //         sql = "SELECT storename,storeaddress,storephone,storefax,storemail,storeurl,storedesc " +
      //               "FROM stores " +
      //               "ORDER BY storename ASC";
      //         cmd = new OleDbCommand(sql, sconn);
      //         using (OleDbDataReader reader = cmd.ExecuteReader())
      //         {
      //            while (reader.Read())
      //            {
      //               // Comprueba que la marca no exista en el archivo actual
      //               if (manufacturers.GetByName(reader.GetString(0)) <= 0)
      //               {
      //                  try
      //                  {
      //                     Store store = new Store();
      //                     store.Name = reader.GetString(0);
      //                     store.Description = string.Empty;
      //                     store.Address = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
      //                     store.Phone = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
      //                     store.FAX = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
      //                     store.Mail = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
      //                     store.URL = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
      //                     stores.Add(store);
      //                  }
      //                  catch (Exception ex)
      //                  {
      //                     errs++;
      //                     errdesc += "Comercio: " + reader.GetString(0) + " (" + ex.Message + ")\n";
      //                  }
      //               }
      //            }
      //         }
      //      }
      //      catch (Exception e)
      //      {
      //         DebugLogger.LogError(this, ex);

      //         throw e;
      //      }

      //      // Calcula el número de elementos a importar
      //      sql = "SELECT Count(*) As units FROM models";
      //      cmd = new OleDbCommand(sql, sconn);
      //      progress.Minimum = 0;
      //      progress.Maximum = (int)cmd.ExecuteScalar();

      //      // Obtiene un listado de modelos
      //      sql = "SELECT SCALES.SCNAME, " +
      //                   "ADMINS.ADMINNAME, " +
      //                   "STORES.STORENAME, " +
      //                   "MODELS.MODNAME, " +
      //                   "MODELS.MODPAINT, " +
      //                   "MODELS.MODERA, " +
      //                   "TYPES.TYPENAME, " +
      //                   "MODELS.MODREF, " +
      //                   "BUILDERS.BUILDNAME, " +
      //                   "MODELS.MODBUYPRICE, " +
      //                   "MODELS.MODBUYDATE, " +
      //                   "MODELS.MODNEM, " +
      //                   "MODELS.MODPANT, " +
      //                   "MODELS.MODSOUND, " +
      //                   "MODELS.MODLIM, " +
      //                   "MODELS.MODLIMYEAR, " +
      //                   "MODELS.MODLIGHTS, " +
      //                   "MODELS.MODFRONTLIGHTS, " +
      //                   "MODELS.MODLENGTH, " +
      //                   "MODELS.MODUNITS, " +
      //                   "MODELS.MODDESC " +
      //            "FROM (((SCALES RIGHT OUTER JOIN (TYPES RIGHT OUTER JOIN (BUILDERS RIGHT OUTER JOIN MODELS ON BUILDERS.BUILDID = MODELS.MODBUILDERID) ON TYPES.TYPEID = MODELS.MODTYPEID) ON SCALES.SCID = MODELS.MODSCALE) LEFT OUTER JOIN ADMINS ON MODELS.MODADMINID = ADMINS.ADMINID) LEFT OUTER JOIN STORES ON MODELS.MODSTOREID = STORES.STOREID)" +
      //            "ORDER BY modname ASC";
      //      cmd = new OleDbCommand(sql, sconn);
      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            try
      //            {
      //               CollectionModel item = new CollectionModel();
      //               item.ScaleID = scales.GetId(reader.IsDBNull(0) ? string.Empty : reader.GetString(0));
      //               item.AdminID = admins.GetByName(reader.IsDBNull(1) ? string.Empty : reader.GetString(1));
      //               item.StoreID = stores.GetId(reader.IsDBNull(2) ? string.Empty : reader.GetString(2));
      //               item.Name = reader.IsDBNull(3) ? "-sin nombre-" : reader.GetString(3);
      //               item.PaintScheme = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
      //               item.Era = reader.IsDBNull(5) ? CollectionModel.Epoche.NotDefined : (CollectionModel.Epoche)reader.GetInt16(5);
      //               item.CategoryID = types.GetId(reader.IsDBNull(6) ? string.Empty : reader.GetString(6));
      //               item.Reference = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
      //               item.ManufacturerID = manufacturers.GetByName(reader.IsDBNull(8) ? string.Empty : reader.GetString(8));
      //               item.BuyPriceStore = reader.IsDBNull(9) ? 0 : reader.GetDecimal(9);
      //               item.BuyDate = reader.IsDBNull(10) ? DateTime.Parse("1/1/1899") : reader.GetDateTime(10);
      //               item.HaveShortCouplers = reader.IsDBNull(11) ? false : reader.GetBoolean(11);
      //               item.HaveFunctionalPantos = reader.IsDBNull(12) ? false : reader.GetBoolean(12);
      //               item.HaveSound = reader.IsDBNull(13) ? false : reader.GetBoolean(13);
      //               item.IsLimited = reader.IsDBNull(14) ? false : reader.GetBoolean(14);
      //               item.LimitedYear = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
      //               item.LightInterior = (reader.IsDBNull(16) ? false : reader.GetBoolean(16)) ? CollectionModel.LightInteriorType.NormalLight : CollectionModel.LightInteriorType.WithoutLight;
      //               item.LightsMode = (CollectionModel.LightFrontType)(reader.IsDBNull(17) ? 0 : (int)reader.GetInt16(17));
      //               item.Length = reader.IsDBNull(18) ? 0 : reader.GetInt32(18);
      //               item.Units = reader.IsDBNull(19) ? 1 : reader.GetInt32(19);
      //               item.Description = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);
      //               item.DigitalDecoderID = 0;
      //               items.Add(item);
      //            }
      //            catch (Exception ex)
      //            {
      //               errs++;
      //               errdesc += "Modelo: " + reader.GetString(3) + " (" + ex.Message + ")\n";
      //            }
      //            progress.Value++;
      //         }
      //      }
      //      progress.Value = progress.Maximum;
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw e;
      //   }
      //   finally
      //   {
      //      cmd.Dispose();

      //      if (errs > 0)
      //      {
      //         MessageBox.Show(errdesc, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      //      }
      //   }
      //}

      ///// <summary>
      ///// Imprime los datos de un modelo a un archivo PDF v1.4
      ///// </summary>
      ///// <param name="modelId">Identificador del modelo.</param>
      ///// <param name="filename">Nombre del archivo de destino.</param>
      //public void SaveAsPDF(int modelId, string filename)
      //{
      //   try
      //   {
      //      CollectionModel model = this.GetByID(modelId);

      //      // Genera un nuevo documento
      //      Document document = new Document();

      //      // Asigna un archivo al documento
      //      PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

      //      // Prepara las fuentes a usar
      //      iTextSharp.text.Font ftitle = FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD);
      //      iTextSharp.text.Font fhead = FontFactory.GetFont(FontFactory.HELVETICA, 11, iTextSharp.text.Font.BOLD);
      //      iTextSharp.text.Font fnormal = FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
      //      iTextSharp.text.Font fbold = FontFactory.GetFont(FontFactory.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
      //      iTextSharp.text.Font finfo = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL);
      //      iTextSharp.text.Font finfob = FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD);

      //      // Establece las propiuedades del documento
      //      document.SetPageSize(PageSize.A4);
      //      document.AddAuthor(Application.ProductName);
      //      document.AddCreationDate();
      //      document.AddCreator(Application.CompanyName + " - " + Application.ProductName);
      //      document.AddTitle("Ficha del modelo: " + model.Name);
      //      document.AddSubject(Application.CompanyName);

      //      // Añade la cabecera y el pie de página
      //      iTextSharp.text.HeaderFooter header = new iTextSharp.text.HeaderFooter(new Phrase(Application.CompanyName, finfob), false);
      //      header.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
      //      document.Header = header;

      //      iTextSharp.text.HeaderFooter foot = new iTextSharp.text.HeaderFooter(new Phrase("Página ", finfo), true);
      //      foot.Alignment = iTextSharp.text.Rectangle.ALIGN_RIGHT;
      //      foot.Border = iTextSharp.text.Rectangle.TOP_BORDER;
      //      document.Footer = foot;

      //      // Abre el nuevo documento
      //      document.Open();

      //      // Escribe el título del documento
      //      Paragraph ptitle = new Paragraph(model.Name, ftitle);
      //      document.Add(ptitle);

      //      // Agrega la imágen del modelo
      //      if (!string.IsNullOrEmpty(model.Picture))
      //      {
      //         iTextSharp.text.Jpeg pImage = new Jpeg(new Uri(model.Picture));
      //         document.Add(pImage);
      //      }

      //      document.Close();
      //   }
      //   catch (Exception ex)
      //   {
      //      throw ex;
      //   }
      //}

      ///// <summary>
      ///// Genera una lista de funciones digitales informadas anteriormente.
      ///// </summary>
      ///// <param name="control">Control de tipo ComboBox que deberá contener la lista generada.</param>
      //public void DigitalFunctionsList(object control)
      //{
      //   string sql = string.Empty;
      //   OleDbCommand cmd = null;

      //   ControlAdapter.ComboBoxAdapter.Clear(control);

      //   try
      //   {
      //      Connect();

      //      // Genera la senténcia SQL que obtiene los elementos
      //      sql = "SELECT DISTINCT description FROM modelsdfunc"; // ORDER BY name Asc";
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            if (!reader.IsDBNull(0))
      //            {
      //               if (!reader.GetString(0).Equals(string.Empty))
      //               {
      //                  ControlAdapter.ComboBoxAdapter.Add(control,
      //                                                     new ComboBoxItem(reader.GetString(0), string.Empty));
      //               }
      //            }
      //         }
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw e;
      //   }
      //   finally
      //   {
      //      cmd.Dispose();
      //   }
      //}

      ///// <summary>
      ///// Genera una lista de técnicos usados en todas las revisiones.
      ///// </summary>
      ///// <param name="control">Control de tipo ComboBox que deberá contener la lista generada.</param>
      //public void RevisionsAuthorsList(object control)
      //{
      //   string sql = string.Empty;
      //   OleDbCommand cmd = null;

      //   ControlAdapter.ComboBoxAdapter.Clear(control);

      //   try
      //   {
      //      Connect();

      //      // Genera la senténcia SQL que obtiene los elementos
      //      sql = "SELECT DISTINCT author FROM modelsrevs ORDER BY author Asc";
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            if (!reader.IsDBNull(0))
      //            {
      //               if (!reader.GetString(0).Equals(string.Empty))
      //               {
      //                  ControlAdapter.ComboBoxAdapter.Add(control, new Rwm.Otc.windows.controls.ComboBoxItem(reader.GetString(0), string.Empty));

      //               }
      //            }
      //         }
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw e;
      //   }
      //   finally
      //   {
      //      cmd.Dispose();
      //   }
      //}

      ///// <summary>
      ///// Genera una lista de las disposiciones de ejes introducidas en todos los modelos
      ///// </summary>
      ///// <param name="control">Control sobre el que se desea llenar la lista.</param>
      //public void ListAxisDispositions(ComboBox control)
      //{
      //   ListAxisDispositions(control, string.Empty);
      //}

      ///// <summary>
      ///// Genera una lista de las disposiciones de ejes introducidas en todos los modelos
      ///// </summary>
      ///// <param name="control">Control sobre el que se desea llenar la lista.</param>
      ///// <param name="text">Texto por defecto que aparecerá seleccionado.</param>
      //public void ListAxisDispositions(ComboBox control, string text)
      //{
      //   string sql = string.Empty;
      //   string txt = control.Text;
      //   string item = string.Empty;
      //   OleDbCommand cmd = null;

      //   try
      //   {
      //      // Configura el control ComboBox
      //      control.Items.Clear();

      //      // Genera la senténcia SQL que obtiene los elementos
      //      Connect();

      //      sql += "SELECT DISTINCT models.modaxisdisp ";
      //      sql += "FROM models ";
      //      sql += "ORDER BY models.modaxisdisp Asc ";
      //      cmd = new OleDbCommand(sql, _app.Connection);

      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            item = !reader.IsDBNull(0) ? reader.GetString(0) : string.Empty;
      //            if (!string.IsNullOrWhiteSpace(item))
      //               control.Items.Add(item);
      //         }
      //      }

      //      // Deja el control preparado
      //      if (string.IsNullOrWhiteSpace(text))
      //      {
      //         if (!string.IsNullOrWhiteSpace(txt))
      //            control.Text = txt;
      //      }
      //      else
      //      {
      //         control.Text = text;
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw e;
      //   }
      //   finally
      //   {
      //      cmd.Dispose();
      //   }
      //}

      ///// <summary>
      ///// Genera una lista de tipos de motor introducidos en todos los modelos.
      ///// </summary>
      ///// <param name="control">Control sobre el que se desea llenar la lista.</param>
      //public void ListEngineTypes(ComboBox control)
      //{
      //   ListEngineTypes(control, string.Empty);
      //}

      ///// <summary>
      ///// Genera una lista de tipos de motor introducidos en todos los modelos.
      ///// </summary>
      ///// <param name="control">Control sobre el que se desea llenar la lista.</param>
      ///// <param name="text">Texto por defecto que aparecerá seleccionado.</param>
      //public void ListEngineTypes(ComboBox control, string text)
      //{
      //   string sql = string.Empty;
      //   string txt = control.Text;
      //   string item = string.Empty;
      //   OleDbCommand cmd = null;

      //   try
      //   {
      //      // Configura el control ComboBox
      //      control.Items.Clear();

      //      // Genera la senténcia SQL que obtiene los elementos
      //      Connect();

      //      sql += "SELECT DISTINCT models.modenginetype ";
      //      sql += "FROM models ";
      //      sql += "ORDER BY models.modenginetype Asc ";
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      using (OleDbDataReader reader = cmd.ExecuteReader())
      //      {
      //         while (reader.Read())
      //         {
      //            item = !reader.IsDBNull(0) ? reader.GetString(0) : string.Empty;
      //            if (!string.IsNullOrWhiteSpace(item))
      //               control.Items.Add(item);
      //         }
      //      }

      //      // Deja el control preparado
      //      if (string.IsNullOrWhiteSpace(text))
      //      {
      //         if (!string.IsNullOrWhiteSpace(txt))
      //            control.Text = txt;
      //      }
      //      else
      //      {
      //         control.Text = text;
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw e;
      //   }
      //   finally
      //   {
      //      cmd.Dispose();
      //   }
      //}

      #endregion

   }
}
