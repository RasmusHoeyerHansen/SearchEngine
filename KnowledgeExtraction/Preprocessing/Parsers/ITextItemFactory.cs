using KnowledgeExtraction.Common;

namespace KnowledgeExtraction.Preprocessing.Parsers
{
    public interface ITextItemFactory<in TIn>
    {
        public ITextItem Extract(TIn inputElement);
    }
}