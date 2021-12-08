using System.IO;
using Microsoft.Extensions.DependencyInjection;
using PreProcessingTest.Parsing.Parsers;

namespace PreProcessingTest
{
    public class DependencyInjection
    {
        public static IServiceCollection AddPreProcessing(IServiceCollection services)
        {
            services.AddTransient(
                typeof(ITextItemFactory<Stream>),
                typeof(TextItemFactory));
            
            return services;
        }
    }
}