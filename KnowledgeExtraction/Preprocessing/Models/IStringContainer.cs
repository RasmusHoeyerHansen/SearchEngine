using System.Collections.Generic;

namespace KnowledgeExtraction.Preprocessing.Models
{
    public interface IStringContainer
    {
        public IEnumerable<string> ParsedStrings { get;}
    }
}