using MessAbout.Api.Products;

namespace MessAbout.Api.IntegrationTests
{
    public class ProductTests : BaseIntegrationTest
    {
        public ProductTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task CreateProduct_ShouldCreateProduct()
        {
            var command = new CreateProduct.Command
            {
                Name = "Test"
            };

            var productId = await Sender.Send(command);

            var product = DbContext.Products.FirstOrDefault(p => p.Id == productId);

            Assert.NotNull(product);
        }
    }
}