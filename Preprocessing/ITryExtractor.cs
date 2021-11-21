namespace PdfExtractor
{
    public interface ITryExtractor<in TIn, TOut>
    {
        public TOut TryExtract(TIn input);
    }
}