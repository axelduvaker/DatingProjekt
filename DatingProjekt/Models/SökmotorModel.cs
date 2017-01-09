using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataLager;

namespace DatingProjekt.Controllers
{
    public class SökmotorModel
    {
        [Display(Name = "Fyll i användarnamnet här.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ett tomt sökfält kommer returnera alla användare!")]
        public string SökText { get; set; }
        public List<Änder> HittadAnd { get; set; }
    }
}