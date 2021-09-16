using Filmes.Classes;
using Filmes.Enum;
using System;


namespace Filmes
{
    class Program
	{
    

	static FilmeRepositorio repositorio = new FilmeRepositorio();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarFilmes();
						break;
					case "2":
						InserirFilme();
						break;
					case "3":
						AtualizarFilme();
						break;
					case "4":
						DeleteFilme();
						break;
					case "5":
						VisualizarFilme();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("VIDEOTECA ONLINE DE FILMES!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar filme");
			Console.WriteLine("2- Inserir novo filme");
			Console.WriteLine("3- Atualizar filme");
			Console.WriteLine("4- Excluir filme");
			Console.WriteLine("5- Visualizar filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		//Lista os filmes cadastrados na videoteca
		private static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
				var excluido = filme.GetExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", filme.GetId(), filme.GetTitulo(), (excluido ? "*Excluído*" : "*Disponivél*"));
			}
		}

		//Adiciona um novo filme na videoteca
		private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");
			Console.WriteLine("------------------------------------------");
            foreach (int f in Gen.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", f, Gen.GetName(typeof(Genero), f));
			}
			Console.WriteLine("------------------------------------------\n");
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());


			Filme novaFilme = new Filme(id: repositorio.ProximoId(),
										genero: (Genero)(entradaGenero),
										titulo: entradaTitulo,
										ano: entradaAno);

			repositorio.Insere(novaFilme);
		}

		//Atualiza as informações do filme
		private static void AtualizarFilme()
		{
			Console.Write("Digite o id da filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			foreach (int i in Gen.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Gen.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno);

			repositorio.Atualiza(indiceFilme, atualizaFilme);
		}

		//Impede que o filme seja visualizado
		private static void DeleteFilme()
		{
			Console.Write("Digite o id da filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceFilme);
		}

		//Visualiza as informações do filme
		private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorio.GetbyId(indiceFilme);

			Console.WriteLine(filme);
		}

		enum Gen
        {
			Acao = 1,
			Aventura = 2,
			Comedia = 3,
			Documentario = 4,
			Drama = 5,
			Espionagem = 6,
			Faroeste = 7,
			Fantasia = 8,
			Ficcao_Cientifica = 9,
			Musical = 10,
			Romance = 11,
			Suspense = 12,
			Terror = 13
		}

	}
}
