using Newtonsoft.Json;
using UseCase1.Models;

namespace UseCase1.Services
{
    public class RestCountriesService: IRestCountriesService<RestCountryDto>
    {
        private string _url;

        public RestCountriesService(IConfiguration configuration)
        {
            _url = configuration.GetValue<string>("CountriesFileUrl");
        }


        public async Task<IEnumerable<RestCountryDto>> GetCountries()
        {
            var result = new List<RestCountryDto>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_url);
                if (response.IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<RestCountryDto>>(stringResult);
                    return result;
                }

                throw new HttpRequestException("Call to REST Countries was not successsfull. Try again later.");
            }
        }
    }
}
