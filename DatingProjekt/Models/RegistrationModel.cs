using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatingProjekt.Models
{
    public class RegistrationModel
    {
        [Required]
        [Display(Name = "Förnamn")]
        public string Förnamn { get; set; }

        [Required]
        [Display(Name = "Efternamn")]
        public string Efternamn { get; set; }

        [Required]
        [Display(Name = "Användarnamn")]
        public string Användarnamn { get; set; }

        [Required]
        [Display(Name = "Kön")]
        public bool Kön { get; set; }

        [Required]
        [Display(Name = "Ålder")]
        public string Ålder { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Lösenord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Lösenord", ErrorMessage = "The password and confirmation password do not match.")]
        public string BekräftaLösenord { get; set; }
        public string ErrorMessage { get; set; }

        [Display(Name = "Beskrivning")]
        [StringLength(250, ErrorMessage = "Beskrivningen får inte vara längre än 250 tecken.", MinimumLength = 0)]
        public string Beskrivning { get; set; }

        [Required(ErrorMessage = "Du måste välja ett alternativ.")]
        [Display(Name = "Intresserad av hane")]
        public bool IntresseradAvHane { get; set; }

        [Required(ErrorMessage = "Du måste välja ett alternativ.")]
        [Display(Name = "Intresserad av hona")]
        public bool IntresseradAvHona { get; set; }
    }
}