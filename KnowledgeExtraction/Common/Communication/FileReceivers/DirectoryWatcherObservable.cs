using System;
using System.IO;
using System.Linq;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Parsers;
using Microsoft.Extensions.Logging;

namespace KnowledgeExtraction.Common.Communication.FileReceivers
{
    internal class PipelineInputObserver : DirectoryWatcherObservable, IHttpFormInputObserver<PdfArticle>
    {
        public PipelineInputObserver(DirectoryInfo info, IPdfFactory<PdfDocument> factory) : base(info, factory)
        {
        }

        public PipelineInputObserver(DirectoryInfo dirInfo, IPdfFactory<PdfDocument> factory, ILogger<PdfArticle> logger) : base(dirInfo, factory, logger)
        {
        }
    }
    
    internal class DirectoryWatcherObservable : IFileWatcherObservable<PdfArticle>
    {
        private readonly FileSystemWatcher Watcher;
        private readonly IPdfFactory<PdfDocument> Factory;
        private readonly ILogger<PdfArticle>? Logger;

        public event Action<PdfArticle>? FileReceived;

        public DirectoryWatcherObservable(DirectoryInfo info, IPdfFactory<PdfDocument> factory)
        {
            this.Factory = factory;
            this.Watcher = new FileSystemWatcher();
            SetupWatcher(info);
        }
        public DirectoryWatcherObservable(DirectoryInfo dirInfo, IPdfFactory<PdfDocument> factory, ILogger<PdfArticle> logger)
            : this(dirInfo, factory)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private void SetupWatcher(DirectoryInfo dirInfo)
        {
            Watcher.Path = dirInfo.FullName;
            Watcher.IncludeSubdirectories = true;
            Watcher.Filter = "*.*";
            Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                                            | NotifyFilters.FileName
                                                            | NotifyFilters.DirectoryName;
            Watcher.Created += OnFileRecieved;
            Watcher.EnableRaisingEvents = true;
        }

        public virtual void OnFileRecieved(object sender, FileSystemEventArgs eventArgs)
        {
            PdfArticle article;
            try
            {
                article = Factory.Parse(eventArgs.FullPath);
            }
            catch (PdfParsingException e)
            {
                if (Logger != null) Logger.LogError(e.Message);
                throw e;
            }
            FileReceived?.Invoke(article);
        }
    }
}