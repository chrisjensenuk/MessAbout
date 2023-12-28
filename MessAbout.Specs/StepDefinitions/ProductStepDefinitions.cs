using MessAbout.Api.Contracts;
using MessAbout.Specs.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Text.Json;

namespace MessAbout.Specs.StepDefinitions
{
    [Binding]
    public class ProductStepDefinitions
    {
        private SpecsWebAppFactory? _factory;
        private HttpClient? _httpClient;
        private HttpResponseMessage? _lastResponse;

        public ProductStepDefinitions(SpecsWebAppFactory factory)
        {
            _factory = factory;
        }

        [Given(@"\[That I am a user]")]
        public void GivenThatIAmAUser()
        {
            _httpClient = _factory!.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:8080")
            });
        }

        [When(@"\[I create a product]")]
        public async Task WhenICreateAProduct()
        {
            _lastResponse = await _httpClient!.PostAsync("/api/products", JsonContent.Create(new CreateProductRequest { Name = "product name" }));
        }

        [Then(@"\[The Id of the created product is returned]")]
        public async Task ThenTheIdOfTheCreatedProductIsReturned()
        {
            _lastResponse.Should().NotBeNull();
            _lastResponse!.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            
            var id = JsonSerializer.Deserialize<Guid>(await _lastResponse.Content.ReadAsStringAsync());
            id.Should().NotBe(Guid.Empty);
        }
    }
}
