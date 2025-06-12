using MultimediaFilmes.Filmes;

namespace MultimediaFilmes.Festivais
{
    internal class AlterarFt
    {
        public static void Alterar(
            Dictionary<string, Festival> Festivais,
            Dictionary<string, Filme> Filmes
        )
        {
            if (Festivais.Count == 0)
            {
                Messages.ConsoleError("Nenhum festival encontrado...\n");
                return;
            }

            // Selecionar festival
            string novoNome = Festival.SelectFestival(Festivais);
            Festival antigo = Festivais[novoNome];

            string? nome = antigo.Nome;
            string? local = antigo.Local;
            DateTime dtinicio = antigo.DtInicio;
            DateTime dtfim = antigo.DtFim;
            List<string> filmes = [.. antigo.Filmes];

            // Alterar nome
            while (true)
            {
                Console.Write($"\nAlterar nome [{antigo.Nome}]: ");
                nome = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Messages.ConsoleWarning("O nome foi mantido");
                    nome = antigo.Nome;
                    break;
                }

                if (Festivais.ContainsKey(nome))
                {
                    Messages.ConsoleWarning("Esse festival já existe!");
                    continue;
                }
                break;
            }

            // Alterar local
            while (true)
            {
                Console.Write($"\nAlterar local [{antigo.Local}]: ");
                local = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(local))
                {
                    Messages.ConsoleWarning("O local foi mantido");
                    local = antigo.Local;
                    break;
                }
                break;
            }

            // Alterar data de início
            while (true)
            {
                Console.Write(
                    $"\nAlterar data de início (dd/MM/yyyy) [{antigo.DtInicio:dd/MM/yyyy}]: "
                );
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Messages.ConsoleWarning("A data foi mantida");
                    dtinicio = antigo.DtInicio;
                    break;
                }

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

                if (dtinicio < DateTime.Today)
                {
                    Messages.ConsoleWarning("Essa data já passou!");
                    continue;
                }
                break;
            }

            // Alterar data de fim
            while (true)
            {
                Console.Write($"\nAlterar data de fim (dd/MM/yyyy) [{antigo.DtFim:dd/MM/yyyy}]: ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Messages.ConsoleWarning("A data foi mantida");
                    dtfim = antigo.DtFim;
                    break;
                }

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

                if (dtinicio >= dtfim)
                {
                    Messages.ConsoleWarning("A data não pode ser menor ou igual à data de início!");
                    continue;
                }
                break;
            }

            // Alterar seleção de filmes
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
                        "Só pode haver, no máximo, 2 filmes de cada realizador num festival!"
                    );
                    continue;
                }

                // se um dos filmes selecionados já estiver inscrito noutro/s festival/ais no mesmo período
                if (
                    filmes.Any(titulo => // para cada filme selecionado
                        Festivais
                            .Values.Where(ft => ft != antigo) // considera todos os festivais, excepto o atual que está a ser alterado
                            .Any(ft => // verifica os festivais que tenham as seguintes condições:
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

            Festivais.Remove(antigo.Nome ?? "");
            Festivais.Add(nome ?? "", festival);

            Messages.ConsoleSuccess("Festival alterado com sucesso!\n");
        }
    }
}
