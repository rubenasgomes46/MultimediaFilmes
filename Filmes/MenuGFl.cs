namespace MultimediaFilmes.Filmes
{
    internal class MenuGFl
    {
        public MenuGFl()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            int opcao;

            Console.WriteLine("\n<< Gestão de Filmes >>\n");

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
                    // voltar ao menu principal
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        return;
                    // listar
                    case 1:
                        ListagemFl.Listagem(Program.Filmes);
                        break;
                    // adicionar
                    case 2:
                        AdicionarFl.Adicionar(Program.Filmes, Program.Realizadores, Program.Genero);
                        break;
                    // alterar
                    case 3:
                        AlterarFl.Alterar(
                            Program.Filmes,
                            Program.Realizadores,
                            Program.Festivais,
                            Program.Genero
                        );
                        break;
                    // remover
                    case 4:
                        RemoverFl.Remover(Program.Filmes, Program.Festivais);
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
