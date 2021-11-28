using System;

namespace Domain_models.Entities
{
    public class WordRatio : IWordRatio
    {
        public string MediaTitle { get; set; }
        public string Word { get; set; }
        public int Occurances { get; set; }

        public Guid MediaId { get; set; }
    }
}