using MultimediaFilmes.Filmes;
using MultimediaFilmes.Realizadores;
using Spectre.Console;

namespace MultimediaFilmes.OutrasConsultas
{
    // Listar Filmes por Realizador
    internal class L3
    {
        public static void Listar(
            Dictionary<string, Filme> Filmes,
            Dictionary<string, Realizador> Realizadores
        )
        {
            string realizador = Realizador.SelectRealizador(Realizadores);

            Table table = new();

            table.AddColumn("Título");
            table.AddColumn("Ano de realização");
            table.AddColumn("Duração (em minutos)");
            table.AddColumn("Género/s");

            foreach (Filme fl in Filmes.Values)
            {
                if (string.Equals(fl.Realizador, realizador, StringComparison.OrdinalIgnoreCase))
                {
                    table.AddRow(
                        fl.Titulo ?? "",
                        fl.AnoRealizacao.ToString(),
                        $"{fl.Duracao} mins",
                        string.Join(", ", fl.Generos)
                    );
                }
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
