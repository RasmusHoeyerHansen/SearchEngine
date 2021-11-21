using System.Collections.Generic;

namespace Domain.Models
{
    public interface IStringContainer
    {
        public IEnumerable<string> ParsedStrings { get;}
    }
}