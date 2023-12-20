<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
=======

using System.ComponentModel.DataAnnotations.Schema;

>>>>>>> PROLIVROS COMMIT-06

namespace ProLivros.Domain
{

    public class Livro
    {
        // public Livro(int codl, string titulo, string editora, int edicao, string anoPublicacao, Autor autor, Assunto assunto)
        // {
        //    Codl = codl;
        //    Titulo = titulo;
        //    Editora = editora;
        //    Edicao = edicao;
        //    AnoPublicacao = anoPublicacao;

        // }
        
        public int Codl { get; set; }
        public string? Titulo { get; set; }
        public string? Editora { get; set; }
        public int Edicao { get; set; }
        public string? AnoPublicacao { get; set; }
        public string? Capa { get; set; }

<<<<<<< HEAD
        [NotMapped]
        public IEnumerable<LivroAutor> LivroAutor { get; set; }
        [NotMapped]
        public IEnumerable<LivroAssunto> LivroAssunto { get; set; }
=======


        [NotMapped]
        public IEnumerable<LivroAutor> LivroAutor { get; set; } = null;
        [NotMapped]
        public IEnumerable<LivroAssunto> LivroAssunto { get; set; } = null;
>>>>>>> PROLIVROS COMMIT-06
    }
}