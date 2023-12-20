<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> PROLIVROS COMMIT-06

namespace ProLivros.Domain
{
    public class Assunto
    {
        // public Assunto(int codAs, string descricao, ICollection<Livro> livros)
        // {
        //    CodAs = codAs;
        //    Descricao = descricao;
        //    Livros = livros;
        // }

        public int CodAs { get; set; }
        public string? Descricao { get; set; }
<<<<<<< HEAD
        public ICollection<LivroAssunto>? LivroAssunto { get; set; }
=======
        [NotMapped]
        public IEnumerable<LivroAssunto>? LivroAssunto { get; set; } = null;
>>>>>>> PROLIVROS COMMIT-06
    }
}
