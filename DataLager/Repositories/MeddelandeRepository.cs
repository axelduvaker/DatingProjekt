using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLager.Repositories
{
    public class MeddelandeRepository
    {
        public DataBasEntities Context { get; set; }

        public MeddelandeRepository()
        {
            this.Context = new DataBasEntities();
        }
        public void nyttMeddelande(Änder and, int mottagarid, string meddelande) //Skickar ett meddelande till en användares vägg.
        {
            var avsändarid = and.id;

            var medis = new Meddelanden();
            medis.Meddelande = meddelande;
            medis.AvsändarID = avsändarid;
            medis.MottagarID = mottagarid;
            Context.Meddelanden.Add(medis);
            Context.SaveChanges();

        }
        public static List<Meddelanden> allaMeddelanden(Änder and) //Hämtar alla meddelanden som finns i databasen som mottagaren har fått.
        {
            using (var databas = new DataBasEntities())
            {
                var meddelanden = from mottagare in databas.Meddelanden
                             where mottagare.MottagarID == and.id
                             select mottagare;
                return meddelanden.ToList();
            }
        }

    }
}
