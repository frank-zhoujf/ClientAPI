using ClientAPI.Models;
using ClientAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<Client>> ClientListAsync()
        {
            var clientList = await clientService.GetClientListAsync();
            return clientList;
        }

        [HttpGet("getclientbyid")]
        public async Task<Client> GetClientByIdAsync(int Id)
        {
            return await clientService.GetClientByIdAsync(Id);
        }

        [HttpPost("addclient")]
        public async Task<Client> AddClientAsync(Client client)
        {
            return await clientService.AddClientAsync(client);
        }

        [HttpPut("updateclient")]
        public async Task<Client> UpdateClientAsync(Client client)
        {
            return await clientService.UpdateClientAsync(client);
        }

        [HttpDelete("deleteclient")]
        public async Task<bool> DeleteClientAsync(int Id)
        {
            return await clientService.DeleteClientAsync(Id);
        }
    }
}
