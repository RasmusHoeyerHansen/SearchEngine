using System.IO;
using Microsoft.Extensions.DependencyInjection;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.Parsers;

namespace KnowledgeExtraction
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKnowledgeExtraction(IServiceCollection services)
        {
            services.AddMvcCore().AddControllersAsServices();
            services.AddTransient(typeof(IExtractor<Stream, PdfArticle>), typeof(PdfArticleFactory));
            return services;
        }
    }

}