﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Newtonsoft.Json;

namespace MegaMediaManager.Model
{
    public class Genre : DomainEntity<int>
    {
        [JsonProperty("name")]
        public string Name;
    }
}