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
                        Console.WriteLine("--- LISTA DE LEITORES ---");
                        if (listaDeLeitores.Count == 0)
                        {
                            Console.WriteLine("Nenhum leitor cadastrado.");
                        }
                        else
                        {
                            foreach (Leitor leitor in listaDeLeitores)
                            {
                                Console.WriteLine($"Nome: {leitor.nome}, CPF: {leitor.cpf}");
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("--- EDITAR LEITOR ---");
                        Console.Write("Digite o CPF do leitor que deseja editar: ");
                        string cpfParaEditar = Console.ReadLine();

                        Leitor leitorParaEditar = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfParaEditar);

                        if (leitorParaEditar != null)
                        {
                            Console.Write("Digite o novo nome do leitor: ");
                            string novoNome = Console.ReadLine();
                            leitorParaEditar.nome = novoNome;
                            Console.WriteLine("Leitor editado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Erro: Leitor não encontrado!");
                        }
                        break;

                    case "4":
                        Console.WriteLine("--- EXCLUIR LEITOR ---");
                        Console.Write("Digite o CPF do leitor que deseja excluir: ");
                        string cpfParaExcluir = Console.ReadLine();

                        Leitor leitorParaExcluir = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfParaExcluir);

                        if (leitorParaExcluir != null)
                        {
                            listaDeLeitores.Remove(leitorParaExcluir);
                            Console.WriteLine("Leitor excluído com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Erro: Leitor não encontrado!");
                        }
                        break;

                    case "5":
                        Console.WriteLine("--- INCLUIR LIVRO ---");
                        Console.Write("CPF do leitor para adicionar o livro: ");
                        string cpfLeitorLivro = Console.ReadLine();

                        Leitor leitorLivro = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorLivro);

                        if (leitorLivro != null)
                        {
                            Console.Write("Digite o título do livro: ");
                            string tituloLivro = Console.ReadLine();    
                            Console.Write("Digite o autor do livro: ");
                            string autorLivro = Console.ReadLine(); 
                            Livro novoLivro = new Livro(tituloLivro, autorLivro);
                            leitorLivro.livrosDoLeitor.Add(novoLivro);
                            Console.WriteLine("Livro adicionado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Erro: Leitor não encontrado!");

                        }
                        break;

                    case "6":
                        Console.WriteLine("--- EDITAR LIVRO ---");
                        Console.Write("CPF do leitor para editar o livro: ");
                        string cpfLeitorEditarLivro = Console.ReadLine();

                        Leitor leitorEditarLivro = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorEditarLivro);

                        if (leitorEditarLivro != null)
                        {
                            Console.Write("Digite o título do livro que deseja editar: ");
                            string tituloLivroEditar = Console.ReadLine();

                            Livro livroParaEditar = leitorEditarLivro.livrosDoLeitor.Find(livroAtual => livroAtual.titulo == tituloLivroEditar);

                            if (livroParaEditar != null)
                            {
                                Console.Write("Digite o novo título do livro: ");
                                string novoTitulo = Console.ReadLine();
                                Console.Write("Digite o novo autor do livro: ");
                                string novoAutor = Console.ReadLine();
                                livroParaEditar.titulo = novoTitulo;
                                livroParaEditar.autor = novoAutor;
                                Console.WriteLine("Livro editado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Erro: Livro não encontrado!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Erro: Leitor não encontrado!");
                        }
                        break;

                    case "7":
                        Console.WriteLine("--- REMOVER LIVRO ---");
                        Console.Write("CPF do leitor para editar o livro: ");
                        string cpfLeitorRemoverLivro = Console.ReadLine();

                        Leitor leitorRemoverLivro = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorRemoverLivro);

                        if (leitorRemoverLivro != null)
                        {
                            Console.Write("Digite o título do livro que deseja remover: ");
                            string tituloLivroRemover = Console.ReadLine();

                            Livro livroParaRemover = leitorRemoverLivro.livrosDoLeitor.Find(livroAtual => livroAtual.titulo == tituloLivroRemover);

                            if (livroParaRemover != null)
                            {
                                leitorRemoverLivro.livrosDoLeitor.Remove(livroParaRemover);
                                Console.WriteLine("Livro removido com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Erro: Livro não encontrado!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Erro: Leitor não encontrado!");
                        }

                        break;

                    case "8":
                        Console.WriteLine("--- DOAR LIVRO ---");
                        Console.Write("CPF do leitor que irá doar o livro: ");
                        string cpfLeitorDoar = Console.ReadLine();

                        Leitor leitorDoar = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorDoar);

                        if (leitorDoar != null)
                        {
                            Console.Write("Digite o título do livro que deseja doar: ");
                            string tituloLivroDoar = Console.ReadLine();

                            Livro livroParaDoar = leitorDoar.livrosDoLeitor.Find(livroAtual => livroAtual.titulo == tituloLivroDoar);

                            if (livroParaDoar != null)
                            {
                                Console.Write("CPF do leitor que irá receber o livro: ");
                                string cpfLeitorReceber = Console.ReadLine();

                                Leitor leitorReceber = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorReceber);

                                if (leitorReceber != null)
                                {
                                    leitorDoar.livrosDoLeitor.Remove(livroParaDoar);
                                    leitorReceber.livrosDoLeitor.Add(livroParaDoar);
                                    Console.WriteLine("Livro doado com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Erro: Leitor destinatário não encontrado!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Erro: Livro não encontrado!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Erro: Leitor doador não encontrado!");
                        }
                        break;

                    case "9":
                        Console.WriteLine("--- LISTA COMPLETA DE LEITORES E SEUS LIVROS ---");
                        if (listaDeLeitores.Count == 0)
                        {
                            Console.WriteLine("Nenhum leitor cadastrado.");
                        }
                        else
                        {
                            foreach (Leitor leitor in listaDeLeitores)
                            {
                                Console.WriteLine($"Nome: {leitor.nome}, CPF: {leitor.cpf}");
                                if (leitor.livrosDoLeitor.Count == 0)
                                {
                                    Console.WriteLine("  Nenhum livro cadastrado para este leitor.");
                                }
                                else
                                {
                                    foreach (Livro livro in leitor.livrosDoLeitor)
                                    {
                                        Console.WriteLine($"  Título: {livro.titulo}, Autor: {livro.autor}");
                                    }
                                }
                            }
                        }
                        break;

                    case "10":
                        Console.WriteLine("--- LISTAR LEITOR ESPECÍFICO E SEUS LIVROS ---");
                        Console.Write("Digite o CPF do leitor que deseja listar: ");
                        string cpfLeitorListar = Console.ReadLine();

                        Leitor leitorListar = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorListar);

                        if (leitorListar != null)
                        {
                            Console.WriteLine($"Nome: {leitorListar.nome}, CPF: {leitorListar.cpf}");
                            if (leitorListar.livrosDoLeitor.Count == 0)
                            {
                                Console.WriteLine("  Nenhum livro cadastrado para este leitor.");
                            }
                            else
                            {
                                foreach (Livro livro in leitorListar.livrosDoLeitor)
                                {
                                    Console.WriteLine($"  Título: {livro.titulo}, Autor: {livro.autor}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Erro: Leitor não encontrado!");
                        }
                        break;

                    case "11":
                        Console.WriteLine("--- PESQUISAR POR LIVRO ESPECÍFICO ---");
                        Console.Write("Digite o título do livro que deseja pesquisar: ");
                        string tituloLivroPesquisar = Console.ReadLine();

                        List<Leitor> leitoresComLivro = listaDeLeitores.FindAll(leitorAtual => leitorAtual.livrosDoLeitor.Exists(livroAtual => livroAtual.titulo == tituloLivroPesquisar));

                        if (leitoresComLivro.Count > 0)
                        {
                            Console.WriteLine($"O livro '{tituloLivroPesquisar}' está com os seguintes leitores:");
                            foreach (Leitor leitor in leitoresComLivro)
                            {
                                Console.WriteLine($"Nome: {leitor.nome}, CPF: {leitor.cpf}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum leitor encontrado com este livro.");
                        }
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