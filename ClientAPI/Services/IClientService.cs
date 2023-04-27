using ClientAPI.Models;

namespace ClientAPI.Services
{
    public interface IClientService
    {
        public Task<IEnumerable<Client>> GetClientListAsync();
        public Task<Client> GetClientByIdAsync(int id);
        public Task<Client> AddClientAsync(Client client);
        public Task<Client> UpdateClientAsync(Client client);
        public Task<bool> DeleteClientAsync(int Id);
    }
}
