using Newtonsoft.Json;
using UseCase1.Models.RestCountry;

namespace UseCase1.Models
{
    public class RestCountryDto
    {
        public NameDto Name { get; set; }

        public IEnumerable<string> Tld { get; set; }

        [JsonProperty("Cca2")]
        public string CountryCodeAlfa2 { get; set; }


        [JsonProperty("Ccn3")]
        public string CountryNumericCode { get; set;}


        [JsonProperty("Cca3")]
        public string CountryCodeAlfa3 { get; set; }


        [JsonProperty("Cioc")]
        public string OlimpicCountryCode { get; set; }

        public bool Independent { get; set; }

        public string Status { get; set; }

        public bool UnMember { get; set; }

        public Dictionary<string, CurrencyDto> Currencies { get; set; }

        public IddDto Idd { get; set; }

        public IEnumerable<string> Capital { get; set; }

        public IEnumerable<string> AltSpellings { get; set; }

        public string Region { get; set; }

        public string SubRegion { get; set; }

        public Dictionary<string, string> Languages { get; set; }

        public Dictionary<string, TranslationDto> Translations { get; set; }

        public IEnumerable<decimal> Latlng { get; set; }

        public bool Landlocked { get; set; }

        public List<string> Borders { get; set; }

        public decimal Area { get; set; }

        public Dictionary<string, DemonymDto> Demonyms { get; set; }

        public string Flag { get; set; }

        public MapsDto Maps { get; set; }

        public ulong Population { get; set; }

        public KeyValuePair<string, decimal> Gini{ get; set; }


        [JsonProperty("fifa")]
        public string FifaCountryCode { get; set; }

        public CarDto Car { get; set; }

        public List<string> Timezones { get; set; }

        public List<string> Continents { get; set; }

        public FlagDto Flags { get; set; }

        public Picture CoatOfArms { get; set; }

        public string StartOfWeek { get; set; }

        public CapitalInfoDto CapitalInfo { get; set; }

        public PostalCodeDto PostalCode { get; set; }
    }
}
