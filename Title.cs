namespace MultimediaFilmes
{
    public class Title
    {
        public Title()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine(
                @"
 __  __       _ _   _             __     _ _         _____ _ _                     
|  \/  |_   _| | |_(_)_ __ ___   /_/  __| (_) __ _  |  ___(_) |_ __ ___   ___  ___ 
| |\/| | | | | | __| | '_ ` _ \ / _ \/ _` | |/ _` | | |_  | | | '_ ` _ \ / _ \/ __|
| |  | | |_| | | |_| | | | | | |  __/ (_| | | (_| | |  _| | | | | | | | |  __/\__ \
|_|  |_|\__,_|_|\__|_|_| |_| |_|\___|\__,_|_|\__,_| |_|   |_|_|_| |_| |_|\___||___/
        "
            );
            Console.WriteLine(
                "Trabalho desenvolvido por: Ângela Ferreira 30242, Adriana Capela 30246 e Rúben Gomes 20875\nDisciplina: Programação e Estrutura de Dados (PED)\nProfessores: Fernando Almeida, Joana Fialho e Teresa Neto\n"
            );

            Console.WriteLine(new string('*', Console.WindowWidth));
            Console.ResetColor();
        }
    }
}
