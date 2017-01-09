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

        public static bool kollaOmVänner(string and1, string and2)
        {
            var _userRepository = new UserRepository();
            var skickande = _userRepository.HamtaAnd(and1).id;
            var mottagande = _userRepository.HamtaAnd(and2).id;

            using (var db = new DataBasEntities())
            {
                var änder = from vän in db.Vänner //Raden under kollar alla kombinationer så att man verkligen ser så att de är vänner.
                            where vän.Frågande == skickande && vän.Mottagande == mottagande || vän.Frågande == mottagande && vän.Mottagande == skickande
                            select vän;
                return änder.ToList().Count > 0;
            }
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

        public static List<Änder> AllaVänner(Änder änder) //Hämtar alla vänner som har accepterat din vänförfrågan.
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
                            var and = userRep.hamtaAnvändarID(item.Frågande);
                            if (and.Aktiv == true)
                            {
                                lista.Add(and);
                            }
                        }
                        else
                        {
                            var annanand = userRep.hamtaAnvändarID(item.Mottagande);
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
            //Hämtar förfrågningar via entitetsmodellen med propertyn "FrågandeAnd"
            var hamtadAnd = from f in Context.Vänner.Include("FrågandeAnd")
                         where f.Mottagande == and.id
                               && f.Accepterad == false
                         select f;

            return hamtadAnd.ToList();
        }
    }
}
