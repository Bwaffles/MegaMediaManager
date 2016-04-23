using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Newtonsoft.Json;

namespace MegaMediaManager.Model
{
    public class Cast : DomainEntity<int>
    {
        //id is the person id.. how to map this....

        [JsonProperty("cast_id")]
        public int CastId;

        [JsonProperty("character")]
        public string Character;

        [JsonProperty("credit_id")]
        public string CreditId;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("order")]
        public int Order;

        [JsonProperty("profile_path")]
        public string ProfilePath;
    }
}
