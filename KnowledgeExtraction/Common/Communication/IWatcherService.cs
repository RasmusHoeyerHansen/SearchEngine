using System;
using System.IO;
using KnowledgeExtraction.Common.Models;

namespace KnowledgeExtraction.Common.Communication
{
    public interface IWatcherService<T> where T : ITextMediaItem
    {
        public void OnSourceAddedOrChanged(object sender, FileSystemEventArgs eventArgs);
        public event Action<T>? MediaItemAddedOrChanged;
    }
}