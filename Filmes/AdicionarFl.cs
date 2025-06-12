using MultimediaFilmes.OutrasClasses;
using MultimediaFilmes.Realizadores;

namespace MultimediaFilmes.Filmes
{
    internal class AdicionarFl
    {
        public static void Adicionar(
            Dictionary<string, Filme> Filmes,
            Dictionary<string, Realizador> Realizadores,
            List<Generos> Genero
        )
        {
            string? titulo;
            int ano;
            int duracao;

            // Título
            while (true)
            {
                Console.Write("\nTítulo: ");
                titulo = Console.ReadLine()?.Trim();

                // se estiver vazio
                if (string.IsNullOrWhiteSpace(titulo))
                {
                    Messages.ConsoleWarning("Escreva um título válido!");
                    continue;
                }

                // se o título já existir
                if (Filmes.ContainsKey(titulo))
                {
                    Messages.ConsoleWarning("Esse título já existe!");
                    continue;
                }
                break;
            }

            // Ano de realização
            while (true)
            {
                Console.Write("\nAno de realização: ");

                // se estiver vazio ou tiver menos de 4 dígitos
                if (
                    !int.TryParse(Console.ReadLine(), out ano)
                    || ano <= 0
                    || ano.ToString().Length != 4
                )
                {
                    Messages.ConsoleWarning("Escreva um ano válido com apenas 4 dígitos!");
                    continue;
                }
                break;
            }

            // Duração
            while (true)
            {
                Console.Write("\nDuração (em minutos): ");

                if (!int.TryParse(Console.ReadLine(), out duracao) || duracao <= 0)
                {
                    Messages.ConsoleWarning("Escreva uma duração válida!");
                    continue;
                }
                break;
            }

            // Selecionar géneros
            List<string> generos = Generos.SelectGeneros(Genero);

            // Selecionar realizador
            string realizador = Realizador.SelectRealizador(Realizadores);

            Filme filme = new()
            {
                Titulo = titulo,
                AnoRealizacao = ano,
                Duracao = duracao,
                Generos = [.. generos],
                Realizador = realizador,
            };

            Filmes.Add(titulo, filme); // adiciona no dicionário

            Messages.ConsoleSuccess("Filme adicionado com sucesso!\n");
        }
    }
}
