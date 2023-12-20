using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProLivros.Domain;

namespace ProLivros.Persistence
{
    public class LivroAssuntoMap : IEntityTypeConfiguration<LivroAssunto>
    {
<<<<<<< HEAD
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
=======
        public void Configure(EntityTypeBuilder<LivroAssunto> modelBuilder)
        {
            //builder.ToTable("Livro_Assunto");
            //builder.HasKey(LA => new { LA.Livro_Codl, LA.Assunto_CodAs });
            //builder.HasNoKey();
            // FK - configuracao
            //    builder.HasOne(u => u.Livro)
            //            .WithMany()
            //            .HasForeignKey(u => u.Livro_Codl)
            //            .IsRequired(true);

            //    builder.HasOne(u => u.Assunto)
            //            .WithMany()
            //            .HasForeignKey(u => u.Assunto_CodAs)
            //            .IsRequired(true);
            modelBuilder.HasNoKey();
            modelBuilder.ToTable("Livro_Assunto");            
            modelBuilder.HasIndex(x => x.Assunto_CodAs, "IX_Livro_Assunto_Assunto_CoAs");
            modelBuilder.HasIndex(y => y.Livro_Codl, "IX_Livro_Assunto_Livro_Codl");


            modelBuilder.HasOne(d => d.Assunto)
                        .WithMany()
                        .HasForeignKey(d => d.Assunto_CodAs);

            modelBuilder.HasOne(d => d.Livro)
                        .WithMany()
                        .HasForeignKey(d => d.Livro_Codl);
            modelBuilder.Navigation(l => l.Assunto).AutoInclude();
        }
>>>>>>> PROLIVROS COMMIT-06
    }
}