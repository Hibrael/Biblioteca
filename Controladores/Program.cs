using System;
using System.Collections.Generic;
using Biblioteca.Modelos;

// Leandro Cordova
// Hibrael Xavier

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
                try
                {
                    Console.Clear();
                    ImprimirTitulo("BIBLIOTECA");
                    Console.WriteLine("1 - Cadastrar leitor");
                    Console.WriteLine("2 - Listar leitores");
                    Console.WriteLine("3 - Editar leitor");
                    Console.WriteLine("4 - Excluir leitor");
                    Console.WriteLine("5 - Incluir livro para um leitor");
                    Console.WriteLine("6 - Editar livro de um leitor");
                    Console.WriteLine("7 - Remover livro de um leitor");
                    Console.WriteLine("8 - Doar livro para outro leitor");
                    Console.WriteLine("9 - Listar todos os leitores e seus livros");
                    Console.WriteLine("10 - Listar um leitor específico e seus livros");
                    Console.WriteLine("11 - Pesquisar por um livro específico");
                    Console.WriteLine("0 - Sair do programa");
                    ImprimirSeparador();
                    Console.Write("Digite a opção desejada: ");

                    opcaoEscolhida = Console.ReadLine() ?? "";

                    switch (opcaoEscolhida)
                    {
                        case "1":
                            ImprimirTitulo("CADASTRAR NOVO LEITOR");
                            Console.Write("Nome: "); string nomeLeitor = Console.ReadLine() ?? "";
                            Console.Write("CPF: "); string cpfLeitor = Console.ReadLine() ?? "";
                            Console.Write("Idade: "); int idadeLeitor = int.Parse(Console.ReadLine() ?? "0");
                            
                            listaDeLeitores.Add(new Leitor(nomeLeitor, cpfLeitor, idadeLeitor));
                            ImprimirSucesso("Leitor cadastrado!");
                            break;

                        case "2":
                            ImprimirTitulo("LISTA DE LEITORES");
                            ValidarListaNaoVazia(listaDeLeitores);
                            foreach (var leitor in listaDeLeitores)
                            {
                                Console.WriteLine($"Nome: {leitor.Nome} | CPF: {leitor.Cpf} | Idade: {leitor.Idade}");
                            }
                            break;

                        case "3":
                            ImprimirTitulo("EDITAR LEITOR");
                            ValidarListaNaoVazia(listaDeLeitores);
                            Console.Write("CPF do leitor: ");
                            var leitorEdicao = BuscarLeitorPorCpf(listaDeLeitores, Console.ReadLine() ?? "");
                            Console.Write("Novo Nome: "); leitorEdicao.Nome = Console.ReadLine() ?? "";
                            Console.Write("Nova Idade: "); leitorEdicao.Idade = int.Parse(Console.ReadLine() ?? "0");
                            ImprimirSucesso("Dados atualizados!");
                            break;

                        case "4":
                            ImprimirTitulo("EXCLUIR LEITOR");
                            ValidarListaNaoVazia(listaDeLeitores);
                            Console.Write("CPF para excluir: ");
                            var leitorExclusao = BuscarLeitorPorCpf(listaDeLeitores, Console.ReadLine() ?? "");
                            listaDeLeitores.Remove(leitorExclusao);
                            ImprimirSucesso("Leitor removido!");
                            break;

                        case "5":
                            ImprimirTitulo("INCLUIR LIVRO");
                            ValidarListaNaoVazia(listaDeLeitores);
                            Console.Write("CPF do leitor: ");
                            var leitorDestino = BuscarLeitorPorCpf(listaDeLeitores, Console.ReadLine() ?? "");
                            
                            Livro novoLivro = ColetarDadosLivro();
                            leitorDestino.LivrosDoLeitor.Add(novoLivro);
                            ImprimirSucesso("Livro adicionado!");
                            break;

                        case "6":
                            ImprimirTitulo("EDITAR LIVRO");
                            ValidarListaNaoVazia(listaDeLeitores);
                            Console.Write("CPF do leitor: ");
                            var leitorParaEditarLivro = BuscarLeitorPorCpf(listaDeLeitores, Console.ReadLine() ?? "");
                            Console.Write("Título do livro para editar: ");
                            var livroParaEditar = BuscarLivroNoLeitor(leitorParaEditarLivro, Console.ReadLine() ?? "");
                            
                            Console.WriteLine("(ISBN não pode ser alterado)");
                            Console.Write("Novo Título: "); livroParaEditar.Titulo = Console.ReadLine() ?? "";
                            Console.Write("Novo Subtítulo: "); livroParaEditar.Subtitulo = Console.ReadLine() ?? "";
                            Console.Write("Novo Escritor: "); livroParaEditar.Escritor = Console.ReadLine() ?? "";
                            Console.Write("Nova Editora: "); livroParaEditar.Editora = Console.ReadLine() ?? "";
                            Console.Write("Novo Gênero: "); livroParaEditar.Genero = Console.ReadLine() ?? "";
                            Console.Write("Novo Ano: "); livroParaEditar.AnoPublicacao = int.Parse(Console.ReadLine() ?? "0");
                            Console.Write("Novo Tipo Capa: "); livroParaEditar.TipoDaCapa = Console.ReadLine() ?? "";
                            Console.Write("Novo Num Páginas: "); livroParaEditar.NumeroDePaginas = int.Parse(Console.ReadLine() ?? "0");
                            ImprimirSucesso("Livro editado!");
                            break;

                        case "7":
                            ImprimirTitulo("REMOVER LIVRO");
                            ValidarListaNaoVazia(listaDeLeitores);
                            Console.Write("CPF do leitor: ");
                            var leitorRemoverLivro = BuscarLeitorPorCpf(listaDeLeitores, Console.ReadLine() ?? "");
                            Console.Write("Título do livro para remover: ");
                            var livroRemocao = BuscarLivroNoLeitor(leitorRemoverLivro, Console.ReadLine() ?? "");
                            leitorRemoverLivro.LivrosDoLeitor.Remove(livroRemocao);
                            ImprimirSucesso("Livro removido!");
                            break;

                        case "8":
                            ImprimirTitulo("DOAR LIVRO");
                            if (listaDeLeitores.Count < 2) 
                            {
                                throw new Exception("Necessário ao menos 2 leitores.");
                            }
                            Console.Write("CPF do Doador: ");
                            var doador = BuscarLeitorPorCpf(listaDeLeitores, Console.ReadLine() ?? "");
                            Console.Write("CPF do Recebedor: ");
                            var recebedor = BuscarLeitorPorCpf(listaDeLeitores, Console.ReadLine() ?? "");
                            if (doador == recebedor) 
                            {
                                throw new Exception("Um leitor não pode doar para si mesmo.");
                            }

                            Console.Write("Título do livro para doar: ");
                            var livroDoado = BuscarLivroNoLeitor(doador, Console.ReadLine() ?? "");
                            doador.LivrosDoLeitor.Remove(livroDoado);
                            recebedor.LivrosDoLeitor.Add(livroDoado);
                            ImprimirSucesso("Doação concluída!");
                            break;

                        case "9":
                            ImprimirTitulo("TODOS OS LEITORES E LIVROS");
                            ValidarListaNaoVazia(listaDeLeitores);
                            foreach (var leitor in listaDeLeitores)
                            {
                                Console.WriteLine($"Leitor: {leitor.Nome} | Livros: {leitor.LivrosDoLeitor.Count}");
                                foreach (var livro in leitor.LivrosDoLeitor)
                                {
                                    Console.WriteLine($"  - {livro.Titulo} ({livro.Escritor})");
                                }
                            }
                            break;

                        case "10":
                            ImprimirTitulo("LEITOR ESPECÍFICO");
                            Console.Write("CPF: ");
                            var leitorFocado = BuscarLeitorPorCpf(listaDeLeitores, Console.ReadLine() ?? "");
                            Console.WriteLine($"Nome: {leitorFocado.Nome} | Idade: {leitorFocado.Idade}");
                            foreach (var livro in leitorFocado.LivrosDoLeitor)
                            {
                                Console.WriteLine($"  - {livro.Titulo} | Ano: {livro.AnoPublicacao}");
                            }
                            break;

                        case "11":
                            ImprimirTitulo("PESQUISAR LIVRO NO SISTEMA");
                            Console.Write("Título da busca: ");
                            string busca = (Console.ReadLine() ?? "").ToLower();
                            bool encontrado = false;
                            foreach (var leitor in listaDeLeitores)
                            {
                                var livrosAchados = leitor.LivrosDoLeitor.FindAll(liv => liv.Titulo.ToLower().Contains(busca));
                                if (livrosAchados.Count > 0)
                                {
                                    encontrado = true;
                                    Console.WriteLine($"O leitor {leitor.Nome} possui o livro!");
                                }
                            }
                            if (!encontrado) Console.WriteLine("Livro não encontrado em nenhum acervo.");
                            break;

                        case "0":
                            break;

                        default:
                            throw new Exception("Opção inválida.");
                    }
                }
                catch (Exception ex)
                {
                    ImprimirErro(ex.Message);
                }

                if (opcaoEscolhida != "0")
                {
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static Livro ColetarDadosLivro()
        {
            Console.Write("ISBN: "); string isbn = Console.ReadLine() ?? "";
            Console.Write("Título: "); string tit = Console.ReadLine() ?? "";
            Console.Write("Subtítulo: "); string sub = Console.ReadLine() ?? "";
            Console.Write("Escritor: "); string esc = Console.ReadLine() ?? "";
            Console.Write("Editora: "); string edi = Console.ReadLine() ?? "";
            Console.Write("Gênero: "); string gen = Console.ReadLine() ?? "";
            Console.Write("Ano: "); int ano = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Capa: "); string cap = Console.ReadLine() ?? "";
            Console.Write("Páginas: "); int pag = int.Parse(Console.ReadLine() ?? "0");
            return new Livro(isbn, tit, sub, esc, edi, gen, ano, cap, pag);
        }

        static Leitor BuscarLeitorPorCpf(List<Leitor> lista, string cpf)
        {
            var leitor = lista.Find(leitorAtual => leitorAtual.Cpf == cpf.Trim());
            if (leitor == null)
            {
                throw new Exception("Leitor não encontrado.");
            }
            return leitor;
        }

        static Livro BuscarLivroNoLeitor(Leitor leitor, string titulo)
        {
            var livro = leitor.LivrosDoLeitor.Find(livroAtual => livroAtual.Titulo.ToLower() == titulo.Trim().ToLower());
            if (livro == null)
            {
                throw new Exception("Livro não encontrado com este leitor.");
            }
            return livro;
        }

        static void ValidarListaNaoVazia(List<Leitor> lista)
        {
            if (lista.Count == 0) 
            {
                throw new Exception("Nenhum leitor cadastrado no sistema.");
            }
        }

        static void ImprimirErro(string m) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n[ERRO] {m}"); Console.ResetColor(); }
        static void ImprimirSucesso(string m) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n[OK] {m}"); Console.ResetColor(); }
        static void ImprimirTitulo(string t) { Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n>>> {t} <<<"); Console.ResetColor(); }
        static void ImprimirSeparador() => Console.WriteLine(new string('-', 40));
    }
}