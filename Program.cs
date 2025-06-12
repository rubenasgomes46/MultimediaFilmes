using MultimediaFilmes.Festivais;
using MultimediaFilmes.Filmes;
using MultimediaFilmes.OutrasClasses;
using MultimediaFilmes.OutrasConsultas;
using MultimediaFilmes.Realizadores;

namespace MultimediaFilmes
{
    public class Program
    {
        // ficheiros
        public static readonly string fpfl = Path.Combine(@"Ficheiros", "filmes.txt");
        public static readonly string fprl = Path.Combine(@"Ficheiros", "realizadores.txt");
        public static readonly string fpft = Path.Combine(@"Ficheiros", "festivais.txt");

        public static readonly string fpg = Path.Combine(@"Ficheiros", "generos.txt");
        public static readonly string fpp = Path.Combine(@"Ficheiros", "paises.txt");

        // dicionários
        public static Dictionary<string, Filme> Filmes = [];
        public static Dictionary<string, Realizador> Realizadores = [];
        public static Dictionary<string, Festival> Festivais = [];

        // listas
        public static List<Generos> Genero = [];
        public static List<Paises> Pais = [];

        static void Main(string[] args)
        {
            // criar pasta "Ficheiros" ao iniciar o programa, caso não exista
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Ficheiros"));

            // carregar todos os dados ao iniciar o programa
            Filme.LoadData(Filmes, fpfl);
            Realizador.LoadData(Realizadores, fprl);
            Festival.LoadData(Festivais, fpft);
            Generos.LoadData(Genero, fpg);
            Paises.LoadData(Pais, fpp);

            Console.Title = "MultimédiaFilmes";

            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("\x1b[3J");
                _ = new Title();

                // Menu principal
                Console.WriteLine();

                Console.WriteLine("[1] Gestão de Filmes");
                Console.WriteLine("[2] Gestão de Realizadores");
                Console.WriteLine("[3] Gestão de Festivais");
                Console.WriteLine("[4] Outras Consultas");
                Console.WriteLine("[5] Exportar/Importar");

                Messages.ConsoleError("[0] TERMINAR PROGRAMA\n");

                Console.Write("> Digite aqui a sua opção: ");
                opcao = int.TryParse(Console.ReadLine(), out int x) ? x : -1;

                switch (opcao)
                {
                    // fechar programa
                    case 0:
                        _ = new SaveData(); // guardar todos os dados ao fechar o programa
                        Messages.ConsoleError("> O programa vai terminar...");
                        Environment.Exit(0);
                        break;
                    // Gestão de Filmes
                    case 1:
                        _ = new MenuGFl();
                        break;
                    // Gestão de Realizadores
                    case 2:
                        _ = new MenuGRl();
                        break;
                    // Gestão de Festivais
                    case 3:
                        _ = new MenuGFt();
                        break;
                    // Outras Consultas
                    case 4:
                        _ = new MenuOC();
                        break;
                    // Importar/Exportar
                    case 5:
                        _ = new MenuExpImp();
                        break;
                    default:
                        break;
                }
            } while (opcao != 0);
            Console.ReadKey();
        }
    }
}
