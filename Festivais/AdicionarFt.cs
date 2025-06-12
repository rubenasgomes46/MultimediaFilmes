using MultimediaFilmes.Filmes;

namespace MultimediaFilmes.Festivais
{
    internal class AdicionarFt
    {
        public static void Adicionar(
            Dictionary<string, Festival> Festivais,
            Dictionary<string, Filme> Filmes
        )
        {
            string? nome;
            string? local;
            DateTime dtinicio;
            DateTime dtfim;
            List<string> filmes;

            // Nome
            while (true)
            {
                Console.Write("\nNome: ");
                nome = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Messages.ConsoleWarning("O nome não pode estar vazio!");
                    continue;
                }

                if (Festivais.ContainsKey(nome))
                {
                    Messages.ConsoleWarning("Esse festival já existe!");
                    continue;
                }
                break;
            }

            // Local
            while (true)
            {
                Console.Write("\nLocal: ");
                local = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(local))
                {
                    Messages.ConsoleWarning("O local não pode estar vazio!");
                    continue;
                }
                break;
            }

            // Data de início
            while (true)
            {
                Console.Write("\nData de início (dd/MM/yyyy): ");
                string? input = Console.ReadLine()?.Trim();

                // se estiver vazio ou não conter o formato correto
                if (
                    !DateTime.TryParseExact(
                        input,
                        "dd/MM/yyyy",
                        null,
                        System.Globalization.DateTimeStyles.None,
                        out dtinicio
                    )
                )
                {
                    Messages.ConsoleWarning("Escreva uma data válida!");
                    continue;
                }

                // se a data for menor à atual
                if (dtinicio < DateTime.Today)
                {
                    Messages.ConsoleWarning("Essa data já passou!");
                    continue;
                }
                break;
            }

            // Data de fim
            while (true)
            {
                Console.Write("\nData de fim (dd/MM/yyyy): ");
                string? input = Console.ReadLine()?.Trim();

                if (
                    !DateTime.TryParseExact(
                        input,
                        "dd/MM/yyyy",
                        null,
                        System.Globalization.DateTimeStyles.None,
                        out dtfim
                    )
                )
                {
                    Messages.ConsoleWarning("Escreva uma data válida!");
                    continue;
                }

                // se for menor ou igual à data de início
                if (dtinicio >= dtfim)
                {
                    Messages.ConsoleWarning("A data não pode ser menor ou igual à data de início!");
                    continue;
                }
                break;
            }

            // Selecionar filmes
            while (true)
            {
                filmes = Filme.SelectFilmes(Filmes);

                // se houver mais do que 2 filmes selecionados do mesmo realizador
                if (
                    filmes
                        .GroupBy(titulo => Filmes?[titulo].Realizador!) // agrupa os filmes pelo realizador
                        .Any(group => group.Count() > 2) // verifica se algum realizador tem mais de 2 filmes
                )
                {
                    Messages.ConsoleWarning(
                        "Só pode haver, pelo menos, 2 filmes de cada realizador num festival!"
                    );
                    continue;
                }

                // se um dos filmes selecionados já estiver inscrito noutro/s festival/ais no mesmo período
                if (
                    filmes.Any(titulo => // para cada filme selecionado
                        Festivais.Values.Any(ft => // verifica os festivais que tenham as seguintes condições:
                            ft.Filmes.Contains(titulo) // o festival contém o filme (vai buscar pelo título)
                            && ft.DtFim >= dtinicio // o festival termina depois ou no mesmo dia da data de início
                            && ft.DtInicio <= dtfim // o festival começa antes ou no mesmo dia da data de fim
                        )
                    )
                )
                {
                    Messages.ConsoleWarning(
                        "Um ou mais filmes selecionados já se encontram inscritos em outro/s festival/ais no mesmo período!"
                    );
                    continue;
                }
                break;
            }

            Festival festival = new()
            {
                Nome = nome,
                Local = local,
                DtInicio = dtinicio,
                DtFim = dtfim,
                Filmes = [.. filmes],
            };

            Festivais.Add(nome, festival);

            Messages.ConsoleSuccess("Festival adicionado com sucesso!\n");
        }
    }
}
