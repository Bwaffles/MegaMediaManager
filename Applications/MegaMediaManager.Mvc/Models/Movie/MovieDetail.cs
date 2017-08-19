using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaMediaManager.Mvc.Models.Movie
{
    public class MovieDetail
    {
        public string Title { get; set; }
        public int Id { get; set;}
        public bool Adult { get; set; }
    }
}