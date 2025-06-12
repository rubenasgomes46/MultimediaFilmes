using MultimediaFilmes.Filmes;
using Spectre.Console;

namespace MultimediaFilmes.OutrasConsultas
{
    // Listar Filmes por Ano
    internal class L2
    {
        public static void Listar(Dictionary<string, Filme> Filmes)
        {
            Console.Write("\nEscreva um ano (ex: 2000): ");

            if (!int.TryParse(Console.ReadLine(), out int ano) || ano.ToString().Length != 4)
            {
                Messages.ConsoleWarning("Escreva um ano válido com 4 dígitos!\n");
                return;
            }

            Table table = new();

            table.AddColumn("Título");
            table.AddColumn("Duração (em minutos)");
            table.AddColumn("Género/s");
            table.AddColumn("Realizador");

            foreach (Filme fl in Filmes.Values)
            {
                if (fl.AnoRealizacao == ano)
                {
                    table.AddRow(
                        fl.Titulo ?? "",
                        $"{fl.Duracao} mins",
                        string.Join(", ", fl.Generos),
                        fl.Realizador ?? ""
                    );
                }
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
