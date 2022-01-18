using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroGames.Classes;
using CadastroGames.Enum;

namespace CadastroGames
{
    public class Program
    {

        static GamesRepositorio repositorio = new GamesRepositorio();
        public static void Main(string[] args)
        {
             string opcao = ObterOpcao();
            while (opcao.ToUpper() != "X")
            {

                switch (opcao)
                {
                    case "1":
                        ListarGames();
                        break;
                    case "2":
                        InserirGames();
                        break;
                    case "3":
                        AtualizarGames();
                        break;
                    case "4":
                        ExcluirGames();
                        break;
                    case "5":
                        VisualizarGames();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine($"Digite apenas as opções apresentadas");
                        break;       
                }
                opcao = ObterOpcao();
            }
        }

        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine($"Programa para cadastro de games\n");
            Console.WriteLine($"Informe a opção desejada: ");

            Console.WriteLine($"1- Listar games");
            Console.WriteLine($"2- Inserir novo game");
            Console.WriteLine($"3- Atualizar game");
            Console.WriteLine($"4- Excluir game");
            Console.WriteLine($"5- Visualizar game");
            Console.WriteLine($"c- Limpar tela");
            Console.WriteLine($"x- Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }

        private static void ListarGames()
        {    
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado.");
                return;
            }

            foreach (var game in lista)
            {
                var excluido = game.GetExcluido();
                Console.WriteLine("#ID {0}: {1} - {2}", game.GetId(), game.GetTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static void InserirGames()
        {
            Console.WriteLine("Inserir novo jogo");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do jogo: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento do jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do jogo: ");
            string entradaDescricao = Console.ReadLine();

            Games novoGame = new Games(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novoGame);
        }

        private static void AtualizarGames()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceGame = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in System.Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do jogo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do jogo: ");
			string entradaDescricao = Console.ReadLine();

			Games atualizaGame = new Games(id: indiceGame,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualizar(indiceGame, atualizaGame);
		}

        private static void ExcluirGames()
		{
			Console.Write("Digite o id da série: ");
			int indiceGame = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceGame);
		}

        private static void VisualizarGames()
		{
			Console.Write("Digite o id da série: ");
			int indiceGame = int.Parse(Console.ReadLine());

			var game = repositorio.RetornaPorId(indiceGame);

			Console.WriteLine(game);
		}
    }
}
