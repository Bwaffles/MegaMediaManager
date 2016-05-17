using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MegaMediaManager.Model
{
    public class MovieKeywords
    {
        public int Id { get; set; }

        [JsonProperty("keywords")]
        public virtual List<Keyword> Keywords { get; set; }
    }
}
