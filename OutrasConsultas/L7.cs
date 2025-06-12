using MultimediaFilmes.Filmes;
using MultimediaFilmes.Realizadores;
using Spectre.Console;

namespace MultimediaFilmes.OutrasConsultas
{
    // Listar os 3 Realizadores com mais Filmes
    internal class L7
    {
        public static void Listar(
            Dictionary<string, Realizador> Realizadores,
            Dictionary<string, Filme> Filmes
        )
        {
            // procurar os 3 realizadores com mais filmes por ordem ascendente
            List<Realizador> top3Rl =
            [
                .. Realizadores
                    .Values.OrderByDescending(rl =>
                        Filmes.Values.Count(fl => fl.Realizador == rl.Nome)
                    )
                    .Take(3),
            ];

            Table table = new();

            table.AddColumn("Nome");
            table.AddColumn("País");
            table.AddColumn("Nº de filmes");

            foreach (Realizador rl in top3Rl)
            {
                table.AddRow(
                    rl.Nome ?? "",
                    rl.Pais ?? "",
                    Filmes.Values.Count(f => f.Realizador == rl.Nome).ToString()
                );
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
