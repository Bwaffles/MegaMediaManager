using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MegaMediaManager.Model;

namespace MegaMediaManager.Mvc.Models
{
    public class DisplayUser
    {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name="Movies")]
        public virtual ICollection<UserMovie> UserMovies { get; set; }
    }
}