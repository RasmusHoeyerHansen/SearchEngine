using Domain_models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OccursInConfiguration : IEntityTypeConfiguration<OccursIn>
    {
        public void Configure(EntityTypeBuilder<OccursIn> builder)
        {
            builder.HasKey(o => new {o.Word, o.ArticleId});
            builder
                .HasOne<Article>(o => o.Article)
                .WithMany(a => a.Words);
            builder.HasOne<Word>(o => o.Word);
        }
    }
}