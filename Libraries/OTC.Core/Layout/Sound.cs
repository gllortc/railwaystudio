using System;
using System.IO;
using Rwm.Otc.Data.ORM;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Utils;

namespace Rwm.Otc.Layout
{
   [ORMTable("sounds")]
   public class Sound : ORMEntity<Sound>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Sound"/>.
      /// </summary>
      public Sound()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Identificador único del elemento.
      /// </summary>
      [ORMProperty("projectid")]
      public Project Project { get; set; }

      /// <summary>
      /// Nombre descriptivo del bloque.
      /// </summary>
      [ORMProperty("name")]
      public string Name { get; set; }

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      [ORMProperty("filename")]
      public string Filename { get; set; }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      
      public Stream SoundStream { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Play a sound.
      /// </summary>
      public void Play()
      {
         bool played = false;
         string path = string.Empty;
         Sound tmpSound = null;

         try
         {
            path = Path.Combine(this.GetCacheFolder(), this.GetCacheFilename());
            if (!File.Exists(path))
            {
               tmpSound = Sound.Get(this.ID);
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

            throw;
         }
         finally
         {
            tmpSound = null;
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

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Filename = string.Empty;
         this.SoundStream = null;
      }

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
