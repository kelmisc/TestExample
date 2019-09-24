using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExample.Models
{
    [JsonObject]
    [Serializable]
    public class UserDataContainer
    {
        [JsonProperty("data")]
        public User User { get; set; }
    }
}
