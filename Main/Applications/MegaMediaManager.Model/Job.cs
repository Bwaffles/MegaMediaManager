using System;
using System.Collections.Generic;
using Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMediaManager.Model
{
    public class Job : ValueObject<Job>
    {
        [JsonProperty("job")]
        public string Job;

        public int DepartmentName;

        [ForeignKey("DepartmentName")]
        public Department Department;
    }
}
