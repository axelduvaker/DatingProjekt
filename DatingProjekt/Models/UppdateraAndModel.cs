using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatingProjekt.Models
{
    public class UppdateraAndModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Fyll iditt förnamn.")]
        [RegularExpression(@"[a-zA-Z \-]+", ErrorMessage = "Ditt förnamn kan bara bestå av bokstäver.")]
        public string Förnamn { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Fyll i ditt efternamn.")]
        [RegularExpression(@"[a-zA-Z \-]+", ErrorMessage = "Ditt efternamn kan bara bestå av bokstäver.")]
        public string Efternamn { get; set; }

        [Required(ErrorMessage = "Välj ditt kön.")]
        [Display(Name = "Kön")]
        [RegularExpression(@"[a-zA-Z \-]+", ErrorMessage = "Ej giltigt kön.")]
        public bool Kön { get; set; }

        [Required(ErrorMessage = "Välj en ålder mellan 1 och 100.")]
        [RegularExpression(@"^(0?[1-9]|[1-9][0-9])$", ErrorMessage = "Du kan inte var yngre än 1 eller äldre än 100.")]
        [Display(Name = "Ålder")]
        public string Ålder { get; set; }

        [StringLength(100, ErrorMessage = "Lösenordet måste ha minst 6 tecken.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Fyll i ett lösenord.")]
        [Display(Name = "Lösenord")]
        public string Lösenord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenord")]
        [Compare("Lösenord", ErrorMessage = "Lösenordet stämmer inte överens med ovanstående.")]
        public string BekräftaLösenord { get; set; }

        [Display(Name = "Beskrivning")]
        [Required(ErrorMessage = "Skriv en kort beskrivning om dig själv.")]
        [StringLength(250, ErrorMessage = "Beskrivningen får inte vara längre än 250 tecken.", MinimumLength = 0)]
        public string Beskrivning { get; set; }

        [Required(ErrorMessage = "Du måste välja ett alternativ.")]
        [Display(Name = "Intresserad av hane")]
        public bool IntresseradAvHane { get; set; }

        [Required(ErrorMessage = "Du måste välja ett alternativ.")]
        [Display(Name = "Intresserad av hona")]
        public bool IntresseradAvHona { get; set; }

        [Display(Name = "Active")]
        [Required(ErrorMessage = "Välj om du vill vara aktiv eller inte.")]
        public bool Aktiv { get; set; }

        [Display(Name = "Visible")]
        [Required(ErrorMessage = "Välj om du vill kunna bli hittad av andra användare.")]
        public bool Allmän { get; set; }
    }
}