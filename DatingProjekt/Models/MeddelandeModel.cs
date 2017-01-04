using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingProjekt.Models
{
    public class MeddelandeModel
    {
        public int MeddelandeID { get; set; }
        public int AvsändarID { get; set; }
        public int MottagarID { get; set; }
        public string Meddelanden { get; set; }
        public DateTime Datum { get; set; }
        public string AvsändarNamn { get; set; }
    }
}