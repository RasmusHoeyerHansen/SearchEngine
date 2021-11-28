using System;
using KnowledgeExtraction.Models;

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