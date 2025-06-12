namespace MultimediaFilmes.Realizadores
{
    internal class MenuGRl
    {
        public MenuGRl()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            int opcao;

            Console.WriteLine("\n<< Gestão de Realizadores >>\n");

            Console.WriteLine("[1] Listar");
            Console.WriteLine("[2] Adicionar");
            Console.WriteLine("[3] Alterar");
            Console.WriteLine("[4] Remover");

            Messages.ConsoleError("[0] VOLTAR\n");

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
                        ListagemRl.Listagem(Program.Realizadores, Program.Filmes);
                        break;
                    case 2:
                        AdicionarRl.Adicionar(Program.Realizadores, Program.Pais);
                        break;
                    case 3:
                        AlterarRl.Alterar(Program.Realizadores, Program.Pais, Program.Filmes);
                        break;
                    case 4:
                        RemoverRl.Remover(Program.Realizadores, Program.Filmes);
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
