using System.IO;
using Infrastructure.Persistence;
using KnowledgeExtraction.Common;
using Microsoft.Extensions.DependencyInjection;
using PreProcessing.Parsing.Parsers;

namespace Infrastructure
{
    public class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services)
        {
            services.AddTransient(
                typeof(IWordCountContext),
                typeof(WordCountContext));
            
            return services;
        }
    }
}