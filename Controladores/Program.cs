using System;
using System.Collections.Generic;
using Biblioteca.Modelos;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Leitor> listaDeLeitores = new List<Leitor>();
            string opcaoEscolhida = "";

            while (opcaoEscolhida != "0")
            {
                Console.WriteLine("--- MENU DA BIBLIOTECA ---");
                Console.WriteLine("1 - Cadastrar leitor");
                Console.WriteLine("2 - Listar leitores");
                Console.WriteLine("3 - Editar leitor");
                Console.WriteLine("4 - Excluir leitor");
                Console.WriteLine("5 - Incluir livro para um leitor");
                Console.WriteLine("6 - Editar livro de um leitor");
                Console.WriteLine("7 - Remover livro de um leitor");
                Console.WriteLine("8 - Doar livro para outro leitor");
                Console.WriteLine("9 - Listar todos os leitores e seus livros");
                Console.WriteLine("10 - Listar um leitor especifico e seus livros");
                Console.WriteLine("11 - Pesquisar por um livro especifico");
                Console.WriteLine("0 - Sair do programa");
                Console.Write("Digite a opcao desejada: ");

                opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida)
                {
                    case "1":
                        Console.WriteLine("--- CADASTRAR NOVO LEITOR ---");
                        Console.Write("Digite o nome do leitor: ");
                        string nomeDoLeitor = Console.ReadLine();

                        Console.Write("Digite o CPF do leitor: ");
                        string cpfDoLeitor = Console.ReadLine();

                        bool cpfJaExiste = listaDeLeitores.Exists(leitorAtual => leitorAtual.cpf == cpfDoLeitor);

                        if (cpfJaExiste)
                        {
                            Console.WriteLine("Erro: Já existe um leitor cadastrado com este CPF!");
                        }
                        else
                        {
                            Leitor novoLeitor = new Leitor(nomeDoLeitor, cpfDoLeitor);
                            listaDeLeitores.Add(novoLeitor);
                            Console.WriteLine("Leitor cadastrado com sucesso!");
                        }
                        break;

                    case "2":
                        // Implementaremos em seguida
                        break;

                    case "0":
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opcao invalida. Tente novamente.");
                        break;
                }

                Console.WriteLine(); 
            }
        }
    }
}