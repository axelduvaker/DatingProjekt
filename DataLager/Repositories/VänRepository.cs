using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLager.Repositories
{
    public class VänRepository
    {
        public DataBasEntities Context { get; set; }

        public VänRepository()
        {
            this.Context = new DataBasEntities();
        }

        public void VänFörfrågan(Änder förfrågan, Änder mottagare)
        {
            var and = new Vänner();
            and.Frågande = förfrågan.id;
            and.Mottagande = mottagare.id;
            and.Accepterad = false;
            Context.Vänner.Add(and);
            Context.SaveChanges();
        }

        public void SvaraFörfrågan(int förfrågan, int mottagare, bool svar)
        {
            var vänförfrågan = Context.Vänner.FirstOrDefault(x => x.Frågande == förfrågan && x.Mottagande == mottagare);

            if (svar)
            {
                vänförfrågan.Accepterad = true;
                Context.SaveChanges();
            }
            else
            {
                Context.Vänner.Remove(vänförfrågan);
                Context.SaveChanges();
            }
        }

        public static List<Änder> AllaVänner(Änder änder)
        {
            var lista = new List<Änder>();
            using (var context = new DataBasEntities())
            {
                var hamtadeVanner =
                from hamtat in context.Vänner
                where (hamtat.Mottagande == änder.id || hamtat.Frågande == änder.id) && hamtat.Accepterad
                select hamtat;
                using (var userRep = new UserRepository())
                {
                    foreach (var item in hamtadeVanner)
                    {
                        if (item.Mottagande == änder.id)
                        {
                            var and = userRep.GetUserID(item.Frågande);
                            if (and.Aktiv == true)
                            {
                                lista.Add(and);
                            }
                        }
                        else
                        {
                            var annanand = userRep.GetUserID(item.Mottagande);
                            if (annanand.Aktiv == true)
                            {
                                lista.Add(annanand);
                            }
                        }
                    }
                    
                }
            }
            return lista;
        }
        public List<Vänner> AktivaFörfrågningar(Änder and)
        {

            var hamtadAnd = from f in Context.Vänner.Include("FrågandeAnd")
                         where f.Mottagande == and.id
                               && f.Accepterad == false
                         select f;

            return hamtadAnd.ToList();
        }

        public bool seAktiva(Änder and)
        {
            var lista = new List<Vänner>();
            var hamtad = from vänner in Context.Vänner
                         where vänner.Frågande == and.id && vänner.Accepterad == false
                         select vänner;
            
            foreach(var sak in hamtad)
            {
                lista.Add(sak);
            }
            return lista.Count > 0;
        }
    }
}
