using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;


namespace KnowledgeExtractionTests
{
    public class DependencyInjectionTest
    {
        private IServiceCollection Services;

        [SetUp]
        public void SetUp()
        {
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            this.Services = KnowledgeExtraction.DependencyInjection.AddKnowledgeExtraction(services);
        }

        [TearDown]
        public void TearDown()
        {
            Services = null;
        }
        
        [Test]
        public void CanRequestServicesWithoutExceptions()
        {
            PreProcessing.DependencyInjection.AddPreProcessing(Services);
            var provider = Services.BuildServiceProvider();
            var restService = provider.GetRequiredService();
        }
    }
}