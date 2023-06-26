using UseCase1.Models.RestCountry;
using UseCase1.Models;
using UseCase1.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace UseCase1_Tests
{
    public class BaseTest
    {
        protected IRestCountriesService<RestCountryDto> _restService;
        protected CountriesService _service;
        protected IEnumerable<RestCountryDto> _testCountries;

        [SetUp]
        public void Setup()
        {             
            #region SetupTestCountries
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
            #endregion

            var mockService = new Mock<IRestCountriesService<RestCountryDto>>();
            mockService.CallBase = true;
            mockService.Setup(x => x.GetCountries()).ReturnsAsync(_testCountries);
            _restService = mockService.Object;

            _service = new CountriesService();
        }
    }
}
