using Spectre.Console;

namespace MultimediaFilmes.Filmes
{
    internal class ListagemFl
    {
        public static void Listagem(Dictionary<string, Filme> Filmes)
        {
            // criar tabela
            Table table = new();

            // cabeçalho
            table.AddColumn("Título");
            table.AddColumn("Ano de realização");
            table.AddColumn("Duração (em minutos)");
            table.AddColumn("Género/s");
            table.AddColumn("Realizador");

            foreach (Filme fl in Filmes.Values)
            {
                // linhas
                table.AddRow(
                    fl.Titulo ?? "",
                    fl.AnoRealizacao.ToString(),
                    $"{fl.Duracao} mins",
                    string.Join(", ", fl.Generos),
                    fl.Realizador ?? ""
                );
            }
            // renderização/exibição da tabela
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
