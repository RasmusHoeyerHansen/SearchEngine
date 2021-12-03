using System.Reflection;
using System.Runtime.CompilerServices;
using KnowledgeExtraction.Common.Communication;
using KnowledgeExtraction.Common.Models;
using Microsoft.Extensions.DependencyInjection;
namespace KnowledgeExtraction
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IFileReceiver<PdfArticle>>();
            return services;
        }
    }

}