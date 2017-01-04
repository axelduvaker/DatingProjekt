using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatingProjekt.Models;
using DataLager.Repositories;

namespace DatingProjekt.APIControllers
{
    public class MessageController : ApiController
    {
        public UserRepository _userRepository { get; set; }
        public MeddelandeRepository _meddelandeRepository { get; set; }
        public MessageController()
        {
            this._userRepository = new UserRepository();
            this._meddelandeRepository = new MeddelandeRepository();
        }

        [HttpPost]
        public void PostMessage(string recieverUsername, string Message)
        {
            var userRepo = new UserRepository();
            _meddelandeRepository.nyttMeddelande(userRepo.HamtaAnd(User.Identity.Name),
                userRepo.HamtaAnd(recieverUsername).id, Message);
        }

        [HttpGet]
        public MeddelandeListaModel hamtaMeddelanden(string and)
        {
            var lista = new MeddelandeListaModel();
            var allaMeddelanden = MeddelandeRepository.allaMeddelanden(_userRepository.HamtaAnd(and));
            var Meddelanden = new List<MeddelandeModel>();
            foreach (var m in allaMeddelanden)
            {
                var model = new MeddelandeModel();
                model.MeddelandeID = m.Id;
                model.Meddelanden = m.Meddelande;
                model.AvsändarID = m.AvsändarID;
                model.MottagarID = m.MottagarID;
                model.AvsändarNamn = _userRepository.Användarnamn(model.AvsändarID);
                Meddelanden.Add(model);
            }
            lista.Meddelanden = Meddelanden;
            return lista;
        }

        [HttpGet]
        public string Användarnamn(int id)
        {
            var userRepo = new DataLager.Repositories.UserRepository();
            var fullName = userRepo.Användarnamn(id);
            return fullName;
        }
    }
}