using System;

namespace Rwm.Otc.Systems
{

   /// <summary>
   /// Implementa una excepción para informar al proceso consumidor que el objeto especificado no existe en una colección.
   /// </summary>
   [Serializable]
   public class DigitalSystemException : Exception
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of OTCBlockNotFoundException.
      /// </summary>
      /// <param name="elementId">Dato que permite identificar el objeto.</param>
      public DigitalSystemException() : base() { }

      /// <summary>
      /// Returns a new instance of OTCBlockNotFoundException.
      /// </summary>
      /// <param name="elementId">Dato que permite identificar el objeto.</param>
      public DigitalSystemException(string message) : base(message) { }

      /// <summary>
      /// Returns a new instance of OTCBlockNotFoundException.
      /// </summary>
      /// <param name="elementId">Dato que permite identificar el objeto.</param>
      public DigitalSystemException(string message, params object[] args) : base(string.Format(message, args)) { }

      /// <summary>
      /// Returns a new instance of OTCBlockNotFoundException.
      /// </summary>
      /// <param name="elementId">Dato que permite identificar el objeto.</param>
      public DigitalSystemException(string message, Exception innerException) : base(message, innerException) { }

      #endregion

   }
}
