﻿using Rwm.Otc.Configuration;
using Rwm.Studio.Plugins.Collection.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Rwm.Studio.Plugins.Collection.Model
{
   /// <summary>
   /// Representa un modelo de la colección.
   /// </summary>
   public class CollectionModel : IIdentifiableObject
   {

      #region Enumerations

      /// <summary>
      /// Épocas posibles del modelo
      /// </summary>
      public enum Epoche : int
      {
         [Description("Sin época definida o no aplicable")]
         NotDefined = 0,
         [Description("Época I: desde el inicio hasta 1920")]
         EpocheI = 1,
         [Description("Época II: desde 1921 hasta 1950")]
         EpocheII = 2,
         [Description("Época III: desde 1951 hasta 1970")]
         EpocheIII = 3,
         [Description("Época IV: desde 1971 hasta 1990")]
         EpocheIV = 4,
         [Description("Época V: desde 1991 hasta 2006")]
         EpocheV = 5,
         [Description("Época VI: desde 2007")]
         EpocheVI = 6
      }

      /// <summary>
      /// Materiales para el chasis/bastidor
      /// </summary>
      public enum FrameType : int
      {
         [Description("No definido o no aplicable")]
         NotDefined = 0,
         [Description("Bastidor metálico y carcasa de plástico")]
         Metall_Plastic = 1,
         [Description("Bastidor metálico y carcasa de plástico y metal")]
         Metall_PlasticMetall = 2,
         [Description("bastidor y carcasa de metal")]
         AllMetall = 3
      }

      /// <summary>
      /// Tipos de iluminación frontal
      /// </summary>
      public enum LightFrontType : int
      {
         [Description("Sin iluminación o no aplicable")]
         [EnumItemImage("ICO_LIGHT_OFF")]
         WithoutLight = 0,
         [Description("Iluminación fija en un sólo sentido")]
         [EnumItemImage("ICO_LIGHT_ON")]
         FixedFrontLights = 4,
         [Description("Un foco según sentido de la marcha")]
         [EnumItemImage("ICO_LIGHT_ON")]
         OneLightDependingSense = 6,
         [Description("Dos focos según sentido de la marcha")]
         [EnumItemImage("ICO_LIGHT_ON")]
         TwoLightDependingSense = 3,
         [Description("Tres focos según sentido de la marcha")]
         [EnumItemImage("ICO_LIGHT_ON")]
         ThreeLightDependingSense = 1,
         [Description("Tres focos hacia adelante y uno hacia atrás")]
         [EnumItemImage("ICO_LIGHT_ON")]
         ThreeLightsForwardOneFocusBack = 5,
         [Description("Tres focos hacia adelante y dos rojos hacia atrás")]
         [EnumItemImage("ICO_LIGHT_ON")]
         WhiteLightsForwardRedFocusBack = 2
      }

      /// <summary>
      /// Tipo de iluminación interior.
      /// </summary>
      public enum LightInteriorType : int
      {
         [Description("Sin iluminación interior o no aplicable")]
         [EnumItemImage("ICO_LIGHT_OFF")]
         WithoutLight = 0,
         [Description("Iluminación interior")]
         [EnumItemImage("ICO_LIGHT_ON")]
         NormalLight = 1,
         [Description("Iluminación interior LED")]
         [EnumItemImage("ICO_LIGHT_ON")]
         LedLight = 2
      }

      /// <summary>
      /// Tipo de iluminación trasera.
      /// </summary>
      public enum LightRearType : int
      {
         [Description("Sin iluminación trasera o no aplicable")]
         WithoutLight = 0,
         [Description("Con iluminación trasera")]
         WithLight = 1
      }

      /// <summary>
      /// Tipo de equipamiento interior del modelo.
      /// </summary>
      public enum InteriorEquipmentType : int
      {
         [Description("Sin decoración interior o no aplicable")]
         WithoutDecoration = 0,
         [Description("Modelo con decoración interior")]
         WithDecoration = 1
      }

      /// <summary>
      /// Tipo de conector digital.
      /// </summary>
      public enum DigitalConnectorType : int
      {
         [Description("Without connector")]
         [EnumItemImage( "ICO_PLUG_16" )]
         Welded = 0,
         [Description("NEM 651 6 pins connector")]
         [EnumItemImage("ICO_PLUG_16")]
         NEM651 = 1,
         [Description("NEM 651 8 pins connector")]
         [EnumItemImage("ICO_PLUG_16")]
         NEM652 = 2,
         [Description("PluX 8 pins connector (NEM 658)")]
         [EnumItemImage("ICO_PLUG_16")]
         NEM658_PluX8 = 3,
         [Description("PluX 12 pins connector (NEM 658)")]
         [EnumItemImage("ICO_PLUG_16")]
         NEM658_PluX12 = 4,
         [Description("PluX 16 pins connector (NEM 658)")]
         [EnumItemImage("ICO_PLUG_16")]
         NEM658_PluX16 = 5,
         [Description("PluX 22 pins connector (NEM 658)")]
         [EnumItemImage("ICO_PLUG_16")]
         NEM658_PluX22 = 6,
         [Description("21MTC 21 pins connector (NEM 660)")]
         [EnumItemImage("ICO_PLUG_16")]
         NEM660_21MTC = 7,
         [Description("Next18 18 pin connector (NEM 662)")]
         [EnumItemImage("ICO_PLUG_16")]
         NEM662_Next18 = 8,
         [Description("JST 9 pins connector")]
         [EnumItemImage("ICO_PLUG_16")]
         JST = 9
      }

      /// <summary>
      /// Describe all types of model couplers.
      /// </summary>
      public enum CouplerTypes : int
      {
         [Description("Enganche estándar")]
         [EnumItemImage("ICO_COUPLER_NO_16")]
         StandardCouplers = 0,
         [Description("Enganche estándar NEM")]
         [EnumItemImage("ICO_COUPLER_16")]
         StandardCouplersNEMPocket = 1,
         [Description("Enganche corto (KKK)")]
         [EnumItemImage("ICO_COUPLER_SHORT_16")]
         CloseCouplersNEMPocket = 2,
         [Description("Enganche corto Fleischmann")]
         [EnumItemImage("ICO_COUPLER_SHORT_16")]
         FleischmannCouplers = 3,
         [Description("Enganche corto Roco")]
         [EnumItemImage("ICO_COUPLER_SHORT_16")]
         RocoCouplers = 4,
         [Description("Enganche corto Kadee")]
         [EnumItemImage("ICO_COUPLER_SHORT_16")]
         KadeeCouplers = 5,
         [Description("Enganche especial no estándar")]
         [EnumItemImage("ICO_COUPLER_NO_16")]
         SpecialCouplers = 99
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="CollectionModel"/>.
      /// </summary>
      public CollectionModel()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Identificador único del modelo (clave primaria)
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Identificador de la administración o operador (tabla ADMINS)
      /// </summary>
      public int AdminID { get; set; }

      /// <summary>
      /// Identificador del establecimiento comercial (tabla STORES)
      /// </summary>
      public int StoreID { get; set; }

      /// <summary>
      /// Identificador de la categoria (tabla TYPES)
      /// </summary>
      public int CategoryID { get; set; }

      /// <summary>
      /// Identificador del fabricante (tabla BUILDERS)
      /// </summary>
      public int ManufacturerID { get; set; }

      /// <summary>
      /// Nombre
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Esquema de pintura
      /// </summary>
      public string PaintScheme { get; set; }

      /// <summary>
      /// Época
      /// </summary>
      public Epoche Era { get; set; }

      /// <summary>
      /// Referencia del fabricante
      /// </summary>
      public string Reference { get; set; }

      /// <summary>
      /// Identificador de la escala (tabla SCALES)
      /// </summary>
      public int ScaleID { get; set; }

      /// <summary>
      /// Precio de catálogo
      /// </summary>
      public decimal BuyPriceCatalogue { get; set; }

      /// <summary>
      /// Precio de compra
      /// </summary>
      public decimal BuyPricePurchase { get; set; }

      /// <summary>
      /// Indica si este modelo está pendiente de compra.
      /// </summary>
      public bool BuyIsPending { get; set; }

      /// <summary>
      /// Fecha de compra
      /// </summary>
      public DateTime BuyDate { get; set; }

      /// <summary>
      /// Indica si dispone de cinemática de enganche corto según normas NEM
      /// </summary>
      public CouplerTypes CouplersType { get; set; }

      /// <summary>
      /// Indica si dispone de pantógrafos funcionales
      /// </summary>
      public bool HaveFunctionalPantos { get; set; }

      /// <summary>
      /// Indica si el modelo dispone de sonido
      /// </summary>
      public bool HaveSound { get; set; }

      /// <summary>
      /// Indica si es un modelo de serie limitada
      /// </summary>
      public bool IsLimited { get; set; }

      /// <summary>
      /// Periodo de venta de la serie limitada
      /// </summary>
      public string LimitedYear { get; set; }

      /// <summary>
      /// Descripción
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets the model picture.
      /// </summary>
      public System.Drawing.Image Picture { get; set; }

      /// <summary>
      /// Gets or sets the original picture file name.
      /// </summary>
      public string PictureFileName { get; set; }

      /// <summary>
      /// Longitud (en mm.)
      /// </summary>
      public int Length { get; set; }

      /// <summary>
      /// Unidades del mismo modelo adquiridas
      /// </summary>
      public int Units { get; set; }

      /// <summary>
      /// Dirección digital asignada
      /// </summary>
      public int DigitalAddress { get; set; }

      /// <summary>
      /// Identificador del decodificador (tabla DECODERS)
      /// </summary>
      public int DigitalDecoderID { get; set; }

      /// <summary>
      /// Matricula del prototipo real
      /// </summary>
      public string RegistrationNumber { get; set; }

      /// <summary>
      /// Tipo del prototipo real
      /// </summary>
      public string Type { get; set; }

      /// <summary>
      /// Tipo UIC del prototipo real
      /// </summary>
      public string TypeUIC { get; set; }

      /// <summary>
      /// Tipo de materia de fabricación de chasis/bastidor.
      /// </summary>
      public FrameType Frame { get; set; }

      /// <summary>
      /// Tipo de iluminación interior.
      /// </summary>
      public LightInteriorType LightInterior { get; set; }

      /// <summary>
      /// Tipo de iluminación trasera.
      /// </summary>
      public LightRearType LightRear { get; set; }

      /// <summary>
      /// Tipo de iluminación de marcha (focos).
      /// </summary>
      public LightFrontType LightFront { get; set; }

      /// <summary>
      /// Tipo de decoración interior.
      /// </summary>
      public InteriorEquipmentType InteriorEquipment { get; set; }

      /// <summary>
      /// Tipo de conector digital.
      /// </summary>
      public DigitalConnectorType DigitalConnector { get; set; }

      /// <summary>
      /// Gets or sets la lista de funciones digitales.
      /// </summary>
      public List<ModelDigitalFunction> DigitalFunctions { get; set; }

      /// <summary>
      /// Gets or sets la lista de revisiones técnicas del modelo.
      /// </summary>
      public List<ModelRevision> MaintenanceRevisions { get; set; }

      /// <summary>
      /// Gets or sets la fecha de la última revisión del modelo.
      /// </summary>
      public DateTime MaintenanceLastRevision { get; set; }

      /// <summary>
      /// Gets or sets el núemro de horas de servicio totales para el modelo.
      /// </summary>
      public int MaintenanceServiceHours { get; set; }

      /// <summary>
      /// Gets or sets el núemro de horas de servicio desde la última revisión.
      /// </summary>
      public int MaintenanceRevisionHours { get; set; }

      /// <summary>
      /// Indica si el modelo dispone de caja original.
      /// </summary>
      public bool HaveOriginalBox { get; set; }

      /// <summary>
      /// Tipo de motor (descripción).
      /// </summary>
      public string EngineType { get; set; }

      /// <summary>
      /// Número de ejes con tracción.
      /// </summary>
      public int AxisWithTraction { get; set; }

      /// <summary>
      /// Número de ruedas con aro de adherencia.
      /// </summary>
      public int AxisWithTractionTires { get; set; }

      /// <summary>
      /// Disposición de los ejes.
      /// </summary>
      public string WheelDisposition { get; set; }

      /// <summary>
      /// Gets or sets la lista de archivos adjuntos al modelo.
      /// </summary>
      public List<ModelFileAttachment> Attachments { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Devuelve un texto descriptivo del modelo.
      /// </summary>
      public string ToString(XmlSettingsManager settings)
      {
         string desc = string.Empty;

         desc += "Modelo real:\n";

         if (!string.IsNullOrEmpty(this.RegistrationNumber.Trim()))
         {
            desc += "Matriculado con el número " + this.RegistrationNumber.Trim() + ". ";
         }
         if (this.AdminID > 0)
         {
            Administration admin = CollectionContext.AdministrationDAO.GetByID(this.AdminID);
            desc += "Modelo adscrito a " + admin.Name + ". ";
         }
         if (this.Era != CollectionModel.Epoche.NotDefined)
         {
            desc += Rwm.Otc.reflection.Attributes.GetDescription(this.Era);
         }
         if (!string.IsNullOrEmpty(this.PaintScheme.Trim()))
         {
            desc += "Esquema de pintura " + this.PaintScheme.Trim() + ". ";
         }

         desc += "\n\nModelo miniatura:\n";

         return desc;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;

         this.AdminID = 0;
         this.StoreID = 0;
         this.CategoryID = 0;
         this.ScaleID = 0;
         this.ManufacturerID = 0;
         this.DigitalDecoderID = 0;
         this.Attachments = new List<ModelFileAttachment>();

         this.Name = string.Empty;
         this.Description = string.Empty;

         this.Reference = string.Empty;
         this.BuyPriceCatalogue = 0;
         this.BuyPricePurchase = 0;
         this.BuyIsPending = false;
         this.BuyDate = DateTime.MinValue;
         this.IsLimited = false;
         this.LimitedYear = string.Empty;
         this.CouplersType = CouplerTypes.StandardCouplers;
         this.HaveFunctionalPantos = false;
         this.HaveSound = false;
         this.LightFront = LightFrontType.WithoutLight;
         this.LightInterior = LightInteriorType.WithoutLight;
         this.LightRear = LightRearType.WithoutLight;
         this.Picture = null;
         this.PictureFileName = string.Empty;
         this.Length = 0;
         this.Units = 0;
         this.DigitalAddress = 0;
         this.DigitalConnector = DigitalConnectorType.Welded;
         this.DigitalFunctions = new List<ModelDigitalFunction>();
         this.Frame = FrameType.NotDefined;
         this.InteriorEquipment = InteriorEquipmentType.WithoutDecoration;
         this.MaintenanceRevisions = new List<ModelRevision>();
         this.MaintenanceServiceHours = 0;
         this.MaintenanceRevisionHours = 0;
         this.MaintenanceLastRevision = DateTime.MinValue;
         this.HaveOriginalBox = false;
         this.AxisWithTraction = 0;
         this.AxisWithTractionTires = 0;

         this.Era = Epoche.NotDefined;
         this.RegistrationNumber = string.Empty;
         this.Type = string.Empty;
         this.TypeUIC = string.Empty;
         this.PaintScheme = string.Empty;
         this.EngineType = string.Empty;
         this.WheelDisposition = string.Empty;
      }

      #endregion

      #region Disabled Code

      private const string XML_NODE_ROOT = "otc-model";
      private const string XML_ATTR_OTCVER = "version";
      private const string XML_ATTR_OTCGENERATOR = "generator";

      private const string XML_ATTR_ID = "id";
      private const string XML_ATTR_NAME = "name";
      private const string XML_ATTR_SHORT = "short";
      private const string XML_ATTR_NEM = "nem";
      private const string XML_ATTR_FUNCTIONAL = "functional";
      private const string XML_ATTR_INTERIOR = "interior";
      private const string XML_ATTR_REAR = "rear";
      private const string XML_ATTR_FRONT = "front";
      private const string XML_ATTR_ENABLED = "enabled";
      private const string XML_ATTR_PERIOD = "period";
      private const string XML_ATTR_BUY = "buy";
      private const string XML_ATTR_CATALOG = "catalog";
      private const string XML_ATTR_PENDING = "pending";
      private const string XML_ATTR_ADDRESS = "address";
      private const string XML_ATTR_CONNECTOR = "connector";
      private const string XML_ATTR_REVISIONH = "rev-hours";
      private const string XML_ATTR_SERVICEH = "srv-hours";
      private const string XML_ATTR_LASTREV = "last-rev";
      private const string XML_ATTR_AUTHOR = "author";
      private const string XML_ATTR_DATE = "date";
      private const string XML_ATTR_TYPE = "type";
      private const string XML_ATTR_UIC = "uic";
      private const string XML_ATTR_LENGTH = "length";
      private const string XML_ATTR_TRACTION = "traction";
      private const string XML_ATTR_TIRES = "tires";
      private const string XML_ATTR_WHEELDISP = "wheel-disp";
      private const string XML_ATTR_ENGINETYPE = "engine-type";

      private const string XML_NODE_AXIS = "axis";
      private const string XML_NODE_NAME = "name";
      private const string XML_NODE_ADMINISTRATION = "administration";
      private const string XML_NODE_STORE = "store";
      private const string XML_NODE_CATEGORY = "category";
      private const string XML_NODE_MANUFACTURER = "manufacturer";
      private const string XML_NODE_PAINTSCHEME = "paint-scheme";
      private const string XML_NODE_EPOCHE = "epoche";
      private const string XML_NODE_REF = "reference";
      private const string XML_NODE_SCALE = "scale";
      private const string XML_NODE_PRICE = "price";
      private const string XML_NODE_BUYDATE = "buy-date";
      private const string XML_NODE_COUPLERS = "couplers";
      private const string XML_NODE_PANTOS = "pantos";
      private const string XML_NODE_LIGHTS = "lights";
      private const string XML_NODE_SOUND = "sound";
      private const string XML_NODE_LIMITED = "limited";
      private const string XML_NODE_DESCRIPTION = "description";
      private const string XML_NODE_PICTURE = "picture";
      private const string XML_NODE_LENGTH = "length";
      private const string XML_NODE_UNITS = "units";
      private const string XML_NODE_DIGITAL = "digital";
      private const string XML_NODE_DECODER = "decoder";
      private const string XML_NODE_FUNCTIONS = "fucntions";
      private const string XML_NODE_FUNCTION = "fucntion";
      private const string XML_NODE_MAINTENANCE = "maintenance";
      private const string XML_NODE_REVISIONS = "revisions";
      private const string XML_NODE_REVISION = "revision";
      private const string XML_NODE_FRAME = "frame";
      private const string XML_NODE_INTERIOREQ = "interior-equip";
      private const string XML_NODE_REGNUM = "reg-num";
      private const string XML_NODE_WAGON = "wagon";
      private const string XML_NODE_MODEL = "model";
      private const string XML_NODE_PROTOTIPE = "prototipe";
      private const string XML_NODE_BIN = "bin";

      ///// <summary>
      ///// Guarda los datos del objeto en un archivo.
      ///// </summary>
      ///// <param name="filename"></param>
      //public void Save(string filename)
      //{
      //   XmlTextWriter writer = null;

      //   try
      //   {
      //      // Asegura que no exista el archivo
      //      // FileInfo file = new FileInfo(filename);
      //      // if (file.Exists) throw new FileNotFoundException("No se encuentra el archivo " + filename);

      //      // Abre el documento
      //      writer = new XmlTextWriter(filename, Encoding.UTF8);
      //      writer.Formatting = Formatting.Indented;
      //      writer.WriteStartDocument();

      //      // Abre una cláusula OTC-MODEL
      //      writer.WriteStartElement(XML_NODE_ROOT);
      //      writer.WriteAttributeString(XML_ATTR_OTCVER, OTCEnvironment.OTCVersion);
      //      writer.WriteAttributeString(XML_ATTR_OTCGENERATOR, OTCEnvironment.ProductName);

      //      // Nombre
      //      writer.WriteElementString(XML_NODE_NAME, this.Name);

      //      // Categoria
      //      CategoryDAO categories = new CategoryDAO();
      //      Category category = categories.GetByID(this.CategoryID);

      //      writer.WriteStartElement(XML_NODE_CATEGORY);
      //      writer.WriteAttributeString(XML_ATTR_ID, this.CategoryID.ToString());
      //      writer.WriteAttributeString(XML_ATTR_NAME, (category != null ? category.Name : string.Empty));
      //      writer.WriteEndElement();

      //      // Referencia
      //      writer.WriteElementString(XML_NODE_REF, this.Reference);

      //      // Unidades
      //      writer.WriteElementString(XML_NODE_UNITS, this.Units.ToString());

      //      // Descripción
      //      writer.WriteElementString(XML_NODE_DESCRIPTION, this.Description);

      //      // Imagen
      //      if (!string.IsNullOrEmpty(this.PictureFullName))
      //      {
      //         FileInfo file = new FileInfo(this.PictureFullName);
      //         if (file.Exists)
      //         {
      //            // Lee el archivo
      //            byte[] buffer = Rwm.Otc.windows.Shell.LoadTextFileToByteArray(file.FullName);

      //            writer.WriteStartElement(XML_NODE_PICTURE);
      //            writer.WriteAttributeString(XML_ATTR_NAME, file.Name);
      //            writer.WriteAttributeString(XML_ATTR_LENGTH, buffer.Length.ToString());
      //            writer.WriteStartElement(XML_NODE_BIN);
      //            writer.WriteAttributeString("xmlns:dt", "urn:schemas-microsoft-com:datatypes");
      //            writer.WriteAttributeString("dt:dt", "bin.base64");
      //            writer.WriteBase64(buffer, 0, buffer.Length);
      //            writer.WriteEndElement();
      //            writer.WriteEndElement();
      //         }
      //      }

      //      writer.WriteStartElement(XML_NODE_MODEL);

      //      // Escala
      //      ScaleDAO scales = new ScaleDAO(app);
      //      Scale scale = scales.GetByID(this.ScaleID);
      //      writer.WriteStartElement(XML_NODE_SCALE);
      //      writer.WriteAttributeString(XML_ATTR_ID, this.ScaleID.ToString());
      //      writer.WriteAttributeString(XML_ATTR_NAME, (scale != null ? scale.Name : string.Empty));
      //      writer.WriteEndElement();

      //      // Fabricante
      //      ManufacturerDAO manufacturers = new ManufacturerDAO(app);
      //      Manufacturer manufacturer = manufacturers.GetByID(this.ManufacturerID);
      //      writer.WriteStartElement(XML_NODE_MANUFACTURER);
      //      writer.WriteAttributeString(XML_ATTR_ID, this.ManufacturerID.ToString());
      //      writer.WriteAttributeString(XML_ATTR_NAME, (manufacturer != null ? manufacturer.Name : string.Empty));
      //      writer.WriteEndElement();

      //      // Longitud
      //      writer.WriteElementString(XML_NODE_LENGTH, this.Length.ToString());

      //      // Enganche
      //      writer.WriteStartElement(XML_NODE_COUPLERS);
      //      writer.WriteAttributeString(XML_ATTR_SHORT, (this.HaveShortCouplers ? "1" : "0"));
      //      writer.WriteAttributeString(XML_ATTR_NEM, (this.HaveNEMCouplers ? "1" : "0"));
      //      writer.WriteEndElement();

      //      // Pantógrafos
      //      writer.WriteStartElement(XML_NODE_PANTOS);
      //      writer.WriteAttributeString(XML_ATTR_FUNCTIONAL, (this.HaveFunctionalPantos ? "1" : "0"));
      //      writer.WriteEndElement();

      //      // Luces
      //      writer.WriteStartElement(XML_NODE_LIGHTS);
      //      writer.WriteAttributeString(XML_ATTR_FRONT, ((int)this.LightFront).ToString());
      //      writer.WriteAttributeString(XML_ATTR_INTERIOR, ((int)this.LightInterior).ToString());
      //      writer.WriteAttributeString(XML_ATTR_REAR, ((int)this.LightRear).ToString());
      //      writer.WriteEndElement();

      //      // carcasa y bastidor
      //      writer.WriteElementString(XML_NODE_FRAME, ((int)this.Frame).ToString());

      //      // Equipamiento interior
      //      writer.WriteElementString(XML_NODE_INTERIOREQ, ((int)this.InteriorEquipment).ToString());

      //      // Establecimiento comercial
      //      StoreDAO stores = new StoreDAO(app);
      //      Store store = stores.GetByID(this.StoreID);
      //      writer.WriteStartElement(XML_NODE_STORE);
      //      writer.WriteAttributeString(XML_ATTR_ID, this.StoreID.ToString());
      //      writer.WriteAttributeString(XML_ATTR_NAME, (store != null ? store.Name : string.Empty));
      //      writer.WriteEndElement();

      //      // Precios
      //      writer.WriteStartElement(XML_NODE_PRICE);
      //      writer.WriteAttributeString(XML_ATTR_BUY, this.BuyPriceStore.ToString());
      //      writer.WriteAttributeString(XML_ATTR_CATALOG, this.BuyPriceCatalogue.ToString());
      //      writer.WriteAttributeString(XML_ATTR_PENDING, (this.BuyIsPending ? "1" : "0"));
      //      writer.WriteEndElement();

      //      // Fecha de compra
      //      writer.WriteElementString(XML_NODE_BUYDATE, this.BuyDate.ToFileTime().ToString());

      //      // Edición limitada
      //      writer.WriteStartElement(XML_NODE_LIMITED);
      //      writer.WriteAttributeString(XML_ATTR_ENABLED, (this.IsLimited ? "1" : "0"));
      //      writer.WriteAttributeString(XML_ATTR_PERIOD, this.LimitedYear);
      //      writer.WriteEndElement();

      //      // Tracción
      //      writer.WriteStartElement(XML_NODE_AXIS);
      //      writer.WriteAttributeString(XML_ATTR_TRACTION, this.AxisWithTraction.ToString());
      //      writer.WriteAttributeString(XML_ATTR_TIRES, this.AxisWithTractionTires.ToString());
      //      writer.WriteAttributeString(XML_ATTR_WHEELDISP, this.WheelDisposition);
      //      writer.WriteAttributeString(XML_ATTR_ENGINETYPE, this.EngineType);
      //      writer.WriteEndElement();

      //      writer.WriteEndElement();

      //      writer.WriteStartElement(XML_NODE_PROTOTIPE);

      //      // Matrícula
      //      writer.WriteElementString(XML_NODE_REGNUM, this.RegistrationNumber);

      //      // Administración
      //      AdministrationDAO admins = new AdministrationDAO(app);
      //      Administration admin = admins.GetByID(this.AdminID);
      //      writer.WriteStartElement(XML_NODE_ADMINISTRATION);
      //      writer.WriteAttributeString(XML_ATTR_ID, this.AdminID.ToString());
      //      writer.WriteAttributeString(XML_ATTR_NAME, (admin != null ? admin.Name : string.Empty));
      //      writer.WriteEndElement();

      //      // Época
      //      writer.WriteElementString(XML_NODE_EPOCHE, ((int)this.Era).ToString());

      //      // Esquema de pintura
      //      writer.WriteElementString(XML_NODE_PAINTSCHEME, this.PaintScheme);

      //      // Vagones
      //      writer.WriteStartElement(XML_NODE_WAGON);
      //      writer.WriteAttributeString(XML_ATTR_TYPE, this.Type);
      //      writer.WriteAttributeString(XML_ATTR_UIC, this.TypeUIC);
      //      writer.WriteEndElement();

      //      writer.WriteEndElement();

      //      // Digital
      //      writer.WriteStartElement(XML_NODE_DIGITAL);
      //      writer.WriteAttributeString(XML_ATTR_ADDRESS, this.DigitalAddress.ToString());
      //      writer.WriteAttributeString(XML_ATTR_CONNECTOR, ((int)this.DigitalConnector).ToString());

      //      // Descodificador
      //      DecoderDAO decoders = new DecoderDAO(app);
      //      Decoder decoder = decoders.Item(this.DigitalDecoderID);

      //      writer.WriteStartElement(XML_NODE_DECODER);
      //      writer.WriteAttributeString(XML_ATTR_ID, this.DigitalDecoderID.ToString());
      //      writer.WriteAttributeString(XML_ATTR_NAME, (decoder != null ? decoder.Name : string.Empty));
      //      writer.WriteEndElement();

      //      // Funciones digitales
      //      writer.WriteStartElement(XML_NODE_FUNCTIONS);
      //      foreach (ModelDigitalFunction function in this.DigitalFunctions)
      //      {
      //         writer.WriteStartElement(XML_NODE_FUNCTION);
      //         writer.WriteAttributeString(XML_ATTR_ID, function.FunctionId.ToString());
      //         writer.WriteAttributeString(XML_ATTR_NAME, function.Name);
      //         writer.WriteEndElement();
      //      }
      //      writer.WriteEndElement();

      //      // Sonido
      //      writer.WriteStartElement(XML_NODE_SOUND);
      //      writer.WriteAttributeString(XML_ATTR_ENABLED, (this.HaveSound ? "1" : "0"));
      //      writer.WriteEndElement();

      //      writer.WriteEndElement();

      //      // Mantenimiento
      //      writer.WriteStartElement(XML_NODE_MAINTENANCE);
      //      writer.WriteAttributeString(XML_ATTR_REVISIONH, this.MaintenanceRevisionHours.ToString());
      //      writer.WriteAttributeString(XML_ATTR_SERVICEH, this.MaintenanceServiceHours.ToString());
      //      writer.WriteAttributeString(XML_ATTR_LASTREV, (this.MaintenanceLastRevision > DateTime.MinValue ? this.MaintenanceLastRevision.ToFileTime().ToString() : string.Empty));

      //      // Revisiones de mantenimiento
      //      foreach (ModelRevision revision in this.MaintenanceRevisions)
      //      {
      //         writer.WriteStartElement(XML_NODE_REVISION);
      //         writer.WriteAttributeString(XML_ATTR_AUTHOR, revision.Author);
      //         writer.WriteAttributeString(XML_ATTR_DATE, revision.Date.ToFileTime().ToString());
      //         writer.WriteAttributeString(XML_ATTR_REVISIONH, revision.RevisionHours.ToString());
      //         writer.WriteAttributeString(XML_ATTR_SERVICEH, revision.ServiceHours.ToString());

      //         // Descripción
      //         writer.WriteString(revision.Description);

      //         writer.WriteEndElement();
      //      }

      //      writer.WriteEndElement();

      //      writer.WriteEndElement(); // otc-model

      //      // Cierra el documento
      //      writer.WriteEndDocument();
      //      writer.Close();
      //   }
      //   catch
      //   {
      //      throw;
      //   }
      //   finally
      //   {
      //      if (writer != null) writer.Close();
      //   }
      //}

      ///// <summary>
      ///// Carga los datos de un objeto desde un archivo.
      ///// </summary>
      ///// <param name="filename">Nombre + path del archivo a cargar.</param>
      //public void Load(string filename)
      //{
      //   int val = 0;
      //   long ldate = 0;
      //   decimal dec = 0;

      //   // Trata el archivo
      //   FileInfo file = new FileInfo(filename);

      //   // Carga el archivo XML
      //   XmlTextReader reader = new XmlTextReader(filename);
      //   reader.WhitespaceHandling = WhitespaceHandling.None;
      //   XmlDocument xmlDoc = new XmlDocument();
      //   xmlDoc.Load(filename);
      //   reader.Close();

      //   // Recupera el nodo raíz
      //   XmlNode xnod = xmlDoc.DocumentElement;
      //   if (!xnod.Name.ToLower().Equals(XML_NODE_ROOT))
      //      throw new Exception("El archivo XML proporcionado no corresponde a una definición de modelo según el estándar OTC.");

      //   // _otcversion = xnod.Attributes[XML_ATTR_OTCVER].Value.ToString();
      //   // _otcgenerator = xnod.Attributes[XML_ATTR_OTCGENERATOR].Value.ToString();

      //   foreach (XmlNode node in xnod.ChildNodes)
      //   {
      //      switch (node.Name.ToLower())
      //      {
      //         case XML_NODE_NAME:

      //            this.Name = node.InnerText;
      //            break;

      //         case XML_NODE_CATEGORY:

      //            CategoryDAO categories = new CategoryDAO();
      //            this.CategoryID = categories.GetId(node.Attributes[XML_ATTR_NAME].Value);

      //            break;

      //         case XML_NODE_REF:

      //            this.Reference = node.InnerText;
      //            break;

      //         case XML_NODE_UNITS:

      //            int units = 0;
      //            int.TryParse(node.InnerText, out units);
      //            this.Units = units;
      //            break;

      //         case XML_NODE_DESCRIPTION:

      //            this.Description = node.InnerText;
      //            break;

      //         case XML_NODE_PICTURE:

      //            int flen = 0;
      //            byte[] fbuffer;
      //            string fname = string.Empty;
                  
      //            foreach (XmlAttribute pfileatt in node.Attributes)
      //            {
      //               switch (pfileatt.Name.ToLower())
      //               {
      //                  case "name": fname = pfileatt.Value; break;
      //                  case "length": flen = int.Parse(pfileatt.Value); break;
      //               }
      //            }
      //            if (node.ChildNodes.Count > 0)
      //            {
      //               fbuffer = new byte[flen];
      //               fbuffer = Convert.FromBase64String(node.ChildNodes[0].FirstChild.Value);

      //               // Asegura la existencia de la carpeta temporal
      //               DirectoryInfo dir = new DirectoryInfo(Path.Combine(Application.StartupPath, "temp"));
      //               if (!dir.Exists) dir.Create();

      //               // Asegura la no existencia del archivo
      //               FileInfo tfile = new FileInfo(Path.Combine(dir.FullName, fname));
      //               if (tfile.Exists) tfile.Delete();

      //               // Guarda el archivo
      //               FileStream fstream = tfile.Create();
      //               fstream.Write(fbuffer, 0, flen);
      //               fstream.Close();
      //               fstream.Dispose();

      //               this.Picture = tfile.Name;
      //            }
      //            break;

      //         case XML_NODE_MODEL:

      //            foreach (XmlNode subnode in node.ChildNodes)
      //            {
      //               switch (subnode.Name.ToLower())
      //               {
      //                  case XML_NODE_SCALE:

      //                     ScaleDAO scales = new ScaleDAO();
      //                     this.ScaleID = scales.GetByName(subnode.Attributes[XML_ATTR_NAME].Value).ID;

      //                     break;

      //                  case XML_NODE_MANUFACTURER:

      //                     ManufacturerDAO manufacturers = new ManufacturerDAO();
      //                     this.ManufacturerID = manufacturers.GetByName(subnode.Attributes[XML_ATTR_NAME].Value).ID;

      //                     break;

      //                  case XML_NODE_LENGTH:

      //                     val = 0;
      //                     int.TryParse(subnode.InnerText, out val);
      //                     this.Length = val;

      //                     break;

      //                  case XML_NODE_COUPLERS:

      //                     this.HaveShortCouplers = (subnode.Attributes[XML_ATTR_SHORT].Value.Equals("1") ? true : false);
      //                     this.HaveNEMCouplers = (subnode.Attributes[XML_ATTR_NEM].Value.Equals("1") ? true : false);
      //                     break;

      //                  case XML_NODE_PANTOS:

      //                     this.HaveFunctionalPantos = (subnode.Attributes[XML_ATTR_FUNCTIONAL].Value.Equals("1") ? true : false);
      //                     break;

      //                  case XML_NODE_LIGHTS:

      //                     val = 0;
      //                     int.TryParse(subnode.Attributes[XML_ATTR_FRONT].Value, out val);
      //                     this.LightFront = (LightFrontType)val;

      //                     val = 0;
      //                     int.TryParse(subnode.Attributes[XML_ATTR_INTERIOR].Value, out val);
      //                     this.LightInterior = (LightInteriorType)val;

      //                     val = 0;
      //                     int.TryParse(subnode.Attributes[XML_ATTR_REAR].Value, out val);
      //                     this.LightRear = (LightRearType)val;

      //                     break;

      //                  case XML_NODE_FRAME:

      //                     val = 0;
      //                     int.TryParse(subnode.InnerText, out val);
      //                     this.Frame = (FrameType)val;

      //                     break;

      //                  case XML_NODE_INTERIOREQ:

      //                     val = 0;
      //                     int.TryParse(subnode.InnerText, out val);
      //                     this.InteriorEquipment = (InteriorEquipmentType)val;

      //                     break;

      //                  case XML_NODE_STORE:

      //                     StoreDAO stores = new StoreDAO();
      //                     this.StoreID = stores.GetByName(subnode.Attributes[XML_ATTR_NAME].Value).ID;

      //                     break;

      //                  case XML_NODE_PRICE:

      //                     dec = 0;
      //                     decimal.TryParse(subnode.Attributes[XML_ATTR_BUY].Value, out dec);
      //                     this.BuyPriceStore = dec;

      //                     dec = 0;
      //                     decimal.TryParse(subnode.Attributes[XML_ATTR_CATALOG].Value, out dec);
      //                     this.BuyPriceCatalogue = dec;

      //                     this.BuyIsPending = (subnode.Attributes[XML_ATTR_PENDING].Value.Equals("1") ? true : false);

      //                     break;

      //                  case XML_NODE_BUYDATE:

      //                     ldate = 0;
      //                     long.TryParse(subnode.InnerText, out ldate);
      //                     this.BuyDate = DateTime.FromFileTime(ldate);

      //                     break;

      //                  case XML_NODE_LIMITED:

      //                     this.IsLimited = (subnode.Attributes[XML_ATTR_ENABLED].Value.Equals("1") ? true : false);
      //                     this.LimitedYear = subnode.Attributes[XML_ATTR_PERIOD].Value;
      //                     break;

      //                  case XML_NODE_AXIS:

      //                     val = 0;
      //                     int.TryParse(subnode.Attributes[XML_ATTR_TRACTION].Value, out val);
      //                     this.AxisWithTraction = val;

      //                     val = 0;
      //                     int.TryParse(subnode.Attributes[XML_ATTR_TIRES].Value, out val);
      //                     this.AxisWithTractionTires = val;

      //                     this.EngineType = subnode.Attributes[XML_ATTR_ENGINETYPE].Value;
      //                     this.WheelDisposition = subnode.Attributes[XML_ATTR_WHEELDISP].Value;
      //                     break;
      //               }
      //            }

      //            break;

      //         case XML_NODE_PROTOTIPE:

      //            foreach (XmlNode subnode in node.ChildNodes)
      //            {
      //               switch (subnode.Name.ToLower())
      //               {

      //                  case XML_NODE_REGNUM:

      //                     this.RegistrationNumber = subnode.InnerText;
      //                     break;

      //                  case XML_NODE_ADMINISTRATION:

      //                     AdministrationDAO administrations = new AdministrationDAO();
      //                     this.AdminID = administrations.GetByName(subnode.Attributes[XML_ATTR_NAME].Value).ID;

      //                     break;

      //                  case XML_NODE_EPOCHE:

      //                     val = 0;
      //                     int.TryParse(subnode.InnerText, out val);
      //                     this.Era = (Epoche)val;

      //                     break;

      //                  case XML_NODE_PAINTSCHEME:

      //                     this.PaintScheme = subnode.InnerText;
      //                     break;

      //                  case XML_NODE_WAGON:

      //                     this.Type = subnode.Attributes[XML_ATTR_TYPE].Value;
      //                     this.TypeUIC = subnode.Attributes[XML_ATTR_UIC].Value;
      //                     break;
      //               }
      //            }

      //            break;

      //         case XML_NODE_DIGITAL:

      //            val = 0;
      //            int.TryParse(node.Attributes[XML_ATTR_ADDRESS].Value, out val);
      //            this.DigitalAddress = val;

      //            val = 0;
      //            int.TryParse(node.Attributes[XML_ATTR_CONNECTOR].Value, out val);
      //            this.DigitalConnector = (DigitalConnectorType)val;

      //            foreach (XmlNode subnode in node.ChildNodes)
      //            {
      //               switch (subnode.Name.ToLower())
      //               {
      //                  case XML_NODE_DECODER:

      //                     DecoderDAO decoders = new DecoderDAO();
      //                     this.DigitalDecoderID = decoders.GetByName(subnode.Attributes[XML_NODE_NAME].Value).ID;

      //                     break;

      //                  case XML_NODE_SOUND:

      //                     this.HaveSound = (subnode.Attributes[XML_ATTR_ENABLED].Value.Equals("1") ? true : false);
      //                     break;

      //                  case XML_NODE_FUNCTIONS:

      //                     foreach (XmlNode fnode in subnode.ChildNodes)
      //                     {
      //                        switch (fnode.Name.ToLower())
      //                        {
      //                           case XML_NODE_FUNCTION:

      //                              ModelDigitalFunction function = new ModelDigitalFunction();

      //                              val = 0;
      //                              int.TryParse(fnode.Attributes[XML_ATTR_ID].Value, out val);
      //                              function.FunctionId = val;

      //                              function.Name = fnode.Attributes[XML_ATTR_NAME].Value;

      //                              this.DigitalFunctions.Add(function);

      //                              break;
      //                        }
      //                     }

      //                     break;
      //               }
      //            }

      //            break;

      //         case XML_NODE_MAINTENANCE:

      //            val = 0;
      //            int.TryParse(node.Attributes[XML_ATTR_REVISIONH].Value, out val);
      //            this.MaintenanceRevisionHours = val;

      //            val = 0;
      //            int.TryParse(node.Attributes[XML_ATTR_SERVICEH].Value, out val);
      //            this.MaintenanceServiceHours = val;

      //            ldate = 0;
      //            long.TryParse(node.Attributes[XML_ATTR_LASTREV].Value, out ldate);
      //            this.MaintenanceLastRevision = DateTime.FromFileTime(ldate);

      //            foreach (XmlNode subnode in node.ChildNodes)
      //            {
      //               switch (subnode.Name.ToLower())
      //               {
      //                  case XML_NODE_REVISION:

      //                     ModelRevision revision = new ModelRevision();

      //                     revision.Author = subnode.Attributes[XML_ATTR_AUTHOR].Value;

      //                     ldate = 0;
      //                     long.TryParse(subnode.Attributes[XML_ATTR_DATE].Value, out ldate);
      //                     revision.Date = DateTime.FromFileTime(ldate);

      //                     val = 0;
      //                     int.TryParse(subnode.Attributes[XML_ATTR_REVISIONH].Value, out val);
      //                     revision.RevisionHours = val;

      //                     val = 0;
      //                     int.TryParse(subnode.Attributes[XML_ATTR_SERVICEH].Value, out val);
      //                     revision.ServiceHours = val;

      //                     revision.Description = subnode.InnerText;

      //                     this.MaintenanceRevisions.Add(revision);

      //                     break;
      //               }
      //            }

      //            break;
      //      }
      //   }
      //}

      ///// <summary>
      ///// Genera una ficha del modelo en formato PDF.
      ///// </summary>
      ///// <param name="filename">Nombre y ruta del archivo a generar.</param>
      ///// <remarks>Si el archivo existe, lo reemplaza.</remarks>
      //public void ToPdf(string filename, RCApplication application)
      //{
      //   float ypos = 0f;
      //   Image picto = null;

      //   try
      //   {
      //      // Genera un nuevo documento
      //      Document document = new Document();

      //      // Asigna un archivo al documento
      //      PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

      //      // Prepara las fuentes a usar
      //      iTextSharp.text.Font ftitle = FontFactory.GetFont(FontFactory.HELVETICA, 20, Font.BOLD);
      //      iTextSharp.text.Font fhead = FontFactory.GetFont(FontFactory.HELVETICA, 11, Font.BOLD);
      //      iTextSharp.text.Font fnormal = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL);
      //      iTextSharp.text.Font fbold = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL);
      //      iTextSharp.text.Font finfo = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL);
      //      iTextSharp.text.Font finfob = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD);

      //      // Establece las propiuedades del documento
      //      document.SetPageSize(PageSize.A4);
      //      document.AddAuthor(Application.ProductName);
      //      document.AddCreationDate();
      //      document.AddCreator(Application.CompanyName + " - " + Application.ProductName);
      //      document.AddTitle("Ficha del modelo: " + this.Name);
      //      document.AddSubject(Application.CompanyName);

      //      // Abre el nuevo documento
      //      document.Open();

      //      BaseFont bfBold = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
      //      BaseFont bfNormal = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

      //      // Dibuja la ficha manualmente
      //      PdfContentByte cb = writer.DirectContent;

      //      cb.Rectangle(document.LeftMargin,
      //                   document.PageSize.Height - document.TopMargin - 50f,
      //                   document.PageSize.Width - document.LeftMargin - document.RightMargin,
      //                   50f);
      //      cb.MoveTo(document.PageSize.Width - document.LeftMargin - document.RightMargin - 20f,
      //                document.PageSize.Height - document.TopMargin - 50f);
      //      cb.LineTo(document.PageSize.Width - document.LeftMargin - document.RightMargin - 20f,
      //                document.PageSize.Height - document.TopMargin);
      //      cb.Stroke();

      //      cb.BeginText();

      //      // Título
      //      AdministrationDAO admins = new AdministrationDAO(application);
      //      Administration admin = admins.GetByID(this.AdminID);
      //      cb.SetFontAndSize(bfNormal, 12);
      //      cb.SetTextMatrix(document.LeftMargin + 5f, document.PageSize.Height - document.TopMargin - 12f);
      //      cb.ShowText(admin != null ? admin.Name : "No asignado a ninguna administración/operador");

      //      cb.SetFontAndSize(bfBold, 16);
      //      cb.SetTextMatrix(document.LeftMargin + 5f, document.PageSize.Height - document.TopMargin - 32f);
      //      cb.ShowText(this.Name);

      //      CategoryDAO categories = new CategoryDAO(application);
      //      Category category = categories.GetByID(this.CategoryID);
      //      cb.SetFontAndSize(bfNormal, 12);
      //      cb.SetTextMatrix(document.LeftMargin + 5f, document.PageSize.Height - document.TopMargin - 45f);
      //      cb.ShowText(category != null ? category.Name : string.Empty);

      //      // Escala
      //      ScaleDAO scales = new ScaleDAO(application);
      //      Scale scale = scales.GetByID(this.ScaleID);
      //      cb.SetFontAndSize(bfNormal, 8);
      //      cb.SetTextMatrix(document.PageSize.Width - document.LeftMargin - document.RightMargin - 20 + 5, document.PageSize.Height - document.TopMargin - 13f);
      //      cb.ShowText(scale != null ? "Escala" : string.Empty);
      //      cb.SetFontAndSize(bfBold, 26);
      //      cb.SetTextMatrix(document.PageSize.Width - document.LeftMargin - document.RightMargin - 20 + 5, document.PageSize.Height - document.TopMargin - 35f);
      //      cb.ShowText(scale != null ? scale.Name : string.Empty);

      //      cb.EndText();

      //      ypos = document.PageSize.Height - document.TopMargin - 50f - 8f;

      //      // Agrega la imágen del modelo (si existe)
      //      if (!string.IsNullOrEmpty(this.Picture))
      //      {
      //         string ifilename = Path.Combine(ModelDAO.ImagesPath, this.Picture);
      //         FileInfo file = new FileInfo(ifilename);
      //         if (file.Exists)
      //         {
      //            // Ancho máximo: página. Altura máxima: 300
      //            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(ifilename);
      //            float scaleFactor = (document.PageSize.Width - document.LeftMargin - document.RightMargin) / img.Width * 100;
      //            img.ScalePercent(scaleFactor);

      //            if (img.Height > 300)
      //            {
      //               scaleFactor = 300 / img.Height * 100;
      //               img.ScalePercent(scaleFactor);
      //            }

      //            ypos = ypos - img.ScaledHeight;
      //            img.SetAbsolutePosition(document.LeftMargin, ypos);
      //            cb.AddImage(img);
      //            cb.Stroke();
      //         }
      //      }

      //      float xpos = document.LeftMargin;
      //      ypos = ypos - 8f - 25f;

      //      // Pictograma: época
      //      if (this.Era != Epoche.NotDefined)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(ModelDAO.GetEraPictogram(this.Era), Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: carcasa y bastidor
      //      if (this.Frame != FrameType.NotDefined)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(ModelDAO.GetFramePictogram(this.Frame), Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: luz de circulación
      //      if (this.LightFront != LightFrontType.WithoutLight)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(ModelDAO.GetFrontLightsPictogram(this.LightFront), Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: luz interior
      //      if (this.LightInterior != LightInteriorType.WithoutLight)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(ModelDAO.GetInteriorLightsPictogram(this.LightInterior), Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: luz trasera
      //      if (this.LightRear != LightRearType.WithoutLight)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(ModelDAO.GetRearLightsPictogram(this.LightRear), Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: pantógrafo funcional
      //      if (this.HaveFunctionalPantos)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(global::Rwm.collection.Properties.Resources.PICTO_ELECT_PANTO, Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: equipamiento interior
      //      if (this.InteriorEquipment != InteriorEquipmentType.WithoutDecoration)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(ModelDAO.GetInteriorEquipmentPictogram(this.InteriorEquipment), Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: cajetines enganche NEM
      //      if (this.HaveNEMCouplers)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(global::Rwm.collection.Properties.Resources.PICTO_COUPLER_NEM, Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: cinemática de enganche corto
      //      if (this.HaveShortCouplers)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(global::Rwm.collection.Properties.Resources.PICTO_COUPLER_KKK, Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: tipo de conector digital
      //      if (this.DigitalConnector != DigitalConnectorType.WithoutConnector)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(ModelDAO.GetDigitalPlugPictogram(this.DigitalConnector), Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: modelo digitalizado
      //      if (this.DigitalDecoderID > 0)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(global::Rwm.collection.Properties.Resources.PICTO_DIGITAL_ADDRESS_MINI, Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Pictograma: modelo con sonido
      //      if (this.HaveSound)
      //      {
      //         picto = iTextSharp.text.Image.GetInstance(global::Rwm.collection.Properties.Resources.PICTO_DIGITAL_SOUND, Color.WHITE);
      //         picto.SetAbsolutePosition(xpos, ypos);
      //         cb.AddImage(picto);
      //         cb.Stroke();

      //         xpos = xpos + picto.Width + 5f;
      //      }

      //      // Actualiza la posición vertical
      //      if (picto != null) ypos = ypos - 8f;

      //      document.Add(new Phrase("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"));

      //      Paragraph par = null;
      //      const int FONT_SIZE_NORMAL = 8;

      //      // Columnado de las características
      //      MultiColumnText columns = new MultiColumnText();
      //      columns.AddRegularColumns(document.LeftMargin, document.PageSize.Width - document.LeftMargin - document.RightMargin, 20f, 2);

      //      // Datos del modelo
      //      par = new Paragraph();

      //      par.Add(new Phrase("Modelo a escala", new Font(bfBold, 16)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Categoria: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(category != null ? category.Name : "- No especificada -", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      ManufacturerDAO manufacturers = new ManufacturerDAO(application);
      //      Manufacturer manufacturer = manufacturers.GetByID(this.ManufacturerID);
      //      par.Add(new Phrase("Fabricante: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(manufacturer != null ? manufacturer.Name : "- No especificado -", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Referencia: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.Reference, new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Longitud: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.Length > 0 ? this.Length + "mm" : string.Empty, new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Pantógrafos funcionales: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.HaveFunctionalPantos ? "Sí" : "No", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Interior detallado: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.InteriorEquipment == InteriorEquipmentType.WithDecoration ? "Sí" : "No", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Cinemática de enganche corto: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.HaveShortCouplers ? "Sí" : "No", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Cajetín de enganche NEM: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.HaveNEMCouplers ? "Sí" : "No", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Cajetín de enganche NEM: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.HaveNEMCouplers ? "Sí" : "No", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Carcasa/bastidor: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(ModelDAO.GetFrameName(this.Frame), new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Iluminación frontal: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(ModelDAO.GetFrontLightsName(this.LightFront), new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Iluminación interior: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(ModelDAO.GetInteriorLightsName(this.LightInterior), new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Iluminación de fin de convoy: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(ModelDAO.GetRearLightsName(this.LightRear), new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      string conname = string.Empty;
      //      switch (this.DigitalConnector)
      //      {
      //         case DigitalConnectorType.Connector6Pin: conname = "NEM 651 (6 pins)"; break;
      //         case DigitalConnectorType.Connector8Pin: conname = "NEM 652 (8 pins)"; break;
      //         case DigitalConnectorType.Connector21Pin: conname = "21 pins"; break;
      //         default: conname = "No"; break;
      //      }
      //      par.Add(new Phrase("Conector digital: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(conname, new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      DecoderDAO decoders = new DecoderDAO(application);
      //      Decoder decoder = decoders.GetByID(this.DigitalDecoderID);
      //      par.Add(new Phrase("Descodificador: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(decoder != null ? decoder.Name : string.Empty, new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Sonido: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.HaveSound ? "Sí" : "No", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      StoreDAO stores = new StoreDAO(application);
      //      Store store = stores.GetByID(this.StoreID);
      //      par.Add(new Phrase("Adquirido en: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(store != null ? store.Name : "- No especificado -", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Fecha de compra: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.BuyDate > DateTime.MinValue ? this.BuyDate.ToString("dd/MM/yyyy") : "- No especificada -", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Precio de compra: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.BuyPriceStore > 0 ? String.Format("{0:C}", this.BuyPriceStore) : "- No especificado -", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Precio de catálogo: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.BuyPriceCatalogue > 0 ? String.Format("{0:C}", this.BuyPriceCatalogue) : "- No especificado -", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Serie limitada: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(this.IsLimited ? "Sí" : "No", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      if (!string.IsNullOrEmpty(this.LimitedYear))
      //      {
      //         par.Add(new Phrase("Serie limitada al periodo: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //         par.Add(new Phrase(!string.IsNullOrEmpty(this.LimitedYear) ? this.LimitedYear : string.Empty, new Font(bfNormal, FONT_SIZE_NORMAL)));
      //         par.Add("\n");
      //      }

      //      // Datos del modelo
      //      par.Add(new Phrase("Prototipo", new Font(bfBold, 16)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Época: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(ModelDAO.GetEraName(this.Era), new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      par.Add(new Phrase("Administración: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //      par.Add(new Phrase(admin != null ? admin.Name : "- No especificada -", new Font(bfNormal, FONT_SIZE_NORMAL)));
      //      par.Add("\n");

      //      if (!string.IsNullOrEmpty(this.RegistrationNumber))
      //      {
      //         par.Add(new Phrase("Matrícula: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //         par.Add(new Phrase(this.RegistrationNumber, new Font(bfNormal, FONT_SIZE_NORMAL)));
      //         par.Add("\n");
      //      }

      //      if (!string.IsNullOrEmpty(this.PaintScheme))
      //      {
      //         par.Add(new Phrase("Esquema de pintura: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //         par.Add(new Phrase(this.PaintScheme, new Font(bfNormal, FONT_SIZE_NORMAL)));
      //         par.Add("\n");
      //      }

      //      if (!string.IsNullOrEmpty(this.Type))
      //      {
      //         par.Add(new Phrase("Tipo: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //         par.Add(new Phrase(this.Type, new Font(bfNormal, FONT_SIZE_NORMAL)));
      //         par.Add("\n");
      //      }

      //      if (!string.IsNullOrEmpty(this.TypeUIC))
      //      {
      //         par.Add(new Phrase("Tipo UIC: ", new Font(bfBold, FONT_SIZE_NORMAL)));
      //         par.Add(new Phrase(this.TypeUIC, new Font(bfNormal, FONT_SIZE_NORMAL)));
      //         par.Add("\n");
      //      }

      //      par.SpacingAfter = 10f;
      //      columns.AddElement(par);
      //      document.Add(columns);

      //      document.Close();
      //   }
      //   catch
      //   {
      //      throw;
      //   }
      //}

      #endregion

   }
}
