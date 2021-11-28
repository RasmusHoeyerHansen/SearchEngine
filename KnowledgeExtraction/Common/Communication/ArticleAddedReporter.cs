using System;
using KnowledgeExtraction.Models;

namespace KnowledgeExtraction.Common.Communication
{
    internal class ArticleAddedReporter : IObserver<PdfArticle>, IArticleAddedReporter
    {
        private IDisposable Subscription;

        public virtual void Subscribe(IObservable<PdfArticle> provider)
        {
            Subscription = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: The location cannot be determined.");
        }

        public virtual void OnNext(PdfArticle value)
        {
            Console.WriteLine();
        }

        public virtual void Unsubscribe()
        {
            Subscription.Dispose();
        }

    }
}