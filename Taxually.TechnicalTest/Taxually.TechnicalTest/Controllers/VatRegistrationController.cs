using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.BL.Interfaces;
using Taxually.TechnicalTest.BL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IVatRegistrationDispatcher _vatRegistrationDispatcher;

        public VatRegistrationController(IVatRegistrationDispatcher vatRegistrationDispatcher)
        {
            _vatRegistrationDispatcher = vatRegistrationDispatcher;
        }
        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            try
            {
                await _vatRegistrationDispatcher.DispatchAsync(request);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
