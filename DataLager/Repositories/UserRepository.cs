using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLager.Repositories
{
    public class UserRepository
    {
        public DataBasEntities Context { get; set; }

        public UserRepository()
        {
            this.Context = new DataBasEntities();
        }

        public void Save()
        {
        Context.SaveChanges();
        }

        public bool UserExists(string fornamn)
        {
                return Context.Änder.Any(x => x.Förnamn == fornamn);
            
        }

        public Änder Get(string förnamn)
        {
                return Context.Änder.FirstOrDefault(x => x.Förnamn == förnamn);
            
        }

        public List<Änder> GetAll()
        {
                return Context.Änder.ToList();
        }

        public void AddAnd(Änder and)
        {
            Context.Änder.Add(and);
            Save();
        }
    }
}
