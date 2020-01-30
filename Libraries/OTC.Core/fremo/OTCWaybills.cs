using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace otc.fremo
{

   /// <summary>
   /// Implementa una clase para la gestión de contratos de carga.
   /// </summary>
   public class OTCWaybills
   {
      /// <summary>Extensión de los archivos que cointienen contratos de carga.</summary>
      public static string WAYBILL_FILE_EXTENSION = "otw";

      /// <summary>Filtro de archivos los que cointienen contratos de carga.</summary>
      public static string WAYBILL_FILE_FILTER = "Archivos de contratos de carga|*.otw";

      /// <summary>
      /// Devuelve una instancia de OTCWaybills.
      /// </summary>
      public OTCWaybills() { }

      #region Methods

      /// <summary>
      /// Guarda un array de contratos de carga FREMO a un archivo XML.
      /// </summary>
      /// <param name="filename">Nombre del archivo.</param>
      /// <param name="bills">Array de contratos a guardar en el archivo.</param>
      public static void Save(string filename, OTCWaybill[] bills)
      {
         try
         {
            // Abre el documento
            XmlTextWriter writer = new XmlTextWriter(filename, Encoding.UTF8);
            writer.WriteStartDocument();

            // Abre una cláusula OTC-PANEL
            writer.WriteStartElement("otc-waybills");
            writer.WriteAttributeString("version", "1.0");
            writer.WriteAttributeString("generator", OTCApplication.ProductName);

            // Bloques
            writer.WriteStartElement("waybills");
            foreach (OTCWaybill bill in bills)
            {
               writer.WriteStartElement("waybill");
               writer.WriteAttributeString("id", bill.ID);
               writer.WriteAttributeString("load", bill.Load);
               writer.WriteAttributeString("notes", bill.Notes);

               writer.WriteStartElement("from");
               writer.WriteAttributeString("station", bill.From);
               writer.WriteAttributeString("route", bill.FromRoute);
               writer.WriteAttributeString("color", bill.FromColor.R + "," + bill.FromColor.G + "," + bill.FromColor.B);
               writer.WriteEndElement();

               writer.WriteStartElement("to");
               writer.WriteAttributeString("station", bill.To);
               writer.WriteAttributeString("route", bill.ToRoute);
               writer.WriteAttributeString("color", bill.ToColor.R + "," + bill.ToColor.G + "," + bill.ToColor.B);
               writer.WriteEndElement();

               writer.WriteEndElement();
            }
            writer.WriteEndElement();

            // Cierra OTC-WAYBILLS
            writer.WriteEndElement();

            // Cierra el documento
            writer.WriteEndDocument();
            writer.Close();
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      /// <summary>
      /// Carga los contratos de carga guardados en un archivo XML en un array.
      /// </summary>
      /// <param name="filename">Nombre del archivo XML.</param>
      /// <returns>Devuelve un array de instancias OTCWaybill.</returns>
      public static List<OTCWaybill> Load(string filename)
      {
         // Inicializaciones
         string[] rgb;
         List<OTCWaybill> bills = new List<OTCWaybill>();

         // Asegura que no exista el archivo
         FileInfo file = new FileInfo(filename);
         if (!file.Exists) throw new FileNotFoundException("No se encuentra el archivo " + filename);

         try
         {
            // Carga el archivo XML
            XmlTextReader reader = new XmlTextReader(filename);
            reader.WhitespaceHandling = WhitespaceHandling.None;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            reader.Close();

            // Recupera el nodo raíz
            XmlNode xnod = xmlDoc.DocumentElement;
            if (!xnod.Name.ToLower().Equals("otc-waybills"))
               throw new Exception("El archivo XML proporcionado no corresponde a una definición de contratos de carga según el estándar OTC (compatible con FREMO).");

            // Recupera los contratos
            foreach (XmlNode node in xnod.ChildNodes)
            {
               switch (node.Name.ToLower())
               {
                  case "waybills":

                     foreach (XmlNode xbill in node.ChildNodes)
                     {
                        if (xbill.Name.ToLower().Equals("waybill"))
                        {
                           // Recupera la información del bloque
                           OTCWaybill bill = new OTCWaybill();
                           bill.ID = xbill.Attributes["id"].Value.ToString();
                           bill.Load = xbill.Attributes["load"].Value.ToString();
                           bill.Notes = xbill.Attributes["notes"].Value.ToString();

                           foreach (XmlNode xdest in xbill.ChildNodes)
                           {
                              switch (xdest.Name.ToLower())
                              {
                                 case "from":
                                    bill.From = xdest.Attributes["station"].Value.ToString();
                                    bill.FromRoute = xdest.Attributes["route"].Value.ToString();
                                    rgb = xdest.Attributes["color"].Value.ToString().Split(',');
                                    bill.FromColor = Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
                                    break;
                                 case "to":
                                    bill.To = xdest.Attributes["station"].Value.ToString();
                                    bill.ToRoute = xdest.Attributes["route"].Value.ToString();
                                    rgb = xdest.Attributes["color"].Value.ToString().Split(',');
                                    bill.ToColor = Color.FromArgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
                                    break;
                              }
                           }

                           // Agrega el nuevo elemento
                           bills.Add(bill);
                        }
                     }
                     break;
               }
            }

            return bills;
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      #endregion

   }
}
