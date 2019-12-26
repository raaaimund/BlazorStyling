using System.Threading.Tasks;
using BlazorStyling.App.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BlazorStyling.App.Tests.Pages
{
    public class ProgressBarTests : IClassFixture<WebApplicationFactory<BlazorStyling.App.Startup>>
    {
        private const string Url = "/progressbar/5";
        protected WebApplicationFactory<BlazorStyling.App.Startup> WebApplicationUnderTest { get; }

        public ProgressBarTests(WebApplicationFactory<Startup> factory)
        {
            WebApplicationUnderTest = factory;
        }

        [Fact]
        public async Task ParameterValueNowShouldSetAriaValueNow()
        {
            var testHost = new Microsoft.AspNetCore.TestHost.
            var client = WebApplicationUnderTest.CreateClient();

            var response = await client.GetAsync(Url);
            var content = await HtmlHelpers.GetDocumentAsync(response);
            var progressBar = content.QuerySelector(".progress-bar");

            response.EnsureSuccessStatusCode();
            Assert.Equal("5", progressBar.GetAttribute("aria-valuenow"));
        }
    }
}
