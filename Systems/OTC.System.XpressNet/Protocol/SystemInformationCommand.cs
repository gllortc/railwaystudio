﻿using System.Collections.Generic;

namespace Rwm.OTC.Systems.XpressNet.Protocol
{
   public class SystemInformationCommand : CommandBase
   {

      #region Properties

      public override int ResponseBytes 
      { 
         get { return 4; } 
      }

      internal override byte[] RequestBytes
      {
         get { return new byte[] { 0x21, 0x21 }; }
      }

      public string Version { get; private set; }

      public string CommandStation { get; private set; }

      #endregion

      #region Methods

      public override void SetResponseData(List<byte> data)
      {
         double ver = (double)((data[2] & 0xF0) >> 4) + ((double)(data[2] & 0x0F) / 10.0);
         this.Version = ver.ToString();
         switch (data[3])
         {
            case 0x00: this.CommandStation = "LZ100"; break;
            case 0x01: this.CommandStation = "LH200"; break;
            case 0x02: this.CommandStation = "DPC (Compact o Commander)"; break;
            default: this.CommandStation = "Modelo desconocido (no Lenz)"; break;
         }
      }

      #endregion

   }
}