using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Rwm.Otc.Data.ORM
{
   public class ORMEntityStructure : IEnumerable<ORMEntityMember>
   {

      #region Constructor

      /// <summary>
      /// Return a new instance of <see cref="ORMEntityStructure"/> filled with all ORM information related to type <c>T</c>.
      /// </summary>
      public ORMEntityStructure(Type ownerType)
      {
         ORMEntityMember member;

         // Initializations
         this.OwnerType = ownerType;
         this.All = new List<ORMEntityMember>();
         this.Fields = new List<ORMEntityMember>();
         this.ForeignCollections = new List<ORMEntityMember>();

         // Get table attribute
         ORMTable[] tables = (ORMTable[])this.OwnerType.GetCustomAttributes(typeof(ORMTable), false);
         if (tables.Length > 0)
         {
            this.Table = (ORMTable)tables[0];
         }

         // Read fields and PKs
         foreach (PropertyInfo pi in this.OwnerType.GetProperties())
         {
            member = ORMEntityMember.CreateInstance(pi);
            if (member != null) 
            {
               if (member.IsPrimaryKey)
               {
                  this.PrimaryKey = member;
               }
               else if (member.IsForeignCollection)
               {
                  this.ForeignCollections.Add(member);
                  this.All.Add(member);
               }
               else
               {
                  this.Fields.Add(member);
                  this.All.Add(member);
               }
            }
         }
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the type of the owner class.
      /// </summary>
      public Type OwnerType { get; private set; } = null;

      /// <summary>
      /// Gets the ORM table attribute.
      /// </summary>
      public ORMTable Table { get; private set; }

      /// <summary>
      /// Gets the ORM primary key attribute.
      /// </summary>
      /// <remarks>
      /// Current verion only supports one long primary key. 
      /// Composite key are not supported yet.
      /// </remarks>
      public ORMEntityMember PrimaryKey { get; private set; }

      /// <summary>
      /// Gets a list of simple fields.
      /// </summary>
      public List<ORMEntityMember> Fields { get; private set; }

      /// <summary>
      /// Gets a list of foreign collections.
      /// </summary>
      public List<ORMEntityMember> ForeignCollections { get; private set; }

      /// <summary>
      /// Gets a list of all fields (excluding primary key).
      /// </summary>
      private List<ORMEntityMember> All { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Get the ORM attribute associated to the specified class property.
      /// </summary>
      /// <param name="propertyName">Property name.</param>
      /// <returns>The requested attribute or <c>null</c> if any property have the specified name.</returns>
      public ORMEntityMember GetByPropertyName(string propertyName)
      {
         if (this.PrimaryKey.Property.Name.Equals(propertyName, System.StringComparison.OrdinalIgnoreCase))
            return this.PrimaryKey;

         foreach (ORMEntityMember member in this)
         {
            if (member.Property.Name.Equals(propertyName, System.StringComparison.OrdinalIgnoreCase))
               return member;
         }

         return null;
      }

      /// <summary>
      /// Get the ORM attribute associated to the specified class property.
      /// </summary>
      /// <param name="propertyName">Property name.</param>
      /// <returns>The requested attribute or <c>null</c> if any property have the specified name.</returns>
      public ORMEntityMember GetByForeignKeyType(Type foreignKeyType)
      {
         if (this.PrimaryKey.Property.PropertyType.Equals(foreignKeyType))
            return this.PrimaryKey;

         foreach (ORMEntityMember member in this)
         {
            if (member.Property.PropertyType.Equals(foreignKeyType))
               return member;
         }

         return null;
      }

      /// <summary>
      /// Get the primary key value of the specified ORM instance.
      /// </summary>
      /// <param name="instance">ORM instance.</param>
      /// <returns>The requested unique identifier.</returns>
      public long GetPrimaryKeyValue(object instance)
      {
         return (long)this.PrimaryKey.GetValue(instance);
      }

      public IEnumerator<ORMEntityMember> GetEnumerator()
      {
         return this.All.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return (IEnumerator)this;
      }

      public override string ToString()
      {
         return this.Table.TableName;
      }

      #endregion

   }
}
