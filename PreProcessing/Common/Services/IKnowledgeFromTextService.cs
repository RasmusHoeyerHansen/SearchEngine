namespace PreProcessing.Common.Services
{
    public interface IKnowledgeFromTextService<in TIn>
    {
        public void ExtractKnowledge(TIn baseFormat);
    }
}