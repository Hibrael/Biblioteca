using System;
namespace Biblioteca.Modelos
{
    public class Leitor
    {
        public string nome;
        public string cpf;
        public List<Livro> livrosDoLeitor;

        public Leitor(string nomeDoLeitor, string cpfDoLeitor)
        {
            nome = nomeDoLeitor;
            cpf = cpfDoLeitor;
            livrosDoLeitor = new List<Livro>();
        }
    }
}