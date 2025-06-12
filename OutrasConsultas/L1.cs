using MultimediaFilmes.Filmes;
using MultimediaFilmes.OutrasClasses;
using Spectre.Console;

namespace MultimediaFilmes.OutrasConsultas
{
    // Listar Filmes por Género
    internal class L1
    {
        public static void Listar(Dictionary<string, Filme> Filmes, List<Generos> Genero)
        {
            string genero = Generos.SelectGenero(Genero);

            Table table = new();

            table.AddColumn("Título");
            table.AddColumn("Ano de realização");
            table.AddColumn("Duração (em minutos)");
            table.AddColumn("Realizador");

            foreach (Filme fl in Filmes.Values)
            {
                if (fl.Generos.Any(g => genero.Equals(g, StringComparison.OrdinalIgnoreCase)))
                {
                    table.AddRow(
                        fl.Titulo ?? "",
                        fl.AnoRealizacao.ToString(),
                        $"{fl.Duracao} mins",
                        fl.Realizador ?? ""
                    );
                }
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
