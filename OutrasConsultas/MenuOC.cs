namespace MultimediaFilmes.OutrasConsultas
{
    internal class MenuOC
    {
        public MenuOC()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            int opcao;

            Console.WriteLine("\n<< Outras Consultas >>\n");

            Console.WriteLine("[1] Listar Filmes por Género");
            Console.WriteLine("[2] Listar Filmes por Ano");
            Console.WriteLine("[3] Listar Filmes por Realizador");
            Console.WriteLine("[4] Listar Filmes por Género e País do Realizador");
            Console.WriteLine(
                "[5] Listar Festivais e respetivos Filmes de um Realizador num Período específico"
            );
            Console.WriteLine("[6] Listar Realizadores por País");
            Console.WriteLine("[7] Listar Top 3 Realizadores");
            Console.WriteLine("[8] Listar Festivais e respetivos Filmes por País do Realizador");

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
                        L1.Listar(Program.Filmes, Program.Genero);
                        break;
                    case 2:
                        L2.Listar(Program.Filmes);
                        break;
                    case 3:
                        L3.Listar(Program.Filmes, Program.Realizadores);
                        break;
                    case 4:
                        L4.Listar(
                            Program.Filmes,
                            Program.Genero,
                            Program.Realizadores,
                            Program.Pais
                        );
                        break;
                    case 5:
                        L5.Listar(Program.Festivais, Program.Filmes, Program.Realizadores);
                        break;
                    case 6:
                        L6.Listar(Program.Realizadores, Program.Pais, Program.Filmes);
                        break;
                    case 7:
                        L7.Listar(Program.Realizadores, Program.Filmes);
                        break;
                    case 8:
                        L8.Listar(
                            Program.Festivais,
                            Program.Filmes,
                            Program.Pais,
                            Program.Realizadores
                        );
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
