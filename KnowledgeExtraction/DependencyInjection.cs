using System.IO;
using Domain_models.Entities;
using KnowledgeExtraction.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using KnowledgeExtraction.WordCounting;
using PreProcessing.Common.Services;

namespace KnowledgeExtraction
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKnowledgeExtraction(IServiceCollection services)
        {
            services.AddTransient(
                typeof(IWordCounter),
                typeof(WordCountingFactory));

            services.AddTransient(typeof(IKnowledgeFromTextService<Stream>), typeof(TextWordCountingFromTextService));

            return services;
        }
    }
}