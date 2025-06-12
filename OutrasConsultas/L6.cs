using MultimediaFilmes.Filmes;
using MultimediaFilmes.OutrasClasses;
using MultimediaFilmes.Realizadores;
using Spectre.Console;

namespace MultimediaFilmes.OutrasConsultas
{
    // Listar Realizadores por País
    internal class L6
    {
        public static void Listar(
            Dictionary<string, Realizador> Realizadores,
            List<Paises> Pais,
            Dictionary<string, Filme> Filmes
        )
        {
            string pais = Paises.SelectPaises(Pais);

            Table table = new();

            table.AddColumn("Nome");
            table.AddColumn("País");
            table.AddColumn("Nº de filmes");

            foreach (Realizador rl in Realizadores.Values)
            {
                if (string.Equals(rl.Pais, pais, StringComparison.OrdinalIgnoreCase))
                {
                    table.AddRow(
                        rl.Nome ?? "",
                        rl.Pais ?? "",
                        Filmes.Values.Count(f => f.Realizador == rl.Nome).ToString()
                    );
                }
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
