using System;
using System.Drawing;

namespace Rwm.Studio.Plugins.Collection.Controls
{

   [AttributeUsage(AttributeTargets.Field, Inherited = false)]
   public class EnumItemImage : Attribute
   {

      public EnumItemImage(string image)
      {
         itemImage = image;
      }

      private string itemImage = null;

      public string Image 
      {
         get { return itemImage; } 
      }

   }
}
