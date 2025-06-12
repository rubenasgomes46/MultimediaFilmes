using Spectre.Console;

namespace MultimediaFilmes.OutrasClasses
{
    public class Generos
    {
        public string? Nome;

        public Generos() { }

        public static void LoadData(List<Generos> Genero, string fpg)
        {
            if (File.Exists(fpg))
            {
                foreach (string line in File.ReadAllLines(fpg))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string nome = line.Trim();

                    if (!Genero.Any(g => g.Nome == nome))
                    {
                        Genero.Add(new Generos { Nome = nome });
                    }
                }
            }
        }

        public static string SelectGenero(List<Generos> Genero)
        {
            string genero = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("\nSelecionar género (Pressione [green]<espaço>[/] para confirmar)")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use as setas para navegar)[/]")
                    .AddChoices(Genero.Select(g => g.Nome!).ToList())
            );

            AnsiConsole.MarkupLine($"\nGénero selecionado: [green]{genero}[/]");

            return genero;
        }

        public static List<string> SelectGeneros(List<Generos> Genero)
        {
            List<string> generos = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                    .Title(
                        "\nSelecionar género/s (use a tecla [green]<espaço>[/] para o/s selecionar)"
                    )
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use as setas para navegar)[/]")
                    .InstructionsText("[grey](Pressione [green]<Enter>[/] para confirmar)[/]")
                    .AddChoices(Genero.Select(g => g.Nome!).ToList())
            );

            AnsiConsole.MarkupLine(
                $"\nGénero/s selecionado/s: {string.Join(", ", generos.Select(g => $"[green]{g}[/]"))}"
            );

            return generos;
        }
    }
}
