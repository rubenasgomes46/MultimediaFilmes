using Spectre.Console;

namespace MultimediaFilmes.Festivais
{
    public class Festival
    {
        public string? Nome;
        public string? Local;
        public DateTime DtInicio;
        public DateTime DtFim;
        public string[] Filmes = [];

        public static void LoadData(Dictionary<string, Festival> Festivais, string fpft)
        {
            if (File.Exists(fpft))
            {
                foreach (string line in File.ReadAllLines(fpft))
                {
                    string[] parts = line.Split(",");

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string nome = parts[0];
                    string local = parts[1];
                    DateTime dtinicio = DateTime.Parse(parts[2]);
                    DateTime dtfim = DateTime.Parse(parts[3]);
                    string[] filmes = parts[4].Split(";");

                    if (!Festivais.ContainsKey(nome))
                    {
                        Festival festival = new()
                        {
                            Nome = nome,
                            Local = local,
                            DtInicio = dtinicio,
                            DtFim = dtfim,
                            Filmes = filmes,
                        };
                        Festivais.Add(nome, festival);
                    }
                }
            }
        }

        public static string SelectFestival(Dictionary<string, Festival> Festivais)
        {
            string festival = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("\nSelecionar festival (Pressione [green]<Enter>[/] para confirmar)")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Use as setas para navegar)[/]")
                    .AddChoices(Festivais.Values.Select(rl => rl.Nome!).ToList())
            );

            AnsiConsole.MarkupLine($"\nFestival selecionado: [green]{festival}[/]");

            return festival;
        }
    }
}
