using UseCase1.Models;
using UseCase1.Models.RestCountry;

namespace UseCase1.Services
{
    public interface ICountriesService<T>
    {
        Task<IEnumerable<T>> FilterCountryWithPopulationLess(IEnumerable<T> inputList, int populationInMil);

        Task<IEnumerable<T>> FilterCountryName(IEnumerable<T> inputList, string countryName);

        Task<IEnumerable<T>> SortCountries(IEnumerable<T> inputList, SortTypes sortType);

        Task<IEnumerable<T>> SelectCountries(IEnumerable<T> inputList, int numbersOfRecordsShown);
    }
}
