using System;

namespace Rwm.Otc.LayoutControl
{

   /// <summary>
   /// Implementa una excepción para informar al proceso consumidor que el objeto especificado no existe en una colección.
   /// </summary>
   [Serializable]
   public class LayoutConfigurationException : Exception
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of OTCBlockNotFoundException.
      /// </summary>
      /// <param name="elementId">Dato que permite identificar el objeto.</param>
      public LayoutConfigurationException() : base() { }

      /// <summary>
      /// Returns a new instance of OTCBlockNotFoundException.
      /// </summary>
      /// <param name="elementId">Dato que permite identificar el objeto.</param>
      public LayoutConfigurationException(string message) : base(message) { }

      /// <summary>
      /// Returns a new instance of OTCBlockNotFoundException.
      /// </summary>
      /// <param name="elementId">Dato que permite identificar el objeto.</param>
      public LayoutConfigurationException(string message, params object[] args) : base(string.Format(message, args)) { }

      /// <summary>
      /// Returns a new instance of OTCBlockNotFoundException.
      /// </summary>
      /// <param name="elementId">Dato que permite identificar el objeto.</param>
      public LayoutConfigurationException(string message, Exception innerException) : base(message, innerException) { }

      #endregion

   }
}
