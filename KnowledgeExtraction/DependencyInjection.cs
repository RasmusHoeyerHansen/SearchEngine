using System.IO;
using Domain_models.Entities;
using KnowledgeExtraction.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using KnowledgeExtraction.Preprocessing.Parsers;
using KnowledgeExtraction.WordCounting;

namespace KnowledgeExtraction
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKnowledgeExtraction(IServiceCollection services)
        {
            services.AddTransient(
                typeof(ITextItemFactory<Stream>), 
                typeof(TextItemFactory));
            
            services.AddTransient(
                typeof(IBaseKnowledgeExtractor), 
                typeof(WordCountingFactory));

            return services;
        }
    }

}