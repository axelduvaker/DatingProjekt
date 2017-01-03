using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLager.Repositories
{
    public class UppdateraAndRepository
    {

        public void UpdateAnd(string currentUser, Änder and)
        {
            using (var DataBasDB = new DataBasEntities())
            {
                Änder currentAnd = DataBasDB.Änder.FirstOrDefault(x => x.Användarnamn == currentUser);

                currentAnd.Förnamn = and.Förnamn;
                currentAnd.Efternamn = and.Efternamn;
                currentAnd.Kön = and.Kön;
                currentAnd.Ålder = and.Ålder;
                currentAnd.Användarnamn = and.Användarnamn;
                currentAnd.Lösenord = and.Lösenord;
                currentAnd.Beskrivning = and.Beskrivning;
                currentAnd.IntresseradAvHona = and.IntresseradAvHona;
                currentAnd.IntresseradAvHane = and.IntresseradAvHane;
                currentAnd.Aktiv = and.Aktiv;
                currentAnd.Allmän = and.Allmän;

                DataBasDB.SaveChanges();
            }
        }
    }
}
