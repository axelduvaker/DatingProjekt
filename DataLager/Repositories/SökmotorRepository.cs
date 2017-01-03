using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLager.Repositories
{
    public class SökmotorRepository : IDisposable
    {
        public DataBasEntities Context { get; set; }

        public SökmotorRepository()
        {
            Context = new DataBasEntities();
        }

        public List<Änder> sökMedAndNamn(string SökAndNamn)
        {
            if (SökAndNamn != "" && SökAndNamn == null)
            {
                return Context.Änder.Where(m => m.Aktiv == true).ToList();
            }
            var HittadAnd = new List<Änder>();

            var SökÄnder = from and in Context.Änder
                           where and.Förnamn.StartsWith(SökAndNamn.Trim())
                           && and.Allmän
                           && and.Aktiv == true
                           select and;
            foreach (var and in SökÄnder)
            {
                HittadAnd.Add(and);
            }

            return HittadAnd;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
