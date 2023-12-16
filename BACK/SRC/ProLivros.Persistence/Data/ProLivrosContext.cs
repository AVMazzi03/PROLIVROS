using Microsoft.EntityFrameworkCore;
using ProLivros.Domain;
using ProLivros.Persistence.Mappping;

namespace ProLivros.Persistence
{
    public class ProLivrosContext : DbContext
    {
        public ProLivrosContext (DbContextOptions<ProLivrosContext> options)
            : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new AssuntoMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new LivroAssuntoMap());
            modelBuilder.ApplyConfiguration(new LivroAutorMap());
        }


        public DbSet<Livro> Livros { get; set;}
        public DbSet<Assunto> Assuntos { get; set;}
        public DbSet<Autor> Autores { get; set; }
        public DbSet<LivroAutor> LivrosAutores { get; set; }
        public DbSet<LivroAssunto> LivrosAssuntos { get; set; }

    }
}
