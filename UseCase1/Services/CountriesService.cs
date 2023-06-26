using UseCase1.Models;
using UseCase1.Models.RestCountry;

namespace UseCase1.Services
{
    public class CountriesService : ICountriesService<RestCountryDto>
    {
        private const int Milion = 1000000;

        public async Task<IEnumerable<RestCountryDto>> FilterCountryName(IEnumerable<RestCountryDto> inputList, string countryName)
        {
            if (countryName == null)
                throw new NullReferenceException("Filter parameter is null");

            return inputList.Where(x => x.Name.Common.Contains(countryName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<RestCountryDto>> FilterCountryWithPopulationLess(IEnumerable<RestCountryDto> inputList, int populationInMil)
        {
            if (populationInMil < 0)
                throw new ArgumentException("Filter parameter cannot be less then 0");

            var maxPopulation = populationInMil * Milion;
            return inputList.Where(x => x.Population < maxPopulation);
        }

        public async Task<IEnumerable<RestCountryDto>> SelectCountries(IEnumerable<RestCountryDto> inputList, int numbersOfRecordsShown)
        {
            if (numbersOfRecordsShown < 0)
                throw new ArgumentException("Select parameter cannot be less then 0");

            return inputList.Take(numbersOfRecordsShown);
        }

        public async Task<IEnumerable<RestCountryDto>> SortCountries(IEnumerable<RestCountryDto> inputList, SortTypes sortType)
        {
            return sortType == SortTypes.ascend ?
                inputList.OrderBy(x => x.Name.Common)
                : inputList.OrderByDescending(x => x.Name.Common);
        }
    }
}
