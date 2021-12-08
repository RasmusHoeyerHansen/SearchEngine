using PreProcessingTest.Common;

namespace PreProcessingTest.Parsing.Parsers
{
    public interface ITextItemFactory<in TIn>
    {
        public ITextItem Extract(TIn inputElement);
    }
}