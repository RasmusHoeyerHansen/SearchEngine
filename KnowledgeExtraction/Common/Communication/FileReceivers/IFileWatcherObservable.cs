using System;
using KnowledgeExtraction.Common.Models;

namespace KnowledgeExtraction.Common.Communication.FileReceivers
{
    public interface IFileWatcherObservable<out TOut> where TOut : ITextMediaItem
    {
        public event Action<TOut>? FileReceived;
        
    }
    public interface IHttpFormInputObserver<out TOut> where TOut : ITextMediaItem
    {
        public event Action<TOut>? FileReceived;
    }
}