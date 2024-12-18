using ProjectMaui.Models;
using SQLite;


namespace ProjectMaui.Services
{
    public class LocalDbService
    {
        private const string DB_NAME = "clients_localdb.db3";
        private readonly SQLiteAsyncConnection connection;
        public LocalDbService() 
        { 
            connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            connection.CreateTableAsync<Client>();
            //connection.CreateTableAsync<Exercise>();
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

        //public async Task<List<Exercise>> GetExercises()
        //{
        //    return await connection.Table<Exercise>().ToListAsync();
        //}

        //public async Task<List<Exercise>> GetExercisesByClientId(int clientId)
        //{
        //    return await connection.Table<Exercise>().Where(x => x.clientId == clientId).ToListAsync();
        //}

        //public async Task AddExercise(Exercise exercise)
        //{
        //    await connection.InsertAsync(exercise);
        //}

        //public async Task UpdateExercise(Exercise exercise)
        //{
        //    await connection.UpdateAsync(exercise);
        //}

        //public async Task DeleteExercise(Exercise exercise)
        //{
        //    await connection.DeleteAsync(exercise);
        //}
    }
}

