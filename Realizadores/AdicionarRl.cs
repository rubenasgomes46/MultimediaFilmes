using MultimediaFilmes.OutrasClasses;

namespace MultimediaFilmes.Realizadores
{
    internal class AdicionarRl
    {
        public static void Adicionar(Dictionary<string, Realizador> Realizadores, List<Paises> Pais)
        {
            string? nome;

            // Nome
            while (true)
            {
                Console.Write("\nNome: ");
                nome = Console.ReadLine()?.Trim();

                // se estiver vazio, conter números ou ter menos de 3 letras
                if (string.IsNullOrWhiteSpace(nome) || nome.Any(char.IsDigit) || nome.Length < 3)
                {
                    Messages.ConsoleWarning(
                        "O nome não pode estar vazio, conter números ou ter menos de 3 letras!"
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

            // Selecionar país
            string pais = Paises.SelectPaises(Pais);

            Realizadores.Add(nome, new Realizador { Nome = nome, Pais = pais });

            Messages.ConsoleSuccess("Realizador adicionado com sucesso!\n");
        }
    }
}
