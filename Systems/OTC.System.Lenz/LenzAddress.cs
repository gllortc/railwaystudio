using Rwm.Otc.Utils;

namespace Rwm.OTC.Systems.Lenz
{
   /// <summary>
   /// Representa una dirección digital Lenz.
   /// </summary>
   public class LenzAddress
   {
      private int _address = 0;
      private byte _highByte = 0;
      private byte _lowByte = 0;

      /// <summary>
      /// Devuelve una instancia de <see cref="LenzAddress"/>.
      /// </summary>
      /// <param name="address">Dirección a convertir.</param>
      public LenzAddress(int address) 
      {
         _address = address;

         ConvertToXNetAddress(_address, out _highByte, out _lowByte);
      }

      /// <summary>
      /// Devuelve una instancia de LenzAddress.
      /// </summary>
      /// <param name="low">Byte bajo.</param>
      /// <param name="high">Byte alto.</param>
      public LenzAddress(byte low, byte high)
      {
         _highByte = high;
         _lowByte = low;

         _address = ConvertFromXNetAddress(_highByte, _lowByte);
      }

      /// <summary>
      /// Devuelve o establece la dirección numérica (0 hasta 9999).
      /// </summary>
      public int Address
      {
         get { return _address; }
         set { _address = value; }
      }

      /// <summary>
      /// Devuelve o establece la parte alta de la dirección.
      /// </summary>
      public byte HighAddress
      {
         get { return _highByte; }
         set { _highByte = value; }
      }

      /// <summary>
      /// Devuelve o establece la parte baja de la dirección.
      /// </summary>
      public byte LowAddress
      {
         get { return _lowByte; }
         set { _lowByte = value; }
      }

      /// <summary>
      /// Comprueba si una dirección digital es válida.
      /// </summary>
      /// <param name="address">Dirección digital a comprobar.</param>
      /// <returns><code>True</code> si la dirección es válida o <code>False</code> en cualquier otro caso.</returns>
      /// <remarks>
      /// Este método sólo es válido para software Lenz de versiones 3.0 o superiores.
      /// </remarks>
      public static bool IsValidAddress(int address) 
      {
         return (address >= 0 && address <= 9999);
      }

      #region Private Members

      private void ConvertToXNetAddress(int _iLocoAddy, out byte _byteAddyAH, out byte _byteAddyAL)
      {
         if (_iLocoAddy >= 0 && _iLocoAddy <= 9999)
         {
            _byteAddyAH = (byte)(BinaryUtils.HiByte(_iLocoAddy) + 0xC0);
            _byteAddyAL = (byte)BinaryUtils.LoByte(_iLocoAddy);
         }
         else
         {
            _byteAddyAH = 0;
            _byteAddyAL = 0;
         }
      }

      private int ConvertFromXNetAddress(byte _byteAddyAH, byte _byteAddyAL)
      {
         int _iLocoAddy = -1;

         if (_byteAddyAH > 0) 
         {
            _iLocoAddy = (int)BinaryUtils.MakeWord(_byteAddyAL, (byte)(_byteAddyAH - 0xC0));
         } 
         else 
         {
            _iLocoAddy = (int)_byteAddyAL;
         }

         return _iLocoAddy;
      }

      #endregion
   }
}
