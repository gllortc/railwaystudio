using System.Data.OleDb;
using System.Windows.Forms;

namespace Rwm.Otc.Data
{
   public class DataColumn
   {
      /// <summary>
      /// Devuelve una instancia de <see cref="DataColumn"/>.
      /// </summary>
      public DataColumn() 
      {
         Name = string.Empty;
         Title = string.Empty;
         Type = OleDbType.Integer;
         Description = string.Empty;
         GroupKey = string.Empty;
         Width = 0;
         Alignment = HorizontalAlignment.Left;
      }

      /// <summary>
      /// Devuelve una instancia de <see cref="DataColumn"/>.
      /// </summary>
      public DataColumn(string name, string title, OleDbType type)
      {
         Name = name;
         Title = title;
         Type = type;
         Description = string.Empty;
         GroupKey = string.Empty;
         Width = 0;
         Alignment = HorizontalAlignment.Left;
      }

      /// <summary>
      /// Devuelve una instancia de <see cref="DataColumn"/>.
      /// </summary>
      public DataColumn(string name, string title, OleDbType type, string groupKey)
      {
         Name = name;
         Title = title;
         Type = type;
         Description = string.Empty;
         GroupKey = groupKey;
         Width = 0;
         Alignment = HorizontalAlignment.Left;
      }

      /// <summary>
      /// Devuelve una instancia de <see cref="DataColumn"/>.
      /// </summary>
      public DataColumn(string name, string title, OleDbType type, string groupKey, int width)
      {
         Name = name;
         Title = title;
         Type = type;
         Description = string.Empty;
         GroupKey = groupKey;
         Width = width;
         Alignment = HorizontalAlignment.Left;
      }

      /// <summary>
      /// Devuelve una instancia de <see cref="DataColumn"/>.
      /// </summary>
      public DataColumn(string name, string title, OleDbType type, string groupKey, int width, HorizontalAlignment alignment)
      {
         Name = name;
         Title = title;
         Type = type;
         Description = string.Empty;
         GroupKey = groupKey;
         Width = width;
         Alignment = alignment;
      }

      /// <summary>
      /// Devuelve una instancia de <see cref="DataColumn"/>.
      /// </summary>
      public DataColumn(string name, string title, OleDbType type, string groupKey, string description) 
      {
         Name = name;
         Title = title;
         Type = type;
         Description = description;
         GroupKey = groupKey;
         Width = 0;
         Alignment = HorizontalAlignment.Left;
      }

      #region Properties

      /// <summary>
      /// Gets or sets el nombre de la columna.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets el nombre visible de la columna.
      /// </summary>
      public string Title { get; set; }

      /// <summary>
      /// Gets or sets la descripción de la columna.
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets el tipo de datos del campo.
      /// </summary>
      public OleDbType Type { get; set; }

      /// <summary>
      /// Gets or sets la clave del grupo de campos al que pertenece.
      /// </summary>
      public string GroupKey { get; set; }

      /// <summary>
      /// Gets or sets el ancho en píxels de la columna.
      /// </summary>
      public int Width { get; set; }

      /// <summary>
      /// Gets or sets la alineación en el contenido.
      /// </summary>
      public HorizontalAlignment Alignment { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Devuelve un filtro correspondiente a una determinada columna.
      /// </summary>
      public DataFilter GetFiltrFromColumn(string value)
      {
         DataFilter filter = new DataFilter();
         filter.Name = this.Name;
         filter.Type = this.Type;
         filter.Value = value;

         return filter;
      }

      /// <summary>
      /// Devuelve un filtro correspondiente a una determinada columna.
      /// </summary>
      static public DataFilter GetFiltrFromColumn(DataColumn column, string value)
      {
         DataFilter filter = new DataFilter();
         filter.Name = column.Name;
         filter.Type = column.Type;
         filter.Value = value;

         return filter;
      }

      #endregion

   }
}
