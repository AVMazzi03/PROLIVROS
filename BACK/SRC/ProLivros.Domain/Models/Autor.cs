<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
=======

using System.ComponentModel.DataAnnotations.Schema;

>>>>>>> PROLIVROS COMMIT-06

namespace ProLivros.Domain
{
    public class Autor
    {
        // public Autor(int codAu, string nome, ICollection<Livro> livros)
        // {
        //    CodAu = codAu;
        //    Nome = nome;
        //    Livros = livros;
        // }

        public int CodAu { get; set; }
        public string? Nome { get; set; }
<<<<<<< HEAD

        public ICollection<LivroAutor>? LivroAutor { get; set; }
=======
        [NotMapped]
        public IEnumerable<LivroAutor> LivroAutor { get; set; } = null;
>>>>>>> PROLIVROS COMMIT-06

    }
}