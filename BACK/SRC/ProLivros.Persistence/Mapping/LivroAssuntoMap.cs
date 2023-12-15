using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProLivros.Domain;

namespace ProLivros.Persistence
{
    public class LivroAssuntoMap : IEntityTypeConfiguration<LivroAssunto>
    {
             public void Configure(EntityTypeBuilder<LivroAssunto> builder){
                
                builder.HasNoKey();
                builder.ToTable("Livro_Assunto");

                // FK - configuracao
                builder.HasOne(u => u.Livro)
                        .WithMany()
                        .HasForeignKey(u => u.Livro_Codl)
                        .IsRequired(true);

                builder.HasOne(u => u.Assunto)
                        .WithMany()
                        .HasForeignKey(u => u.Assunto_CodAs)
                        .IsRequired(true);
             }
    }
}