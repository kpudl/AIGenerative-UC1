using Newtonsoft.Json;

namespace UseCase1.Models.RestCountry
{
    public class NameDto
    {
        public string Common { get; set; }

        public string Official { get; set; }

        [JsonProperty("nativeName")]
        public Dictionary<string, NativeNameDto> NativeNames { get; set; }
    }
}
