using System;
using System.ComponentModel.DataAnnotations;

namespace Domain_models.Entities
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Literal { get; set; }
    }
}