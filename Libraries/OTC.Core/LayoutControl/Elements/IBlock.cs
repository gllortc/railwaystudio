namespace Rwm.Otc.LayoutControl.Elements
{
   public interface IBlock
   {

      bool IsOccupied { get; }

      Rwm.Otc.TrainControl.CollectionModel Train { get; set; }

   }
}
