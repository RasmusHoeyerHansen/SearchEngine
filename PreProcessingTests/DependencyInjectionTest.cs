
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PreProcessingTest;
using PreProcessingTest.Parsing.Parsers;

namespace PreProcessingTests
{
    public class DependencyInjectionTest
    {
        private IServiceCollection Services;

        [SetUp]
        public void SetUp()
        {
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            this.Services = DependencyInjection.AddPreProcessing(services);
        }

        [TearDown]
        public void TearDown()
        {
            Services = null;
        }
        [Test]
        public void CanRequest_IWordCounter_Service_DoesNotThrow()
        {
            DependencyInjection.AddPreProcessing(Services);
            ServiceProvider provider = Services.BuildServiceProvider();
            Assert.DoesNotThrow(() => provider.GetRequiredService<ITextItemFactory<Stream>>());
        }
    }
}