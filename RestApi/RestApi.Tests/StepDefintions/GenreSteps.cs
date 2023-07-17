using Microsoft.Extensions.DependencyInjection;
using RestApi.Tests.Mocks;
using TechTalk.SpecFlow;

namespace RestApi.Tests.StepDefintions
{
    [Scope(Feature = "Genre Resource")]
    [Binding]
    public class GenreSteps : BaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory factory)
         : base(factory.WithWebHostBuilder(builder =>
         {
             builder.ConfigureServices(services =>
             {
                 services.AddScoped(_ => GenreMock.GenreRepoMock.Object);
             });
         }))
        {
        }

        [BeforeFeature]
        public static void Mocks()
        {
            GenreMock.GetGenres();
        }
    }
}