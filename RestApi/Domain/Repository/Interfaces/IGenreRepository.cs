using Domain.Model.DataBase;
using Domain.Models.Request;

namespace Domain.Repository.Interfaces
{
    public interface IGenreRepository
    {
        IList<Genre> Get();
        Genre Get(int id);
        void Create(GenreRequest genre);
        void Update(int id, GenreRequest genre);
        void Delete(int id);
        List<Genre> MoviesGenres(int movieId);
    }
}
