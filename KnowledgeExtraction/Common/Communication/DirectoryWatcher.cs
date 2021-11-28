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
            Logger = new Logger<PdfArticle>(new LoggerFactory());
            SetupWatcher(pathToFolder);
        }
        
        public DirectoryWatcher(string pathToFolder, IPdfFactory<PdfDocument> factory, ILogger<PdfArticle> logger)
        {
            this.Factory = factory;
            this.Watcher = new FileSystemWatcher();
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
                PdfAddedOrChanged?.Invoke(article);
            }
            catch (PdfParsingException e)
            {
                Logger.LogError($"ERROR PARSING FILE: {e.Message}");
            }
        }
    }
}