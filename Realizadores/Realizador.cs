using MultimediaFilmes.Filmes;
using Spectre.Console;

namespace MultimediaFilmes.Realizadores
{
    public class Realizador
    {
        public string? Nome;
        public string? Pais;
        public List<Filme> Filmes = [];

        public static void LoadData(Dictionary<string, Realizador> Realizadores, string fprl)
        {
            if (File.Exists(fprl))
            {
                foreach (string line in File.ReadAllLines(fprl))
                {
                    string[] parts = line.Split(",");

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string nome = parts[0];
                    string pais = parts[1];

                    if (!Realizadores.ContainsKey(nome))
                    {
                        Realizador rl = new()
                        {
                            Nome = nome,
                            Pais = pais,
                            Filmes = [],
                        };
                        Realizadores.Add(nome, rl);
                    }
                }
            }
        }

        public static string SelectRealizador(Dictionary<string, Realizador> Realizadores)
        {
            string realizador = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("\nSelecionar realizador (Pressione [green]<Enter>[/] para confirmar)")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use as setas para navegar)[/]")
                    .AddChoices(Realizadores.Values.Select(rl => rl.Nome!).ToList())
            );

            AnsiConsole.MarkupLine($"\nRealizador selecionado: [green]{realizador}[/]");

            return realizador;
        }
    }
}
