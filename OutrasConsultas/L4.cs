using MultimediaFilmes.Filmes;
using MultimediaFilmes.OutrasClasses;
using MultimediaFilmes.Realizadores;
using Spectre.Console;

namespace MultimediaFilmes.OutrasConsultas
{
    // Listar Filmes por Género e País do Realizador
    internal class L4
    {
        public static void Listar(
            Dictionary<string, Filme> Filmes,
            List<Generos> Genero,
            Dictionary<string, Realizador> Realizadores,
            List<Paises> Pais
        )
        {
            string genero = Generos.SelectGenero(Genero);
            string pais = Paises.SelectPaises(Pais);

            Table table = new();

            table.AddColumn("Título");
            table.AddColumn("Ano de realização");
            table.AddColumn("Duração (em minutos)");
            table.AddColumn("Realizador");

            foreach (Filme fl in Filmes.Values)
            {
                if (
                    fl.Generos.Any(g => genero.Equals(g, StringComparison.OrdinalIgnoreCase))
                    && Realizadores.TryGetValue(fl.Realizador ?? "", out Realizador? realizador)
                    && string.Equals(realizador.Pais, pais, StringComparison.OrdinalIgnoreCase)
                )
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
