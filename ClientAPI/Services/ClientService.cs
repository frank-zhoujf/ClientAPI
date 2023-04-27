using ClientAPI.Data;
using ClientAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly DbContextClass _dbContext;

        public ClientService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            var result = await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteClientAsync(int Id)
        {
            var client = _dbContext.Clients.Where(x => x.ClientId == Id).FirstOrDefault();
            var result = _dbContext.Remove(client);
            await _dbContext.SaveChangesAsync();
            return result != null;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await Task.FromResult(_dbContext.Clients.Where(x => x.ClientId == id).FirstOrDefault());
        }

        public async Task<IEnumerable<Client>> GetClientListAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            var result = _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
