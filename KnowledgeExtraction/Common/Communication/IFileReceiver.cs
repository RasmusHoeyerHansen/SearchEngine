using System;
using KnowledgeExtraction.Common.Models;

namespace KnowledgeExtraction.Common.Communication
{
    public interface IFileReceiver<out TOut> where TOut : ITextMediaItem
    {
        public event Action<TOut>? FileReceived;
    }
}