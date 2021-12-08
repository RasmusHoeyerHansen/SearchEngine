using PreProcessing.Common;

namespace PreProcessing.Parsing.Parsers
{
    public interface ITextItemFactory<in TIn>
    {
        public ITextItem Extract(TIn inputElement);
    }
}