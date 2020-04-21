namespace Rwm.Studio.Plugins.Collection.Model
{
   /// <summary>
   /// Representa un comercio dónde se pueden adquirir modelos.
   /// </summary>
   public class Store : IIdentifiableObject
   {
      // Declaración de variables internas
      private int _id;
      private string _name;
      private string _address;
      private string _phone;
      private string _fax;
      private string _mail;
      private string _url;
      private string _description;

      #region Properties

      public int ID
      {
         get { return _id; }
         set { _id = value; }
      }

      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      public string Description
      {
         get { return _description; }
         set { _description = value; }
      }

      public string Address
      {
         get { return _address; }
         set { _address = value; }
      }

      public string Phone
      {
         get { return _phone; }
         set { _phone = value; }
      }

      public string FAX
      {
         get { return _fax; }
         set { _fax = value; }
      }

      public string Mail
      {
         get { return _mail; }
         set { _mail = value; }
      }

      public string URL
      {
         get { return _url; }
         set { _url = value; }
      }

      #endregion

   }
}
