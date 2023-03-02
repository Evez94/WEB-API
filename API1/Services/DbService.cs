using Dapper;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace API1.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _dbConnection;

        public DbService(IConfiguration configuration)
        {
             _dbConnection = new NpgsqlConnection(configuration.GetConnectionString("Employeedb"));
          // SqlConnection _dbConnection = new SqlConnection(configuration.GetConnectionString("Empdb"));
        }
        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _dbConnection.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;
        }
        public async Task<List<T>> GetAll<T>(string command, object parms)
        {

            List<T> result = new List<T>();
            result = (await _dbConnection.QueryAsync<T>(command, parms)).ToList();
            return result;
        }

        public async Task<int> EditData(string command, object parms)
        {
            int result;
            result = await _dbConnection.ExecuteAsync(command, parms);
            return result;
        }

       

       
    }
}
