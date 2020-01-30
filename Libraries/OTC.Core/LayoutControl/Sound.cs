using Rwm.Otc.Utils;
using System.IO;
namespace Rwm.Otc.LayoutControl
{
   public class Sound
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
      /// Identificador único del elemento.
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Nombre descriptivo del bloque.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets the icon of the type of the bloc.
      /// </summary>
      public string Filename { get; set; }

      /// <summary>
      /// Gets the group of the type of the bloc.
      /// </summary>
      public Stream SoundStream { get; set; }

      #endregion

      #region Methods

      public string GetCacheFilename(Project project)
      {
         return IOUtils.GetFilenameFromString(string.Format("{0}_{1}_{2}",
                                                            project.Name,
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

      #endregion

   }
}
