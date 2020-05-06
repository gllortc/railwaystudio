using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Trains;
using static Rwm.Otc.Data.ORMForeignCollection;

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
      public AccessoryDecoder() { }

      /// <summary>
      /// Gets a new instance of <see cref="AccessoryDecoder"/>.
      /// </summary>
      /// <param name="numberOfOutputs">Number of outputs to assign to new instance.</param>
      public AccessoryDecoder(int numberOfOutputs)
      {
         this.InitializeOutouts(numberOfOutputs);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMProperty("PROJECTID")]
      public Project Project { get; set; } = null;

      /// <summary>
      /// Gets or sets the manufacturer.
      /// </summary>
      [ORMProperty("MANUFACTURERID")]
      public Manufacturer Manufacturer { get; set; } = null;

      /// <summary>
      /// Gets or sets the decoder name.
      /// </summary>
      [ORMProperty("NAME")]
      public string Name { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets las notas y comentarios al elemento.
      /// </summary>
      [ORMProperty("DESCRIPTION")]
      public string Notes { get; set; } = string.Empty;

      /// <summary>
      /// Gets or sets the decoder's model name or number.
      /// </summary>
      [ORMProperty("MODEL")]
      public string Model { get; set; } = string.Empty;

      /// <summary>
      /// Establece o devuelve la dirección inicial del descodificador.
      /// </summary>
      [ORMProperty("STARTADDRESS")]
      public int StartAddress { get; set; } = 0;

      /// <summary>
      /// Gets or sets the owner section of the layout where the decoder is installed.
      /// </summary>
      [ORMProperty("SECTIONID")]
      public Section Section { get; set; } = null;

      /// <summary>
      /// Gets or sets the list of device outputs.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<AccessoryDecoderOutput> Outputs { get; set; } = new List<AccessoryDecoderOutput>();

      /// <summary>
      /// Gets the associated icon.
      /// </summary>
      public Image Icon
      {
         get { return Properties.Resources.ICO_MODULE_ACC_16; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Returns the specified decoder output.
      /// </summary>
      /// <param name="index">Output index.</param>
      /// <returns>The requested output or <null> if the output doesn't exists.</null></returns>
      public AccessoryDecoderOutput GetOutputByIndex(int index)
      {
         if (this.Outputs == null) 
            return null;

         foreach (AccessoryDecoderOutput output in this.Outputs)
         {
            if (output.Index == index)
               return output;
         }

         return null;
      }

      /// <summary>
      /// Get all decoders information in an instance of <see cref="DataTable"/>.
      /// </summary>
      /// <returns>An instance of <see cref="DataTable"/> filled with the requested data.</returns>
      public static DataSet FindByConnection()
      {
         string sql = string.Empty;
         DataSet ds = new DataSet();

         Logger.LogDebug("Rwm.Otc.Layout.AccessoryDecoder.FindByConnection()");

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
                        m.name || ' ' || d.model         as ""Decoder"",
                        dc.decoderoutput                 as ""DecoderInput"",
                        dc.address                       as ""Address"",
                        e.name                           as ""ConnectTo"" 
                    FROM 
                        " + Switchboard.TableName + @" s
                        Inner Join " + Element.TableName + @" e                     On (e.switchboardid = s.id)
                        Inner Join " + AccessoryDecoderConnection.TableName + @" dc On (e.id = dc.elementid)
                        Inner Join " + AccessoryDecoder.TableName + @" d            On (d.id = dc.decoderid)
                        Left join  " + Manufacturer.TableName + @" m                On (m.id = d.MANUFACTURERID)
                    ORDER BY 
                        s.name  Asc,
                        d.name  Asc,
                        dc.decoderoutput Asc";

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
                        m.name || ' ' || d.model         as ""Decoder"",
                        dc.DECODEROUTPUT                 as ""DecoderInput"",
                        dc.address                       as ""Address"",
                        CASE 
                           WHEN (e.name <> '') THEN e.name
                           ELSE ('X:' || (e.x + 1) || ' Y:' || (e.y + 1))
                        END                              as ""ConnectTo"" 
                    FROM 
                        " + Switchboard.TableName + @" s
                        Inner Join " + Element.TableName + @" e                     On (e.switchboardid = s.id)
                        Inner Join " + AccessoryDecoderConnection.TableName + @" dc On (e.id = dc.elementid)
                        Inner Join " + AccessoryDecoder.TableName + @" d            On (d.id = dc.decoderid) 
                        Left  join " + Manufacturer.TableName + @" m                On (m.id = d.MANUFACTURERID) 
                    WHERE 
                        s.id = @sbid
                    ORDER BY 
                        s.name  Asc,
                        d.name  Asc,
                        dc.DECODEROUTPUT Asc";

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

      private void InitializeOutouts(int numberOfOutputs)
      {
         for (int i = 1; i <= numberOfOutputs; i++)
         {
            AccessoryDecoderOutput output = new AccessoryDecoderOutput();
            output.AccessoryDecoder = this;
            output.Index = i;
            output.Mode = AccessoryDecoderOutput.OutputMode.OneShot;

            this.Outputs.Add(output);
         }
      }

      #endregion

   }
}
