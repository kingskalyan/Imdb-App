using Dapper;
using Domain.Model.DataBase;
using Domain.Models.Request;
using Domain.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Domain.Repository
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly List<Review> _reviews = new List<Review>();
        private readonly string _connectionString;
        public ReviewRepository(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.IMDBDB)
        {
            _connectionString = connectionStrings.Value.IMDBDB;
        }
        public void Create(ReviewRequest review)
        {
            string query = @"INSERT INTO [Review]
                            VALUES(
	                            @Message
	                            ,@MovieId
	                            )";

            var parameters = new { Message = review.Message, MovieId = review.MovieId };

            Create(query, parameters);
        }

        public void Delete(int id)
        {
            string query = @"DELETE
                            FROM [Review]
                            WHERE Id = @Id";

            Delete(query, new { Id = id });
        }

        public IList<Review> Get(int movieId)
        {
            string query = @"SELECT *
                            FROM [Review] where MovieId = @movieId";

            var parameters = new { MovieId = movieId };
            using var connection = new SqlConnection(_connectionString);
            var result = connection.Query<Review>(query, parameters);
            return result.ToList();
        }

        public Review Get(int id, int movieId)
        {
            string query = @"SELECT *
                            FROM [Review]
                            WHERE Id = @Id AND MovieId = @movieId";

            using var connection = new SqlConnection(_connectionString);
            var parameters = new { Id = id, MovieId = movieId };
            var result = connection.Query<Review>(query, parameters);
            return result.FirstOrDefault();
        }

        public void Update(int id, ReviewRequest review)
        {
            string query = @"UPDATE Review
                            SET Id = @Id
	                            ,Message = @Message
	                            ,MovieId = @MovieId";

            var parameters = new { Id = id, MovieId = review.MovieId, Review = review.Message };

            Update(query, parameters);
        }
    }
}
