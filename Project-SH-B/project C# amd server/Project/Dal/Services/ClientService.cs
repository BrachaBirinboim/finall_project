using Dal.DalApi;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class ClientService : IClientService
    {

        NutritionInstitute nutritionContext;
        public ClientService(NutritionInstitute nutrition)
        {
            this.nutritionContext = nutrition;
        }
     
        public Client Add(Client client)
        {
            nutritionContext.Clients.Add(client);
            nutritionContext.SaveChanges();
            return client;
        }

        public List<Client> GetAll()
        {
           return nutritionContext.Clients.ToList();
        }

        public int SuspendClient(int id)
        {
           Client client=nutritionContext.Clients.FirstOrDefault(c => c.Id == id);
            client.Active = false;
            nutritionContext.SaveChanges();
            return id;

        }
    }
}
