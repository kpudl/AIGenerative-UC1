using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UseCase1.Models;
using UseCase1.Models.RestCountry;
using UseCase1.Services;

namespace UseCase1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestCountriesController : ControllerBase
    {
        private readonly IEnumerable<RestCountryDto> _countriesList;
        private readonly ICountriesService<RestCountryDto> _countriesService;

        public RestCountriesController(IEnumerable<RestCountryDto> countriesList,
            ICountriesService<RestCountryDto> countriesService)
        {
            _countriesList = countriesList;
            _countriesService = countriesService;
        }

        [HttpGet]
        public ActionResult Get(string? country=null, int? population=null, SortTypes? sortBy=null, int? records=null) 
        {
            var listOfCountries = _countriesList;

            if (!string.IsNullOrEmpty(country))
                listOfCountries = _countriesService.FilterCountryName(listOfCountries, country);
            if (population != null)
                listOfCountries = _countriesService.FilterCountryWithPopulationLess(listOfCountries, population.Value);
            if (sortBy != null)
                listOfCountries = _countriesService.SortCountries(listOfCountries, sortBy.Value);
            if (records != null)
                listOfCountries = _countriesService.SelectCountries(listOfCountries, records.Value);

            return Ok(JsonConvert.SerializeObject(listOfCountries, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }));
        }
    }
}
