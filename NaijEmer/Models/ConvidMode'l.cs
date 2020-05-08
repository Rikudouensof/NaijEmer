using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaijEmer.Models
{
    class ConvidMode_l
    {
    }


    public class Rootobject
    {
        public Class3[] Property1 { get; set; }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Class3
    {
        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "CountryCode")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "Province")]
        public string Province { get; set; }

        [JsonProperty(PropertyName = "City")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "CityCode")]
        public string CityCode { get; set; }

        [JsonProperty(PropertyName = "Lat")]
        public string Lat { get; set; }

        [JsonProperty(PropertyName = "Lon")]
        public string Lon { get; set; }


        [JsonProperty(PropertyName = "Confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty(PropertyName = "Deaths")]
        public int Deaths { get; set; }

        [JsonProperty(PropertyName = "Recovered")]
        public int Recovered { get; set; }

        [JsonProperty(PropertyName = "Active")]
        public int Active { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public DateTime Date { get; set; }
    }


}
