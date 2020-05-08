using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaijEmer.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    class EmergencyContactCLass
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Phone")]
        public string Phone { get; set; }


        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }


        [JsonProperty(PropertyName = "DateCreated")]
        public string DateCreated { get; set; }


        [JsonProperty(PropertyName = "Area")]
        public string Area { get; set; }


        [JsonProperty(PropertyName = "State")]
        public string State { get; set; }
    }
}
