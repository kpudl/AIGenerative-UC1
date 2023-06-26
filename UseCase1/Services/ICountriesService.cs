using UseCase1.Models.RestCountry;

namespace UseCase1.Services
{
    public interface ICountriesService<T>
    {
        IEnumerable<T> FilterCountryWithPopulationLess(IEnumerable<T> inputList, uint populationInMil);

        IEnumerable<T> FilterCountryName(IEnumerable<T> inputList, string countryName);

        IEnumerable<T> SortCountries(IEnumerable<T> inputList, SortTypes sortType);

        IEnumerable<T> SelectCountries(IEnumerable<T> inputList, int numbersOfRecordsShown);
    }
}
