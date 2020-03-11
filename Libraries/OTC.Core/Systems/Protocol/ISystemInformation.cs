namespace Rwm.Otc.Systems.Protocol
{
   public interface ISystemInformation
   {

      string SystemName { get; }

      string SystemVersion { get; }

      string InterfaceName { get; }

      string InterfaceVersion { get; }

   }
}
