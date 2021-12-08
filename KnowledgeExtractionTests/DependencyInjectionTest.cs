using KnowledgeExtraction.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PreProcessing;


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
        public void CanRequest_IWordCounter_Service_DoesNotThrow()
        {
            DependencyInjection.AddPreProcessing(Services);
            ServiceProvider provider = Services.BuildServiceProvider();
            Assert.DoesNotThrow(() => provider.GetRequiredService<IWordCounter>());
        }
    }
}