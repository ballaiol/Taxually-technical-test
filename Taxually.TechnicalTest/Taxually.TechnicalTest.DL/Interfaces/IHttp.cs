using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxually.TechnicalTest.DL.Interfaces
{
    public interface IHttp
    {
        Task PostAsync<TRequest>(string url, TRequest request);
    }
}
