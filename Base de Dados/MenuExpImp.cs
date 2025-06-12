using MultimediaFilmes.Base_de_Dados;

namespace MultimediaFilmes
{
    internal class MenuExpImp
    {
        public MenuExpImp()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            int opcao;

            Console.WriteLine("[1] Exportar");
            Console.WriteLine("[2] Importar");

            Messages.ConsoleError("[0] VOLTAR\n");

            Console.WriteLine(
                "Nomes válidos: filmes, realizadores, festivais, paises e generos (tudo em minúsculas)"
            );
            Console.WriteLine("Formatos válidos: .txt\n");

            do
            {
                Console.Write("> Digite aqui a sua opção: ");
                opcao = int.TryParse(Console.ReadLine(), out int x) ? x : -1;

                switch (opcao)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        return;
                    case 1:
                        Exportar.ExportarFicheiro();
                        break;
                    case 2:
                        Importar.ImportarFicheiros();
                        break;
                    default:
                        Messages.ConsoleError(
                            "Opção inválida! Veja as opções disponíveis e tente novamente\n"
                        );
                        break;
                }
            } while (opcao != 0);
            Console.ReadKey();
        }
    }
}
