using Dapper;
using Domain.Model.DataBase;
using Domain.Models.Request;
using Domain.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Domain.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly string _connectionString;
        public GenreRepository(IOptions<ConnectionStrings> connectionString) : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value.IMDBDB;
        }

        public void Create(GenreRequest genre)
        {
            string query = @"INSERT INTO [Genre]
                            VALUES (@Name)";

            var parameters = new { Name = genre.Name };
            Create(query, parameters);
        }

        public void Delete(int id)
        {
            string query = @"
                        DELETE
                        FROM [MoviesGenres]
                        WHERE GenreId = @Id

                        DELETE
                        FROM [Genre]
                        WHERE Id = @Id";

            Delete(query, new { Id = id });
        }

        public IList<Genre> Get()
        {
            string query = @"SELECT *
                        FROM [Genre]";

            return Get(query);
        }

        public Genre Get(int id)
        {
            string query = @"SELECT *
                            FROM [Genre]
                            WHERE Id = @Id";

            return Get(query, new { Id = id });
        }

        public List<Genre> MoviesGenres(int movieId)
        {
            var query = @"SELECT * FROM MoviesGenres mg INNER JOIN Genre g ON g.Id = mg.GenreId where MovieId = @Id";
            var parameters = new { Id = movieId };
            var connection = new SqlConnection(_connectionString);
            return connection.Query<Genre>(query, parameters).ToList();
        }

        public void Update(int id, GenreRequest genre)
        {
            string query = @"UPDATE [Genre]
                            SET [Id] = @Id
	                            ,[Name] = @Name
                            WHERE Id = @Id";

            var parameters = new { Id = genre.Id, Name = genre.Name };

            Update(query, parameters);
        }
    }
}
