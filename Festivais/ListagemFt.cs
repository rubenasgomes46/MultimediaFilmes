using Spectre.Console;

namespace MultimediaFilmes.Festivais
{
    internal class ListagemFt
    {
        public static void Listagem(Dictionary<string, Festival> Festivais)
        {
            Table table = new();

            table.AddColumn("Nome");
            table.AddColumn("Local");
            table.AddColumn("Datas (início e fim)");
            table.AddColumn("Filmes inscritos");

            foreach (Festival ft in Festivais.Values)
            {
                table.AddRow(
                    ft.Nome ?? "",
                    ft.Local ?? "",
                    $"{ft.DtInicio:dd/MM/yyyy} a {ft.DtFim:dd/MM/yyyy}",
                    string.Join(", ", ft.Filmes)
                );
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
