
using System;
using System.IO;
using System.Linq;
using Castle.Core;
using Domain_models.Exceptions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KnowledgeExtraction.Common.Communication;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

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

        public static IPdfFactory<PdfDocument> CorrectParsingFactory
        {
            get
            {
                IPdfFactory<PdfDocument> factory = Substitute.For<IPdfFactory<PdfDocument>>();
                factory.Parse(Arg.Is(Directory+FileName)).Returns(new PdfArticle(Strings, Directory+FileName, "title"));
                return factory;
            }
        }
        
        public static IPdfFactory<PdfDocument> ExceptionThrowingFactory
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
            DirectoryWatcher watcher = new DirectoryWatcher(Directory, factory:CorrectParsingFactory);
            watcher.PdfAddedOrChanged += AssertArticle;
            
            //Act
            CreateTestPDF("some text");
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
            DirectoryWatcher watcher = new DirectoryWatcher(Directory, factory:CorrectParsingFactory);
            watcher.PdfAddedOrChanged += ObserverFunction;
            
            //Act
            watcher.OnFileAddedOrChanged(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory, FileName){});
        }
        
        [Test]
        public void Watcher_OnFailedFileParse_ThrowsPdfParsingException()
        {
            //Arrange
            ILogger<PdfArticle> logger = Substitute.For<ILogger<PdfArticle>>();
            DirectoryWatcher watcher = new DirectoryWatcher(Directory, ExceptionThrowingFactory,logger);

            //Act
            Assert.DoesNotThrow(() => watcher.OnFileAddedOrChanged(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory, FileName)));
        }
        
        [Test]
        public void Watcher_OnFailedFileParse_Calls_ILoggerLogError()
        {
            //Arrange
            ILogger<PdfArticle> logger = Substitute.For<ILogger<PdfArticle>>();
            DirectoryWatcher watcher = new DirectoryWatcher(Directory, ExceptionThrowingFactory, logger);
            watcher.OnFileAddedOrChanged(null, new FileSystemEventArgs(WatcherChangeTypes.Changed,Directory, FileName){});
            //Act
            logger.ReceivedWithAnyArgs().LogError(default);
        }



        
    }
}