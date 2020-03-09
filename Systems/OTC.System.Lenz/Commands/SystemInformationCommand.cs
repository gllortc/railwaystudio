using System;

namespace Rwm.OTC.Systems.Lenz.Commands
{
   public class SystemInformationCommand : Command
   {

      #region Constructors

      public SystemInformationCommand()
      {
         this.RequestData = new byte[] { 0xFF, 0xFE, 0x21, 0x21, 0x00 };
         this.ResponseHeaderData = new byte[] { 0x63, 0x21 };
      }

      #endregion

      #region Properties

      public string SystemName { get; private set; }

      public string SystemVersion { get; private set; }

      #endregion

      #region Methods

      public override bool GetCommandData(byte[] data)
      {
         double ver = 0.0;

         if (data.Length >= 4)
         {
            // Get system version
            ver = (double)((data[2] & 0xF0) >> 4) + ((double)(data[2] & 0x0F) / 10.0);
            this.SystemVersion = ver.ToString();

            // Get system model
            switch (data[3])
            {
               case 0x00:
                  this.SystemName = "LZ100";
                  break;
               case 0x01:
                  this.SystemName = "LH200";
                  break;
               case 0x02:
                  this.SystemName = "DPC (Compact o Commander)";
                  break;
               default:
                  this.SystemName = "Unknown model";
                  break;
            }

            return true;
         }
         else
         {
            return false;
         }
      }

      #endregion

   }
}
