﻿using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Svg;
using Svg.Transforms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Xml;

namespace Rwm.Otc.Themes
{
   /// <summary>
   /// Theme SpDrS60 for the OTC model railway control system.
   /// </summary>
   /// <remarks>
   /// SVG file name convention:
   /// B[block_type_number]_[acc_status]_[fb_status]_[route_active].svg
   /// </remarks>
   public class Theme : ITheme
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="Theme"/>.
      /// </summary>
      public Theme()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the theme unique identifier (GUID).
      /// </summary>
      public string ID
      {
         get { return "2449F2E8-60FC-47C0-A66B-96F5EA4DF0FA"; }
      }

      /// <summary>
      /// Gets the name of the theme.
      /// </summary>
      public string Name
      {
         get { return "Siemens SpDrS60 SVG"; }
      }

      /// <summary>
      /// Gets a brief description of the theme.
      /// </summary>
      public string Description 
      {
         get { return "Siemens SpDrS60 OTC theme"; }
      }

      /// <summary>
      /// Gets the element width (in pixels).
      /// </summary>
      public Size ElementSize
      {
         get { return new Size(32, 32); }
      }

      /// <summary>
      /// Cache for the element images.
      /// </summary>
      /// <remarks>
      /// The key for each image is as follows:
      /// [IMAGE_KEY]_[ROTATION_ENUM_VALUE]
      /// </remarks>
      private Dictionary<string, Image> ImageCache { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Gets the element image in function of his status.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <returns>An image representing the element and all his properties.</returns>
      public Image GetElementImage(Element block)
      {
         return this.GetElementImage(block, false);
      }

      /// <summary>
      /// Gets the element image in function of his status.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <param name="designImage">A value indicating if the image must be represented in design mode or working mode.</param>
      /// <returns>An image representing the element and all his properties.</returns>
      public Image GetElementImage(Element element, bool designImage)
      {
         string xmlSource = string.Empty;
         string imgKey = null;
         string cacheKey = null;
         Image image = null;

         try
         {
            imgKey = this.GetResourceName(element, designImage);
            cacheKey = string.Format("{0}_{1}",
                                     imgKey,
                                     (int)element.Rotation);

            if (this.ImageCache.ContainsKey(cacheKey))
            {
               image = this.ImageCache[cacheKey];
            }
            else
            {
               ResourceManager rm = new ResourceManager("Rwm.Otc.Themes.Properties.Resources",
                                                        Assembly.GetExecutingAssembly());
               xmlSource = rm.GetString(imgKey);
               if (xmlSource == null)
               {
                  Logger.LogWarning(this, "THEME WARNING: {0} key not supported in current theme {1}", imgKey, this.Name);
                  return Properties.Resources.ICO_IMAGE_ERROR_32;
               }

               xmlSource = xmlSource.Replace("#NAME", element.Name);

               XmlDocument xml = new XmlDocument();
               xml.LoadXml(xmlSource);

               SvgDocument svg = SvgDocument.Open(xml);

               if ((int)element.Rotation > 0)
               {
                  SvgRotate rotation = new SvgRotate((int)element.Rotation * 90.0f,
                                                     (float)svg.Height / 2.0f,
                                                     (float)svg.Width / 2.0f);
                  svg.Transforms.Add(rotation);
               }

               image = (Image)svg.Draw();

               if (!this.ImageCache.ContainsKey(cacheKey)) 
                  this.ImageCache.Add(cacheKey, image);
               else 
                  this.ImageCache[cacheKey] = image;
            }

            // Print the train name into the block
            if (!designImage && element.Properties.IsBlock && element.IsBlockOccupied)
            {
               Image imageClone = (Image)image.Clone();

               using (Graphics g = Graphics.FromImage(imageClone))
               using (Font font = new Font("Calibri", 10, FontStyle.Bold))
               {
                  g.DrawString(element.Train.Name, font, Brushes.Black, 3, 3);
               }

               return imageClone;
            }

            return image;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            return Properties.Resources.ICO_IMAGE_ERROR_32;
         }
      }

      /// <summary>
      /// Gets the element image in function of his status.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <param name="status">A value indicating if the image must be represented in design mode or working mode.</param>
      /// <returns>An image representing the element and all his properties.</returns>
      public Image GetElementImage(Element element, int status)
      {
         string imgKey = null;
         string cacheKey = null;
         Image image = null;

         try
         {
            imgKey = this.GetResourceName(element, status);
            cacheKey = string.Format("{0}_{1}",
                                     imgKey,
                                     (int)element.Rotation);

            if (this.ImageCache.ContainsKey(cacheKey))
            {
               image = this.ImageCache[cacheKey];
            }
            else
            {
               ResourceManager rm = new ResourceManager("Rwm.Otc.Themes.Properties.Resources",
                                                        Assembly.GetExecutingAssembly());

               XmlDocument xml = new XmlDocument();
               xml.LoadXml(rm.GetString(imgKey));

               SvgDocument svg = SvgDocument.Open(xml);

               if ((int)element.Rotation > 0)
               {
                  SvgRotate rotation = new SvgRotate((int)element.Rotation * 90.0f,
                                                     (float)svg.Height / 2.0f,
                                                     (float)svg.Width / 2.0f);
                  svg.Transforms.Add(rotation);
               }

               image = (Image)svg.Draw();

               this.ImageCache.Add(cacheKey, image);
            }

            // Print the train name into the block
            if (element.Properties.IsBlock && element.IsBlockOccupied)
            {
               Image imageClone = (Image)image.Clone();

               using (Graphics g = Graphics.FromImage(imageClone))
               using (Font font = new Font("Calibri", 10))
               {
                  g.DrawString(element.Train.Name, font, Brushes.Black, 3, 3);
               }

               return imageClone;
            }

            return image;
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);

            return Properties.Resources.ICO_IMAGE_ERROR_32;
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ImageCache = new Dictionary<string, Image>();
      }

      /// <summary>
      /// Create the resource name to get from library resources
      /// </summary>
      /// <remarks>
      /// SVG image name convention:
      /// 
      /// B[block_type_number]_[acc_status]_[fb_status]_[route_active].svg
      /// 
      /// </remarks>
      private string GetResourceName(Element block, bool designMode)
      {
         if (designMode)
         {
            return string.Format("B{0}_{1}_{2}_{3}",
                                 ((int)block.Properties.ID).ToString("00"),        // Main element type
                                 Element.STATUS_UNDEFINED.ToString("00"),     // Accessory status
                                 Element.STATUS_UNDEFINED.ToString("00"),     // Feedback status
                                 (block.IsActivatedInRoute ? "1" : "0"));           // Activated in route
         }
         else
         {
            return string.Format("B{0}_{1}_{2}_{3}",
                                 ((int)block.Properties.ID).ToString("00"),        // Main element type
                                 block.AccessoryStatus.ToString("00"),            // Accessory status
                                 (block.FeedbackStatus ? 1 : 0).ToString("00"),   // Accessory status
                                 (block.IsActivatedInRoute ? "1" : "0"));           // Activated in route
         }
      }

      /// <summary>
      /// Create the resource name to get from library resources
      /// </summary>
      private string GetResourceName(Element block, int status)
      {
         return string.Format("B{0}_{1}_{2}_{3}",
                              ((int)block.Properties.ID).ToString("00"),    // Main element type
                              status.ToString("00"),                       // Accessory status
                              "00",                                        // Feedback status
                              "0");                                        // Activated in route
      }

      #endregion

   }
}