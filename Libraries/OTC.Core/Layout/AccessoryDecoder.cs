using System;
using System.Collections.Generic;
using System.Data;
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
      /// Gets or sets the owner layout module where the decoder is installed.
      /// </summary>
      [ORMProperty("MODULEID")]
      public Module Module { get; set; } = null;

      /// <summary>
      /// Gets or sets the list of device outputs.
      /// </summary>
      [ORMForeignCollection(OnDeleteActionTypes.DeleteInCascade)]
      public List<AccessoryDecoderOutput> Outputs { get; set; } = new List<AccessoryDecoderOutput>();

      /// <summary>
      /// Gets a string describing the manufacturer and model of the current accessory decoder.
      /// </summary>
      public string ModelDescription
      {
         get
         {
            if (string.IsNullOrWhiteSpace(this.Model) && string.IsNullOrWhiteSpace(this.Manufacturer?.Name))
               return "Sense dades";
            else
               return (this.Manufacturer?.Name + " " + this.Model).Trim();
         }
      }

      /// <summary>
      /// Gets a string describing the digital addresses used in the current decoder.
      /// </summary>
      public string AddressRangeDescription
      {
         get
         {
            bool isConsecutive = true;
            int previousAdd = -1;
            string range = string.Empty;

            foreach (AccessoryDecoderOutput output in this.Outputs)
            {
               if (previousAdd > 0 && previousAdd + 1 != output.Address)
               {
                  isConsecutive = false;
                  break;
               }

               previousAdd = output.Address;
            }

            if (this.Outputs.Count <= 0)
               range = "Not defined";
            else if (isConsecutive)
               range = String.Format("{0:D3} - {1:D3}", this.Outputs[0].Address, this.Outputs[this.Outputs.Count - 1].Address);
            else
               foreach (AccessoryDecoderOutput output in this.Outputs)
                  range = (String.IsNullOrEmpty(range) ? string.Empty : ", ") + String.Format("{0:D3}", output.Address);

            return range;
         }
      }

      /// <summary>
      /// Gets the associated small icon (16x16px).
      /// </summary>
      public static System.Drawing.Image SmallIcon
      {
         get { return Properties.Resources.ICO_ACCESSORY_DECODER_16; }
      }

      /// <summary>
      /// Gets the associated large icon (32x32px).
      /// </summary>
      public static System.Drawing.Image LargeIcon
      {
         get { return Properties.Resources.ICO_ACCESSORY_DECODER_32; }
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
         string sql;
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
            throw ex;
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
         string sql;
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
            throw ex;
         }
         finally
         {
            Disconnect();
         }
      }

      /// <summary>
      /// Get all decoders information organized by section.
      /// </summary>
      /// <returns>An instance of <see cref="DataSet"/> filled with the requested data.</returns>
      public static DataSet FindBySection()
      {
         string sql;
         DataSet ds = new DataSet();

         Logger.LogDebug("Rwm.Otc.Layout.Device.FindBySection()");

         try
         {
            Connect();

            sql = @"SELECT 
                        s.id    as ""ID"",
                        s.name  as ""Name""
                    FROM 
                        " + Module.TableName + @" s
                    ORDER BY 
                        s.name  Asc";

            ds.Tables.Add(AccessoryDecoder.ExecuteDataTable(sql));
            ds.Tables[0].TableName = Module.TableName;

            sql = @"SELECT 
                       s.id                      as ""SectionID"",
                       --s.name                    as ""Section"",
                       ad.name                   as ""Name"", 
                       m.name || ' ' || ad.model as ""Decoder"",
                       ado.""INDEX""             as ""Output"",
                       ado.ADDRESS               as ""Address"",
                       CASE
                          WHEN(e.name <> '') THEN e.name
                          ELSE('X:' || (e.x + 1) || ' Y:' || (e.y + 1))
                       END as ""ConnectTo""
                    FROM
                        " + Module.TableName + @" s
                        Inner Join " + AccessoryDecoder.TableName + @" ad            On (ad.SECTIONID = s.ID)
                        Inner Join " + AccessoryDecoderOutput.TableName + @" ado     On (ado.DECODERID = ad.id)
                        Inner Join " + AccessoryDecoderConnection.TableName + @" adc On (adc.DECODEROUTPUT = ado.ID)
                        Left Join " + Element.TableName + @" e                       On (e.ID = adc.ELEMENTID)
                        Left Join " + Manufacturer.TableName + @" m                  On (ad.MANUFACTURERID = m.ID)
                    --WHERE
                    --    s.id = @sbid
                    ORDER BY
                        s.name        Asc,
                        ad.name       Asc,
                        ado.""INDEX"" Asc";

            ds.Tables.Add(AccessoryDecoder.ExecuteDataTable(sql));
            ds.Tables[0].TableName = AccessoryDecoder.TableName;

            // Create a relation to be used in reports
            ds.Relations.Add(new DataRelation("SectionDecoder",
                                              ds.Tables[Module.TableName].Columns["ID"],
                                              ds.Tables[AccessoryDecoder.TableName].Columns["SECTIONID"]));


            return ds;
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);
            throw ex;
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
