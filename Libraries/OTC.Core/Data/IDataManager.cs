namespace Rwm.Otc.Data
{
   public interface IDataManager
   {

      void Connect();

      void Disconnect();

      void CheckDatabase();

      void BeginTransaction();

      void Commit();

      void Rollback();

   }
}
