
namespace PdfExtractor
{
    public interface IExtractor<in TIn, out TOut>
    {
        public TOut Parse(TIn document);
    }
}