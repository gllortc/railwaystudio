using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Rwm.Otc.TrainControl.Persistence
{

   public class AdministrationDAO : DataManager<Administration>
   {

      #region Constants

      public const string LogosFolderName = "logos";

      // SQL declarations
      internal static string SQL_TABLE = "admins";
      internal static string SQL_FIELDS_SELECT = "adminid, adminname, admindesc, adminurl, adminfile, adminimage";
      internal static string SQL_FIELDS_INSERT = "adminname, admindesc, adminurl, adminfile, adminimage";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="AdministrationDAO"/>.
      /// </summary>
      /// <param name="app">Una instáncia de RCApplication.</param>
      public AdministrationDAO() : base() { }

      #endregion

      #region Methods

//      /// <summary>
//      /// Agrega una nueva administración/operadora.
//      /// </summary>
//      /// <param name="model">Una instáncia de RCAdministration.</param>
//      public override void Add(Administration admin)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            // Añade el registro
//            sql = @"INSERT INTO 
//                        " + AdministrationDAO.SQL_TABLE + @" (" + AdministrationDAO.SQL_FIELDS_INSERT + @") 
//                    VALUES 
//                        (@adminname, @admindesc, @adminurl, @adminfile, @adminimage)";

//            SetParameter("adminname", admin.Name);
//            SetParameter("admindesc", admin.Description);
//            SetParameter("adminurl", admin.URL);
//            SetParameter("adminfile", admin.LogoFilename);
//            SetParameter("adminimage", admin.LogoImage);

//            ExecuteNonQuery(sql);

//            // Obtiene el nuevo ID
//            sql = @"SELECT 
//                        Max(adminid) As id 
//                    FROM 
//                        " + AdministrationDAO.SQL_TABLE;

//            admin.ID = (int)ExecuteScalar(sql);
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Actualiza los datos de una administración/operadora.
//      /// </summary>
//      /// <param name="model">Una instáncia de RCAdministration.</param>
//      public override void Update(Administration admin)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"UPDATE 
//                        " + AdministrationDAO.SQL_TABLE + @" 
//                    SET 
//                        adminname = @adminname, 
//                        admindesc = @admindesc,
//                        adminurl = @adminurl, 
//                        adminfile = @adminfile,
//                        adminimage = @adminimage 
//                    WHERE 
//                        adminid = @adminid";

//            SetParameter("adminname", admin.Name);
//            SetParameter("admindesc", admin.Description);
//            SetParameter("adminurl", admin.URL);
//            SetParameter("adminfile", admin.LogoFilename);
//            SetParameter("adminimage", admin.LogoImage);
//            SetParameter("adminid", admin.ID);

//            ExecuteNonQuery(sql);
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Elimina una administración/operadora si no tiene ningún modelo asignado
//      /// </summary>
//      /// <param name="ItemID">Identificador de la administración/operadora.</param>
//      public override int Delete(long itemid)
//      {
//         string sql = string.Empty;

//         try
//         {
//            // Averigua el número de modelos asignados a esta categoria
//            if (this.CountItems(itemid) > 0)
//            {
//               throw new Exception("This administration cannot be deleted because it has related models.");
//            }

//            Connect();

//            sql = @"DELETE 
//                    FROM 
//                        " + AdministrationDAO.SQL_TABLE + @" 
//                    WHERE 
//                        adminid = @adminid";

//            SetParameter("adminid", itemid);
//            return ExecuteNonQuery(sql);
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Recupera las propiedades de una Administración/Operadora.
//      /// </summary>
//      /// <param name="itemid">Identificador.</param>
//      /// <returns>Una instáncia de RCAdministration.</returns>
//      public override Administration GetByID(long itemId)
//      {
//         string sql = string.Empty;
//         Administration item = null;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + AdministrationDAO.SQL_FIELDS_INSERT + @" 
//                    FROM 
//                        " + AdministrationDAO.SQL_TABLE + @" 
//                    WHERE 
//                        adminid = @adminid";

//            SetParameter("adminid", itemId);

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               if (reader.Read())
//               {
//                  item = this.ReadEntityRecord(reader);
//               }
//            }

//            // Obtiene la imagen
//            if (item != null && !item.LogoFilename.Equals(string.Empty))
//            {
//               FileInfo file = new FileInfo(Path.Combine(AdministrationDAO.LogosPath, item.LogoFilename));
//               if (file.Exists)
//               {
//                  item.LogoImage = Image.FromFile(file.FullName);
//               }
//               else
//               {
//                  item.LogoFilename = string.Empty;
//                  item.LogoImage = null;
//               }
//            }

//            return item;
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Averigua el ID de una administración a partir de su nombre.
//      /// </summary>
//      /// <param name="name">Nombre de la administración.</param>
//      /// <returns>Identificador del registro.</returns>
//      public Administration GetByName(string name)
//      {
//         string sql = string.Empty;
//         Administration item = null;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + AdministrationDAO.SQL_FIELDS_INSERT + @" 
//                    FROM 
//                        " + AdministrationDAO.SQL_TABLE + @" 
//                    WHERE 
//                        LCase(adminname) = @adminname";

//            SetParameter("adminname", name);

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               if (reader.Read())
//               {
//                  item = this.ReadEntityRecord(reader);
//               }
//            }

//            // Obtiene la imagen
//            if (item != null && !item.LogoFilename.Equals(string.Empty))
//            {
//               FileInfo file = new FileInfo(Path.Combine(AdministrationDAO.LogosPath, item.LogoFilename));
//               if (file.Exists)
//               {
//                  item.LogoImage = Image.FromFile(file.FullName);
//               }
//               else
//               {
//                  item.LogoFilename = string.Empty;
//                  item.LogoImage = null;
//               }
//            }

//            return item;
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Get all railway companies.
//      /// </summary>
//      /// <returns>The requested list filled with information.</returns>
//      public override IEnumerable<Administration> GetAll()
//      {
//         string sql = string.Empty;
//         Administration admin;
//         List<Administration> admins = new List<Administration>();

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        " + AdministrationDAO.SQL_FIELDS_SELECT + @"
//                    FROM 
//                        " + AdministrationDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        adminname";

//            using (SQLiteDataReader reader = ExecuteReader(sql))
//            {
//               while (reader.Read())
//               {
//                  admin = this.ReadEntityRecord(reader);
//                  if (admin != null)
//                  {
//                     admins.Add(admin);
//                  }
//               }
//            }

//            return admins;
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

//      /// <summary>
//      /// Get all railway companies as a <see cref="DataSource"/>.
//      /// </summary>
//      /// <returns>The requested <see cref="DataSource"/> filled with information.</returns>
//      public System.Data.DataTable GetAllAsDataTable()
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        adminid     As '#ID', 
//                        adminname   As 'Name', 
//                        admindesc   As 'Description'
//                    FROM 
//                        " + AdministrationDAO.SQL_TABLE + @" 
//                    ORDER BY 
//                        adminname";

//            return ExecuteDataTable(sql);
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

      ///// <summary>
      ///// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      ///// </summary>
      ///// <param name="comboBox">Control contenedor de la lista.</param>
      ///// <param name="defaultId">Identificador del elemento a preseleccionar.</param>
      ///// <param name="addNoAdminOption">Indica si añade un elemento para permitir no seleccionar ningún elemento.</param>
      //public void List(ComboBox comboBox, int defaultId, bool addNoAdminOption)
      //{
      //   int idx = 0;
      //   OleDbCommand sqlCmd = null;
      //   OleDbDataReader sqlRead = null;

      //   // Vacía la lista
      //   comboBox.Items.Clear();

      //   try
      //   {
      //      string sql = "SELECT adminname,adminid FROM admins ORDER BY adminname Asc";

      //      // Añade la opción de no seleccionar administración
      //      comboBox.Items.Add(new ComboBoxItem("[Sin administración asociada]", 0));

      //      // Rellena la lista
      //      Connect();
      //      sqlCmd = new OleDbCommand(sql, _app.Connection);
      //      sqlRead = sqlCmd.ExecuteReader();
      //      while (sqlRead.Read())
      //      {
      //         comboBox.Items.Add(new ComboBoxItem(sqlRead.GetString(0), sqlRead.GetInt32(1)));
      //      }
      //      sqlRead.Close();

      //      if (defaultId > 0)
      //      {
      //         foreach (ComboBoxItem item in comboBox.Items)
      //         {
      //            if (Rwm.Otc.Math.Numeric.IsNumeric(item.Value.ToString()))
      //            {
      //               if ((int)item.Value == defaultId)
      //               {
      //                  comboBox.SelectedIndex = idx;
      //                  break;
      //               }
      //            }
      //            idx++;
      //         }
      //      }
      //      else if (addNoAdminOption)
      //         comboBox.SelectedIndex = 0;
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      sqlRead.Dispose();
      //      sqlCmd.Dispose();
      //      // _app.Disconnect();
      //   }
      //}

      ///// <summary>
      ///// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      ///// </summary>
      ///// <param name="comboBox">Control contenedor de la lista.</param>
      //public void List(ComboBox comboBox)
      //{
      //   this.List(comboBox, -1, false);
      //}

      ///// <summary>
      ///// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      ///// </summary>
      ///// <param name="comboBox">Control contenedor de la lista.</param>
      ///// <param name="defaultId">Identificador del elemento a preseleccionar.</param>
      //public void List(ComboBox comboBox, int defaultId)
      //{
      //   this.List(comboBox, defaultId, false);
      //}

      ///// <summary>
      ///// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      ///// </summary>
      ///// <param name="comboBox">Control contenedor de la lista.</param>
      ///// <param name="addNoAdminOption">Indica si añade un elemento para permitir no seleccionar ningún elemento.</param>
      //public void List(ComboBox comboBox, bool addNoAdminOption)
      //{
      //   this.List(comboBox, -1, addNoAdminOption);
      //}

      /*
      /// <summary>
      /// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      /// </summary>
      /// <param name="comboBox">Control contenedor de la lista.</param>
      /// <param name="imageIndex">Índice de la imagen a mostrar.</param>
      /// <param name="addNoAdminOption">Indica si añade un elemento para permitir no seleccionar ningún elemento.</param>
      public void List(ImageComboBoxEdit comboBox, int imageIndex, bool addNoAdminOption)
      {
         this.List(comboBox, -1, imageIndex, addNoAdminOption);
      }

      /// <summary>
      /// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      /// </summary>
      /// <param name="comboBox">Control contenedor de la lista.</param>
      /// <param name="defaultId">Identificador del elemento a preseleccionar.</param>
      /// <param name="imageIndex">Índice de la imagen a mostrar.</param>
      public void List(ImageComboBoxEdit comboBox, int defaultId, int imageIndex)
      {
         this.List(comboBox, defaultId, imageIndex, false);
      }

      /// <summary>
      /// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      /// </summary>
      /// <param name="comboBox">Control contenedor de la lista.</param>
      /// <param name="defaultId">Identificador del elemento a preseleccionar.</param>
      /// <param name="imageIndex">Índice de la imagen a mostrar.</param>
      /// <param name="addNoAdminOption">Indica si añade un elemento para permitir no seleccionar ningún elemento.</param>
      public void List(System.Windows.Forms.ComboBox comboBox, int defaultId, int imageIndex, bool addNoAdminOption)
      {
         int idx = 0;
         OleDbCommand sqlCmd = null;
         OleDbDataReader sqlRead = null;

         try
         {

            string sql = "SELECT adminname,adminid FROM admins ORDER BY adminname Asc";

            // Añade la opción de no seleccionar administración
            comboBox.Items.Add(new otc.forms.controls.ComboBoxItem("[Sin administración asociada]", -1));

            // Rellena la lista
            Connect();
            sqlCmd = new OleDbCommand(sql, _app.Connection);
            sqlRead = sqlCmd.ExecuteReader();
            while (sqlRead.Read())
            {
               comboBox.Items.Add(new otc.forms.controls.ComboBoxItem(sqlRead.GetString(0), sqlRead.GetInt32(1)));
            }
            sqlRead.Close();

            if (defaultId > 0)
            {
               foreach (ImageComboBoxItem item in comboBox.Items)
               {
                  if (Utils.IsNumeric(item.Value.ToString()))
                  {
                     if ((int)item.Value == defaultId)
                     {
                        comboBox.SelectedIndex = idx;
                        break;
                     }
                  }
                  idx++;
               }
            }
            else if (addNoAdminOption)
               comboBox.SelectedIndex = 0;
         }
         catch (Exception e)
         {
            throw e;
         }
         finally
         {
            sqlRead.Dispose();
            sqlCmd.Dispose();
            _app.Disconnect();
         }
      }

      /// <summary>
      /// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      /// </summary>
      /// <param name="comboBox">Control contenedor de la lista.</param>
      /// <param name="imageIndex">Índice de la imagen a mostrar.</param>
      public void List(System.Windows.Forms.ComboBox comboBox, int imageIndex)
      {
         this.List(comboBox, -1, imageIndex, false);
      }

      /// <summary>
      /// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      /// </summary>
      /// <param name="comboBox">Control contenedor de la lista.</param>
      /// <param name="imageIndex">Índice de la imagen a mostrar.</param>
      /// <param name="addNoAdminOption">Indica si añade un elemento para permitir no seleccionar ningún elemento.</param>
      public void List(System.Windows.Forms.ComboBox comboBox, int imageIndex, bool addNoAdminOption)
      {
         this.List(comboBox, -1, imageIndex, addNoAdminOption);
      }

      /// <summary>
      /// Rellena un control ImageComboBoxEdit con una lista de Administraciones/Operadores
      /// </summary>
      /// <param name="comboBox">Control contenedor de la lista.</param>
      /// <param name="defaultId">Identificador del elemento a preseleccionar.</param>
      /// <param name="imageIndex">Índice de la imagen a mostrar.</param>
      public void List(System.Windows.Forms.ComboBox comboBox, int defaultId, int imageIndex)
      {
         this.List(comboBox, defaultId, imageIndex, false);
      }*/

      ///// <summary>
      ///// Rellena un control ListView con una lista de administraciones ferroviarias.
      ///// </summary>
      ///// <param name="listView">Control contenedor de la lista.</param>
      //public void ListView(ListView listView)
      //{
      //   OleDbCommand sqlCmd = null;
      //   OleDbDataReader sqlRead = null;

      //   try
      //   {
      //      // Genera la senténcia SQL que obtiene los elementos
      //      string sql = "SELECT adminid,adminname,adminurl FROM admins ORDER BY adminname Asc";

      //      // Configura el control ListView
      //      listView.Clear();
      //      listView.Columns.Add("Administración / Operadora", 150);
      //      listView.Columns.Add("URL", 250);
      //      listView.View = System.Windows.Forms.View.Details;

      //      listView.SmallImageList = new ImageList();
      //      listView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
      //      listView.SmallImageList.ImageSize = new System.Drawing.Size(16, 16);
      //      listView.SmallImageList.Images.Add("IMG_ADMIN", global::Rwm.collection.Properties.Resources.IMG_ADMIN_16);

      //      Connect();
      //      sqlCmd = new OleDbCommand(sql, _app.Connection);
      //      sqlRead = sqlCmd.ExecuteReader();
      //      while (sqlRead.Read())
      //      {
      //         System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem();
      //         item.Tag = sqlRead.GetInt32(0);
      //         item.Text = sqlRead.IsDBNull(1) ? string.Empty : sqlRead.GetString(1);
      //         item.SubItems.Add(sqlRead.IsDBNull(2) ? string.Empty : sqlRead.GetString(2));
      //         item.ImageKey = "IMG_ADMIN";
      //         listView.Items.Add(item);
      //      }
      //      sqlRead.Close();

      //      // if (listView.Items.Count > 0)
      //      //   listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      sqlRead.Dispose();
      //      sqlCmd.Dispose();
      //      // _app.Disconnect();
      //   }
      //}

//      /// <summary>
//      /// Calcula el número de modelos asignados a una administración/operadora.
//      /// </summary>
//      /// <param name="itemid">Identificador de la administración/operadora.</param>
//      /// <returns>El número de modelos asignados.</returns>
//      public int CountItems(long itemid)
//      {
//         string sql = string.Empty;

//         try
//         {
//            Connect();

//            sql = @"SELECT 
//                        Count(*) As nregs 
//                    FROM 
//                        " + ModelDAO.SQL_TABLE + @" 
//                    WHERE 
//                        modadminid = @modadminid";

            
//            SetParameter("modadminid", itemid);
//            return (int)ExecuteScalar(sql);
//         }
//         catch (Exception ex)
//         {
//            Logger.LogError(this, ex);

//            throw;
//         }
//         finally
//         {
//            Disconnect();
//         }
//      }

      /// <summary>
      /// Read a category from the current reader record.
      /// </summary>
      public override Administration ReadEntityRecord(SQLiteDataReader reader)
      {
         // adminid, adminname, admindesc, adminurl, adminfile, adminimage

         Administration record = new Administration();
         record.ID = (int)reader.GetInt64(0);
         record.Name = reader.GetString(1);
         record.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
         record.URL = reader.IsDBNull(3) ? string.Empty : reader.GetString(1);
         record.LogoFilename = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

         string imgBytes = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
         record.LogoImage = string.IsNullOrWhiteSpace(imgBytes) ? null : Rwm.Otc.Data.SQLiteHelper.ByteToImage(Encoding.ASCII.GetBytes(imgBytes));

         return record;
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Devuelve la ruta a la carpeta que contiene los logiotipos de las administraciones.
      /// </summary>
      public static string LogosPath
      {
         get { return Path.Combine(Application.StartupPath, AdministrationDAO.LogosFolderName); }
      }

      #endregion

   }
}
