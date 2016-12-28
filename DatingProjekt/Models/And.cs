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
        public virtual string Kön { get; set; }
        public virtual string Ålder { get; set; }
        public virtual string Lösenord { get; set; }
        public virtual string Användarnamn { get; set; }
        public string Profilbild { get; set; }
    }
}