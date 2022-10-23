using System.Xml.Serialization;
using Taxually.TechnicalTest.BL.Interfaces;
using Taxually.TechnicalTest.BL.Models;

namespace Taxually.TechnicalTest.BL.Converters
{
    public class XmlWriter : IXmlWriter
    {
        public string? WriteXml(VatRegistrationRequest request)
        {
            using var stringwriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
            serializer.Serialize(stringwriter, request);
            var xml = stringwriter.ToString();

            return xml;
        }
    }
}
