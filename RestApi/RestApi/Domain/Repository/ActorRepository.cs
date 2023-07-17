using Domain.Model.DataBase;
using Domain.Models.Request;
using Domain.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Domain.Repository
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        private readonly string _connectionString;
        public ActorRepository(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.IMDBDB)
        {
            _connectionString = connectionStrings.Value.IMDBDB;
        }

        public void Update(int id, ActorRequest actor)
        {
            string query = @"UPDATE [Actor]
                            SET [Id] = @Id
	                            ,[Name] = @Name
	                            ,[Bio] = @Bio
	                            ,[DateOfBirth] = @DateOfBirth
	                            ,[Gender] = @Gender
                            WHERE Id = @Id";

            var parameters = new { Name = actor.Name, DateOfBirth = actor.DateOfBirth, Gender = actor.Gender, Bio = actor.Bio };

            Update(query, parameters);

        }

        public void Create(ActorRequest actor)
        {
            string query = @"INSERT INTO [Actor]
                            VALUES (
	                            @Name
	                            ,@Bio
	                            ,@DateOfBirth
	                            ,@Gender
	                            )";
            var parameters = new { Name = actor.Name, DateOfBirth = actor.DateOfBirth, Gender = actor.Gender, Bio = actor.Bio };

            Create(query, parameters);
        }


        public IList<Actor> Get()
        {
            string query = @"SELECT *
                            FROM [Actor]";

            return Get(query);
        }

        public Actor Get(int id)
        {
            string query = @"SELECT *
                            FROM [Actor]
                            WHERE Id = @Id";
            var res = Get(query, new { Id = id });
            return Get(query, new { Id = id });

        }

        public List<Actor> MoviesActors(int id)
        {
            string query = "SELECT * FROM MoviesActors ma INNER JOIN Actor a ON a.Id = ma.ActorId where MovieId = @Id";
            var connection = new SqlConnection(_connectionString);
            var parameters = new { Id = id };/*
            var res = connection.Query<Actor>(query, parameters).ToList();*/
            return new List<Actor>();
        }


        public void Delete(int id)
        {
            string query = @"
                        DELETE
                        FROM [MoviesActors]
                        WHERE ActorId = @Id
                        
                        DELETE
                        FROM [Actor]
                        WHERE Id = @Id";

            Delete(query, new { Id = id });
        }
    }
}
