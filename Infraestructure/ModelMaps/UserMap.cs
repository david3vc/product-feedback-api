using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.ModelMaps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_usuario");
            builder.Property(e => e.Username).HasColumnName("username");
            builder.Property(e => e.Password).HasColumnName("password");
            builder.Property(e => e.Name).HasColumnName("name");
        }
    }
}
