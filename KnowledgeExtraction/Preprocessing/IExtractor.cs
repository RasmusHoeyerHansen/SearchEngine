
namespace KnowledgeExtraction.Preprocessing
{
    public interface IExtractor<in TIn, out TOut>
    {
        public TOut Extract(TIn inputElement);
    }
}