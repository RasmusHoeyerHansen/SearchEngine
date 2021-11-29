using System;
using System.IO;
using Domain_models.Exceptions;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing;
using KnowledgeExtraction.Preprocessing.Models;
using Microsoft.Extensions.Logging;

namespace KnowledgeExtraction.Common.Communication
{
    internal class DirectoryWatcher
    {
        private readonly FileSystemWatcher Watcher;
        private readonly IPdfFactory<PdfDocument> Factory;
        private readonly ILogger<PdfArticle> Logger;

        public event Action<PdfArticle>? PdfAddedOrChanged;

        public DirectoryWatcher(string pathToFolder, IPdfFactory<PdfDocument> factory)
        {
            this.Factory = factory;
            this.Watcher = new FileSystemWatcher();
            SetupWatcher(pathToFolder);
        }
        
        public DirectoryWatcher(string pathToFolder, IPdfFactory<PdfDocument> factory, ILogger<PdfArticle> logger)
            : this(pathToFolder, factory)
        {
            this.Logger = logger;
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
            Watcher.Created += OnFileAddedOrChanged;
            Watcher.Changed += OnFileAddedOrChanged;
            Watcher.EnableRaisingEvents = true;
        }

        public virtual void OnFileAddedOrChanged(object sender, FileSystemEventArgs eventArgs)
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
            PdfAddedOrChanged?.Invoke(article);
        }
    }
}