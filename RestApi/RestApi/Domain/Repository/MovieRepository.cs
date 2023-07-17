using Dapper;
using Domain.Model.DataBase;
using Domain.Models.Request;
using Domain.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Domain.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly string _connectionString;
        public MovieRepository(IOptions<ConnectionStrings> connectionString) : base(connectionString.Value.IMDBDB)
        {
            _connectionString = connectionString.Value.IMDBDB;
        }

        public void Create(MovieRequest movie)
        {

            var parameters = new
            {
                Name = movie.Name,
                Plot = movie.Plot,
                YearOfRelease = movie.YearOfRelease,
                Actors = movie.Actors,
                Genres = movie.Genres,
                ProducerId = movie.ProducerId,
                Poster = movie.Poster
            };

            using var connection = new SqlConnection(_connectionString);
            connection.Execute("sp_Add_Movie", parameters, commandType: CommandType.StoredProcedure);

        }

        public void Delete(int id)
        {
            string query = @"

                        DELETE
                        FROM [MoviesActors]
                        WHERE MovieId = @Id

                        DELETE
                        FROM [MoviesGenres]
                        WHERE MovieId = @Id

                        DELETE
                        FROM Movie
                        WHERE Id = @Id";

            Delete(query, new
            {
                Id = id
            });
        }

        public IList<Movie> Get()
        {
            string query = @"SELECT * FROM Movie";

            return Get(query);
        }

        public Movie Get(int id)
        {
            string query = @"Select * FROM Movie WHERE Id = @Id";

            var parameters = new { Id = id };
            return Get(query, parameters);
        }




        public void Update(int id, MovieRequest movie)
        {
            var parameters = new
            {
                Id = id,
                Name = movie.Name,
                Plot = movie.Plot,
                YearOfRelease = movie.YearOfRelease,
                Actors = movie.Actors,
                Genres = movie.Genres,
                ProducerId = movie.ProducerId,
                Poster = movie.Poster
            };

            using var connection = new SqlConnection(_connectionString);
            connection.Execute("sp_Update_Movie", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
