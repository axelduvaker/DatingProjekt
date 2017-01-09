using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingProjekt.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Fyll i ett förnamn!")]
        [Display(Name = "Förnamn")]
        [RegularExpression(@"[a-zåäöA-ZÅÄÖ \-]+", ErrorMessage = "Endast bokstäver!")]
        public string Förnamn { get; set; }

        [Required(ErrorMessage = "Fyll i ett efternamn!")]
        [Display(Name = "Efternamn")]
        [RegularExpression(@"[a-zåäöA-ZÅÄÖ \-]+", ErrorMessage = "Endast bokstäver!")]
        public string Efternamn { get; set; }

        [Required(ErrorMessage = "Fyll i ett användarnamn!")]
        [Display(Name = "Användarnamn")]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9]*$", ErrorMessage = "Endast nummer och/eller bokstäver tack! Inte heller Å, Ä eller Ö.")]
        [Remote("uniktNamn", "Account", HttpMethod = "POST", ErrorMessage = "Detta användarnamn finns redan!")]
        public string Användarnamn { get; set; }

        [Required(ErrorMessage = "Vänligen ange ett kön!")]
        [Display(Name = "Kön")]
        public bool Kön { get; set; }

        [Required(ErrorMessage = "Ange din ålder!")]
        [Display(Name = "Ålder")]
        [RegularExpression(@"^(0?[1-9]|[1-9][0-9])$", ErrorMessage = "Du måste vara mellan 1 och 100 år!")]
        public string Ålder { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lösenordet måste vara minst sex tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Lösenord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [System.Web.Mvc.Compare("Lösenord", ErrorMessage = "Lösenorden matchar ej varandra.")]
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