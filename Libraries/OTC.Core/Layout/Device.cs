using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Rwm.Otc.Data.ORM;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.TrainControl;
using static Rwm.Otc.Data.ORM.ORMForeignCollection;

namespace Rwm.Otc.Layout
{

   /// <summary>
   /// Implements a control device (accessory decoder, sensor encoder, etc).
   /// </summary>
   [ORMTable("devices")]
   public class Device : ORMEntity<Device>
   {

      #region Enumerations

      /// <summary>
      /// Enumera los tipos de descodificadores de accesorios.
      /// </summary>
      public enum DeviceType : int
      {
         /// <summary>Accessory control module.</summary>
         Undefined = 0,
         /// <summary>Accessory control module.</summary>
         AccessoryDecoder = 1,
         /// <summary>Sensor module.</summary>
         FeedbackModule = 2
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="Device"/>.
      /// </summary>
      public Device() 
      {
         Initialize();
      }

      /// <summary>
      /// Gets a new instance of <see cref="Device"/>.
      /// </summary>
      /// <param name="type">Type of device.</param>
      public Device(Device.DeviceType type)
      {
         Initialize();

         this.Type = type;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; }

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMProperty("projectid")]
      public Project Project { get; set; }

      /// <summary>
      /// Gets or sets the decoder name.
      /// </summary>
      [ORMProperty("name")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets las notas y comentarios al elemento.
      /// </summary>
      [ORMProperty("description")]
      public string Notes { get; set; }

      /// <summary>
      /// Gets or sets the decoder's manufacturer name.
      /// </summary>
      [ORMProperty("builderid")]
      public Manufacturer Manufacturer { get; set; }

      /// <summary>
      /// Gets or sets the decoder's model name or number.
      /// </summary>
      [ORMProperty("model")]
      public string Model { get; set; }

      /// <summary>
      /// Gets or sets the number of outputs of the decoder.
      /// </summary>
      [ORMProperty("outputs")]
      public int Outputs { get; set; }

      /// <summary>
      /// Establece o devuelve la dirección inicial del descodificador.
      /// </summary>
      [ORMProperty("startaddress")]
      public int StartAddress { get; set; }

      /// <summary>
      /// Establece o devuelve el tipo de descodificador.
      /// </summary>
      [ORMProperty("type")]
      public DeviceType Type { get; set; }

      /// <summary>
      /// Gets or sets the list of connections for the device.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<DeviceConnection> Connections { get; set; }

      /// <summary>
      /// Gets the number of connections.
      /// </summary>
      public int ConnectionsCount 
      {
         get { return (this.Connections == null ? 0 : this.Connections.Count); } 
      }

      /// <summary>
      /// Gets the associated icon.
      /// </summary>
      public Image Icon
      {
         get
         {
            switch (this.Type)
            {
               case Device.DeviceType.AccessoryDecoder:
                  return Rwm.Otc.Properties.Resources.ICO_MODULE_ACC_16;

               case Device.DeviceType.FeedbackModule:
                  return Rwm.Otc.Properties.Resources.ICO_MODULE_SENSOR_16;

               default:
                  return null;
            }
         }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Get all decoders information in an instance of <see cref="DataTable"/>.
      /// </summary>
      /// <returns>An instance of <see cref="DataTable"/> filled with the requested data.</returns>
      public static DataSet FindByConnection()
      {
         string sql = string.Empty;
         DataSet ds = new DataSet();

         Logger.LogDebug("Rwm.Otc.Layout.Device.FindByConnection()");

         try
         {
            Connect();

            sql = @"SELECT 
                        s.id    as ""SwitchboardID"",
                        s.name  as ""Switchboard""
                    FROM 
                        " + Switchboard.TableName + @" s
                    ORDER BY 
                        s.name  Asc";

            ds.Tables.Add(Device.ExecuteDataTable(sql));
            ds.Tables[0].TableName = "Switchboards";

            sql = @"SELECT 
                        s.id                             as ""SwitchboardID"",
                        s.name                           as ""Switchboard"",
                        d.name                           as ""Name"", 
                        d.manufacturer || ' ' || d.model as ""Decoder"",
                        dc.name                          as ""Output"",
                        dc.address                       as ""Address"",
                        e.name                           as ""ConnectTo"" 
                    FROM 
                        " + Switchboard.TableName + @" s
                        Inner Join " + Element.TableName + @" e           On (e.switchboardid = s.id)
                        Inner Join " + DeviceConnection.TableName + @" dc On (e.id = dc.elementid)
                        Inner Join " + Device.TableName + @" d            On (d.id = dc.deviceid)
                    ORDER BY 
                        s.name  Asc,
                        d.name  Asc,
                        dc.name Asc";

            ds.Tables.Add(Device.ExecuteDataTable(sql));
            ds.Tables[1].TableName = "Connections";

            // Create a relation to be used in reports
            ds.Relations.Add(new DataRelation("SwitchboardConnection",
                                              ds.Tables["Switchboards"].Columns["SwitchboardID"],
                                              ds.Tables["Connections"].Columns["SwitchboardID"]));

            return ds;
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Get all decoders information in an instance of <see cref="DataTable"/>.
      /// </summary>
      /// <returns>An instance of <see cref="DataTable"/> filled with the requested data.</returns>
      public static DataSet FindBySwitchboard(int switchboardId)
      {
         string sql = string.Empty;
         DataSet ds = new DataSet();

         Logger.LogDebug("Rwm.Otc.Layout.Device.FindBySwitchboard(" + switchboardId + ")");

         try
         {
            Connect();

            sql = @"SELECT 
                        s.id                             as ""SwitchboardID"",
                        s.name                           as ""Switchboard"",
                        d.name                           as ""Name"", 
                        d.manufacturer || ' ' || d.model as ""Decoder"",
                        dc.name                          as ""Output"",
                        dc.address                       as ""Address"",
                        CASE 
                           WHEN (e.name <> '') THEN e.name
                           ELSE ('X:' || (e.x + 1) || ' Y:' || (e.y + 1))
                        END                              as ""ConnectTo"" 
                    FROM 
                        " + Switchboard.TableName + @" s
                        Inner Join " + Element.TableName + @" e           On (e.switchboardid = s.id)
                        Inner Join " + DeviceConnection.TableName + @" dc On (e.id = dc.elementid)
                        Inner Join " + Device.TableName + @" d            On (d.id = dc.deviceid) 
                    WHERE 
                        s.id = @sbid
                    ORDER BY 
                        s.name  Asc,
                        d.name  Asc,
                        dc.name Asc";

            Device.SetParameter("sbid", switchboardId);

            ds.Tables.Add(Device.ExecuteDataTable(sql));
            ds.Tables[0].TableName = "Connections";

            return ds;
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);

            throw;
         }
         finally
         {
            Disconnect();
         }
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
         this.Manufacturer = null;
         this.Model = string.Empty;
         this.Outputs = 0;
         this.StartAddress = 0;
         this.Type = DeviceType.AccessoryDecoder;
         this.Notes = string.Empty;
         this.Connections = new List<DeviceConnection>();
      }

      #endregion

   }
}
