
using PDfExtractor.Models;

namespace PdfExtractor
{
    public interface IExtractor<in TIn, out TOut> where TOut : IExtractResult
    {
        public TOut Parse(TIn document);
    }
}