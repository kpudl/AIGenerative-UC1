namespace UseCase1.Services
{
    public interface IRestCountriesService<T>
    {
        Task<IEnumerable<T>> GetCountries();
    }
}
