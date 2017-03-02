using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fare.Models;
using Fare.Models.Interfaces;

namespace Fare.Controllers
{
    public class FareServiceController : ApiController
    {
        private ICalculator calc;

        /// <summary>
        /// DI calculator constructor for Fare Service
        /// </summary>
        /// <param name="calc"></param>
        public FareServiceController(ICalculator calc)
        {
            this.calc = calc;
        }

        // POST: api/FareService/{{ride}}
        [HttpPost]
        public HttpResponseMessage CalculateFarePrice(Ride ride)
        {
            var cost = calc.Calculate(ride);
            return Request.CreateResponse(HttpStatusCode.OK, new { cost = cost });
        }
    }
}
