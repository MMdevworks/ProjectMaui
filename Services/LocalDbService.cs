using ProjectMaui.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaui.Services
{
    public class LocalDbService
    {
        private const string DB_NAME = "clients_local_db.db3";
        private readonly SQLiteAsyncConnection connection;
        public LocalDbService() 
        { 
            connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            connection.CreateTableAsync<Client>();
        }

        public async Task<List<Client>> GetClients()
        {
            return await connection.Table<Client>().ToListAsync();
        }

        public async Task<Client> GetClientById(string name)
        {
            return await connection.Table<Client>().Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task CreateClient(Client client)
        {
            await connection.InsertAsync(client);
        }

        public async Task UpdateClient(Client client)
        {
            await connection.UpdateAsync(client);
        }
        public async Task DeleteClient(Client client)
        {
            await connection.DeleteAsync(client);
        }
    }
}
