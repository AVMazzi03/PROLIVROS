using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Domain
{
    public class LivroAutor
    {
        public int Livro_Codl { get; set; }
        public Livro? Livro { get; set; }
        public int  Autor_CodAu { get; set; }
        public Assunto? Autor { get; set; }
    }
}