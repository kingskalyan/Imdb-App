using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;
using RestApi.Tests.Mocks;

namespace RestApi.Tests.StepDefintions
{
    [Scope(Feature = "Movie Resource")]
    [Binding]
    public class MovieSteps : BaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory factory)
           : base(factory.WithWebHostBuilder(builder =>
           {
               builder.ConfigureServices(services =>
               {
                   services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                   services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
                   services.AddScoped(_ => ProducerMock.ProducerRepoMock.Object);
                   services.AddScoped(_ => MovieMock.MovieMockRepo.Object);
               });
           }))
        {
        }

        [BeforeFeature]
        public static void Mocks()
        {
            MovieMock.GetMovies();
            ActorMock.GetActors();
            GenreMock.GetGenres();
            ProducerMock.GetProducers();
        }
    }
}