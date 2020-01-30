using Rwm.Otc.Configuration;
using Rwm.Otc.Diagnostics;
using Rwm.Studio.Plugins.Collection.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Collection.Model
{
   public class DecoderDAO : CollectionDataEntity
   {

      #region Constants

      // SQL constant declarations
      internal static string SQL_TABLE = "decoders";
      internal static string SQL_FIELDS_SELECT = "decid,decname,decdesc,decfile,decurl";
      internal static string SQL_FIELDS_INSERT = "decname,decdesc,decfile,decurl";

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="DecoderDAO"/>.
      /// </summary>
      public DecoderDAO(XmlSettingsManager settings)
         : base(settings)
      {
         // Asegura la existéncia de la carpeta de manuales
         //DirectoryInfo directory = new DirectoryInfo(DecoderDAO.FilesPath);
         //if (!directory.Exists) directory.Create();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Nombre de la carpeta que contiene los manuales
      /// </summary>
      public static string FilesFolderName
      {
         get { return "manuals"; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Agrega un nuevo decodificador.
      /// </summary>
      /// <param name="model">Una instáncia de RCDecoder.</param>
      public void Add(Decoder decoder)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            // Agrega el nuevo registro
            sql = @"INSERT INTO 
                        " + DecoderDAO.SQL_TABLE + @" (" + DecoderDAO.SQL_FIELDS_INSERT + @") 
                    VALUES 
                        (@decname,@decdesc,@decfile,@decurl)";

            SetParameter("decname", decoder.Name);
            SetParameter("decdesc", decoder.Description);
            SetParameter("decfile", decoder.File);
            SetParameter("decurl", decoder.URL);
            ExecuteNonQuery(sql);

            // Obtiene lel nuevo ID
            sql = @"SELECT 
                        Max(decid) As id 
                    FROM 
                        " + DecoderDAO.SQL_TABLE;

            decoder.ID = (int)ExecuteScalar(sql);
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
      /// Actualiza los datos de un decodificador.
      /// </summary>
      /// <param name="model">Una instáncia de RCDecoder.</param>
      public void Update(Decoder decoder)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"UPDATE 
                        " + DecoderDAO.SQL_TABLE + @" 
                    SET 
                        decname = @decname, 
                        decdesc = @decdesc, 
                        decfile = @decfile, 
                        decurl = @decurl 
                    WHERE 
                        decid = @decid";

            
            SetParameter("@decname", decoder.Name);
            SetParameter("@decdesc", decoder.Description);
            SetParameter("@decfile", decoder.File);
            SetParameter("@decurl", decoder.URL);
            SetParameter("@decid", decoder.ID);

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
      /// Elimina un decodificador si no está asignado a ningún modelo.
      /// </summary>
      /// <param name="ItemID">Identificador del decodificador.</param>
      public void Delete(int itemId)
      {
         string sql = string.Empty;

         try
         {
            // Averigua el número de modelos asignados a este decodificador
            if (this.CountItems(itemId) > 0)
            {
               throw new Exception("No se puede eliminar este decodificador porqué tiene modelos asociados.");
            }

            Connect();

            sql = @"DELETE 
                    FROM 
                        " + DecoderDAO.SQL_TABLE + @" 
                    WHERE 
                        decid = @decid";
            
            SetParameter("decid", itemId);
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
      /// Recupera las propiedades de un decodificador.
      /// </summary>
      /// <param name="itemid">Identificador del decodificador.</param>
      /// <returns>Una instáncia de RCDecoder.</returns>
      public Decoder GetByID(Int32 itemId)
      {
         return GetByID((Int64)itemId);
      }
      
      /// <summary>
      /// Recupera las propiedades de un decodificador.
      /// </summary>
      /// <param name="itemid">Identificador del decodificador.</param>
      /// <returns>Una instáncia de RCDecoder.</returns>
      public Decoder GetByID(Int64 itemId)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        " + DecoderDAO.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + DecoderDAO.SQL_TABLE + @" 
                    WHERE 
                        decid = @decid";

            SetParameter("decid", itemId);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return DecoderDAO.ReadEntityRecord(reader);
               }
               reader.Close();
            }

            return null;
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
      /// Recupera las propiedades de un decodificador.
      /// </summary>
      /// <param name="itemid">Identificador del decodificador.</param>
      /// <returns>Una instáncia de RCDecoder.</returns>
      public Decoder GetByName(string name)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        " + DecoderDAO.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + DecoderDAO.SQL_TABLE + @" 
                    WHERE 
                        decname = @decname";

            SetParameter("decname", name);

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               if (reader.Read())
               {
                  return DecoderDAO.ReadEntityRecord(reader);
               }
               reader.Close();
            }

            return null;
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
      /// Get all decoders.
      /// </summary>
      /// <returns>The requested list of decoders.</returns>
      public List<Decoder> GetAll()
      {
         string sql = string.Empty;
         List<Decoder> items = new List<Decoder>();

         try
         {
            Connect();

            sql = @"SELECT 
                        " + DecoderDAO.SQL_FIELDS_SELECT + @" 
                    FROM 
                        " + DecoderDAO.SQL_TABLE + @" 
                    ORDER BY 
                        decname Asc";

            using (SQLiteDataReader reader = ExecuteReader(sql))
            {
               while (reader.Read())
               {
                  items.Add(DecoderDAO.ReadEntityRecord(reader));
               }
               reader.Close();
            }

            return items;
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
      /// Calcula el número de modelos asignados a un decodificador.
      /// </summary>
      /// <param name="itemid">Identificador del decodificador.</param>
      /// <returns>El número de modelos asignados.</returns>
      public int CountItems(int itemid)
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        Count(*) As nregs 
                    FROM 
                        " + DecoderDAO.SQL_TABLE + @" 
                    WHERE 
                        moddecoderid = @moddecoderid";

            SetParameter("moddecoderid", itemid);
            return (int)ExecuteScalar(sql);
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
      /// Get all objects as a <see cref="DataTable"/>.
      /// </summary>
      /// <returns>The requested <see cref="DataTable"/> filled with information.</returns>
      public System.Data.DataTable GetAllAsDataTable()
      {
         string sql = string.Empty;

         try
         {
            Connect();

            sql = @"SELECT 
                        decid       As '#ID', 
                        decname     As 'Name',
                        decurl      As 'URL'
                    FROM 
                        " + DecoderDAO.SQL_TABLE + @" 
                    ORDER BY 
                        decname";

            return this.ExecuteDataTable(sql);
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

      #region Static Members

      /// <summary>
      /// Devuelve la ruta de acceso a la carpeta de documentación de descodificadores.
      /// </summary>
      public static string FilesPath
      {
         get { return Path.Combine(Application.StartupPath, DecoderDAO.FilesFolderName); }
      }

      internal static Decoder ReadEntityRecord(SQLiteDataReader reader)
      {
         Decoder item = new Decoder();
         item = new Decoder();
         item.ID = (reader.IsDBNull(0) ? 0 : reader.GetInt32(0));
         item.Name = (reader.IsDBNull(1) ? string.Empty : reader.GetString(1));
         item.Description = (reader.IsDBNull(2) ? string.Empty : reader.GetString(2));
         item.File = (reader.IsDBNull(3) ? string.Empty : reader.GetString(3));
         item.URL = (reader.IsDBNull(4) ? string.Empty : reader.GetString(4));

         return item;
      }

      #endregion

      #region Disabled Code

      ///// <summary>
      ///// Rellena un control ComboBox con una lista de decoders.
      ///// </summary>
      ///// <param name="comboBox">Control contenedor.</param>
      ///// <param name="defaultId">ID del elemento preseleccionado.</param>
      //public void List(ComboBox comboBox, int defaultId)
      //{
      //   int idx = 0;
      //   OleDbCommand cmd = null;
      //   OleDbDataReader read = null;

      //   try
      //   {
      //      string sql = "SELECT decname,decid FROM decoders ORDER BY decname ASC";

      //      // Agrega la opción de no digitalizado
      //      comboBox.Items.Clear();
      //      comboBox.Items.Add(new ComboBoxItem("[Modelo no digitalizado]", (object)0));

      //      // Rellena la lista desplegable
      //      Connect();
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      read = cmd.ExecuteReader();
      //      while (read.Read())
      //      {
      //         comboBox.Items.Add(new ComboBoxItem(read.GetString(0), read.GetInt32(1)));
      //      }
      //      read.Close();

      //      // Preselecciona el elemento indicado
      //      foreach (ComboBoxItem item in comboBox.Items)
      //      {
      //         if ((int)item.Value == defaultId)
      //         {
      //            comboBox.SelectedIndex = idx;
      //            break;
      //         }
      //         idx++;
      //      }

      //      // Si dispone de archivo y/o web asociados, activa los botones
      //      if (comboBox.SelectedItem != null)
      //      {
      //         if ((int)((ComboBoxItem)comboBox.SelectedItem).Value <= 0) return;
      //         Decoder deco = this.Item((int)((ComboBoxItem)comboBox.SelectedItem).Value);
      //         if (deco == null) return;
      //         // if (!deco.File.Equals("")) comboBox.Buttons[2].Enabled = true;
      //         // if (!deco.HREF.Equals("")) comboBox.Buttons[3].Enabled = true;
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      DebugLogger.LogError(this, ex);

      //      throw;
      //   }
      //   finally
      //   {
      //      read.Dispose();
      //      cmd.Dispose();

      //      // _app.Disconnect();
      //   }
      //}

      ///// <summary>
      ///// Rellena un control ComboBox con una lista de decoders.
      ///// </summary>
      ///// <param name="comboBox">Control contenedor.</param>
      //public void List(ComboBox comboBox)
      //{
      //   this.List(comboBox, -1);
      //}

      ///// <summary>
      ///// Rellena un control ListView con una lista de decodificadores.
      ///// </summary>
      ///// <param name="listView">Control contenedor de la lista.</param>
      //public void ListView(ListView listView)
      //{
      //   OleDbCommand cmd = null;
      //   OleDbDataReader read = null;

      //   try
      //   {
      //      // Genera la senténcia SQL que obtiene los elementos
      //      string sql = "SELECT decid,decname FROM decoders ORDER BY decname";

      //      // Configura el control ListView
      //      listView.Clear();
      //      listView.Columns.Add("Denominación", 350);
      //      listView.View = System.Windows.Forms.View.Details;

      //      listView.SmallImageList = new ImageList();
      //      listView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
      //      listView.SmallImageList.ImageSize = new System.Drawing.Size(16, 16);
      //      listView.SmallImageList.Images.Add("IMG_DECODER", global::Rwm.collection.Properties.Resources.IMG_DECODER_16);

      //      Connect();
      //      cmd = new OleDbCommand(sql, _app.Connection);
      //      read = cmd.ExecuteReader();
      //      while (read.Read())
      //      {
      //         System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem();
      //         item.Tag = read.GetInt32(0);
      //         item.Text = read.IsDBNull(1) ? string.Empty : read.GetString(1);
      //         item.ImageKey = "IMG_DECODER";

      //         listView.Items.Add(item);
      //      }
      //      read.Close();

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
      //      read.Dispose();
      //      cmd.Dispose();

      //      // _app.Disconnect();
      //   }
      //}

      #endregion

   }
}
