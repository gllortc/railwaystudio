﻿using System;
using System.IO;
using Rwm.Otc.Data;

namespace Rwm.Otc.Trains
{
   [ORMTable("TRAIN_DECODERS")]
   public class TrainDecoder : ORMEntity<TrainDecoder>
   {

      #region Constructors

      /// <summary>
      /// Devuelve una instancia de RCDecoder.
      /// </summary>
      public TrainDecoder() 
      {
         this.ID = 0;
         this.Name = string.Empty;
         this.Description = string.Empty;
         this.File = null;
         this.URL = string.Empty;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets the owner project.
      /// </summary>
      [ORMProperty("projectid")]
      public Project Project { get; set; }

      /// <summary>
      /// Gets or sets the decoder manufacturer.
      /// </summary>
      [ORMProperty("manufacturerid")]
      public Manufacturer Manufacturer { get; set; }

      /// <summary>
      /// Gets or sets the decoder name/model.
      /// </summary>
      [ORMProperty("name")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the decoder description/notes.
      /// </summary>
      [ORMProperty("description")]
      public string Description { get; set; }

      [Obsolete]
      [ORMProperty("file")]
      public MemoryStream File { get; set; }

      /// <summary>
      /// Gets or sets an URL containig the decoder owner's manual.
      /// </summary>
      [ORMProperty("web")]
      public string URL { get; set; }

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_DECODER_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_DECODER_32; }
      }

      public string DisplayName
      {
         get
         {
            if (string.IsNullOrWhiteSpace(this.Name) && this.Manufacturer == null)
               return "NS";
            else if (string.IsNullOrWhiteSpace(this.Name))
               return this.Manufacturer.Name;
            else if (this.Manufacturer == null)
               return this.Name;
            else
               return (this.Manufacturer.Name + " " + this.Name).Trim();
         }
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Nombre de la carpeta que contiene los manuales
      /// </summary>
      public static string FilesFolderName
      {
         get { return "manuals"; }
      }

      /// <summary>
      /// Devuelve la ruta de acceso a la carpeta de documentación de descodificadores.
      /// </summary>
      public static string FilesPath
      {
         get { return Path.Combine(System.Windows.Forms.Application.StartupPath, TrainDecoder.FilesFolderName); }
      }

      #endregion

   }
}
