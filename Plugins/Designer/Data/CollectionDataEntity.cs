using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.TrainControl;
using System;

namespace Rwm.Studio.Plugins.Collection.Data
{
   /// <summary>
   /// Base class to develop persisten entities for the collection module.
   /// </summary>
   public class CollectionDataEntity : Rwm.Otc.Data.DataEntity
   {

      #region Constants

      /// <summary>Database current version.</summary>
      public const string SETTING_KEY_DB_SCHEMAVER = "collection.db.version";

      // /// <summary>Database version 3.5</summary>
      // public const string DB_VERSION_3_5 = DB_CURRENT_VERSION;
      /// <summary>Database version 1.0</summary>
      public const string DB_VERSION_1_0 = "1.0";

      /// <summary>Database current version.</summary>
      public const string DB_CURRENT_VERSION = DB_VERSION_1_0;

      #endregion

      #region Constructors

      public CollectionDataEntity(XmlSettingsManager settings) : base(settings)
      {
         
      }

      #endregion

      #region Methods

      /// <summary>
      /// Ensure that the database exist and is compatible with the latest version.
      /// </summary>
      public override void CheckDatabase()
      {
         string currentDbVer = string.Empty;
         string sql = string.Empty;
         Version version = null;

         if (this.DatabaseChecked)
         {
            return;
         }

         try
         {
            version = new Version(GetPropertyString(SETTING_KEY_DB_SCHEMAVER, "0.1"));

            if (version.CompareTo(new Version(DB_VERSION_1_0)) < 0)
            {
               Update_V1_0();
            }
            //else if (currentDbVer.CompareTo(DB_VERSION_3_5) < 0)
            //{
            //   Update_V3_5();
            //}

            this.DatabaseChecked = true;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            throw;
         }
      }

      #endregion

      #region Private Members

      private void Update_V1_0()
      {
         string sql = string.Empty;

         sql = @"CREATE TABLE " + AdministrationDAO.SQL_TABLE + @" (
                     adminid           integer primary key autoincrement,
                     adminname         text,
                     admindesc         text,
                     adminurl          text,
                     adminfile         text,
                     adminimage        text)";

         this.CreateTable(AdministrationDAO.SQL_TABLE, sql);

         sql = @"CREATE TABLE " + ManufacturerDAO.SQL_TABLE + @" (
                     buildid           integer primary key autoincrement,
                     buildname         text,
                     builddesc         text,
                     buildurl          text,
                     buildaddress      text)";

         this.CreateTable(ManufacturerDAO.SQL_TABLE, sql);

//         sql = @"CREATE TABLE cars (
//                     carid             integer primary key autoincrement,
//                     carmodelid        integer,
//                     caradminid        integer,
//                     carnumber         text,
//                     carepoche         integer,
//                     cartype           text,
//                     cartypepre        text,
//                     cartypepost       text,
//                     caruic            text,
//                     cardesc           text,
//                     carmaxspeed       integer,
//                     carlong           real,
//                     carlongaxels      real,
//                     carweight         real,
//                     carloadlong       real,
//                     carloadsurf       real,
//                     carloadvol        real,
//                     carloaddesc       text,
//                     caroptions        integer)";

//         this.CreateTable(ManufacturerDAO.SQL_TABLE, sql);

         sql = @"CREATE TABLE " + DecoderDAO.SQL_TABLE + @" (
                     decid             integer primary key autoincrement,
                     decname           text,
                     decdesc           text,
                     decfile           blob NULL,
                     decurl            text)";

         this.CreateTable(DecoderDAO.SQL_TABLE, sql);

//         sql = @"CREATE TABLE images (
//                     imgid             integer primary key autoincrement,
//                     imgmodelid        integer,
//                     imgname           text,
//                     imgdesc           text,
//                     imgfile           blob NULL)";

//         this.CreateTable(DecoderDAO.SQL_TABLE, sql);

//         sql = @"CREATE TABLE maintenance (
//                     actionid          integer primary key autoincrement,
//                     actionmodelid     integer,
//                     actiondate        integer,
//                     actionname        text,
//                     actiondesc        text)";

//         this.CreateTable(DecoderDAO.SQL_TABLE, sql);

         sql = @"CREATE TABLE " + CategoryDAO.SQL_TABLE + @" (
                     typeid            integer not null primary key autoincrement,
                     typename          text, 
                     typeicon          text, 
                     typemaint         integer)";

         this.CreateTable(CategoryDAO.SQL_TABLE, sql);

         sql = @"CREATE TABLE " + StoreDAO.SQL_TABLE + @" (
                     storeid           integer not null primary key autoincrement,
                     storename         text,
                     storeaddress      text,
                     storephone        text,
                     storemail         text,
                     storeurl          text,
                     storedesc         text)";

         this.CreateTable(StoreDAO.SQL_TABLE, sql);

         sql = @"CREATE TABLE " + ScaleDAO.SQL_TABLE + @" (
                     scid              integer primary key autoincrement,
                     scname            text,
                     scscale           text,
                     sctwidth          real,
                     scrtwidth         real)";

         this.CreateTable(ScaleDAO.SQL_TABLE, sql);

         sql = @"CREATE TABLE " + ModelDAO.SQL_TABLE + @" (
                     modid                integer primary key autoincrement,
                     modadminid           integer,
                     modstoreid           integer,
                     modtypeid            integer  NOT NULL,
                     modname              text     NOT NULL,
                     modpaint             text,
                     modepoche            integer,
                     modref               text,
                     modbuilderid         integer,
                     modscaleid           integer,
                     modcatprice          real,
                     modbuyprice          real,
                     modbuydate           integer,
                     modbuypending        integer,
                     modcouplers          integer,
                     modpant              integer,
                     modsound             integer,
                     modlim               integer,
                     modlimyear           text,
                     modlength            integer,
                     modframe             integer,
                     moddecointerior      integer,
                     modlightfront        integer,
                     modlightinterior     integer,
                     modlightrear         integer,
                     modoriginalbox       integer,
                     modaxisdisp          text,
                     modaxistraction      integer,
                     modaxistires         integer,
                     moddesc              text,
                     modpicture           blob     NULL,
                     modpicturefilename   text, 
                     modunits             integer,
                     moddigitaladd        integer,
                     moddigitaldecoderid  integer,
                     moddigitalconn       integer,
                     modregnumber         text,
                     modtype              text,
                     modtypeuic           text,
                     modenginetype        text
                     modsrvtotalhours     integer,
                     modsrvrevhours       integer,
                     FOREIGN KEY (modadminid)            REFERENCES " + AdministrationDAO.SQL_TABLE + @" (adminid), 
                     FOREIGN KEY (modstoreid)            REFERENCES " + StoreDAO.SQL_TABLE + @" (storeid), 
                     FOREIGN KEY (modtypeid)             REFERENCES " + CategoryDAO.SQL_TABLE + @" (typeid), 
                     FOREIGN KEY (modbuilderid)          REFERENCES " + ManufacturerDAO.SQL_TABLE + @" (buildid), 
                     FOREIGN KEY (modscaleid)            REFERENCES " + ScaleDAO.SQL_TABLE + @" (scid), 
                     FOREIGN KEY (moddigitaldecoderid)   REFERENCES " + DecoderDAO.SQL_TABLE + @" (decid))";

         this.CreateTable(ModelDAO.SQL_TABLE, sql);

//         sql = @"CREATE TABLE modelsdfunc (
//                     modelid           integer,
//                     funcid            integer,
//                     description       text)";

//         this.CreateTable(ModelDAO.SQL_TABLE, sql);

//         sql = @"CREATE TABLE modelsrevs (
//                     id                integer primary key autoincrement,
//                     modelid           integer,
//                     revdate           integer,
//                     servicehours      real,
//                     runninghours      real,
//                     description       text,
//                     author            text)";

//         this.CreateTable(ModelDAO.SQL_TABLE, sql);

//         sql = @"CREATE TABLE images (
//                     imageid        integer not null primary key autoincrement,
//                     imagefilename  text not null,
//                     imagecontent   blob null)";

//         this.CreateTable(StoreDAO.SQL_TABLE, sql);

         SetProperty(CollectionDataEntity.SETTING_KEY_DB_SCHEMAVER, DB_VERSION_1_0);
      }

      #endregion

   }
}
