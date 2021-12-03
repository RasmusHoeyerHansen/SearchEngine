
namespace KnowledgeExtraction.Preprocessing.Parsers
{
    public interface IExtractor<in TIn, out TOut>
    {
        public TOut Extract(TIn inputElement);
    }
}