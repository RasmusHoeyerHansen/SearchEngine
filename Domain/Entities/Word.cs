using System.ComponentModel.DataAnnotations;

namespace Domain_models.Entities
{
    public class Word
    {
        [Key]
        public string Literal { get; set; }
    }
}