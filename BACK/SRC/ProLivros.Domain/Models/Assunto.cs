using System.ComponentModel.DataAnnotations;

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
        public ICollection<LivroAssunto>? LivroAssunto { get; set; }
    }
}
