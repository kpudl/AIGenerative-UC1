using NUnit.Framework.Internal;
using UseCase1.Models.RestCountry;
using UseCase1.Services;

namespace UseCase1_Tests
{
    public class CountriesServiceTests: BaseTest
    {
        [Test]
        public void CheckFilterCountryName()
        {
            var result = _service.FilterCountryName(_testCountries, "orr").Result;
            Assert.AreEqual(result.Count(), 1);

            result = _service.FilterCountryName(_testCountries, "sp").Result;
            Assert.AreEqual(result.Count(), 1);

            result = _service.FilterCountryName(_testCountries, "co").Result;
            Assert.AreEqual(result.Count(), 2);

            result = _service.FilterCountryName(_testCountries, "xc").Result;
            Assert.AreEqual(result.Count(), 0);

            Assert.ThrowsAsync<NullReferenceException>(() => _service.FilterCountryName(_testCountries, null));
        }

        [Test]
        public void CheckFilterCountryWithPopulationLess()
        {
            var result = _service.FilterCountryWithPopulationLess(_testCountries, 1).Result;
            Assert.AreEqual(result.Count(), 0);

            result = _service.FilterCountryWithPopulationLess(_testCountries, 20).Result;
            Assert.AreEqual(result.Count(), 3);

            result = _service.FilterCountryWithPopulationLess(_testCountries, 19).Result;
            Assert.AreEqual(result.Count(), 2);

            result = _service.FilterCountryWithPopulationLess(_testCountries, 50).Result;
            Assert.AreEqual(result.Count(), 4);

            Assert.ThrowsAsync<ArgumentException>(() => _service.FilterCountryWithPopulationLess(_testCountries, -10));
        }

        [Test]
        public void CheckSortCountries()
        {
            var result = _service.SortCountries(_testCountries, SortTypes.ascend).Result;
            Assert.AreEqual(result.Count(), 4);
            Assert.AreEqual(result.First().Name.Common, "Andorra");
            Assert.AreEqual(result.Last().Name.Common, "Spain");

            result = _service.SortCountries(_testCountries, 0).Result;
            Assert.AreEqual(result.Count(), 4);
            Assert.AreEqual(result.First().Name.Common, "Andorra");
            Assert.AreEqual(result.Last().Name.Common, "Spain");

            result = _service.SortCountries(_testCountries, SortTypes.descend).Result;
            Assert.AreEqual(result.Count(), 4);
            Assert.AreEqual(result.First().Name.Common, "Spain");
            Assert.AreEqual(result.Last().Name.Common, "Andorra");
        }

        [Test]
        public void CheckSelectCountries()
        {
            var result = _service.SelectCountries(_testCountries, 1).Result;
            Assert.AreEqual(result.Count(), 1);

            result = _service.SelectCountries(_testCountries, 4).Result;
            Assert.AreEqual(result.Count(), 4);

            result = _service.SelectCountries(_testCountries, 200).Result;
            Assert.AreEqual(result.Count(), _testCountries.Count());

            Assert.ThrowsAsync<ArgumentException>(() => _service.SelectCountries(_testCountries, -10));
        }
    }
}
