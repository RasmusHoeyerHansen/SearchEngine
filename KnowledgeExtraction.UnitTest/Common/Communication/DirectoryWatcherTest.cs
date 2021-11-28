
using System;
using System.IO;
using System.Linq;
using Castle.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KnowledgeExtraction.Common.Communication;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing;
using NSubstitute;
using NUnit.Framework;
using PdfDocument = KnowledgeExtraction.Preprocessing.Models.PdfDocument;

namespace ExtractorTests.Common.Communication
{
    public class DirectoryWatcherTest : PdfCreator
    {
        public static string FilePath
        {
            get
            {
                string pathToDirctory = Directory.GetCurrentDirectory();
                DirectoryInfo dirInfo = new DirectoryInfo(pathToDirctory);
                return dirInfo.FullName;
            }
        }

        static string[] Strings
        {
            get
            {
                string[] s = {"hello", "world"};
                return s;
            }
        }

        public static IPdfFactory<PdfDocument> Factory
        {
            get
            {
                IPdfFactory<PdfDocument> factory = Substitute.For<IPdfFactory<PdfDocument>>();
                factory.Parse(Arg.Is(FilePath)).Returns(new PdfArticle(Strings, FilePath, "title"));
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
            DirectoryWatcher watcher = new DirectoryWatcher(FilePath, factory:Factory);
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
            bool isCalled = false;
            void ObserverFunction(PdfArticle a)
            {
                Assert.AreEqual(a.ParsedStrings.Count(), Strings.Count());
                for (int i = 0; i < a.ParsedStrings.Count(); i++)
                {
                    Assert.AreEqual(Strings[i], a.ParsedStrings[i]);
                }
            }
            DirectoryWatcher watcher = new DirectoryWatcher(FilePath, factory:Factory);
            watcher.PdfAddedOrChanged += ObserverFunction;
            
            //Act
            CreateTestPDF(string.Join("",Strings));
            //Assert
            Assert.IsTrue(isCalled);
        }



        
    }
}