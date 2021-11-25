using System.Linq;
using System.Text.RegularExpressions;
using KnowledgeExtraction.Models;
using KnowledgeExtraction.Preprocessing.Models;
using KnowledgeExtraction.Preprocessing.Strategies.Abstractions;

namespace KnowledgeExtraction.Preprocessing.Strategies
{
    public class NoWhiteSpaceStrategy : DocumentTextReader<iTextSharp.text.Document>
    {
        public PdfArticle? ExecuteExtraction(PdfDocument data)
        {
            string? text = ReadText(data.Path);
            string[]? strings = text.Split(" ");
            RemoveWhiteSpace(strings);
            return new PdfArticle(text.Split(" "), data.Path, DocumentTitle);
        }

        private void RemoveWhiteSpace(string[] strings)
        {
            for (int i = 0; i < strings.Count(); i++)
            {
                strings[i] = Regex.Replace(strings[i], @"\s+", "");
            }
        }
    }
}