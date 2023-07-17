using Domain.Models.Request;
using Domain.Models.Response;

namespace Service.Interfaces
{
    public interface IMovieService
    {
        public List<MovieResponse> Get();
        public MovieResponse Get(int id);
        public void Create(MovieRequest movie);
        public void Update(int id, MovieRequest movie);
        public void Delete(int id);
    }
}
