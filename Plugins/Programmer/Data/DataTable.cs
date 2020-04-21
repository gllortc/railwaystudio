using System.Collections.Generic;

namespace Rwm.Studio.Plugins.Collection.Data
{
   /// <summary>
   /// Representa una tabla de datos sobre la que se pueden hacer diversas operaciones.
   /// </summary>
   public class DataTable
   {
      public enum QueryOperator
      {
         And,
         Or
      }

      /// <summary>
      /// Devuelve una instancia de <see cref="DataTable"/>.
      /// </summary>
      public DataTable()
      {
         // Inicializaciones
         this.QueryOperatorType = QueryOperator.And;
         Fields = new List<DataColumn>();
         Filters = new List<DataFilter>();
      }

      /// <summary>
      /// Gets or sets el nombre de la tabla.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets el nombre visible de la tabla.
      /// </summary>
      public string Title { get; set; }

      /// <summary>
      /// Gets or sets el nombre del campo que actúa de identificador único.
      /// </summary>
      /// <remarks>
      /// Puede no formar parte de la lista de campos de la tabla.
      /// </remarks>
      public string ID { get; set; }

      /// <summary>
      /// Gets or sets el nombre del campo que contiene la imagen del elemento.
      /// </summary>
      /// <remarks>
      /// Puede no formar parte de la lista de campos de la tabla.
      /// </remarks>
      public string Icon { get; set; }

      /// <summary>
      /// Contiene la lista de campos de la tabla.
      /// </summary>
      public List<DataColumn> Fields { get; set; }

      /// <summary>
      /// Contiene la lista de campos de filtro.
      /// </summary>
      public List<DataFilter> Filters { get; set; }

      /// <summary>
      /// Especifica que tipo de operador se aplica a los filtros concatenados.
      /// </summary>
      public QueryOperator QueryOperatorType { get; set; }

      /// <summary>
      /// Indica si una tabla contiene un determinado campo.
      /// </summary>
      public bool ContainsColumn(string name)
      {
         foreach (DataColumn column in this.Fields)
         {
            if (column.Name.Equals(name))
            {
               return true;
            }
         }
         return false;
      }

      /// <summary>
      /// Indica si una tabla contiene un determinado filtro.
      /// </summary>
      public bool ContainsFilter(string name)
      {
         foreach (DataColumn column in this.Fields)
         {
            if (column.Name.Equals(name))
            {
               return true;
            }
         }
         return false;
      }

      /// <summary>
      /// Aplica un filtro a una columna de filtrado previamente añadida a los filtros.
      /// </summary>
      /// <param name="ColumnName">Nombre de la columna a la que se desea aplicar el filtro.</param>
      /// <param name="value">Valor del filtro.</param>
      public void SetFilterValue(string ColumnName, string filterValue)
      {
         foreach (DataFilter filter in this.Filters)
         {
            if (filter.Equals(ColumnName))
            {
               filter.Value = filterValue;
               return;
            }
         }
      }

      /// <summary>
      /// Devuelve una senténcia SQL que contiene las columnas de la tabla y los filtros aplicados.
      /// </summary>
      /// <returns>Una cadena que representa la senténcia SQL.</returns>
      public string GetFilterSqlQuery()
      {
         string sql = string.Empty;

         // Genera la cláusula SELECT
         sql += "SELECT ";
         foreach (DataColumn column in this.Fields)
         {
            sql += column.Name + ",";
         }
         sql = sql.Substring(0, sql.Length - 1); // Elimina la última coma
         if (!string.IsNullOrWhiteSpace(this.ID)) sql += "," + this.ID;
         if (!string.IsNullOrWhiteSpace(this.Icon)) sql += "," + this.Icon;
         sql += " ";

         // Genera la cláusula FROM
         sql += "FROM  ((((((DECODERS RIGHT OUTER JOIN " +
                "            MODELS ON DECODERS.DECID = MODELS.MODDECODERID) LEFT OUTER JOIN " +
                "            SCALES ON MODELS.MODSCALE = SCALES.SCID) LEFT OUTER JOIN " +
                "            TYPES ON MODELS.MODTYPEID = TYPES.TYPEID) LEFT OUTER JOIN " +
                "            STORES ON MODELS.MODSTOREID = STORES.STOREID) LEFT OUTER JOIN " +
                "            BUILDERS ON MODELS.MODBUILDERID = BUILDERS.BUILDID) LEFT OUTER JOIN " +
                "            ADMINS ON MODELS.MODADMINID = ADMINS.ADMINID) ";

         // Genera la cláusula WHERE
         if (this.Filters.Count > 0)
         {
            sql += "WHERE ";
            foreach (DataFilter filter in this.Filters)
            {
               if (!string.IsNullOrWhiteSpace(filter.Value))
               {
                  sql += filter.GetSqlFilter() + this.GetQueryOperator();
/*

                  switch (filter.Type)
                  {
                     case OleDbType.Boolean:
                        sql += filter.Name + "=" + filter.Value + this.GetQueryOperator();
                        break;

                     case OleDbType.WChar:
                        if (!filter.IsLikeFilter)
                           sql += filter.Name + "='" + filter.Value + "'" + this.GetQueryOperator();
                        else
                           sql += filter.Name + " LIKE '%" + filter.Value + "%'" + this.GetQueryOperator();
                        break;

                     case OleDbType.BigInt:
                     case OleDbType.Integer:
                     case OleDbType.SmallInt:
                        sql += filter.Name + "=" + filter.Value + this.GetQueryOperator();
                        break;
                  }*/
               }
            }

            // Elimina el último operador (AND, OR)
            sql = sql.Substring(0, sql.Length - this.GetQueryOperator().Length).Trim() + " "; 
         }

         // Genera la cláusula ORDER BY
         sql += "ORDER BY models.modname ASC";

         return sql;
      }

      ///// <summary>
      ///// Genera un listado basado en un <see cref="DataTable"/> sobre un control <see cref="ListView"/>.
      ///// </summary>
      ///// <param name="listView">Control <see cref="ListView"/> que mostrará el listado.</param>
      ///// <param name="table">Una instancia de <see cref="DataTable"/> que contiene la información a mostrar en el listado.</param>
      //public void ListByColumns(RCApplication application, ListView listView)
      //{
      //   int idx = 0;
      //   string sql = string.Empty;
      //   string val = string.Empty;
      //   OleDbCommand cmd = null;
      //   OleDbDataReader reader = null;
      //   ColumnHeader colHead = null;

      //   try
      //   {
      //      // Configura el control ListView
      //      listView.Items.Clear();
      //      listView.Columns.Clear();
      //      foreach (DataColumn column in this.Fields)
      //      {
      //         colHead = new ColumnHeader();
      //         colHead.Text = column.Title;
      //         colHead.TextAlign = column.Alignment;
      //         if (column.Width > 0) colHead.Width = column.Width;

      //         listView.Columns.Add(colHead);
      //      }
      //      listView.View = System.Windows.Forms.View.Details;

      //      application.Connect();

      //      cmd = new OleDbCommand(this.GetFilterSqlQuery(), application.Connection);
      //      reader = cmd.ExecuteReader();
      //      while (reader.Read())
      //      {
      //         System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem();
      //         if (!string.IsNullOrWhiteSpace(this.ID)) item.Tag = int.Parse(reader[this.Fields.Count].ToString());
      //         if (!string.IsNullOrWhiteSpace(this.Icon)) item.ImageKey = reader[this.Fields.Count + 1].ToString();

      //         idx = 0;
      //         foreach (DataColumn column in this.Fields)
      //         {
      //            switch (column.Type)
      //            {
      //               case OleDbType.WChar:
      //                  val = !reader.IsDBNull(idx) ? reader.GetString(idx) : string.Empty;
      //                  break;

      //               case OleDbType.Boolean:
      //                  val = !reader.IsDBNull(idx) ? (reader.GetBoolean(idx) ? "Sí" : "No") : "No";
      //                  break;

      //               case OleDbType.Integer:
      //                  val = !reader.IsDBNull(idx) ? reader.GetInt32(idx).ToString() : "0";
      //                  break;

      //               case OleDbType.SmallInt:
      //                  val = !reader.IsDBNull(idx) ? reader.GetInt16(idx).ToString() : "0";
      //                  break;

      //               case OleDbType.Decimal:
      //               case OleDbType.Currency:
      //                  val = !reader.IsDBNull(idx) ? reader.GetDecimal(idx).ToString("c") : "0";
      //                  break;

      //               case OleDbType.Date:
      //                  val = !reader.IsDBNull(idx) ? (reader.GetDateTime(idx) == DateTime.MinValue ? "No especificada" : reader.GetDateTime(idx).ToString(Rwm.Otc.windows.OTCForms.FORMAT_DATE_SIMPLE)) : string.Empty;
      //                  break;
      //            }

      //            if (idx == 0) item.Text = val;
      //            else item.SubItems.Add(val);

      //            idx++;
      //            if (idx >= this.Fields.Count) break;
      //         }
      //         listView.Items.Add(item);
      //      }
      //      reader.Close();
      //   }
      //   catch (Exception e)
      //   {
      //      System.Diagnostics.Trace.TraceError("ERROR executing ModelDAO.ListByColumns(ListView, DataTable):\nMessage:\n{0}\nTrace:\n{1}\n\n", e.Message, e.StackTrace);
      //      System.Diagnostics.Trace.Flush();

      //      throw;
      //   }
      //   finally
      //   {
      //      reader.Dispose();
      //      cmd.Dispose();
      //   }
      //}

      /// <summary>
      /// Devuelve el operador de concatenación de filtros en formato texto.
      /// </summary>
      private string GetQueryOperator()
      {
         if (this.QueryOperatorType == QueryOperator.Or)
            return " OR ";

         return " AND "; ;
      }
   }
}
