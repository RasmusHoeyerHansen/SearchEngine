using Domain_models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAndInfrastructure.DataAccess.Configurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();
        }
    }
}