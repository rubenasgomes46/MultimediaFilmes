using Spectre.Console;

namespace MultimediaFilmes.Filmes
{
    public class Filme
    {
        public string? Titulo;
        public int AnoRealizacao;
        public int Duracao;
        public string[] Generos = [];
        public string? Realizador;

        public static void LoadData(Dictionary<string, Filme> Filmes, string fpfl)
        {
            // se o ficheiro não existir, ignora
            if (File.Exists(fpfl))
            {
                foreach (string line in File.ReadAllLines(fpfl))
                {
                    string[] parts = line.Split(",");

                    // se não houver dados, ignora
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string titulo = parts[0];
                    int anoRealizacao = int.Parse(parts[1]);
                    int duracao = int.Parse(parts[2]);
                    string[] generos = parts[3].Split(";");
                    string realizador = parts[4];

                    // evitar duplicação
                    // ao evitar a duplicação, os dados repetidos não são exibidos
                    if (!Filmes.ContainsKey(titulo))
                    {
                        Filme filme = new()
                        {
                            Titulo = titulo,
                            AnoRealizacao = anoRealizacao,
                            Duracao = duracao,
                            Generos = generos,
                            Realizador = realizador,
                        };
                        // adiciona no dicionário
                        Filmes.Add(titulo, filme);
                    }
                }
            }
        }

        // Selecionar um filme
        public static string SelectFilme(Dictionary<string, Filme> Filmes)
        {
            string filme = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("\nSelecionar filme (Pressione [green]<espaço>[/] para confirmar)")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use as setas para navegar)[/]")
                    .AddChoices(Filmes.Values.Select(rl => rl.Titulo!).ToList())
            );

            AnsiConsole.MarkupLine($"\nFilme selecionado: [green]{filme}[/]");

            return filme;
        }

        // Selecionar vários filmes
        public static List<string> SelectFilmes(Dictionary<string, Filme> Filmes)
        {
            List<string> filmes = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                    .Title(
                        "\nSelecionar filme/s (use a tecla [green]<espaço>[/] para o/s selecionar)"
                    )
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use as setas para navegar)[/]")
                    .InstructionsText("[grey](Pressione [green]<Enter>[/] para confirmar)[/]")
                    .AddChoices(Filmes.Values.Select(rl => rl.Titulo!).ToList())
            );

            AnsiConsole.MarkupLine(
                $"\nFilme/s selecionado/s: {string.Join(", ", filmes.Select(fl => $"[green]{fl}[/]"))}"
            );

            return filmes;
        }
    }
}
