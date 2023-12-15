using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Domain
{
    public class LivroAssunto
    {
        public int Livro_Codl { get; set; }
        public Livro Livro { get; set; }
        public int Assunto_CodAs { get; set; }
        public Assunto Assunto { get; set; }

    }
}