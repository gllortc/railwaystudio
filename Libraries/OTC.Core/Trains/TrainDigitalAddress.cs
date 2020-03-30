namespace Rwm.Otc.Trains
{
   public class TrainDigitalAddress
   {

      public TrainDigitalAddress() { }

      public TrainDigitalAddress(uint address) 
      {
         this.CalculateCV(address);
      }

      public bool IsLongAddress { get; private set; } = false;

      public uint Address { get; private set; } = 3;

      public uint CV1 { get; private set; } = 3;

      public uint CV17 { get; private set; } = 0;

      public uint CV18 { get; private set; } = 0;

      public void SetAddress(uint address)
      {
         this.CalculateCV(address);
      }

      private void CalculateCV(uint address)
      {
         if (address < 127)
         {
            this.IsLongAddress = false;
            this.Address = address;
            this.CV1 = address;
            this.CV17 = 0;
            this.CV18 = 0;
         }
         else
         {
            this.IsLongAddress = true;
            this.Address = address;
            this.CV1 = address / 256;
            this.CV17 = this.CV1 + 192;
            this.CV18 = address - (this.CV1 * 256);
         }
      }

   }
}
