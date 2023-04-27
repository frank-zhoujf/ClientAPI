using ClientAPI.Models;

namespace ClientAPI.Services
{
    public interface IClientService
    {
        public IEnumerable<Client> GetClientList();
        public Client GetClientById(int id);
        public Client AddClient(Client client);
        public Client UpdateClient(Client client);
        public bool DeleteClient(int Id);
    }
}
