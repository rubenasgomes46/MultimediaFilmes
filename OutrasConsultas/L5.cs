using MultimediaFilmes.Festivais;
using MultimediaFilmes.Filmes;
using MultimediaFilmes.Realizadores;
using Spectre.Console;

namespace MultimediaFilmes.OutrasConsultas
{
    // Listar Festivais e respetivos Filmes de um Realizador num Período específico
    internal class L5
    {
        public static void Listar(
            Dictionary<string, Festival> Festivais,
            Dictionary<string, Filme> Filmes,
            Dictionary<string, Realizador> Realizadores
        )
        {
            string realizador = Realizador.SelectRealizador(Realizadores);

            Console.Write("\nData de início (dd/MM/yyyy): ");
            string? input = Console.ReadLine()?.Trim();

            if (
                !DateTime.TryParseExact(
                    input,
                    "dd/MM/yyyy",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime inicio
                )
            )
            {
                Messages.ConsoleWarning("Escreva uma data válida!\n");
                return;
            }

            Console.Write("\nData de fim (dd/MM/yyyy): ");
            string? input2 = Console.ReadLine()?.Trim();

            if (
                !DateTime.TryParseExact(
                    input2,
                    "dd/MM/yyyy",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime fim
                )
            )
            {
                Messages.ConsoleWarning("Escreva uma data válida!\n");
                return;
            }

            Table table = new();

            table.AddColumn("Festival");
            table.AddColumn("Datas (início e fim)");
            table.AddColumn($"Filmes ({realizador})");

            foreach (Festival ft in Festivais.Values)
            {
                if (ft.DtInicio >= inicio && ft.DtFim <= fim)
                {
                    // filmes de cada realizador selecionado
                    List<string> FlRl =
                    [
                        .. ft.Filmes.Where(t =>
                            Filmes.ContainsKey(t) && Filmes[t].Realizador == realizador
                        ),
                    ];

                    table.AddRow(
                        ft.Nome ?? "",
                        $"{ft.DtInicio:dd/MM/yyyy} a {ft.DtFim:dd/MM/yyyy}",
                        string.Join(", ", FlRl)
                    );
                }
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
