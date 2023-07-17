using Microsoft.Extensions.DependencyInjection;
using RestApi.Tests.Mocks;
using TechTalk.SpecFlow;

namespace RestApi.Tests.StepDefintions
{
    [Scope(Feature = "Actor Resource")]
    [Binding]
    public class ActorSteps : BaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ActorMock.ActorRepoMock.Object);
                });
            }))
        {
        }

        [BeforeFeature]
        public static void Mocks()
        {
            ActorMock.GetActors();
        }
    }
}