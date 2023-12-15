using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProLivros.Domain;

namespace ProLivros.Persistence

{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(p => p.CodAu);
            builder.Property(p => p.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}