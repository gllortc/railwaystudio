using System.Data.OleDb;

namespace Rwm.collection.Data
{
   /// <summary>
   /// Clase encargada de actualizar el esquema de la base de datos.
   /// </summary>
   /// <remarks>
   /// La versión del esquema no debe coincidir obligatoriament con la del software. 
   /// Son versiones totalmente independientes.
   /// </remarks>
   public class DataUpgrader
   {
      /// <summary>Clave de acceso a la versión de la base de datos.</summary>
      private const string KEY_SYSDATA_SCHEMAVER = "DB.VERSION";

      /// <summary>Versión 1.0 (1.x, 2.x).</summary>
      public const string DB_SCHEMA_VERSION_1_0 = "1.0";
      /// <summary>Versión 2.0 (2008).</summary>
      public const string DB_SCHEMA_VERSION_2_0 = "2.0";
      /// <summary>Versión 3.5 (2011).</summary>
      public const string DB_SCHEMA_VERSION_3_5 = "3.5";
      /// <summary>Versión 3.6 (Dec 2011).</summary>
      public const string DB_SCHEMA_VERSION_3_6 = "3.6";

      /// <summary>
      /// Devuelve una instancia de <see cref="DataUpgrader"/>.
      /// </summary>
      /// <param name="application">Una instancia de <see cref="RCApplication"/> que representa la aplicación.</param>
      public DataUpgrader()
      {

      }

      /// <summary>
      /// Devuelve la última versión del esquema de base de datos.
      /// </summary>
      public string CurrentVersion
      {
         get { return DB_SCHEMA_VERSION_3_6; }
      }

      #region Methods

      /// <summary>
      /// Indica si la versión de la base de datos es la correcta.
      /// </summary>
      public bool IsLastVersion()
      {
         // Comprueba la versión de la BBDD
         string dbv = _app.GetSysData(KEY_SYSDATA_SCHEMAVER, DB_SCHEMA_VERSION_1_0);

         if (dbv.CompareTo(this.CurrentVersion) < 0)
            return false;

         return true;
      }

      public void Upgrade()
      {
         // Obtiene la versión actual
         string runningVersion = _app.GetSysData(KEY_SYSDATA_SCHEMAVER, DB_SCHEMA_VERSION_1_0);

         // Upgrade a la versión 3.5
         if (runningVersion.CompareTo(DB_SCHEMA_VERSION_3_5) < 0)
            Upgrade3_5();

         // Upgrade a la versión 3.6
         if (runningVersion.CompareTo(DB_SCHEMA_VERSION_3_6) < 0)
            Upgrade3_6();
      }

      #endregion

      #region Upgrade Processes

      private void Upgrade3_5()
      {
         string sql;
         OleDbTransaction transaction;
         OleDbCommand cmd;

         System.Diagnostics.Trace.TraceInformation("UPGRADE: Upgrading to version {0}", DB_SCHEMA_VERSION_3_5);

         transaction = _app.Connection.BeginTransaction();

         // Tabla MODELS
         CreateField("MODELS", "MODFRAME", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODLIGHTINTERIOR", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODLIGHTREAR", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODDECOINTERIOR", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODDIGITALCONNECTOR", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODBUYPENDING", "BIT DEFAULT 0", transaction);
         CreateField("MODELS", "MODSRVTOTALHOURS", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODSRVREVHOURS", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODORIGINALBOX", "BIT DEFAULT 0", transaction);
         CreateField("MODELS", "MODAXISTRACTION", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODAXISTIRES", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODCATPRICE", "CURRENCY DEFAULT 0", transaction);
         CreateField("MODELS", "MODDIGITALADD", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODDIGITALDEC", "VARCHAR(255) DEFAULT ''", transaction);
         CreateField("MODELS", "MODDECODERID", "LONG DEFAULT 0", transaction);
         CreateField("MODELS", "MODKKK", "BIT DEFAULT 0", transaction);
         CreateField("MODELS", "MODREGNUMBER", "VARCHAR(64) DEFAULT ''", transaction);
         CreateField("MODELS", "MODTYPE", "VARCHAR(32) DEFAULT ''", transaction);
         CreateField("MODELS", "MODTYPEUIC", "VARCHAR(32) DEFAULT ''", transaction);
         System.Diagnostics.Trace.TraceInformation("Table MODELS upgraded");

         // Tabla ADMINS
         CreateField("ADMINS", "ADMINFILE", "VARCHAR(255) DEFAULT ''", transaction);
         System.Diagnostics.Trace.TraceInformation("Table ADMINS upgraded");

         // Tabla MODELSDFUNC (funciones digitales)
         if (!TableExists("MODELSDFUNC", transaction))
         {
            sql = "CREATE TABLE MODELSDFUNC " +
                  "(MODELID LONG, " +                                // Identificador del modelo
                   "FUNCID INTEGER, " +                              // Número de la función
                   "DESCRIPTION VARCHAR(255) DEFAULT '', " +         // Nombre descriptivo de la función
                   "CONSTRAINT idxModelsDFuncPrimary PRIMARY KEY (MODELID, FUNCID), " +
                   "FOREIGN KEY (MODELID) REFERENCES MODELS(MODID)" +
                  ")";
            cmd = new OleDbCommand(sql, _app.Connection, transaction);
            cmd.ExecuteNonQuery();
            System.Diagnostics.Trace.TraceInformation("Table MODELSDFUNC created");
         }

         // Tabla MODELSREVISIONS (revisiones de mantenimiento / reparaciones)
         if (!TableExists("MODELSREVS", transaction))
         {
            sql = "CREATE TABLE MODELSREVS " +
                  "(MODELID LONG, " +                                // Identificador del modelo
                   "REVDATE DATE, " +                                // Fecha de revisión
                   "SERVICEHOURS INTEGER DEFAULT 0, " +              // Horas totales en servicio
                   "RUNNINGHOURS INTEGER DEFAULT 0, " +              // Horas desde la última revisión
                   "DESCRIPTION NTEXT NOT NULL, " +                  // Descripción de la revisión
                   "AUTHOR VARCHAR DEFAULT '', " +                   // Revisión hecha por...
                   "FOREIGN KEY (MODELID) REFERENCES MODELS(MODID)" +
                  ")";
            cmd = new OleDbCommand(sql, _app.Connection, transaction);
            cmd.ExecuteNonQuery();
            System.Diagnostics.Trace.TraceInformation("Table MODELSREVS created");
         }

         // Tabla DECODERS
         if (!TableExists("DECODERS", transaction))
         {
            sql = "CREATE TABLE DECODERS " +
                  "(DECID AUTOINCREMENT PRIMARY KEY, " +             // Identificador del descodificador
                   "DECNAME VARCHAR(255), " +                        // Nombre del descodificador
                   "DECDESC NTEXT DEFAULT '', " +                    // Descripción
                   "DECFILE VARCHAR(255) DEFAULT '', " +             // Archivo (manual) sin path
                   "DECWEB VARCHAR(255) DEFAULT '' " +               // Web
                  ")";
            cmd = new OleDbCommand(sql, _app.Connection, transaction);
            cmd.ExecuteNonQuery();
            System.Diagnostics.Trace.TraceInformation("Table DECODERS created");
         }

         // Tabla CARS
         if (!TableExists("CARS", transaction))
         {
            sql = "CREATE TABLE CARS " +
                  "(CARID AUTOINCREMENT PRIMARY KEY, " +             // Identificador
                   "CARMODELID LONG DEFAULT 0, " +                   // Identificador del modelo al que pertenece
                   "CARADMINID LONG DEFAULT 0, " +                   // Identificador de la administració/operadora
                   "CARNUMBER VARCHAR(64) DEFAULT '', " +            // Matrícula
                   "CAREPOCHE INTEGER DEFAULT 0, " +                 // Época
                   "CARTYPE VARCHAR(25) DEFAULT '', " +              // Tipo
                   "CARTYPEPRE VARCHAR(25) DEFAULT '', " +           // pre-Tipo
                   "CARTYPEPOST VARCHAR(25) DEFAULT '', " +          // post-Tipo
                   "CARUIC VARCHAR(25) DEFAULT '', " +               // Tipo UIC
                   "CARDESC VARCHAR(128) DEFAULT '', " +             // Descripción
                   "CARMAXSPEED INTEGER DEFAULT 0, " +               // Velocidad máxima autorizada
                   "CARLONG NUMERIC(18) DEFAULT 0, " +               // Longitud entre topes
                   "CARLONGAXELS NUMERIC(18) DEFAULT 0, " +          // Longitud entre ejes
                   "CARWEIGHT NUMERIC(18) DEFAULT 0, " +             // Peso en vacío
                   "CARLOADLONG NUMERIC(18) DEFAULT 0, " +           // Longitud de la carga
                   "CARLOADSURF NUMERIC(18) DEFAULT 0, " +           // Superfície de la carga
                   "CARLOADVOL NUMERIC(18) DEFAULT 0, " +            // Volúmen de la carga
                   "CARLOADDESC VARCHAR(255) DEFAULT '', " +         // Descripción de la carga
                   "CAROPTIONS INTEGER DEFAULT 0 " +                 // Opciones
                  ")";
            cmd = new OleDbCommand(sql, _app.Connection, transaction);
            cmd.ExecuteNonQuery();
            System.Diagnostics.Trace.TraceInformation("Table CARS created");
         }

         // Tabla SYSDATA
         if (!TableExists("SYSDATA", transaction))
         {
            sql = "CREATE TABLE SYSDATA (" +
                   "SDKEY VARCHAR(64) PRIMARY KEY, " +               // Identificador del modelo
                   "SDVALUE VARCHAR(255) " +                         // Fecha de revisión
                  ")";
            cmd = new OleDbCommand(sql, _app.Connection, transaction);
            cmd.ExecuteNonQuery();

            System.Diagnostics.Trace.TraceInformation("Table SYSDATA created");
         }

         // Actualiza la versión de la BBDD
         SetSchemaVersion(DB_SCHEMA_VERSION_3_5, transaction);

         transaction.Commit();

         System.Diagnostics.Trace.TraceInformation("UPGRADE: Database upgraded to version {0}.\n\n", DB_SCHEMA_VERSION_3_5);
         System.Diagnostics.Trace.Flush();
      }

      private void Upgrade3_6()
      {
         string sql;
         OleDbTransaction transaction;
         OleDbCommand cmd;

         System.Diagnostics.Trace.TraceInformation("UPGRADE: Upgrading to version {0}...\n", DB_SCHEMA_VERSION_3_6);

         transaction = _app.Connection.BeginTransaction();

         // Tabla MODELS
         CreateField("MODELS", "MODENGINETYPE", "VARCHAR(255) DEFAULT ''", transaction);
         CreateField("MODELS", "MODAXISDISP", "VARCHAR(32) DEFAULT ''", transaction);
         CreateField("MODELS", "MODAXISTRACTION", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODAXISTIRES", "INTEGER DEFAULT 0", transaction);
         CreateField("MODELS", "MODORIGINALBOX", "BIT DEFAULT 1", transaction);
         ExecuteSQL("UPDATE MODELS SET MODORIGINALBOX=1", transaction);

         // Tabla TYPES
         CreateField("TYPES", "TYPEMAINT", "BIT DEFAULT 1", transaction);
         ExecuteSQL("UPDATE TYPES SET TYPEMAINT=1", transaction);

         // Tabla MODELSFILES
         if (!TableExists("MODELFILES", transaction))
         {
            sql = "CREATE TABLE MODELFILES " +
                  "(FILEID AUTOINCREMENT PRIMARY KEY, " +   // Identificador del documento
                   "FILEMODELID LONG, " +                   // Identificador del modelo al que pertenece
                   "FILETITLE VARCHAR(255), " +             // Nombre del documento
                   "FILENAME VARCHAR(255), " +              // Nombre del archivo
                   "FOREIGN KEY (FILEMODELID) REFERENCES MODELS(MODID)" +
                  ")";
            cmd = new OleDbCommand(sql, _app.Connection, transaction);
            cmd.ExecuteNonQuery();
            System.Diagnostics.Trace.TraceInformation("Table MODELFILES created");
         }

         // Actualiza la versión de la BBDD
         SetSchemaVersion(DB_SCHEMA_VERSION_3_6, transaction);

         transaction.Commit();

         System.Diagnostics.Trace.TraceInformation("UPGRADE: Database upgraded to version {0}.\n\n", DB_SCHEMA_VERSION_3_6);
         System.Diagnostics.Trace.Flush();
      }

      #endregion

      #region Private members

      /// <summary>
      /// Verifica si existe una determinada tabla en la base de datos.
      /// </summary>
      /// <param name="tableName">Nombre de la tabla a verificar.</param>
      /// <returns><code>true</code> si la tabla existe o <code>false</code> en cualquier otro caso.</returns>
      private bool TableExists(string tableName, OleDbTransaction transaction)
      {
         OleDbCommand cmd = null;

         try
         {
            cmd = new OleDbCommand("SELECT Count(*) FROM " + tableName, _app.Connection, transaction);
            cmd.ExecuteScalar();

            return true;
         }
         catch
         {
            return false;
         }
         finally
         {
            cmd.Dispose();
         }
      }

      /// <summary>
      /// Verifica si existe una determinada tabla en la base de datos.
      /// </summary>
      /// <param name="tableName">Nombre de la tabla a verificar.</param>
      /// <returns><code>true</code> si la tabla existe o <code>false</code> en cualquier otro caso.</returns>
      private bool FieldExists(string tableName, string fieldName, OleDbTransaction trans)
      {
         OleDbCommand cmd = null;

         try
         {
            cmd = new OleDbCommand("SELECT TOP 1 " + fieldName + " FROM " + tableName, _app.Connection, trans);
            cmd.ExecuteScalar();

            return true;
         }
         catch
         {
            return false;
         }
         finally
         {
            cmd.Dispose();
         }
      }

      private void CreateField(string tableName, string fieldName, string properties, OleDbTransaction transaction)
      {
         OleDbCommand cmd = null;

         if (!FieldExists(tableName, fieldName, transaction))
         {
            cmd = new OleDbCommand("ALTER TABLE " + tableName + " ADD COLUMN " + fieldName + " " + properties, _app.Connection, transaction);
            cmd.ExecuteNonQuery();
         }
      }

      private void ExecuteSQL(string sql, OleDbTransaction transaction)
      {
         OleDbCommand cmd = new OleDbCommand(sql, _app.Connection, transaction);
         cmd.ExecuteNonQuery();
      }

      /// <summary>
      /// Actualiza la versión del esquema de la base de datos.
      /// </summary>
      /// <param name="version">Versión a establecer.</param>
      /// <param name="transaction">Transacción abierta.</param>
      private void SetSchemaVersion(string version, OleDbTransaction transaction)
      {
         OleDbCommand cmd = new OleDbCommand("UPDATE sysdata SET sdvalue=@DBVER WHERE UCase(SDKEY)=UCase(@SDKEY)", _app.Connection, transaction);
         cmd.Parameters.Add(new OleDbParameter("DBVER", version));
         cmd.Parameters.Add(new OleDbParameter("SDKEY", "DB.VERSION"));
         cmd.ExecuteNonQuery();
      }

      #endregion

   }
}
