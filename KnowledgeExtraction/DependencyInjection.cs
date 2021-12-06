using System.IO;
using KnowledgeExtraction.Common.Communication;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.FileReceivers;
using KnowledgeExtraction.Preprocessing.Parsers;
using Microsoft.Extensions.DependencyInjection;
namespace KnowledgeExtraction
{
    public static class KnowledgeExtractionDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IExtractor<Stream, PdfArticle>), typeof(PdfArticleFactory));
            services.AddTransient(typeof(IFileReceiver<PdfArticle>),typeof(FileController));
            return services;
        }
    }

}