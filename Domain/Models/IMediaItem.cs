using System.Collections.Generic;

namespace Domain_models.Models
{
    public interface IMediaItem
    {
        public string Title { get;}
        public IEnumerable<string> ParsedStrings { get; set; }
    }
}