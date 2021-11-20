
namespace PdfExtractor
{
    public interface IExtractor
    {
        public PdfArticle ParsePdf(PdfDocument document);
        
    }
}