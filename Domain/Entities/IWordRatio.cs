namespace Domain_models.Entities
{
    public interface IWordRatio
    {
        public string Word { get; set; }
        public int Occurances { get; set; }
    }
}