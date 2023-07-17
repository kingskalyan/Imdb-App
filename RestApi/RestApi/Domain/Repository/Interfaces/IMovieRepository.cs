using Domain.Model.DataBase;
using Domain.Models.Request;

namespace Domain.Repository.Interfaces
{
    public interface IMovieRepository
    {
        IList<Movie> Get();
        Movie Get(int id);
        void Create(MovieRequest movie);
        void Update(int id, MovieRequest movie);
        void Delete(int id);
    }
}
