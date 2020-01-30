namespace Rwm.Otc.Net
{

   #region OTCNetMessageClient

   /// <summary>
   /// Implementa una estación de la red OTC.
   /// </summary>
   public class OTCNetMessageClient
   {
      private string _login = string.Empty;
      private string _ip = string.Empty;
      private bool _isserver = false;

      /// <summary>
      /// Returns a new instance of OTCNetMessageClient.
      /// </summary>
      public OTCNetMessageClient()
      {
         _login = string.Empty;
         _ip = string.Empty;
         _isserver = false;
      }

      /// <summary>
      /// Returns a new instance of OTCNetMessageClient.
      /// </summary>
      public OTCNetMessageClient(string Login, bool IsServer)
      {
         _login = Login;
         _ip = string.Empty;
         _isserver = IsServer;
      }

      /// <summary>
      /// Returns a new instance of OTCNetMessageClient.
      /// </summary>
      public OTCNetMessageClient(string Login, string IP, bool IsServer)
      {
         _login = Login;
         _ip = IP;
         _isserver = IsServer;
      }

      /// <summary>
      /// Login de la estación.
      /// </summary>
      public string Login
      {
         get { return _login; }
         set { _login = value; }
      }

      /// <summary>
      /// IP de la estación.
      /// </summary>
      public string IP
      {
         get { return _ip; }
         set { _ip = value; }
      }

      /// <summary>
      /// Indica si la estación actúa de servidor.
      /// </summary>
      public bool IsServer
      {
         get { return _isserver; }
         set { _isserver = value; }
      }
   }

   #endregion

}
