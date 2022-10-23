using Taxually.TechnicalTest.BL.Models;

namespace Taxually.TechnicalTest.BL.Interfaces
{
    public interface IVatRegistrationDispatcher
    {
        Task DispatchAsync(VatRegistrationRequest request);
    }
}
