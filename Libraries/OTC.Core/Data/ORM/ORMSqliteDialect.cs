using System;
using Rwm.Otc.Diagnostics;

namespace Rwm.Otc.Data.ORM
{
   /// <summary>
   /// ORM database dialect for the SQLite database engine.
   /// </summary>
   internal class ORMSqliteDialect<T>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ORMSqliteDialect"/>.
      /// </summary>
      public ORMSqliteDialect()
      {
         this.IsInitialized = false;
      }

      #endregion

      #region Properties

      private bool IsInitialized { get; set; } = false;

      private ORMSqlCommand NewIDCommand { get; set; }

      private ORMSqlCommand SelectCommand { get; set; }

      private ORMSqlCommand UpdateCommand { get; set; }

      private ORMSqlCommand InsertCommand { get; set; }

      private ORMSqlCommand DeleteCommand { get; set; }

      private ORMSqlCommand SelectAllCommand { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Generate a SQL command to obtain the newest unique identifier for generic type.
      /// </summary>
      /// <returns>The requested SQL command.</returns>
      public ORMSqlCommand GetNewIDCommand()
      {
         try
         {
            if (this.NewIDCommand != null)
               return this.NewIDCommand;
            else
               this.NewIDCommand = new ORMSqlCommand();

            // Generate SELECT clause
            this.NewIDCommand.SqlCommand += "select ";
            this.NewIDCommand.SqlCommand += "max(" + ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName + ")";

            // Generate FROM clause
            this.NewIDCommand.SqlCommand += " from ";
            this.NewIDCommand.SqlCommand += ORMEntity<T>.ORMStructure.Table.TableName;

            this.NewIDCommand.SqlCommand = this.NewIDCommand.SqlCommand.Trim();

            return this.NewIDCommand;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      /// <summary>
      /// Generate a SQL command to get the specified instance of generic type.
      /// </summary>
      /// <returns>The requested SQL command.</returns>
      public ORMSqlCommand GetSelectCommand()
      {
         try
         {
            if (this.SelectCommand != null)
               return this.SelectCommand;
            else
               this.SelectCommand = new ORMSqlCommand();

            // Generate SELECT clause
            this.SelectCommand.SqlCommand = " select ";

            this.SelectCommand.SqlCommand += ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName;
            foreach (ORMEntityMember member in ORMEntity<T>.ORMStructure.Fields)
            {
               this.SelectCommand.SqlCommand += ", [" + member.Attribute.FieldName + "]";
            }

            // Generate FROM clause
            this.SelectCommand.SqlCommand += " from ";
            this.SelectCommand.SqlCommand += ORMEntity<T>.ORMStructure.Table.TableName;

            // Generate WHERE clause
            this.SelectCommand.SqlCommand += " where ";
            this.SelectCommand.SqlCommand += ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName + "=@" + ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName;
            this.SelectCommand.PrimaryKeyName = ORMEntity<T>.ORMStructure.PrimaryKey;

            return this.SelectCommand;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      public ORMSqlCommand GetInsertCommand()
      {
         bool first;

         try
         {
            if (this.InsertCommand != null)
               return this.InsertCommand;
            else
               this.InsertCommand = new ORMSqlCommand();

            // Generate INSERT INTO clause
            this.InsertCommand.SqlCommand += " insert into ";
            this.InsertCommand.SqlCommand += ORMEntity<T>.ORMStructure.Table.TableName;

            // Generate fields list
            first = true;
            this.InsertCommand.SqlCommand += " (";
            foreach (ORMEntityMember member in ORMEntity<T>.ORMStructure.Fields)
            {
               if (!member.IsForeignCollection)
               {
                  this.InsertCommand.SqlCommand += (!first ? ", " : String.Empty) + "[" + member.Attribute.FieldName + "]";
                  this.InsertCommand.Parameters.Add(member);
                  first = false;
               }
            }
            this.InsertCommand.SqlCommand += ") ";

            // Generate VALUES clause
            this.InsertCommand.SqlCommand += " values ";

            first = true;
            this.InsertCommand.SqlCommand += " (";
            foreach (ORMEntityMember member in ORMEntity<T>.ORMStructure)
            {
               if (!member.IsForeignCollection)
               {
                  this.InsertCommand.SqlCommand += (!first ? ", " : String.Empty) + "@" + member.Attribute.FieldName;
                  first = false;
               }
            }
            this.InsertCommand.SqlCommand += ") ";

            return this.InsertCommand;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      public ORMSqlCommand GetUpdateCommand()
      {
         bool first;

         try
         {
            if (this.UpdateCommand != null)
               return this.UpdateCommand;
            else
               this.UpdateCommand = new ORMSqlCommand();

            // Generate INSERT INTO clause
            this.UpdateCommand.SqlCommand += " update ";
            this.UpdateCommand.SqlCommand += ORMEntity<T>.ORMStructure.Table.TableName;

            // Generate SET clause
            first = true;
            this.UpdateCommand.SqlCommand += " set ";
            foreach (ORMEntityMember member in ORMEntity<T>.ORMStructure.Fields)
            {
               this.UpdateCommand.SqlCommand += (!first ? ", " : String.Empty) + "[" + member.Attribute.FieldName + "]" + "=@" + member.Attribute.FieldName;
               this.UpdateCommand.Parameters.Add(member);
               first = false;
            }

            // Generate WHERE clause
            this.UpdateCommand.SqlCommand += " where ";
            this.UpdateCommand.SqlCommand += ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName + "=@" + ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName;
            this.UpdateCommand.PrimaryKeyName = ORMEntity<T>.ORMStructure.PrimaryKey;

            return this.UpdateCommand;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      public ORMSqlCommand GetDeleteCommand()
      {
         try
         {
            if (this.DeleteCommand != null)
               return this.DeleteCommand;
            else
               this.DeleteCommand = new ORMSqlCommand();

            // Generate DELETE clause
            this.DeleteCommand.SqlCommand += " delete ";

            // Generate FROM clause
            this.DeleteCommand.SqlCommand += " from ";
            this.DeleteCommand.SqlCommand += ORMEntity<T>.ORMStructure.Table.TableName;

            // Generate WHERE clause
            this.DeleteCommand.SqlCommand += " where ";
            this.DeleteCommand.SqlCommand += ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName + "=@" + ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName;
            this.DeleteCommand.PrimaryKeyName = ORMEntity<T>.ORMStructure.PrimaryKey;

            return this.DeleteCommand;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      public ORMSqlCommand GetSelectAllCommand()
      {
         try
         {
            if (this.SelectAllCommand != null)
               return this.SelectAllCommand;
            else
               this.SelectAllCommand = new ORMSqlCommand();

            // Generate DELETE clause
            this.SelectAllCommand.SqlCommand += " select ";
            this.SelectAllCommand.SqlCommand += ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName;
            this.SelectAllCommand.SqlCommand += " as ID ";

            // Generate FROM clause
            this.SelectAllCommand.SqlCommand += " from ";
            this.SelectAllCommand.SqlCommand += ORMEntity<T>.ORMStructure.Table.TableName;

            return this.SelectAllCommand;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      public ORMSqlCommand GetSelectByFieldCommand(string propertyName)
      {
         try
         {
            ORMSqlCommand cmd = new ORMSqlCommand();
            ORMEntityMember member = ORMEntity<T>.ORMStructure.GetByPropertyName(propertyName);

            // Generate SELECT clause
            cmd.SqlCommand += " select ";
            cmd.SqlCommand += ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName;
            cmd.SqlCommand += " as ID ";

            // Generate FROM clause
            cmd.SqlCommand += " from ";
            cmd.SqlCommand += ORMEntity<T>.ORMStructure.Table.TableName;

            // Generate WHERE clause
            cmd.SqlCommand += " where ";
            cmd.SqlCommand += member.Attribute.FieldName + "=@" + member.Attribute.FieldName;
            cmd.Parameters.Add(member);

            return cmd;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      public ORMSqlCommand GetSelectByQuery(string whereClause)
      {
         try
         {
            ORMSqlCommand cmd = new ORMSqlCommand();

            // Generate SELECT clause
            cmd.SqlCommand += " select ";
            cmd.SqlCommand += ORMEntity<T>.ORMStructure.PrimaryKey.Attribute.FieldName;
            cmd.SqlCommand += " as ID ";

            // Generate FROM clause
            cmd.SqlCommand += " from ";
            cmd.SqlCommand += ORMEntity<T>.ORMStructure.Table.TableName;

            // Generate WHERE clause
            whereClause = whereClause.Trim();
            if (!whereClause.StartsWith("WHERE", StringComparison.InvariantCultureIgnoreCase)) whereClause = "WHERE " + whereClause;
            cmd.SqlCommand += whereClause;

            return cmd;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      #endregion

   }
}
