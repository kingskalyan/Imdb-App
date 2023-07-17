using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Repository.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;
        private readonly IGenreRepository _genreRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IProducerService _producerService;
        

        public MovieService(IMovieRepository movieRepository, IGenreService genreService, IActorRepository actorRepository, IProducerService producerService, IActorService actorService, IGenreRepository genreRepository,IProducerRepository producerRepository)
        {
            _movieRepository = movieRepository;
            _genreService = genreService;
            _actorService = actorService;
            _genreRepository = genreRepository;
            _producerRepository = producerRepository;
            _actorRepository = actorRepository;
            _producerService = producerService;
            
        }
        public void Create(MovieRequest movie)
        {
            var ids = movie.Actors.Split(',');

            foreach (string id in ids)
            {
                if (int.TryParse(id, out int Id))
                {
                    var res = _actorService.Get().FirstOrDefault(actor => actor.Id == Id);
                    if (res == null)
                    {
                        throw new Exception("Actor with ID - " + id + " does not exist");
                    }
                }
            }
            var GenreIds = movie.Genres.Split(',');
            foreach (string id in GenreIds)
            {
                if (int.TryParse(id, out int Id))
                {
                    var res = _genreRepository.Get().FirstOrDefault(genre => genre.Id == Id);
                    if (res == null)
                    {
                        throw new Exception("Genre with ID - " + id + " does not exist");
                    }
                }
            }

            var result = _producerRepository.Get(movie.ProducerId);

            if (result == null)
            {
                throw new Exception("Producer with ID - " + movie.ProducerId + " does not exist");
            }
            var movieRequest = new MovieRequest()
            {
                Name = movie.Name,
                ProducerId = movie.ProducerId,
                Plot = movie.Plot,
                Actors = movie.Actors,
                Genres = movie.Genres,
                Poster = movie.Poster,
                YearOfRelease = movie.YearOfRelease,
            };
            _movieRepository.Create(movieRequest);
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }

        public MovieResponse Get(int id)
        {
            var movie = _movieRepository.Get(id);

            if (movie == null)
            {
                throw new Exception("Movie with Id - " + id + " doesn't exist");
            }

            var actorResponse = _actorService.MoviesActors(id);

            if (actorResponse == null)
            {
                throw new Exception("Actors haven't existed");
            }

            var genreResponse = _genreService.MoviesGenres(id);

            if (genreResponse == null)
            {
                throw new Exception("genres haven't existed");
            }

            var producerResponse = _producerService.Get(movie.Producer);

            
            if (producerResponse == null)
            {
                throw new Exception("producer hasn't existed");
            }

            

            var movieResponse = new MovieResponse() { Id = id, Name = movie.Name, Actors = actorResponse, Genres = genreResponse, Plot = movie.Plot, Poster = movie.Poster, Producer = producerResponse, YearOfRelease = movie.YearOfRelease };

            return movieResponse;
        }

        public List<MovieResponse> Get()
        {
            var movieResponse = new List<MovieResponse>();
            var movies = _movieRepository.Get();

            foreach (var movie in movies)
            {
                var actors = _actorService.MoviesActors(movie.Id);
                var genres = _genreService.MoviesGenres(movie.Id);
                var producer = _producerService.Get(movie.Producer);
                movieResponse.Add(new MovieResponse() { Id = movie.Id, Name = movie.Name, Genres = genres, Actors = actors, Plot = movie.Plot, Poster = movie.Poster, Producer = producer, YearOfRelease = movie.YearOfRelease });
            }
            return movieResponse;
        }

        public void Update(int id , MovieRequest movie)
        {
            string[] ids = movie.Actors.Split(',');
            foreach (string idString in ids)
            {
                if (int.TryParse(idString, out int Id))
                {
                    if (!_actorRepository.Get().ToList().Exists(actor => actor.Id == Id))
                    {
                        throw new Exception("Actor with ID - " + idString + " does not exist");
                    }
                }
            }
            string[] GenreIdStrings = movie.Genres.Split(',');
            foreach (string idString in GenreIdStrings)
            {
                if (int.TryParse(idString, out int genreId))
                {
                    if (!_genreRepository.Get().ToList().Exists(genre => genre.Id == genreId))
                    {
                        throw new Exception("Genre with ID - " + idString + " does not exist");
                    }
                }
            }

            var result = _producerRepository.Get(movie.ProducerId);
            if (result == null)
            {
                throw new Exception("Producer with ID - " + movie.ProducerId + " does not exist");
            }

            _movieRepository.Update(id, movie);
        }
    }
}
