using Taxually.TechnicalTest.BL.Interfaces;
using Taxually.TechnicalTest.BL.Models;
using Taxually.TechnicalTest.DL.Interfaces;

namespace Taxually.TechnicalTest.BL.Services
{
    public class VatRegistrationDispatcher : IVatRegistrationDispatcher
    {
        private readonly IHttp _http;
        private readonly IQueue _queue;
        private readonly ICsvBuilder _csvBuilder;
        private readonly IXmlWriter _xmlWriter;

        public VatRegistrationDispatcher(IHttp http, IQueue queue, ICsvBuilder csvBuilder, IXmlWriter xmlWriter)
        {
            _http = http;
            _queue = queue;
            _csvBuilder = csvBuilder;
            _xmlWriter = xmlWriter;
        }

        public async Task DispatchAsync(VatRegistrationRequest request)
        {
            switch (request.Country)
            {
                case "GB":
                    // UK has an API to register for a VAT number
                    await _http.PostAsync("https://api.uktax.gov.uk", request);
                    break;
                case "FR":
                    // France requires an excel spreadsheet to be uploaded to register for a VAT number
                    var csv = _csvBuilder.BuildCsv(request);

                    // Queue file to be processed
                    await _queue.EnqueueAsync("vat-registration-csv", csv);
                    break;
                case "DE":
                    // Germany requires an XML document to be uploaded to register for a VAT number
                    var xml = _xmlWriter.WriteXml(request);

                    // Queue xml doc to be processed
                    await _queue.EnqueueAsync("vat-registration-xml", xml);

                    break;
                default:
                    throw new Exception("Country not supported");
            }
        }
    }
}
