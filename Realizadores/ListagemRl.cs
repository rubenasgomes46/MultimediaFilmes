using MultimediaFilmes.Filmes;
using Spectre.Console;

namespace MultimediaFilmes.Realizadores
{
    internal class ListagemRl
    {
        public static void Listagem(
            Dictionary<string, Realizador> Realizadores,
            Dictionary<string, Filme> Filmes
        )
        {
            Table table = new();

            table.AddColumn("Nome");
            table.AddColumn("País");
            table.AddColumn("Nº de filmes realizados");

            foreach (Realizador rl in Realizadores.Values)
            {
                table.AddRow(
                    rl.Nome ?? "",
                    rl.Pais ?? "",
                    Filmes.Values.Count(fl => fl.Realizador == rl.Nome).ToString() // contagem dos filmes associados ao realizador
                );
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
