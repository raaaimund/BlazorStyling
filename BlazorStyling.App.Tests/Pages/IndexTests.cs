using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace BlazorStyling.App.Tests.Pages
{
    public class IndexTests : BaseTest, IClassFixture<WebApplicationFactory<BlazorStyling.App.Startup>>
    {
        private const string Url = "/";

        public IndexTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task IndexRouteShouldBeAvailable()
        {
            var client = WebApplicationUnderTest.CreateClient();

            var response = await client.GetAsync(Url);
            var content = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
