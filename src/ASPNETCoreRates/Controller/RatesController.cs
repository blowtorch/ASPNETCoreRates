
using System.Linq;
using ASPNETCoreRates.Models;
using DataAccess.Database;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETCoreRates.Controller
{
    [Route("api/[controller]")]
    public class RatesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRatesRepository ratesRepository;

        public RatesController(IRatesRepository ratesRepository)
        {
            this.ratesRepository = ratesRepository;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var rates = ratesRepository.GetRates();
            var models = rates.Select(RateViewModel.FromRateDto).ToArray();
            return new JsonResult(models);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult("value");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return new CreatedAtRouteResult("anyroute", null);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return new OkResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new NoContentResult();
        }
    }
}
