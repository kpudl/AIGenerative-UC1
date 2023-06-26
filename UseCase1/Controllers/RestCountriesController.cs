using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UseCase1.Models;
using UseCase1.Models.RestCountry;

namespace UseCase1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestCountriesController : ControllerBase
    {
        private readonly IEnumerable<RestCountryDto> _countriesList;

        public RestCountriesController(IEnumerable<RestCountryDto> countriesList)
        {
            _countriesList = countriesList;
        }

        [HttpGet]
        public ActionResult Get(string? country=null, int? population=null, SortTypes? sortBy=null, int? records=null) 
        {
            return Ok(JsonConvert.SerializeObject(_countriesList, Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }));
        }
    }
}
