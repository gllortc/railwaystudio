using Rwm.Otc.Configuration;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.LayoutControl.Actions;
using Rwm.Otc.LayoutControl.Elements;
using System;

namespace Rwm.Otc.LayoutControl.Data
{
   /// <summary>
   /// Base class to develop persisten entities for the layout control module.
   /// </summary>
   public class ControlDataEntity : DataEntity
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
      /// <param name="settings">The current application settings.</param>
      public ControlDataEntity(XmlSettingsManager settings) : base(settings) { }

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
               Update_V1_0();
            }
            if (version.CompareTo(new Version(DB_VERSION_1_1)) < 0)
            {
               Update_V1_1();
            }
            if (version.CompareTo(new Version(DB_VERSION_1_2)) < 0)
            {
               Update_V1_2();
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

         sql = @"CREATE TABLE " + SwitchboardPanelManager.SQL_TABLE + @" (
                        id                integer primary key autoincrement,
                        name              text,
                        description       text,
                        width             integer DEFAULT 20 NOT NULL,
                        height            integer DEFAULT 10 NOT NULL)";

         this.CreateTable(SwitchboardPanelManager.SQL_TABLE, sql);

         sql = @"CREATE TABLE " + ElementManager.SQL_TABLE + @" (
                        id                integer primary key autoincrement,
                        panelid           integer not null,
                        name              text,
                        x                 integer DEFAULT 0 NOT NULL,
                        y                 integer DEFAULT 0 NOT NULL,
                        width             integer DEFAULT 1 NOT NULL,
                        rotation          integer,
                        type              integer,
                        status            integer, 
                        FOREIGN KEY (panelid) REFERENCES " + SwitchboardPanelManager.SQL_TABLE + @" (id))";

         this.CreateTable(ElementManager.SQL_TABLE, sql);

         sql = @"CREATE TABLE " + ControlModuleManager.SQL_TABLE + @" (
                        id                integer primary key autoincrement,
                        name              text,
                        manufacturer      text,
                        model             text,
                        outputs           integer DEFAULT 4 NOT NULL,
                        startaddress      integer DEFAULT 0 NOT NULL,
                        type              integer,
                        description       text)";

         this.CreateTable(ControlModuleManager.SQL_TABLE, sql);

         sql = @"CREATE TABLE " + ControlModuleConnectionManager.SQL_TABLE + @" (
                        id                integer primary key autoincrement, 
                        [index]           integer NOT NULL DEFAULT 0, 
                        decoderid         integer NOT NULL, 
                        blockid           integer, 
                        name              text, 
                        address           integer, 
                        output            integer NOT NULL DEFAULT 0, 
                        switchtime        integer, 
                        out1              integer, 
                        out2              integer, 
                        FOREIGN KEY (decoderid) REFERENCES " + ControlModuleManager.SQL_TABLE + @" (id), 
                        FOREIGN KEY (blockid)   REFERENCES " + ElementManager.SQL_TABLE + @" (id))";

         this.CreateTable(ControlModuleConnectionManager.SQL_TABLE, sql);         

         sql = @"CREATE TABLE " + RouteManager.SQL_BLOCK_TABLE + @" (
                        id                integer primary key autoincrement,
                        routeid           integer,
                        blockid           integer,
                        status            integer, 
                        FOREIGN KEY (routeid)   REFERENCES " + RouteManager.SQL_TABLE + @" (id), 
                        FOREIGN KEY (blockid)   REFERENCES " + ElementManager.SQL_TABLE + @" (id))";

         this.CreateTable(RouteManager.SQL_BLOCK_TABLE, sql);

         sql = @"CREATE TABLE " + RouteManager.SQL_TABLE + @" (
                        id                integer primary key autoincrement,
                        panelid           integer,
                        name              integer,
                        description       text, 
                        FOREIGN KEY (panelid) REFERENCES " + SwitchboardPanelManager.SQL_TABLE + @" (id))";

         this.CreateTable(RouteManager.SQL_TABLE, sql);

         SetProperty(ControlDataEntity.SETTING_KEY_DB_SCHEMAVER, DB_VERSION_1_0);

         Disconnect();
      }

      private void Update_V1_1()
      {
         string sql = string.Empty;

         Connect();

         sql = @"CREATE TABLE " + SoundManager.SQL_TABLE + @" (
                        id                integer primary key autoincrement,
                        name              text,
                        filename          text,
                        sounddata         blob)";

         this.CreateTable(SoundManager.SQL_TABLE, sql);

         SetProperty(ControlDataEntity.SETTING_KEY_DB_SCHEMAVER, DB_VERSION_1_1);

         Disconnect();
      }

      private void Update_V1_2()
      {
         string sql = string.Empty;

         Connect();

         sql = @"CREATE TABLE " + ElementActionManager.SQL_TABLE + @" (
                        id                integer primary key autoincrement,
                        blockid           integer,
                        type              text    NOT NULL DEFAULT '', 
                        eventtype         integer NOT NULL DEFAULT 0,
                        description       text,
                        conditionstatus   integer, 
                        executionorder    integer, 
                        intparam1         integer, 
                        intparam2         integer, 
                        FOREIGN KEY (blockid) REFERENCES " + ElementManager.SQL_TABLE + @" (id))";

         this.CreateTable(ElementActionManager.SQL_TABLE, sql);

         SetProperty(ControlDataEntity.SETTING_KEY_DB_SCHEMAVER, DB_VERSION_1_2);

         Disconnect();
      }

      #endregion

   }
}
