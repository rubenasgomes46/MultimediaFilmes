using Spectre.Console;

namespace MultimediaFilmes.OutrasClasses
{
    public class Paises
    {
        public string? Nome;

        public Paises() { }

        public static void LoadData(List<Paises> Pais, string fpp)
        {
            if (File.Exists(fpp))
            {
                foreach (string line in File.ReadAllLines(fpp))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string nome = line.Trim();

                    if (!Pais.Any(p => p.Nome == nome))
                    {
                        Pais.Add(new Paises { Nome = nome });
                    }
                }
            }
        }

        public static string SelectPaises(List<Paises> Pais)
        {
            string pais = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("\nSelecione um país (Pressione [green]<Enter>[/] para confirmar)")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use as setas para navegar)[/]")
                    .AddChoices(Pais.Select(p => p.Nome!).ToList())
            );

            AnsiConsole.MarkupLine($"\nPaís selecionado: [green]{pais}[/]");

            return pais;
        }
    }
}
