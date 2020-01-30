using System.Data.OleDb;

namespace Rwm.Studio.Plugins.Collection.Data
{
   public class DataFilter
   {
      public enum FilterComparator
      {
         Equal,
         BiggerThan,
         SmallerThan,
         Like
      }

      /// <summary>
      /// Devuelve una instancia de <see cref="DataFilter"/>.
      /// </summary>
      public DataFilter() 
      {
         Name = string.Empty;
         Type = OleDbType.Integer;
         Value = string.Empty;
         ComparationType = DataFilter.FilterComparator.Equal;
      }

      /// <summary>
      /// Devuelve una instancia de <see cref="DataFilter"/>.
      /// </summary>
      public DataFilter(string name, OleDbType type, string value)
      {
         Name = name;
         Type = type;
         Value = value;
         ComparationType = FilterComparator.Equal;
      }

      /// <summary>
      /// Devuelve una instancia de <see cref="DataFilter"/>.
      /// </summary>
      public DataFilter(string name, OleDbType type, string value, FilterComparator comparationType) 
      {
         Name = name;
         Type = type;
         Value = value;
         ComparationType = comparationType;
      }

      /// <summary>
      /// Gets or sets el nombre de la columna que se aplicará en el filtro.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets el tipo de datos del campo de filtrado.
      /// </summary>
      public OleDbType Type { get; set; }

      /// <summary>
      /// Gets or sets el tipo de comparador entre campo y valor.
      /// </summary>
      public FilterComparator ComparationType { get; set; }

      /// <summary>
      /// Gets or sets el filtro a aplicar a ese campo.
      /// </summary>
      public string Value { get; set; }

      /// <summary>
      /// Indica si un filtro para cadenas de texto debe ser tratado como un filtro LIKE.
      /// <seealso cref="http://msdn.microsoft.com/es-es/library/ms179859.aspx"/>
      /// </summary>
      // public bool IsLikeFilter { get; set; }

      public string GetSqlFilter()
      {
         string op = string.Empty;
         string filter = " (" + this.Name;

         switch (ComparationType)
         {
            case FilterComparator.BiggerThan:   filter += " > ";    break;
            case FilterComparator.SmallerThan:  filter += " < ";    break;
            case FilterComparator.Like:         filter += " Like "; break;
            default:                            filter += " = ";    break;
         }

         if (Type == OleDbType.WChar)
         {
            if (ComparationType == FilterComparator.Like)
               filter += "'%" + this.Value + "%'";
            else
               filter += "'" + this.Value + "'";
         }
         else
         {
            filter += this.Value;
         }

         return filter + ") ";
      }
   }
}
