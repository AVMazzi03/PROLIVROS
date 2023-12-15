using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProLivros.Domain;

namespace ProLivros.Persistence
{
    class AssuntoMap : IEntityTypeConfiguration<Assunto>
    {
        public void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder.ToTable("Assunto");
            builder.HasKey( p => p.CodAs);
            builder.Property(p => p.Descricao)   
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}