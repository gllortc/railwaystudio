using System;
using System.Xml.Linq;

namespace Rwm.Otc.xml.serialization
{
    /// <summary>
    /// Provides deserializer methods for some known .NET built-in types.
    /// </summary>
    internal class KnownDotNetTypesDeserializers
    {
        /// <summary>
        /// Deserializes an object of type <c>TimeSpan</c>.
        /// </summary>
        /// <param name="baseElement">The XML element containing serialized <c>TimeSpan</c>.</param>
        /// <returns>deserialized <c>TimeSpan</c> object.</returns>
        public static object DeserializeTimeSpan(XElement baseElement)
        {
            string strTicks = baseElement.Element("Ticks").Value;
            long ticks = 0L;
            if (Int64.TryParse(strTicks, out ticks))
            {
                return new TimeSpan(ticks);
            }
            return null;
        }

        /// <summary>
        /// Deserializes an object of type <c>GUID</c>.
        /// </summary>
        /// <param name="baseElement">The XML element containing serialized <c>GUID</c>.</param>
        /// <returns>deserialized <c>GUID</c> object</returns>
        internal static object DeserializeGuid(XElement baseElement)
        {
            string strGuidValue = baseElement.Value;
            Guid g = new Guid(strGuidValue);
            return g;
        }
    }
}
