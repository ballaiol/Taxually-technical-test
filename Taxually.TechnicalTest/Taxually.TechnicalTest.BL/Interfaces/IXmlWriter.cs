using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.BL.Models;

namespace Taxually.TechnicalTest.BL.Interfaces
{
    public interface IXmlWriter
    {
        string? WriteXml(VatRegistrationRequest request);
    }
}
