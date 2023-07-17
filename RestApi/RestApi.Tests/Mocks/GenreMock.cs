using Domain.Model.DataBase;
using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Repository.Interfaces;
using Moq;

namespace RestApi.Tests.Mocks
{
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();
        public static readonly List<Genre> _listOfGenres = new List<Genre>()
        {
            new Genre()
            {
                Id = 1,
                Name = "Action"
            }
        };
        public static readonly Dictionary<int, int> _movieGenres = new Dictionary<int, int>()
        {
            {1,1},
        };

        public static void GetGenres()
        {
            GenreRepoMock.Setup(a => a.Get()).Returns(_listOfGenres);

            GenreRepoMock.Setup(g => g.Get(It.IsAny<int>())).Returns((int id) => _listOfGenres.FirstOrDefault(genre=>genre.Id == id));

            GenreRepoMock.Setup(g => g.Create(It.IsAny<GenreRequest>())).Callback((GenreRequest request) =>
            {
                var genre = new Genre() { Id = _listOfGenres.Count() + 1, Name = request.Name };
                _listOfGenres.Add(genre);
            });

            GenreRepoMock.Setup(g => g.Delete(It.IsAny<int>())).Callback((int id) =>
            {
                var result = _listOfGenres.FindIndex(a => a.Id == id);
                if (result != -1)
                {
                    _listOfGenres.RemoveAt(result);
                }
            });

            GenreRepoMock.Setup(g => g.Update(It.IsAny<int>(), It.IsAny<GenreRequest>())).Callback((int id, GenreRequest request) =>
            {
                var genre = new Genre() { Id = id, Name = request.Name };
                var result = _listOfGenres.FindIndex(gen => gen.Id == id);
                _listOfGenres[result] = genre;
            });

            GenreRepoMock.Setup(a => a.MoviesGenres(It.IsAny<int>())).Returns((int movieId) =>
            {
                var genres = new List<Genre>();
                foreach (var item in _movieGenres)
                {
                    if (item.Key == movieId)
                    {
                        var genre = _listOfGenres.Find(a => a.Id == item.Value);
                        genres.Add(genre);
                    }
                }
                return genres;
            });
        }
    }
}
