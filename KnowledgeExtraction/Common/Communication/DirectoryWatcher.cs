using System;
using System.IO;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing;
using KnowledgeExtraction.Preprocessing.Models;
using Microsoft.Extensions.Logging;

namespace KnowledgeExtraction.Common.Communication
{
    internal class DirectoryWatcher : IWatcherService<PdfArticle>
    {
        private readonly FileSystemWatcher Watcher;
        private readonly IPdfFactory<PdfDocument> Factory;
        private readonly ILogger<PdfArticle>? Logger;

        public event Action<PdfArticle>? MediaItemAddedOrChanged;

        public DirectoryWatcher(string pathToFolder, IPdfFactory<PdfDocument> factory)
        {
            this.Factory = factory;
            this.Watcher = new FileSystemWatcher();
            SetupWatcher(pathToFolder);
        }
        
        public DirectoryWatcher(string pathToFolder, IPdfFactory<PdfDocument> factory, ILogger<PdfArticle> logger)
            : this(pathToFolder, factory)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            SetupWatcher(pathToFolder);
        }

        private void SetupWatcher(string path)
        {
            Watcher.Path = path;
            Watcher.IncludeSubdirectories = true;
            Watcher.Filter = "*.*";
            Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                                            | NotifyFilters.FileName
                                                            | NotifyFilters.DirectoryName;
            Watcher.Created += OnSourceAddedOrChanged;
            Watcher.Changed += OnSourceAddedOrChanged;
            Watcher.EnableRaisingEvents = true;
        }

        public virtual void OnSourceAddedOrChanged(object sender, FileSystemEventArgs eventArgs)
        {
            PdfArticle article;
            try
            {
                article = Factory.Parse(eventArgs.FullPath);
            }
            catch (PdfParsingException e)
            {
                if (Logger != null) Logger.LogError(e.Message);
                return;
            }
            MediaItemAddedOrChanged?.Invoke(article);
        }
    }
}