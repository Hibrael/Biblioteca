using System;
using System.Collections.Generic;

namespace Biblioteca.Modelos
{
    public class Leitor
    {
        private static List<string> ListaCpfsExistentes = new List<string>();

        private string _nome;
        private string _cpf;
        private int _idade;

        public List<Livro> LivrosDoLeitor { get; set; }

        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome não pode ser nulo ou vazio.");
                
                _nome = value.Trim();
            }
        }

        public string Cpf
        {
            get => _cpf;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O CPF não pode ser nulo ou vazio.");
                }

                string cpfFormatado = value.Trim();

                if (ListaCpfsExistentes.Contains(cpfFormatado) && _cpf != cpfFormatado)
                {       
                    throw new ArgumentException("Este CPF já está cadastrado.");
                }


                if (_cpf != null) ListaCpfsExistentes.Remove(_cpf);
                
                _cpf = cpfFormatado;
                ListaCpfsExistentes.Add(_cpf);
            }
        }

        public int Idade
        {
            get => _idade;
            set
            {
                if (value < 0)
                    throw new ArgumentException("A idade não pode ser negativa.");
                
                _idade = value;
            }
        }

        public Leitor(string nomeDoLeitor, string cpfDoLeitor, int idadeDoLeitor)
        {
            Nome = nomeDoLeitor;
            Cpf = cpfDoLeitor;
            Idade = idadeDoLeitor;
            LivrosDoLeitor = new List<Livro>();
        }
    }
}