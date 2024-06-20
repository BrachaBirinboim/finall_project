using AutoMapper;
using Bl.BlApi;
using Bl.BlModels;
using Dal;
using Dal.DalApi;
using Dal.Models;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Blservices
{
    internal class BlClientService : IBlClientService
    {
        IClientService clientService;
        IMapper mapper;

        public BlClientService(DalManager dalManager,IMapper mapper)
        {
            clientService = dalManager.Clients;
            this.mapper = mapper;   

        }
        public Bl.BlModels.Client Add(Bl.BlModels.Client client)
        {
            Dal.Models.Client c = mapper.Map<Dal.Models.Client>(client);
            clientService.Add(c);
            return client;
        }

        public List<ClientForGet> GetClients()
        {
          
            //List<BlDietitian> blDietitians = new List<BlDietitian>();
            //var list = dietitianService.GetAll();
            //list.ForEach(d => blDietitians.Add(map.Map<Bl.BlModels.BlDietitian>(d)));
            //return blDietitians;
            List<ClientForGet> clientForGets = new List<ClientForGet>();
            var list = clientService.GetAll().Where(c => c.Active == true).ToList();
            list.ForEach(c => clientForGets.Add(mapper.Map<ClientForGet>(c)));
            return clientForGets;
        }

        public int SuspendClient(int id)
        {
            return clientService.SuspendClient(id);
        }
    }
}
