using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UseCase1.Controllers;
using UseCase1.Models;
using UseCase1.Models.RestCountry;

namespace UseCase1_Tests
{
    public class Tests
    {
        private IEnumerable<RestCountryDto> _testCountries;

        [SetUp]
        public void Setup()
        {
            _testCountries = new List<RestCountryDto>() {
                new RestCountryDto()
                {
                   Name = new NameDto()
                   {
                       Common = "Spain"
                   } ,
                   Population = 19000000
                },
                new RestCountryDto()
                {
                   Name = new NameDto()
                   {
                       Common = "Andorra"
                   } ,
                   Population = 2000000
                },
                new RestCountryDto()
                {
                   Name = new NameDto()
                   {
                       Common = "DR Congo"
                   } ,
                   Population = 20000000
                },
                new RestCountryDto()
                {
                   Name = new NameDto()
                   {
                       Common = "cook Islands"
                   } ,
                   Population = 18999999
                }
            };
        }

        [Test]
        public void CheckEndpointTest()
        {
            var restCountriesController = new RestCountriesController(_testCountries);
            var result = (OkObjectResult)restCountriesController.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 200);

            var resultValue = JsonConvert.DeserializeObject<IEnumerable<RestCountryDto>>(result.Value.ToString());
            Assert.AreEqual(resultValue.Count(), _testCountries.Count());
        }
    }
}