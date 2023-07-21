using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.ModelMaps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_category");
            builder.Property(e => e.Description).HasColumnName("description");
        }
    }
}
