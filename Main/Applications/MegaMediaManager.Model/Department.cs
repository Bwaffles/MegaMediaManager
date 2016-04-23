using System;
using System.Collections.Generic;
using Infrastructure;
using Newtonsoft.Json;

namespace MegaMediaManager.Model
{
    public class Department : ValueObject<Department>
    {
        [JsonProperty("department")]
        public string Department;

        public ICollection<Job> Jobs;
    }
}
