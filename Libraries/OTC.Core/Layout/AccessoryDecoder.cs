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
   [ORMTable("ACC_DECODERS")]
   public class AccessoryDecoder : ORMEntity<AccessoryDecoder>
   {

      #region Constructors

      /// <summary>
      /// Gets a new instance of <see cref="AccessoryDecoder"/>.
      /// </summary>
      public AccessoryDecoder() 
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
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMProperty("PROJECTID")]
      public Project Project { get; set; }

      /// <summary>
      /// Gets or sets the manufacturer.
      /// </summary>
      [ORMProperty("MANUFACTURERID")]
      public Manufacturer Manufacturer { get; set; }

      /// <summary>
      /// Gets or sets the decoder name.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets las notas y comentarios al elemento.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Notes { get; set; }

      /// <summary>
      /// Gets or sets the decoder's model name or number.
      /// </summary>
      [ORMProperty("MODEL")]
      public string Model { get; set; }

      /// <summary>
      /// Gets or sets the number of outputs of the decoder.
      /// </summary>
      [ORMProperty("OUTPUTS")]
      public int Outputs { get; set; }

      /// <summary>
      /// Establece o devuelve la dirección inicial del descodificador.
      /// </summary>
      [ORMProperty("STARTADDRESS")]
      public int StartAddress { get; set; }

      /// <summary>
      /// Gets or sets the name of the owner's module (or layout part) that contains the decoder.
      /// </summary>
      [ORMProperty("MODULE")]
      public string Module { get; set; }

      /// <summary>
      /// Gets or sets the list of connections for the device.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<AccessoryDecoderConnection> Connections { get; set; }

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
         get { return Rwm.Otc.Properties.Resources.ICO_MODULE_ACC_16; }
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

            ds.Tables.Add(AccessoryDecoder.ExecuteDataTable(sql));
            ds.Tables[0].TableName = "Switchboards";

            sql = @"SELECT 
                        s.id                             as ""SwitchboardID"",
                        s.name                           as ""Switchboard"",
                        d.name                           as ""Name"", 
                        d.manufacturer || ' ' || d.model as ""Decoder"",
                        dc.name                          as ""DecoderInput"",
                        dc.address                       as ""Address"",
                        e.name                           as ""ConnectTo"" 
                    FROM 
                        " + Switchboard.TableName + @" s
                        Inner Join " + Element.TableName + @" e           On (e.switchboardid = s.id)
                        Inner Join " + AccessoryDecoderConnection.TableName + @" dc On (e.id = dc.elementid)
                        Inner Join " + AccessoryDecoder.TableName + @" d            On (d.id = dc.deviceid)
                    ORDER BY 
                        s.name  Asc,
                        d.name  Asc,
                        dc.name Asc";

            ds.Tables.Add(AccessoryDecoder.ExecuteDataTable(sql));
            ds.Tables[1].TableName = "AccessoryConnections";

            // Create a relation to be used in reports
            ds.Relations.Add(new DataRelation("SwitchboardConnection",
                                              ds.Tables["Switchboards"].Columns["SwitchboardID"],
                                              ds.Tables["AccessoryConnections"].Columns["SwitchboardID"]));

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
                        dc.name                          as ""DecoderInput"",
                        dc.address                       as ""Address"",
                        CASE 
                           WHEN (e.name <> '') THEN e.name
                           ELSE ('X:' || (e.x + 1) || ' Y:' || (e.y + 1))
                        END                              as ""ConnectTo"" 
                    FROM 
                        " + Switchboard.TableName + @" s
                        Inner Join " + Element.TableName + @" e           On (e.switchboardid = s.id)
                        Inner Join " + AccessoryDecoderConnection.TableName + @" dc On (e.id = dc.elementid)
                        Inner Join " + AccessoryDecoder.TableName + @" d            On (d.id = dc.deviceid) 
                    WHERE 
                        s.id = @sbid
                    ORDER BY 
                        s.name  Asc,
                        d.name  Asc,
                        dc.name Asc";

            AccessoryDecoder.SetParameter("sbid", switchboardId);

            ds.Tables.Add(AccessoryDecoder.ExecuteDataTable(sql));
            ds.Tables[0].TableName = "AccessoryConnections";

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
         this.Notes = string.Empty;
         this.Connections = new List<AccessoryDecoderConnection>();
      }

      #endregion

   }
}
