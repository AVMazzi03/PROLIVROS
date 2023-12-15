using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProLivros.Domain;

namespace ProLivros.Persistence.Mappping

{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(p => p.Codl);
            builder.Property(p => p.Titulo)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(p => p.Editora)
                .HasColumnType("varchar()")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(p => p.AnoPublicacao)
                .HasColumnType("varchar")
                .HasMaxLength(4)
                .IsRequired();
            builder.Property(p => p.Edicao)
                .IsRequired();
            builder.Property(p => p.Capa)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}