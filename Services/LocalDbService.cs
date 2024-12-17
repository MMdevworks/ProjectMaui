using ProjectMaui.Models;
using SQLite;


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
        // todo try catch
        public async Task<List<Client>> GetClients()
        {
            return await connection.Table<Client>().ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await connection.Table<Client>().Where(x => x.Id == id).FirstOrDefaultAsync();
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
