using Taxually.TechnicalTest.DL.Interfaces;

namespace Taxually.TechnicalTest.DL.Http
{
    public class TaxuallyHttpClient : IHttp
    {
        public Task PostAsync<TRequest>(string url, TRequest request)
        {
            // Actual HTTP call removed for purposes of this exercise
            return Task.CompletedTask;
        }
    }
}
