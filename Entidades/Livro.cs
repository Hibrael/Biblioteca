namespace Biblioteca.Modelos
{
    public class Livro
    {
        public string titulo;
        public string autor;

        public Livro(string nomeDoTitulo, string nomeDoAutor)
        {
            titulo = nomeDoTitulo;
            autor = nomeDoAutor;
        }
    }
}