//using Dal.Models;
using Bl.BlModels;
//using Dal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bl;
using Bl.BlApi;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        IBlClientService BlClientService;
        public ClientsController(BlManager blManager)
        {
            BlClientService = blManager.Clients;
        }
        [HttpPost]
        public ActionResult<Bl.BlModels.Client> AddClient(Bl.BlModels.Client client)
        {
            return BlClientService.Add(client);
        }
        [HttpDelete("{clientId}")]
        public ActionResult<int> DeleteClient(int clientId)
        {
            return BlClientService.SuspendClient(clientId);
        }
        [HttpGet]
        public ActionResult<List<ClientForGet>> GetAll() {
            return BlClientService.GetClients();
        }
    }
}
