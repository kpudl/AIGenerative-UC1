using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UseCase1.Controllers;
using UseCase1.Models;

namespace UseCase1_Tests
{
    public class ControllerTests: BaseTest
    {
        [Test]
        public void CheckEndpointTest()
        {
            var restCountriesController = new RestCountriesController(_service, _restService);
            var result = (OkObjectResult)restCountriesController.Get().Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 200);

            var resultValue = JsonConvert.DeserializeObject<IEnumerable<RestCountryDto>>(result.Value.ToString());
            Assert.AreEqual(resultValue.Count(), _testCountries.Count());
        }

        [Test]
        public void CheckEndpointTestWithFilters()
        {
            var restCountriesController = new RestCountriesController(_service,_restService);
            var result = (OkObjectResult)restCountriesController.Get(country:"SP").Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, 200);

            var resultValue = JsonConvert.DeserializeObject<IEnumerable<RestCountryDto>>(result.Value.ToString());
            Assert.AreEqual(resultValue.Count(), 1);
        }
    }
}