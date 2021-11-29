using System.Reflection;
using KnowledgeExtraction.Common.Communication;
using KnowledgeExtraction.Common.Models;
using Microsoft.Extensions.DependencyInjection;

namespace KnowledgeExtraction
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IWatcherService<PdfArticle>>();
            return services;
        }
    }

}