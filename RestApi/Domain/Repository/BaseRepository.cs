using Dapper;
using Microsoft.Data.SqlClient;

namespace Domain.Repository
{
    public class BaseRepository<T> where T : class
    {
        private readonly string _connectionString;

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<T> Get(string query)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query).ToList();
        }

        public T Get(string query, Object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<T>(query, parameters);
        }

        public void Create(string query, Object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, parameters);
        }

        public void Update(string query, Object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, parameters);
        }

        public void Delete(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, parameters);
        }
    }
}
