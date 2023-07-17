using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Repository;
using Domain.Repository.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public void Create(GenreRequest genre)
        {
            _genreRepository.Create(genre);
        }

        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }

        public IList<GenreResponse> Get()
        {
            var genreResponse = new List<GenreResponse>();
            genreResponse = _genreRepository.Get().Select(g => new GenreResponse() { Id = g.Id,Name = g.Name}).ToList();
            return genreResponse;
        }

        public GenreResponse Get(int id)
        {
            var response = new GenreResponse();
            var genre = _genreRepository.Get(id);
            if(genre == null)
            {
                return null;
            }

            response.Id = id;
            response.Name = genre.Name;

            return response;
        }

        public List<GenreResponse> MoviesGenres(int movieId)
        {
            var genreResponse = new List<GenreResponse>();
            var genres = _genreRepository.MoviesGenres(movieId);

            if(genres == null)
            {
                return null;
            }
            foreach (var genre in genres)
            {
                var temp = new GenreResponse() { Id = genre.Id, Name = genre.Name };
                genreResponse.Add(temp);
            }

            return genreResponse;
        }

        public void Update(int id, GenreRequest genre)
        {
            _genreRepository.Update(id, genre);
        }
    }
}
