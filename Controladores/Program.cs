using System;
using System.Collections.Generic;
using Biblioteca.Modelos;

// Hibrael Xavier
// Leandro Cordova

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
                Console.Clear();
                ImprimirTitulo("MENU DA BIBLIOTECA");
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
                ImprimirSeparador();
                Console.Write("Digite a opcao desejada: ");

                opcaoEscolhida = Console.ReadLine() ?? "";

                switch (opcaoEscolhida)
                {
                    case "1":
                        ImprimirTitulo("CADASTRAR NOVO LEITOR");
                        Console.Write("Digite o nome do leitor: ");
                        string nomeDoLeitor = Console.ReadLine() ?? "";

                        Console.Write("Digite o CPF do leitor: ");
                        string cpfDoLeitor = Console.ReadLine() ?? "";

                        if (!valida_cpf(cpfDoLeitor))
                        {
                            ImprimirErro("Erro: CPF inválido. O CPF deve conter no mínimo 11 dígitos numéricos!");
                        }
                        else
                        {
                            bool cpfJaExiste = listaDeLeitores.Exists(leitorAtual => leitorAtual.cpf == cpfDoLeitor);

                            if (cpfJaExiste)
                            {
                                ImprimirErro("Erro: Já existe um leitor cadastrado com este CPF!");
                            }
                            else
                            {
                                Leitor novoLeitor = new Leitor(nomeDoLeitor, cpfDoLeitor);
                                listaDeLeitores.Add(novoLeitor);
                                ImprimirSucesso("Leitor cadastrado com sucesso!");
                            }
                        }
                        break;

                    case "2":
                        ImprimirTitulo("LISTA DE LEITORES");
                        if (VerificaSeTemLeitores(listaDeLeitores, "Nenhum leitor cadastrado."))
                        {
                            foreach (Leitor leitor in listaDeLeitores)
                            {
                                Console.WriteLine($"Nome: {leitor.nome}, CPF: {leitor.cpf}");
                            }
                        }
                        break;

                    case "3":
                        ImprimirTitulo("EDITAR LEITOR");
                        Console.Write("Digite o CPF do leitor que deseja editar: ");
                        string cpfParaEditar = Console.ReadLine() ?? "";

                        Leitor? leitorParaEditar = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfParaEditar);

                        if (leitorParaEditar != null)
                        {
                            Console.Write("Digite o novo nome do leitor: ");
                            string novoNome = Console.ReadLine() ?? "";
                            leitorParaEditar.nome = novoNome;
                            ImprimirSucesso("Leitor editado com sucesso!");
                        }
                        else
                        {
                            ImprimirErro("Erro: Leitor não encontrado!");
                        }
                        break;

                    case "4":
                        ImprimirTitulo("EXCLUIR LEITOR");
                        Console.Write("Digite o CPF do leitor que deseja excluir: ");
                        string cpfParaExcluir = Console.ReadLine() ?? "";

                        Leitor? leitorParaExcluir = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfParaExcluir);

                        if (leitorParaExcluir != null)
                        {
                            listaDeLeitores.Remove(leitorParaExcluir);
                            ImprimirSucesso("Leitor excluuído com sucesso!");
                        }
                        else
                        {
                            ImprimirErro("Erro: Leitor não encontrado!");
                        }
                        break;

                    case "5":
                        ImprimirTitulo("INCLUIR LIVRO");
                        if (VerificaSeTemLeitores(listaDeLeitores, "Erro: Nenhum leitor cadastrado! Cadastre um leitor antes de adicionar livros."))
                        {
                            Console.Write("CPF do leitor para adicionar o livro: ");
                            string cpfLeitorLivro = Console.ReadLine() ?? "";

                            Leitor? leitorLivro = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorLivro);

                            if (leitorLivro != null)
                            {
                                Console.Write("Digite o título do livro: ");
                                string tituloLivro = Console.ReadLine() ?? "";    
                                Console.Write("Digite o autor do livro: ");
                                string autorLivro = Console.ReadLine() ?? ""; 
                                Livro novoLivro = new Livro(tituloLivro, autorLivro);
                                leitorLivro.livrosDoLeitor.Add(novoLivro);
                                ImprimirSucesso("Livro adicionado com sucesso!");
                            }
                            else
                            {
                                ImprimirErro("Erro: Leitor não encontrado!");
                            }
                        }
                        break;

                    case "6":
                        ImprimirTitulo("EDITAR LIVRO");
                        if (VerificaSeTemLeitores(listaDeLeitores))
                        {
                            Console.Write("CPF do leitor para editar o livro: ");
                            string cpfLeitorEditarLivro = Console.ReadLine() ?? "";

                            Leitor? leitorEditarLivro = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorEditarLivro);

                            if (leitorEditarLivro != null)
                            {
                                if (leitorEditarLivro.livrosDoLeitor.Count == 0)
                                {
                                    ImprimirErro("Erro: Este leitor não possui livros cadastrados!");
                                }
                                else
                                {
                                    Console.Write("Digite o título do livro que deseja editar: ");
                                    string tituloLivroEditar = Console.ReadLine() ?? "";
                                    string tituloLivroEditarLower = tituloLivroEditar?.ToLowerInvariant() ?? "";

                                    Livro? livroParaEditar = leitorEditarLivro.livrosDoLeitor.Find(livroAtual => (livroAtual.titulo?.ToLowerInvariant() ?? "") == tituloLivroEditarLower);

                                    if (livroParaEditar != null)
                                    {
                                        Console.Write("Digite o novo título do livro: ");
                                        string novoTitulo = Console.ReadLine() ?? "";
                                        Console.Write("Digite o novo autor do livro: ");
                                        string novoAutor = Console.ReadLine() ?? "";
                                        livroParaEditar.titulo = novoTitulo;
                                        livroParaEditar.autor = novoAutor;
                                        ImprimirSucesso("Livro editado com sucesso!");
                                    }
                                    else
                                    {
                                        ImprimirErro("Erro: Livro não encontrado!");
                                    }
                                }
                            }
                            else
                            {
                                ImprimirErro("Erro: Leitor não encontrado!");
                            }
                        }
                        break;

                    case "7":
                        ImprimirTitulo("REMOVER LIVRO");
                        if (VerificaSeTemLeitores(listaDeLeitores))
                        {
                            Console.Write("CPF do leitor para remover o livro: ");
                            string cpfLeitorRemoverLivro = Console.ReadLine() ?? "";

                            Leitor? leitorRemoverLivro = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorRemoverLivro);

                            if (leitorRemoverLivro != null)
                            {
                                if (leitorRemoverLivro.livrosDoLeitor.Count == 0)
                                {
                                    ImprimirErro("Erro: Este leitor não possui livros cadastrados!");
                                }
                                else
                                {
                                    Console.Write("Digite o título do livro que deseja remover: ");
                                    string tituloLivroRemover = Console.ReadLine() ?? "";
                                    string tituloLivroRemoverLower = tituloLivroRemover?.ToLowerInvariant() ?? "";

                                    Livro? livroParaRemover = leitorRemoverLivro.livrosDoLeitor.Find(livroAtual => (livroAtual.titulo?.ToLowerInvariant() ?? "") == tituloLivroRemoverLower);

                                    if (livroParaRemover != null)
                                    {
                                        leitorRemoverLivro.livrosDoLeitor.Remove(livroParaRemover);
                                        ImprimirSucesso("Livro removido com sucesso!");
                                    }
                                    else
                                    {
                                        ImprimirErro("Erro: Livro não encontrado!");
                                    }
                                }
                            }
                            else
                            {
                                ImprimirErro("Erro: Leitor não encontrado!");
                            }
                        }
                        break;

                    case "8":
                        ImprimirTitulo("DOAR LIVRO");
                        if (listaDeLeitores.Count < 2)
                        {
                            ImprimirErro("Erro: É necessário ter pelo menos 2 leitores cadastrados para fazer uma doação!");
                        }
                        else
                        {
                            Console.Write("CPF do leitor que irá doar o livro: ");
                            string cpfLeitorDoar = Console.ReadLine() ?? "";

                            Leitor? leitorDoar = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorDoar);

                            if (leitorDoar != null)
                            {
                                if (leitorDoar.livrosDoLeitor.Count == 0)
                                {
                                    ImprimirErro("Erro: Este leitor não possui livros para doar!");
                                }
                                else
                                {
                                    Console.Write("Digite o título do livro que deseja doar: ");
                                    string tituloLivroDoar = Console.ReadLine() ?? "";
                                    string tituloLivroDoarLower = tituloLivroDoar?.ToLowerInvariant() ?? "";

                                    Livro? livroParaDoar = leitorDoar.livrosDoLeitor.Find(livroAtual => (livroAtual.titulo?.ToLowerInvariant() ?? "") == tituloLivroDoarLower);

                                    if (livroParaDoar != null)
                                    {
                                        Console.Write("CPF do leitor que irá receber o livro: ");
                                        string cpfLeitorReceber = Console.ReadLine() ?? "";

                                        Leitor? leitorReceber = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorReceber);

                                        if (leitorReceber != null)
                                        {
                                            if (leitorReceber.cpf == leitorDoar.cpf)
                                            {
                                                ImprimirErro("Erro: Um leitor não pode doar um livro para si mesmo!");
                                            }
                                            else
                                            {
                                                leitorDoar.livrosDoLeitor.Remove(livroParaDoar);
                                                leitorReceber.livrosDoLeitor.Add(livroParaDoar);
                                                ImprimirSucesso("Livro doado com sucesso!");
                                            }
                                        }
                                        else
                                        {
                                            ImprimirErro("Erro: Leitor destinatário não encontrado!");
                                        }
                                    }
                                    else
                                    {
                                        ImprimirErro("Erro: Livro não encontrado!");
                                    }
                                }
                            }
                            else
                            {
                                ImprimirErro("Erro: Leitor doador não encontrado!");
                            }
                        }
                        break;

                    case "9":
                        ImprimirTitulo("LISTA COMPLETA DE LEITORES E SEUS LIVROS");
                        if (VerificaSeTemLeitores(listaDeLeitores, "Erro: Nenhum leitor cadastrado. Cadastre um leitor antes de listar."))
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
                        ImprimirTitulo("LISTAR LEITOR ESPECÍFICO E SEUS LIVROS");
                        if (VerificaSeTemLeitores(listaDeLeitores))
                        {
                            Console.Write("Digite o CPF do leitor que deseja listar: ");
                            string cpfLeitorListar = Console.ReadLine() ?? "";

                            Leitor? leitorListar = listaDeLeitores.Find(leitorAtual => leitorAtual.cpf == cpfLeitorListar);

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
                                ImprimirErro("Erro: Leitor não encontrado!");
                            }
                        }
                        break;

                    case "11":
                        ImprimirTitulo("PESQUISAR POR LIVRO ESPECÍFICO");
                        if (VerificaSeTemLeitores(listaDeLeitores))
                        {
                            bool temLivrosRegistrados = listaDeLeitores.Exists(leitorAtual => leitorAtual.livrosDoLeitor.Count > 0);
                            
                            if (!temLivrosRegistrados)
                            {
                                ImprimirErro("Erro: Nenhum livro cadastrado no sistema!");
                            }
                            else
                            {
                                Console.Write("Digite o título do livro que deseja pesquisar: ");
                                string tituloLivroPesquisar = Console.ReadLine() ?? "";
                                string tituloLivroPesquisarLower = tituloLivroPesquisar?.ToLowerInvariant() ?? "";

                                List<Leitor> leitoresComLivro = listaDeLeitores.FindAll(leitorAtual => leitorAtual.livrosDoLeitor.Exists(livroAtual => (livroAtual.titulo?.ToLowerInvariant() ?? "") == tituloLivroPesquisarLower));

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
                            }
                        }
                        break;

                    case "0":
                        ImprimirTitulo("SAÍDA DO SISTEMA");
                        break;

                    default:
                        ImprimirErro("Opcao invalida. Tente novamente.");
                        break;
                }

                if (opcaoEscolhida != "0")
                {
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

        static bool VerificaSeTemLeitores(List<Leitor> lista, string mensagem = "Erro: Nenhum leitor cadastrado!")
        {
            if (lista.Count == 0)
            {
                ImprimirErro(mensagem);
                return false;
            }
            return true;
        }

        static void ImprimirErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        static void ImprimirSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        static void ImprimirTitulo(string titulo)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔" + new string('═', titulo.Length + 2) + "╗");
            Console.WriteLine("║ " + titulo + " ║");
            Console.WriteLine("╚" + new string('═', titulo.Length + 2) + "╝");
            Console.ResetColor();
        }

        static void ImprimirSeparador()
        {
            Console.WriteLine(new string('─', 60));
        }

        static bool valida_cpf(string cpfDigitado)
        {
            string cpfLimpo = System.Text.RegularExpressions.Regex.Replace(cpfDigitado, "[^0-9]", "");
            return cpfLimpo.Length >= 11;
        }
    }
}