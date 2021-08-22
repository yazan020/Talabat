using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TalabatApi.Domain.Model
{
    public class UserData
    {
        [Key]
        public int id { get; set; }


        [JsonProperty("latitude")]
        public long UserLat { get; set; }

        [JsonProperty("longitude")]
        public long UserLong { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("region_name")]
        public string RegionName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}