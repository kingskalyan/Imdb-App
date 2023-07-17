using Domain.Model.DataBase;
using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Repository.Interfaces;
using Moq;

namespace RestApi.Tests.Mocks
{
    public class MovieMock
    {
        public static readonly Mock<IMovieRepository> MovieMockRepo = new Mock<IMovieRepository>();
        private static readonly List<Movie> _listOfMovies = new List<Movie>()
        {
            new Movie()
            {
                Id = 1,
                Name = "Avatar",
                Producer = 1,
                Plot = "A paralyzed former Marine joins the Avatar Program, a project that allows humans to remotely control genetically engineered  bodies, in order to infiltrate  and stop the RDA corporation from mining a valuable mineral on their planet.",
                Poster = @"C:\Users\Kalyan\Downloads\Avatar.png",
                YearOfRelease = new DateTime(2009,05,22)
            }
        };

        public static void GetMovies()
        {
            var actors = ActorMock.ListOfActors;
            var genres = GenreMock._listOfGenres;

            MovieMockRepo.Setup(m => m.Get()).Returns(_listOfMovies);

            MovieMockRepo.Setup(m => m.Get(It.IsAny<int>())).Returns((int id)=>_listOfMovies.FirstOrDefault(movie=>movie.Id == id));

            MovieMockRepo.Setup(repo => repo.Create(It.IsAny<MovieRequest>())).Callback((MovieRequest movie) =>
            {
                    var actorsResponse = new List<Actor>();
                    var genresResponse = new List<Genre>();
                    var ids = movie.Actors.Split(',');
                    foreach (var id in ids)
                    {
                        var actorId = int.Parse(id);
                        actorsResponse.Append(actors.First(a => a.Id == actorId));
                    }
                    var Ids = movie.Genres.Split(',');
                    foreach (var id in Ids)
                    {
                        var genreId = int.Parse(id);
                        genresResponse.Append(genres.First(g => g.Id == genreId));
                    }
                });

            MovieMockRepo.Setup(m => m.Update(It.IsAny<int>(), It.IsAny<MovieRequest>())).Callback((int movieId, MovieRequest movieRequest) =>
            {
                var movie = _listOfMovies.ToList().FindIndex(m => m.Id == movieId);

                var actorsResponse = new List<Actor>();
                var genresResponse = new List<Genre>();
                var ids = movieRequest.Actors.Split(',');
                foreach (var id in ids)
                {
                    var actorId = int.Parse(id);
                    actorsResponse.Append(actors.First(a => a.Id == actorId));
                }
                var Ids = movieRequest.Genres.Split(',');
                foreach (var id in Ids)
                {
                    var genreId = int.Parse(id);
                    genresResponse.Append(genres.First(g => g.Id == genreId));
                }
            });

            MovieMockRepo.Setup(x => x.Delete(It.IsAny<int>()))
               .Callback((int id) =>
               {
                   var movInd = _listOfMovies.ToList().FindIndex(a => a.Id == id);
                   _listOfMovies.ToList().RemoveAt(movInd);
               });
        }
    }
}
