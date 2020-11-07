using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rwm.Studio.Plugins.Collection.Model
{
   class Folder
   {

      public Folder(string name) 
      {
         this.Name = name;
      }

      public Folder(string name, bool canManageFolders, bool canManageObjects, object obj)
      {
         this.Name = name;
         this.CanManageFolders = canManageFolders;
         this.CanManageObjects = canManageObjects;
         this.Object = obj;
      }

      public string Name { get; set; }

      public List<Folder> Folders { get; set; } = new List<Folder>();

      public bool CanManageFolders { get; set; } = false;

      public bool CanManageObjects { get; set; } = false;

      public object Object { get; set; } = null;

      public Folder AddFolder(string name)
      {
         return this.AddFolder(name, false, false, null);
      }

      public Folder AddFolder(string name, object obj)
      {
         return this.AddFolder(name, false, false, obj);
      }

      public Folder AddFolder(string name, bool canManageFolders)
      {
         Folder folder = new Folder(name, canManageFolders, false, null);
         this.Folders.Add(folder);
         return folder;
      }

      public Folder AddFolder(string name, bool canManageFolders, bool canManageObjects, object obj)
      {
         Folder folder = new Folder(name, canManageFolders, canManageObjects, obj);
         this.Folders.Add(folder);
         return folder;
      }

   }
}
