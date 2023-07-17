using Domain.Model.DataBase;
using Domain.Models.Request;
using Domain.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace Domain.Repository
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(IOptions<ConnectionStrings> connectionString) : base(connectionString.Value.IMDBDB)
        {
        }
        public void Create(ProducerRequest producer)
        {
            string query = @"INSERT INTO [Producer]
                            VALUES (
	                            @Name
	                            ,@Bio
	                            ,@DateOfBirth
	                            ,@Gender
	                            )";

            var parameters = new { Name = producer.Name, Bio = producer.Bio, DateOfBirth = producer.DateOfBirth, Gender = producer.Gender };

            Create(query, parameters);
        }
        public void Delete(int id)
        {
            string query = @"DELETE
                            FROM [Producer]
                            WHERE Id = @Id";

            Delete(query, new { Id = id });
        }
        public IList<Producer> Get()
        {
            string query = @"SELECT *
                            FROM [Producer]";

            return Get(query);
        }
        public Producer Get(int id)
        {
            string query = @"SELECT *
                            FROM [Producer]
                            WHERE Id = @Id";

            return Get(query, new { Id = id });
        }
        public void Update(int id, ProducerRequest producer)
        {
            string query = @"UPDATE [Producer]
                            SET [Id] = @Id
	                            ,[Name] = @Name
	                            ,[Bio] = @Bio
	                            ,[DateOfBirth] = @DateOfBirth
	                            ,[Gender] = @Gender
                            WHERE Id = @Id";

            var parameters = new { Name = producer.Name, Bio = producer.Bio, DateOfBirth = producer.DateOfBirth, Gender = producer.Gender };

            Update(query, parameters);
        }
    }
}
