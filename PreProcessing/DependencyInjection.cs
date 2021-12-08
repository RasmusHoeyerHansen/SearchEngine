using System.IO;
using Microsoft.Extensions.DependencyInjection;
using PreProcessing.Parsing.Parsers;

namespace PreProcessing
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