using MultimediaFilmes.Filmes;
using MultimediaFilmes.OutrasClasses;

namespace MultimediaFilmes.Realizadores
{
    internal class AlterarRl
    {
        public static void Alterar(
            Dictionary<string, Realizador> Realizadores,
            List<Paises> Pais,
            Dictionary<string, Filme> Filmes
        )
        {
            if (Realizadores.Count == 0)
            {
                Messages.ConsoleError("Nenhum realizador encontrado...\n");
                return;
            }

            // Selecionar realizador
            string novoNome = Realizador.SelectRealizador(Realizadores);
            Realizador antigo = Realizadores[novoNome];

            string? nome = antigo.Nome;

            // procurar filmes associados ao realizador selecionado, caso existam
            List<Filme> FilmesDoRealizador =
            [
                .. Filmes.Values.Where(fl => fl.Realizador == antigo.Nome),
            ];

            // se o realizador possuir filmes associados, não pode ser alterado
            if (FilmesDoRealizador.Count != 0)
            {
                Messages.ConsoleError(
                    $"O realizador não pode ser alterado: Possui {FilmesDoRealizador.Count} filme/s associado/s\n"
                );
                return;
            }

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

                if (nome.Any(char.IsDigit) || nome.Length < 3)
                {
                    Messages.ConsoleWarning(
                        "O nome não pode conter números ou ter menos de 3 letras!"
                    );
                    continue;
                }

                if (Realizadores.ContainsKey(nome))
                {
                    Messages.ConsoleWarning("Esse nome já existe!");
                    continue;
                }
                break;
            }

            // Alterar seleção de país
            string pais = Paises.SelectPaises(Pais);

            Realizadores.Remove(antigo.Nome ?? "");
            Realizadores.Add(nome ?? "", new Realizador { Nome = nome, Pais = pais });

            Messages.ConsoleSuccess("Realizador alterado com sucesso!\n");
        }
    }
}
