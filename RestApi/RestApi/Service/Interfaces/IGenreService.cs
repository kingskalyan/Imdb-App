using Domain.Models.Request;
using Domain.Models.Response;

namespace Service.Interfaces
{
    public interface IGenreService
    {
        IList<GenreResponse> Get();
        GenreResponse Get(int id);
        void Create(GenreRequest genre);
        void Update(int id, GenreRequest genre);
        void Delete(int id);
        List<GenreResponse> MoviesGenres(int movieId);

    }
}
