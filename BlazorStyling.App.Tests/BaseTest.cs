using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace BlazorStyling.App.Tests
{
    public abstract class BaseTest
    {
        protected WebApplicationFactory<BlazorStyling.App.Startup> WebApplicationUnderTest { get; }

        public BaseTest(WebApplicationFactory<BlazorStyling.App.Startup> factory)
        {
            WebApplicationUnderTest = factory;
        }
    }
}
