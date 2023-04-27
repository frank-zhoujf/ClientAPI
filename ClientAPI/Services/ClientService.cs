using ClientAPI.Data;
using ClientAPI.Models;

namespace ClientAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly DbContextClass _dbContext;

        public ClientService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public Client AddClient(Client client)
        {
            var result = _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteClient(int Id)
        {
            var client = _dbContext.Clients.Where(x => x.ClientId == Id).FirstOrDefault();
            var result = _dbContext.Remove(client);
            _dbContext.SaveChanges();
            return result != null;
        }

        public Client GetClientById(int id)
        {
            return _dbContext.Clients.Where(x => x.ClientId == id).FirstOrDefault();
        }

        public IEnumerable<Client> GetClientList()
        {
            return _dbContext.Clients.ToList();
        }

        public Client UpdateClient(Client client)
        {
            var result = _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
