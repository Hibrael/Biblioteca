using System;

namespace Biblioteca.Modelos
{
    public class Livro
    {
        private string isbn;
        private string titulo;
        private string subtitulo;
        private string escritor;
        private string editora;
        private string genero;
        private int anoPublicacao;
        private string tipoDaCapa;
        private int numeroDePaginas;

        public string Isbn
        {
            get => isbn;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O ISBN não pode ser nulo ou vazio.");
                isbn = value.Trim();
            }
        }

        public string Titulo
        {
            get => titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O título não pode ser nulo ou vazio.");
                titulo = value.Trim();
            }
        }

        public string Subtitulo
        {
            get => subtitulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O subtítulo não pode ser nulo ou vazio.");
                subtitulo = value.Trim();
            }
        }

        public string Escritor
        {
            get => escritor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O escritor não pode ser nulo ou vazio.");
                escritor = value.Trim();
            }
        }

        public string Editora
        {
            get => editora;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A editora não pode ser nula ou vazia.");
                editora = value.Trim();
            }
        }

        public string Genero
        {
            get => genero;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O gênero não pode ser nulo ou vazio.");
                genero = value.Trim();
            }
        }

        public int AnoPublicacao
        {
            get => anoPublicacao;
            set
            {
                int anoAtual = DateTime.Now.Year;
                if (value < 1970 || value > anoAtual)
                    throw new ArgumentException($"O ano de publicação deve estar entre 1970 e {anoAtual}.");
                
                anoPublicacao = value;
            }
        }

        public string TipoDaCapa
        {
            get => tipoDaCapa;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O tipo da capa não pode ser nulo ou vazio.");
                tipoDaCapa = value.Trim();
            }
        }

        public int NumeroDePaginas
        {
            get => numeroDePaginas;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O número de páginas deve ser maior que zero.");
                numeroDePaginas = value;
            }
        }

        public Livro(string isbn, string titulo, string subtitulo, string escritor, 
                     string editora, string genero, int ano, string capa, int paginas)
        {
            Isbn = isbn;
            Titulo = titulo;
            Subtitulo = subtitulo;
            Escritor = escritor;
            Editora = editora;
            Genero = genero;
            AnoPublicacao = ano;
            TipoDaCapa = capa;
            NumeroDePaginas = paginas;
        }
    }
}