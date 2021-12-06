


using System;
using System.IO;
using System.Linq;
using KnowledgeExtraction.Common.Communication.FileReceivers;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Parsers;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace ExtractorTests.Common.Communication
{
    public class DirectoryWatcherTest : PdfCreator
    {
        public static DirectoryInfo Directory
        {
            get
            {
                return new DirectoryInfo(System.IO.Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar);;
            }
        }

        public static string FileName => "test.pdf";

        static string[] Strings
        {
            get
            {
                string[] s = {"hello", "world"};
                return s;
            }
        }

        private static IPdfFactory<PdfDocument> CorrectParsingFactory
        {
            get
            {
                IPdfFactory<PdfDocument> factory = Substitute.For<IPdfFactory<PdfDocument>>();
                factory.Parse(Arg.Is(Directory+FileName)).Returns(new PdfArticle(Strings,  "title"));
                return factory;
            }
        }
        
        private static IPdfFactory<PdfDocument> ExceptionThrowingFactory
        {
            get
            {
                IPdfFactory<PdfDocument> factory = Substitute.For<IPdfFactory<PdfDocument>>();
                factory.Parse(Arg.Is(Directory+FileName)).Throws(new PdfParsingException("Exception"));
                return factory;
            }
        }



        [Test]
        public void Watcher_CallsPdfAddedOrChanged_OnAddedFile()
        {
            //Arrange
            bool isCalled = false;
            void AssertArticle(PdfArticle a)
            {
                isCalled = true;
            }
            DirectoryWatcherObservable directoryWatcherObservable = new DirectoryWatcherObservable(Directory, CorrectParsingFactory);
            directoryWatcherObservable.FileReceived += AssertArticle;
            
            //Act
            directoryWatcherObservable.OnFileRecieved(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory.FullName, FileName));
            //Assert
            Assert.IsTrue(isCalled);
        }
        
        [Test]
        public void Watcher_CallsPdfAddedOrChanged_ArticleDoesContainText()
        {
            //Arrange
            void ObserverFunction(PdfArticle a)
            {
                Assert.AreEqual(a.ParsedStrings.Count(), Strings.Count());
                for (int i = 0; i < a.ParsedStrings.Count(); i++)
                {
                    Assert.AreEqual(Strings[i], a.ParsedStrings[i]);
                }
            }

            var x = CorrectParsingFactory.Parse(Directory.FullName);
            DirectoryWatcherObservable directoryWatcherObservable = new DirectoryWatcherObservable(Directory, factory:CorrectParsingFactory);
            directoryWatcherObservable.FileReceived += ObserverFunction;
            
            //Act
            directoryWatcherObservable.OnFileRecieved(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory.FullName, FileName){});
        }
        
        [Test]
        public void Watcher_OnFailedFileParse_ThrowsPdfParsingException()
        {
            //Arrange
            ILogger<PdfArticle> logger = Substitute.For<ILogger<PdfArticle>>();
            DirectoryWatcherObservable directoryWatcherObservable = new DirectoryWatcherObservable(Directory, ExceptionThrowingFactory,logger);

            //Act
            Assert.Throws<PdfParsingException>(() => 
                directoryWatcherObservable.OnFileRecieved(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory.FullName, FileName)));
        }
        
        [Test]
        public void Watcher_OnFailedFileParse_Calls_ILoggerLogError()
        {
            //Arrange
            ILogger<PdfArticle> logger = Substitute.For<ILogger<PdfArticle>>();
            DirectoryWatcherObservable directoryWatcherObservable = new DirectoryWatcherObservable(Directory, ExceptionThrowingFactory, logger);
            try
            {
                directoryWatcherObservable.OnFileRecieved(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory.FullName, FileName){});
            }
            catch (Exception e)
            {
                //Act
                logger.ReceivedWithAnyArgs().LogError(default);
            }
        }



        
    }
}