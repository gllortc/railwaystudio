using System;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Trains;

namespace Rwm.Otc.Data
{
   /// <summary>
   /// Base class to develop persisten entities for the layout control module.
   /// </summary>
   public class ControlDataEntity : DataConsumer
   {

      #region Constants

      /// <summary>Database current version.</summary>
      private const string SETTING_KEY_DB_SCHEMAVER = "control.db.version";

      /// <summary>Database version 1.0</summary>
      private const string DB_VERSION_1_0 = "1.0";
      /// <summary>Database version 1.1</summary>
      private const string DB_VERSION_1_1 = "1.1";
      /// <summary>Database version 1.2</summary>
      private const string DB_VERSION_1_2 = "1.2";

      /// <summary>Database current version.</summary>
      private const string DB_CURRENT_VERSION = DB_VERSION_1_2;

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ControlDataEntity"/>.
      /// </summary>
      public ControlDataEntity() : base() { }

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
            version = new Version(GetPropertyString(SETTING_KEY_DB_SCHEMAVER, "0.0"));

            if (version.CompareTo(new Version(DB_VERSION_1_0)) < 0)
            {
               this.Update_V1_0();
            }
            if (version.CompareTo(new Version(DB_VERSION_1_1)) < 0)
            {
               this.Update_V1_1();
            }
            if (version.CompareTo(new Version(DB_VERSION_1_2)) < 0)
            {
               this.Update_V1_2();
            }

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

         Connect();

         sql = @"CREATE TABLE " + ORMSqliteDriver.SQL_REGISTRY_TABLE + @"(
                     key               TEXT PRIMARY KEY,
                     value             TEXT)";

         this.CreateTable(ORMSqliteDriver.SQL_REGISTRY_TABLE, sql);

         sql = @"CREATE TABLE " + Project.TableName + @" (
                     id                INTEGER PRIMARY KEY AUTOINCREMENT,
                     name              TEXT  UNIQUE NOT NULL,
                     description       TEXT,
                     version           TEXT  DEFAULT ('1.0') 
                 );";

         this.CreateTable(Project.TableName, sql);

         sql = @"CREATE TABLE " + Switchboard.TableName + @" (
                     id                INTEGER PRIMARY KEY AUTOINCREMENT,
                     name              TEXT,
                     description       TEXT,
                     width             INTEGER DEFAULT 20 NOT NULL,
                     height            INTEGER DEFAULT 10 NOT NULL 
                 );";

         this.CreateTable(Switchboard.TableName, sql);

         sql = @"CREATE TABLE " + Element.TableName + @" (
                     id                INTEGER PRIMARY KEY AUTOINCREMENT,
                     panelid           INTEGER NOT NULL REFERENCES " + Switchboard.TableName + @" (id), 
                     name              TEXT,
                     x                 INTEGER DEFAULT 0 NOT NULL,
                     y                 INTEGER DEFAULT 0 NOT NULL,
                     width             INTEGER DEFAULT 1 NOT NULL,
                     rotation          INTEGER,
                     type              INTEGER,
                     status            INTEGER 
                 );";

         this.CreateTable(Element.TableName, sql);

         sql = @"CREATE TABLE " + AccessoryDecoder.TableName + @" (
                     id                INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     name              TEXT,
                     manufacturer      TEXT,
                     model             TEXT,
                     outputs           INTEGER DEFAULT 4 NOT NULL,
                     startaddress      INTEGER DEFAULT 0 NOT NULL,
                     type              INTEGER,
                     description       TEXT 
                 );";

         this.CreateTable(AccessoryDecoder.TableName, sql);

         sql = @"CREATE TABLE " + AccessoryDecoderConnection.TableName + @" (
                     id                INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                     [index]           INTEGER NOT NULL DEFAULT 0, 
                     decoderid         INTEGER NOT NULL REFERENCES " + AccessoryDecoder.TableName + @" (id), 
                     blockid           INTEGER REFERENCES " + Element.TableName + @" (id), 
                     name              TEXT, 
                     address           INTEGER, 
                     output            INTEGER NOT NULL DEFAULT 0, 
                     switchtime        INTEGER, 
                     out1              INTEGER, 
                     out2              INTEGER 
                 );";

         this.CreateTable(AccessoryDecoderConnection.TableName, sql);

         sql = @"CREATE TABLE " + Route.TableName + @" (
                     id                INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     name              TEXT,
                     description       TEXT, 
                     fromBlock         INTEGER REFERENCES blocks (id), 
                     toBlock           INTEGER REFERENCES blocks (id), 
                     bidirectional     BOOLEAN NOT NULL DEFAULT false
                 );";

         this.CreateTable(Route.TableName, sql);

         sql = @"CREATE TABLE " + RouteElement.TableName + @" (
                     id                INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     routeid           INTEGER REFERENCES " + Route.TableName + @" (id),
                     blockid           INTEGER REFERENCES " + Element.TableName + @" (id),
                     status            INTEGER
                 );";

         this.CreateTable(RouteElement.TableName, sql);

         //----------------------------------------------
         // MODEL TRAINS SCHEMA
         //----------------------------------------------

         sql = @"CREATE TABLE " + Company.TableName + @" (
                     adminid           INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     adminname         TEXT,
                     admindesc         TEXT,
                     adminurl          TEXT,
                     adminfile         TEXT,
                     adminimage        BLOB NULL 
                 );";

         this.CreateTable(Company.TableName, sql);

         sql = @"CREATE TABLE " + Manufacturer.TableName + @" (
                     buildid           INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     buildname         TEXT,
                     builddesc         TEXT,
                     buildurl          TEXT,
                     buildaddress      TEXT 
                 );";

         this.CreateTable(Manufacturer.TableName, sql);

         sql = @"CREATE TABLE " + TrainDecoder.TableName + @" (
                     decid             INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     decname           TEXT,
                     decdesc           TEXT,
                     decfile           BLOB NULL,
                     decurl            TEXT 
                 );";

         this.CreateTable(TrainDecoder.TableName, sql);

         sql = @"CREATE TABLE " + Category.TableName + @" (
                     typeid            INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     typename          TEXT, 
                     typeicon          TEXT, 
                     typemaint         INTEGER 
                 );";

         this.CreateTable(Category.TableName, sql);

         sql = @"CREATE TABLE " + Store.TableName + @" (
                     storeid           INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     storename         TEXT,
                     storeaddress      TEXT,
                     storephone        TEXT,
                     storemail         TEXT,
                     storeurl          TEXT,
                     storedesc         TEXT 
                 );";

         this.CreateTable(Store.TableName, sql);

         sql = @"CREATE TABLE " + Gauge.TableName + @" (
                     scid              INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     scname            TEXT,
                     scscale           TEXT,
                     sctwidth          REAL,
                     scrtwidth         REAL 
                 );";

         this.CreateTable(Gauge.TableName, sql);

         sql = @"CREATE TABLE " + Train.TableName + @" (
                     modid                INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                     modadminid           INTEGER REFERENCES " + Company.TableName + @" (adminid),
                     modstoreid           INTEGER REFERENCES " + Store.TableName + @" (storeid),
                     modtypeid            INTEGER NOT NULL REFERENCES " + Category.TableName + @" (typeid),
                     modname              TEXT NOT NULL,
                     modpaint             TEXT,
                     modepoche            INTEGER,
                     modref               TEXT,
                     modbuilderid         INTEGER REFERENCES " + Manufacturer.TableName + @" (buildid),
                     modscaleid           INTEGER REFERENCES " + Gauge.TableName + @" (scid),
                     modcatprice          REAL,
                     modbuyprice          REAL,
                     modbuydate           INTEGER,
                     modbuypending        INTEGER NOT NULL DEFAUL(false),
                     modcouplers          INTEGER,
                     modpant              INTEGER,
                     modsound             INTEGER,
                     modlim               INTEGER,
                     modlimyear           TEXT,
                     modlength            INTEGER,
                     modframe             INTEGER,
                     moddecointerior      INTEGER,
                     modlightfront        INTEGER,
                     modlightinterior     INTEGER,
                     modlightrear         INTEGER,
                     modoriginalbox       INTEGER,
                     modaxisdisp          TEXT,
                     modaxistraction      INTEGER,
                     modaxistires         INTEGER,
                     moddesc              TEXT,
                     modpicture           BLOB NULL,
                     modpicturefilename   TEXT, 
                     modunits             INTEGER,
                     moddigitaladd        INTEGER,
                     moddigitaldecoderid  INTEGER  REFERENCES " + TrainDecoder.TableName + @" (decid),
                     moddigitalconn       INTEGER,
                     modregnumber         TEXT,
                     modtype              TEXT,
                     modtypeuic           TEXT,
                     modenginetype        TEXT,
                     modsrvtotalhours     INTEGER,
                     modsrvrevhours       INTEGER 
                 );";

         this.CreateTable(Train.TableName, sql);

         SetProperty(ControlDataEntity.SETTING_KEY_DB_SCHEMAVER, DB_VERSION_1_0);

         Disconnect();
      }

      private void Update_V1_1()
      {
         string sql = string.Empty;

         Connect();

         sql = @"CREATE TABLE " + Sound.TableName + @" (
                        id                integer primary key autoincrement,
                        name              text,
                        filename          text,
                        sounddata         blob 
                 );";

         this.CreateTable(Sound.TableName, sql);

         SetProperty(ControlDataEntity.SETTING_KEY_DB_SCHEMAVER, DB_VERSION_1_1);

         Disconnect();
      }

      private void Update_V1_2()
      {
         string sql = string.Empty;

         Connect();

         sql = @"CREATE TABLE " + ElementAction.TableName + @" (
                        id                integer primary key autoincrement,
                        blockid           integer,
                        type              text    NOT NULL DEFAULT '', 
                        eventtype         integer NOT NULL DEFAULT 0,
                        description       text,
                        conditionstatus   integer, 
                        executionorder    integer, 
                        intparam1         integer, 
                        intparam2         integer, 
                        FOREIGN KEY (blockid) REFERENCES " + Element.TableName + @" (id) 
                 );";

         this.CreateTable(Rwm.Otc.Layout.ElementAction.TableName, sql);

         SetProperty(ControlDataEntity.SETTING_KEY_DB_SCHEMAVER, DB_VERSION_1_2);

         Disconnect();
      }

      #endregion

   }
}
