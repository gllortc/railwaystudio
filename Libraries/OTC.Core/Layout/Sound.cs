using System;
using System.IO;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Utils;

namespace Rwm.Otc.Layout
{
   [ORMTable("SOUNDS")]
   public class Sound : ORMEntity<Sound>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Sound"/>.
      /// </summary>
      public Sound() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Identificador único del elemento.
      /// </summary>
      [ORMProperty("PROJECTID")]
      public Project Project { get; set; } = null;

      /// <summary>
      /// Nombre descriptivo del bloque.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      [ORMProperty("FILENAME")]
      public string Filename { get; set; } = string.Empty;

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      // [ORMProperty("FILEDATA")]
      public Stream SoundStream { get; set; } = null;

      #endregion

      #region Methods

      /// <summary>
      /// Play a sound.
      /// </summary>
      public void Play()
      {
         bool played = false;

         try
         {
            string path = Path.Combine(this.GetCacheFolder(), this.GetCacheFilename());
            if (!File.Exists(path))
            {
               Sound tmpSound = Sound.Get(this.ID);
               tmpSound.SoundStream.Seek(0, SeekOrigin.Begin);

               using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
               {
                  tmpSound.SoundStream.CopyTo(fs);
                  fs.Flush();
               }
            }

            if (File.Exists(path))
            {
               played = true;

               System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
               player.Play();
            }

            if (!played)
            {
               System.Media.SystemSounds.Beep.Play();
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      public string GetCacheFilename()
      {
         return IOUtils.GetFilenameFromString(string.Format("{0}_{1}_{2}",
                                                            OTCContext.Project.Name,
                                                            this.ID,
                                                            this.Filename));
      }

      public override string ToString()
      {
         return string.Format("{0} ({1})", this.Name, this.Filename);
      }

      #endregion

      #region Private Members

      private string GetCacheFolder()
      {
         string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
         if (Environment.OSVersion.Version.Major >= 6)
         {
            path = Directory.GetParent(path).ToString();
         }

         path = Path.Combine(path, "Railwaymania", "RailwayStudio", "SoundCache");

         if (!Directory.Exists(path))
         {
            Directory.CreateDirectory(path);
         }

         return path;
      }

      #endregion

   }
}
