using UseCase1.Models;
using UseCase1.Models.RestCountry;

namespace UseCase1.Services
{
    public class CountriesService : ICountriesService<RestCountryDto>
    {
        private const int Milion = 1000000;

        public IEnumerable<RestCountryDto> FilterCountryName(IEnumerable<RestCountryDto> inputList, string countryName)
        {
            if (countryName == null)
                throw new NullReferenceException("Filter parameter is null");

            return inputList.Where(x => x.Name.Common.Contains(countryName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<RestCountryDto> FilterCountryWithPopulationLess(IEnumerable<RestCountryDto> inputList, uint populationInMil)
        {
            if (populationInMil < 0)
                throw new ArgumentException("Filter parameter cannot be less then 0");

            var maxPopulation = populationInMil * Milion;
            return inputList.Where(x => x.Population < maxPopulation);
        }

        public IEnumerable<RestCountryDto> SelectCountries(IEnumerable<RestCountryDto> inputList, int numbersOfRecordsShown)
        {
            if (numbersOfRecordsShown < 0)
                throw new ArgumentException("Select parameter cannot be less then 0");

            return inputList.Take(numbersOfRecordsShown);
        }

        public IEnumerable<RestCountryDto> SortCountries(IEnumerable<RestCountryDto> inputList, SortTypes sortType)
        {
            return sortType == SortTypes.ascend ?
                inputList.OrderBy(x => x.Name.Common)
                : inputList.OrderByDescending(x => x.Name.Common);
        }
    }
}
