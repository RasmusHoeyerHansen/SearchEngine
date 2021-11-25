using System;
using System.IO;
using iTextSharp.text.pdf.parser;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing;

namespace KnowledgeExtraction.FileWatcher
{
    public class FolderWatcher
    {
        private readonly FileSystemWatcher Watcher;
        private readonly PdfArticleFactory Factory;
        public Func<string, PdfArticle> OnCreation;

        public FolderWatcher(string pathToFolder, PdfArticleFactory pdfFactory)
        {
            this.Factory = pdfFactory;
            this.Watcher = new FileSystemWatcher(pathToFolder);
            Watcher.NotifyFilter = NotifyFilters.Size;
            Watcher.IncludeSubdirectories = true;
            Watcher.Filter = "*.pdf";
            Watcher.EnableRaisingEvents = true;
            Watcher.Changed += OnChanged;
        }

        private void OnChanged(object sender, FileSystemEventArgs args)
        {
            string? x = args.FullPath;
            
        }
        
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
        }
    }
}