using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatingProjekt.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Användarnamn")]
        public string Användarnamn { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Lösenord { get; set; }

        [Display(Name = "Kom ihåg mig")]
        public bool RememberMe { get; set; }
        public string ErrorMessage { get; set; }
    }
}