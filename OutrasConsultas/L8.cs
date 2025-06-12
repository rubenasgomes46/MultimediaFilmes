using MultimediaFilmes.Festivais;
using MultimediaFilmes.Filmes;
using MultimediaFilmes.OutrasClasses;
using MultimediaFilmes.Realizadores;
using Spectre.Console;

namespace MultimediaFilmes.OutrasConsultas
{
    // Listar Festivais e respetivos Filmes por País do Realizador
    internal class L8
    {
        public static void Listar(
            Dictionary<string, Festival> Festivais,
            Dictionary<string, Filme> Filmes,
            List<Paises> Pais,
            Dictionary<string, Realizador> Realizadores
        )
        {
            string pais = Paises.SelectPaises(Pais);

            Table table = new();

            table.AddColumn("Festival");
            table.AddColumn("Realizador");
            table.AddColumn("Filmes");

            foreach (Festival ft in Festivais.Values)
            {
                foreach (string titulo in ft.Filmes)
                {
                    if (Filmes.TryGetValue(titulo, out Filme? fl))
                    {
                        if (
                            Realizadores.TryGetValue(fl.Realizador ?? "", out Realizador? rl)
                            && rl.Pais == pais
                        )
                        {
                            List<string> FlRl =
                            [
                                .. ft.Filmes.Where(t =>
                                    Filmes.ContainsKey(t) && Filmes[t].Realizador == rl.Nome
                                ),
                            ];

                            table.AddRow(ft.Nome ?? "", rl.Nome ?? "", string.Join(", ", FlRl));
                        }
                    }
                }
            }
            AnsiConsole.Write(table);
            Console.WriteLine();
        }
    }
}
