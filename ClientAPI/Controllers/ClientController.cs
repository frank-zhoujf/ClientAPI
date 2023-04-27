using ClientAPI.Models;
using ClientAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        public ClientController(IClientService _clientService)
        {
            clientService = _clientService;
        }

        [HttpGet("clientlist")]
        public IEnumerable<Client> ClientList()
        {
            var clientList = clientService.GetClientList();
            return clientList;
        }

        [HttpGet("getclientbyid")]
        public Client GetClientById(int Id)
        {
            return clientService.GetClientById(Id);
        }

        [HttpPost("addclient")]
        public Client AddClient(Client client)
        {
            return clientService.AddClient(client);
        }

        [HttpPut("updateclient")]
        public Client UpdateClient(Client client)
        {
            return clientService.UpdateClient(client);
        }

        [HttpDelete("deleteclient")]
        public bool DeleteClient(int Id)
        {
            return clientService.DeleteClient(Id);
        }
    }
}
