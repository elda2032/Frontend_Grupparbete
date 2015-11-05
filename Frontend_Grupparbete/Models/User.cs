using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;

namespace Frontend_Grupparbete.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Profession { get; set; }

        public int Income { get; set; }

    }
}