﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLager.Repositories
{
    public class UserRepository : IDisposable
    {
        public DataBasEntities Context { get; set; }

        public UserRepository()
        {
            this.Context = new DataBasEntities();
        }

        public List<Änder> RandomProfiler()
        {
            var random = new List<Änder>();
            var lista = Context.Änder.OrderBy(x => Guid.NewGuid()).ToList();
            random.Add(lista[0]);
            random.Add(lista[1]);
            random.Add(lista[2]);
            random.Add(lista[3]);
            return random;
        }

        public void Save()
        {
        Context.SaveChanges();
        }

        public bool användareFinns(string användarnamn)
        {
                return Context.Änder.Any(x => x.Användarnamn == användarnamn);
            
        }
        public bool finnsLösen(string lösenord)
        {
            return Context.Änder.Any(x => x.Lösenord == lösenord);
        }
        public Änder loggaIn(string userName, string password)
        {
            var user = Context.Änder.FirstOrDefault(x => x.Förnamn.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                                                        x.Lösenord.Equals(password, StringComparison.OrdinalIgnoreCase));

            return user;
        }

        public Änder HamtaAnd(string användarnamn)
        {
            return Context.Änder.FirstOrDefault(x => x.Användarnamn.Equals(användarnamn));
        }

        public bool kollaOmUnikt(string namn)
        {
            var ejUnikt = HamtaAnd(namn);
            return ejUnikt == null;
        }

        public string Användarnamn(int id)
        {
            var användare = Context.Änder.FirstOrDefault(x => x.id.Equals(id));
            var användarnamn = användare.Användarnamn;
                return användarnamn;
        }

        public Änder hamtaAnvändarID(int id)
        {
            return Context.Änder.FirstOrDefault(x => x.id == id);
        }

        public void läggTillAnvändare(Änder and)
        {
            Context.Änder.Add(and);
            Save();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
