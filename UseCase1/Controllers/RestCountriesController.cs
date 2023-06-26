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
        private readonly ICountriesService<RestCountryDto> _countriesService;
        private readonly IRestCountriesService<RestCountryDto> _restCountriesService;

        public RestCountriesController(ICountriesService<RestCountryDto> countriesService,
            IRestCountriesService<RestCountryDto> restCountriesService)
        {
            _countriesService = countriesService;
            _restCountriesService = restCountriesService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string? country=null, int? population=null, SortTypes? sortBy=null, int? records=null) 
        {
            try
            {
                var listOfCountries = await _restCountriesService.GetCountries();

                if (!string.IsNullOrEmpty(country))
                    listOfCountries = await _countriesService.FilterCountryName(listOfCountries, country);
                if (population != null)
                    listOfCountries = await _countriesService.FilterCountryWithPopulationLess(listOfCountries, population.Value);
                if (sortBy != null)
                    listOfCountries = await _countriesService.SortCountries(listOfCountries, sortBy.Value);
                if (records != null)
                    listOfCountries = await _countriesService.SelectCountries(listOfCountries, records.Value);

                return Ok(JsonConvert.SerializeObject(listOfCountries, Formatting.Indented,
                                new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore
                                }));
            }
            catch (NullReferenceException ex)
            {
                return BadRequest($"Null reference exception catched: {ex.Message}");
            }
            catch (ArgumentException ex)
            { 
                return BadRequest($"Bad argument exception catched: {ex.Message}");
            }
            catch(HttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
