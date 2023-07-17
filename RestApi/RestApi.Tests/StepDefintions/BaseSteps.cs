using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using TechTalk.SpecFlow;

namespace RestApi.Tests.StepDefintions
{
    [Binding]
    public class BaseSteps
    {
        protected WebApplicationFactory<TestStartUp> Factory;
        protected HttpClient httpClient { get; set; }
        protected HttpResponseMessage response { get; set; }

        public BaseSteps(WebApplicationFactory<TestStartUp> baseFactory)
        {
            Factory = baseFactory;
        }

        [Given(@"I am a client")]
        public void GivenIAmAClient()
        {
            httpClient = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost/")
            });
        }

        [When(@"I make Get Request '([^']*)'")]
        public async Task WhenIMakeGetRequest(string resourceEndpoint)
        {
            var fullEndpoint = httpClient.BaseAddress + resourceEndpoint;
            var uri = new Uri(fullEndpoint);
            response = await httpClient.GetAsync(uri);
        }

        [Then(@"response code must be '([^']*)'")]
        public void ThenResponseCodeMustBe(string expectedResponse)
        {
            Assert.Equal((int)(response.StatusCode), int.Parse(expectedResponse));
        }

        [Then(@"response data must look like '([^']*)'")]
        public void ThenResponseDataMustLookLike(string p0)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.Equal(p0, result);
        }

        [When(@"I make Get Request with '([^']*)' and '([^']*)'")]
        public async Task WhenIMakeGetRequestWithAnd(int p0, string p1)
        {
            var endpoint = httpClient.BaseAddress + p1;
            var uri = new Uri(endpoint + p0);
            response = await httpClient.GetAsync(uri);
        }

        [When(@"I make Post Request with '([^']*)' and '([^']*)'")]
        public async Task WhenIMakePostRequestWithAnd(string requestBody, string endpoint)
        {
            var fullEndpoint = httpClient.BaseAddress + endpoint;
            var uri = new Uri(fullEndpoint);
            var stringContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
            response = await httpClient.PostAsync(uri, stringContent);
        }

        [When(@"I make Update Request with '([^']*)' , '([^']*)' and '([^']*)'")]
        public async Task WhenIMakeUpdateRequestWithAnd(string requestBody, string id, string endpoint)
        {
            var fullEndpoint = httpClient.BaseAddress + endpoint + id;
            var uri = new Uri(fullEndpoint);
            var stringContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
            response = await httpClient.PutAsync(uri, stringContent);
        }

        [When(@"I make Delete Request with '([^']*)' and '([^']*)'")]
        public async Task WhenIMakeDeleteRequestWithAnd(string p0, string p1)
        {
            var fullEndpoint = httpClient.BaseAddress + p1 + p0;
            var uri = new Uri(fullEndpoint);
            response = await httpClient.DeleteAsync(uri);
        }
    }
}