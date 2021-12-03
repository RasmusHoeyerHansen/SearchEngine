


using System;
using System.IO;
using System.Linq;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.FileReceivers;
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
        public static string Directory => System.IO.Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
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
            DirectoryWatcher directoryWatcher = new DirectoryWatcher(Directory, CorrectParsingFactory);
            directoryWatcher.FileReceived += AssertArticle;
            
            //Act
            directoryWatcher.OnFileRecieved(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory, FileName));
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

            var x = CorrectParsingFactory.Parse(Directory);
            DirectoryWatcher directoryWatcher = new DirectoryWatcher(Directory, factory:CorrectParsingFactory);
            directoryWatcher.FileReceived += ObserverFunction;
            
            //Act
            directoryWatcher.OnFileRecieved(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory, FileName){});
        }
        
        [Test]
        public void Watcher_OnFailedFileParse_ThrowsPdfParsingException()
        {
            //Arrange
            ILogger<PdfArticle> logger = Substitute.For<ILogger<PdfArticle>>();
            DirectoryWatcher directoryWatcher = new DirectoryWatcher(Directory, ExceptionThrowingFactory,logger);

            //Act
            Assert.Throws<PdfParsingException>(() => directoryWatcher.OnFileRecieved(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory, FileName)));
        }
        
        [Test]
        public void Watcher_OnFailedFileParse_Calls_ILoggerLogError()
        {
            //Arrange
            ILogger<PdfArticle> logger = Substitute.For<ILogger<PdfArticle>>();
            DirectoryWatcher directoryWatcher = new DirectoryWatcher(Directory, ExceptionThrowingFactory, logger);
            try
            {
                directoryWatcher.OnFileRecieved(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory, FileName){});
            }
            catch (Exception e)
            {
                //Act
                logger.ReceivedWithAnyArgs().LogError(default);
            }
        }



        
    }
}