using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingProjekt.Models
{
    public class VisitModel
    {
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Användarnamn { get; set; }
        public string Beskrivning { get; set; }
        public string Ålder { get; set; }
        public string Profilbild { get; set; }
        public bool Kön { get; set; }
        public bool IntresseradAvHane { get; set; }
        public bool IntresseradAvHona { get; set; }
        public bool NuvarandeVän { get; set; }
    }
}