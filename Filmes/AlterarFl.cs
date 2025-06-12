using MultimediaFilmes.Festivais;
using MultimediaFilmes.OutrasClasses;
using MultimediaFilmes.Realizadores;

namespace MultimediaFilmes.Filmes
{
    internal class AlterarFl
    {
        public static void Alterar(
            Dictionary<string, Filme> Filmes,
            Dictionary<string, Realizador> Realizadores,
            Dictionary<string, Festival> Festivais,
            List<Generos> Genero
        )
        {
            if (Filmes.Count == 0)
            {
                Messages.ConsoleError("Nenhum filme encontrado...\n");
                return;
            }

            // Selecionar filme
            string novoTitulo = Filme.SelectFilme(Filmes);
            Filme antigo = Filmes[novoTitulo]; // armazenar a chave principal (título) do filme original para comparação

            // procurar festivais em que o filme selecionado esteja inscrito, caso existam
            List<Festival> FestivaisComFilmes =
            [
                .. Festivais.Values.Where(ft => ft.Filmes.Contains(antigo.Titulo)),
            ];

            // se o filme estiver inscrito em festivais, não pode ser alterado
            if (FestivaisComFilmes.Count != 0)
            {
                Messages.ConsoleError(
                    $"O filme não pode ser alterado: Está inscrito em {FestivaisComFilmes.Count} festival/ais\n"
                );
                return;
            }

            string? titulo = antigo.Titulo;
            int ano = antigo.AnoRealizacao;
            int duracao = antigo.Duracao;

            // Alterar título
            while (true)
            {
                Console.Write($"\nAlterar título [{antigo.Titulo}]: ");
                titulo = Console.ReadLine()?.Trim();

                // se estiver vazio, o título original é mantido
                if (string.IsNullOrWhiteSpace(titulo))
                {
                    Messages.ConsoleWarning("O título foi mantido");
                    titulo = antigo.Titulo;
                    break;
                }

                // se o título inserido já existir
                if (Filmes.ContainsKey(titulo))
                {
                    Messages.ConsoleWarning("Esse título já existe!");
                    continue;
                }
                break;
            }

            // Alterar ano de realização
            while (true)
            {
                Console.Write($"\nAlterar ano de realização [{antigo.AnoRealizacao}]: ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Messages.ConsoleWarning("O ano foi mantido");
                    ano = antigo.AnoRealizacao;
                    break;
                }

                if (!int.TryParse(input, out ano) || ano <= 0 || ano.ToString().Length != 4)
                {
                    Messages.ConsoleWarning("Escreva um ano válido com apenas 4 dígitos!");
                    continue;
                }
                break;
            }

            // Alterar duração
            while (true)
            {
                Console.Write($"\nAlterar duração (em minutos) [{antigo.Duracao} mins]: ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Messages.ConsoleWarning("A duração foi mantida");
                    duracao = antigo.Duracao;
                    break;
                }

                if (!int.TryParse(input, out duracao) || duracao <= 0)
                {
                    Messages.ConsoleWarning("Escreva uma duração válida!");
                    continue;
                }
                break;
            }

            // Alterar seleção de géneros
            //Console.WriteLine($"[{string.Join(", ", antigo.Generos)}]");
            List<string> generos = Generos.SelectGeneros(Genero);

            // Alterar seleção de realizador
            //Console.WriteLine($"[{antigo.Realizador}]");
            string realizador = Realizador.SelectRealizador(Realizadores);

            Filme filme = new()
            {
                Titulo = titulo,
                AnoRealizacao = ano,
                Duracao = duracao,
                Generos = [.. generos],
                Realizador = realizador,
            };

            Filmes.Remove(antigo.Titulo ?? ""); // remover o filme através da chave antiga
            Filmes.Add(titulo ?? "", filme); // adicionar filme atualizado no dicionário

            Messages.ConsoleSuccess("Filme alterado com sucesso!\n");
        }
    }
}
