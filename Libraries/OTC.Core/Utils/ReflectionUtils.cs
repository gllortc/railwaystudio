using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Rwm.Otc.Utils
{
   public class ReflectionUtils
   {

      /// <summary>
      /// Devuelve el texto asociado al atributo DescriptionAttribute para un elemento de enumeración.
      /// </summary>
      /// <param name="value">Elemento de enumeración para el que se desea obtener la descripción.</param>
      public static string GetDescription(Enum value)
      {
         FieldInfo fi = value.GetType().GetField(value.ToString());
         DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
         return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
      }

      public static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
      {
         if (generic == toCheck)
         {
            return false;
         }

         while (toCheck != null && toCheck != typeof(object))
         {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
               return true;
            }

            toCheck = toCheck.BaseType;
         }

         return false;
      }

      public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
      {
         List<T> objects = new List<T>();
         foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes())
         {
            if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(T)))
            {
               objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }
         }
         objects.Sort();
         return objects;
      }

      public static string GetCurrentAssemblyPath()
      {
         string codeBase = Assembly.GetExecutingAssembly().CodeBase;
         UriBuilder uri = new UriBuilder(codeBase);
         return System.IO.Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));
      }

      public static string GetAssemblyPath(Type type)
      {
         string codeBase = type.Assembly.CodeBase;
         UriBuilder uri = new UriBuilder(codeBase);
         return System.IO.Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));
      }

      public static string GetAssemblyFile(Type type)
      {
         string codeBase = type.Assembly.CodeBase;
         UriBuilder uri = new UriBuilder(codeBase);
         return Uri.UnescapeDataString(uri.Path);
      }

   }
}
