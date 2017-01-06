using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingProjekt.Models
{
    public class And
    {
        public virtual int AndId { get; set; }
        public virtual string Förnamn { get; set; }
        public virtual string Efternamn { get; set; }
        public bool Kön { get; set; }
        public virtual string Ålder { get; set; }
        public virtual string Lösenord { get; set; }
        public string Användarnamn { get; set; }
        public string Profilbild { get; set; }
        public bool IntresseradAvHane { get; set; }
        public bool IntresseradAvHona { get; set; }
        public string Beskrivning { get; set; }
        public bool Aktiv { get; set; }
        public bool Allmän { get; set; }
    }
}