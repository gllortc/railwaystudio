using System;
using System.Collections.Generic;
using System.Text;

namespace Rwm.Otc.xml.serialization
{

   /// <summary>
   /// Provides a wrapper arount enum types, in order to provide alias definition capabilities for enums
   /// </summary>
   internal class EnumWrapper
   {
      private Type m_enumType = null;
      private Dictionary<string, string> m_enumMembers = new Dictionary<string, string>();

      /// <summary>
      /// Initializes a new instance of the <see cref="EnumWrapper"/> class.
      /// </summary>
      /// <param name="t">The enum type.</param>
      public EnumWrapper(Type t)
      {
         if (!t.IsEnum)
            throw new ArithmeticException();

         m_enumType = t;

         foreach (var m in t.GetFields())
         {
            if (m.FieldType == t)
            {
               string originalName = m.Name;
               string alias = originalName;
               foreach (var attr in m.GetCustomAttributes(false))
               {
                  if (attr is OTCEnumAttribute)
                  {
                     alias = (attr as OTCEnumAttribute).Alias;
                  }
               }

               if (alias != originalName)
               {
                  if (!m_enumMembers.ContainsKey(alias))
                     m_enumMembers.Add(m.Name, alias);
                  else if (!m_enumMembers.ContainsKey(originalName))
                     m_enumMembers.Add(m.Name, originalName);
                  else
                     throw new OTCException("Enum alias already exists");
               }
            }
         }
      }

      #region Methods

      /// <summary>
      /// Parses the alias and returns the correct enum value. Throws an exception if the alias cannot be matched.
      /// </summary>
      /// <param name="alias">The alias.</param>
      /// <returns>the enum member corresponding to the specified alias</returns>
      public object ParseAlias(string alias)
      {
         string[] components = alias.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

         if (components.Length > 0)
         {
            StringBuilder sb = new StringBuilder();
            string realName = FindRealNameFromAlias(components[0]);
            sb.Append(realName);

            for (int i = 1; i < components.Length; i++)
            {
               sb.Append(", ");
               realName = FindRealNameFromAlias(components[i]);
               sb.Append(realName);
            }

            return Enum.Parse(m_enumType, sb.ToString());
         }

         throw new Exception("Invalid enum alias");
      }

      /// <summary>
      /// Gets the alias for the specified enum value.
      /// </summary>
      /// <param name="enumMember">The enum member.</param>
      /// <returns>the alias corresponding to the specified enum member</returns>
      public object GetAlias(object enumMember)
      {
         string originalName = enumMember.ToString();

         string[] components = originalName.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

         if (components.Length == 1)
         {
            string alias;
            if (m_enumMembers.TryGetValue(originalName, out alias))
               return alias;
            else
               return enumMember;
         }
         else if (components.Length > 1)
         {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < components.Length; i++)
            {
               if (i != 0)
                  result.Append(", ");

               string alias;
               if (m_enumMembers.TryGetValue(components[i], out alias))
                  result.Append(alias);
               else
                  result.Append(components[i]);
            }

            return result.ToString();
         }
         else
         {
            throw new Exception("Invalid enum member");
         }
      }

      #endregion

      #region Private members

      /// <summary>
      /// Finds the real name from alias.
      /// </summary>
      /// <param name="alias">The alias.</param>
      /// <returns>the real name of the enum member</returns>
      private string FindRealNameFromAlias(string alias)
      {
         alias = alias.Trim();
         foreach (var pair in m_enumMembers)
         {
            if (pair.Value == alias)
               return pair.Key;
         }

         return alias;
      }

      #endregion

   }
}
