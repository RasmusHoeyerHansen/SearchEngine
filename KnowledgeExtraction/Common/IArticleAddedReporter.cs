using System;
using KnowledgeExtraction.Common.Models;

namespace KnowledgeExtraction.Common
{
    internal interface IArticleAddedReporter
    {
        void Subscribe(IObservable<PdfArticle> provider);
        void OnCompleted();
        void OnError(Exception e);
        void OnNext(PdfArticle value);
        void Unsubscribe();
    }
}