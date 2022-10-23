using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.BL.Interfaces;
using Taxually.TechnicalTest.BL.Models;

namespace Taxually.TechnicalTest.BL.Converters
{
    public class CsvBuilder : ICsvBuilder
    {
        public byte[] BuildCsv(VatRegistrationRequest request)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{request.CompanyName},{request.CompanyId}");

            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());

            return csv;
        }
    }
}
