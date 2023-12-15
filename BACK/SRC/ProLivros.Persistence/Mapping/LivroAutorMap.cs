using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProLivros.Domain;


namespace ProLivros.Persistence
{
    public class LivroAutorMap : IEntityTypeConfiguration<LivroAutor>
    {
        public void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            builder.HasNoKey();
            builder.ToTable("Livro_Autor");

            // FK - configuracao
            builder.HasOne(u => u.Livro)
                    .WithMany()
                    .HasForeignKey(u => u.Livro_Codl)
                    .IsRequired(true);

            builder.HasOne(u => u.Autor)
                    .WithMany()
                    .HasForeignKey(u => u.Autor_CodAu)
                    .IsRequired(true);
        }
    }
}