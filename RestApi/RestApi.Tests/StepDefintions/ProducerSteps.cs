using Microsoft.Extensions.DependencyInjection;
using RestApi.Tests.Mocks;
using TechTalk.SpecFlow;

namespace RestApi.Tests.StepDefintions
{
    [Scope(Feature = "Producer Resource")]
    [Binding]
    public class ProducerSteps : BaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => ProducerMock.ProducerRepoMock.Object);
                });
            }))
        {
        }

        [BeforeFeature]
        public static void Mocks()
        {
            ProducerMock.GetProducers();
        }
    }
}