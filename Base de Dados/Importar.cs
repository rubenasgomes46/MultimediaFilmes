using MultimediaFilmes.Festivais;
using MultimediaFilmes.Filmes;
using MultimediaFilmes.OutrasClasses;
using MultimediaFilmes.Realizadores;

namespace MultimediaFilmes.Base_de_Dados
{
    public class Importar
    {
        public static void ImportarFicheiros()
        {
            Console.Write("\nCaminho do ficheiro a importar: ");
            string? path = Console.ReadLine()?.Trim();

            // se não for encontrado nenhum ficheiro através do caminho fornecido
            if (string.IsNullOrEmpty(path))
            {
                Messages.ConsoleWarning("Ficheiro não encontrado!\n");
                return;
            }

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Ficheiros"); // encontra a diretoria da pasta "Ficheiros"

            string directory = Path.Combine(folderPath, Path.GetFileName(path)); // obtem o caminho completo do ficheiro na pasta de destino
            string? fileName = Path.GetFileNameWithoutExtension(directory).ToLower(); // obtem o nome do ficheiro sem extensão/formato
            string? fileExtension = Path.GetExtension(path).ToLower(); // obtem o formato do ficheiro

            // Formatos válidos para importação
            HashSet<string?> ValidFileFormats = [".txt"];

            // se o formato não for válido
            if (!ValidFileFormats.Contains(fileExtension))
            {
                Messages.ConsoleWarning("Formato do ficheiro inválido!\n");
                return;
            }

            // Nomes válidos para importação
            Dictionary<string, Action<string>> ValidFileNames = new()
            {
                { "filmes", dir => Filme.LoadData(Program.Filmes, dir) },
                { "realizadores", dir => Realizador.LoadData(Program.Realizadores, dir) },
                { "festivais", dir => Festival.LoadData(Program.Festivais, dir) },
                { "generos", dir => Generos.LoadData(Program.Genero, dir) },
                { "paises", dir => Paises.LoadData(Program.Pais, dir) },
            };

            try
            {
                // se existir um ficheiro com o mesmo nome
                if (
                    ValidFileFormats.Any(ext =>
                        File.Exists(Path.Combine(folderPath, fileName + ext))
                    )
                )
                {
                    Messages.ConsoleWarning("Esse ficheiro já existe!\n");
                    return;
                }

                // se o nome do ficheiro for válido
                if (!(fileName == null || !ValidFileNames.ContainsKey(fileName)))
                {
                    ValidFileNames[fileName](directory); // carrega os dados do ficheiro
                    File.Copy(path, directory, true); // copia/importa o ficheiro para a pasta

                    Messages.ConsoleSuccess(
                        $"Ficheiro importado com sucesso: {fileName}{fileExtension}\n"
                    );
                }
                else
                {
                    Messages.ConsoleWarning("Nome do ficheiro inválido!\n");
                    return;
                }
            }
            catch (Exception ex)
            {
                Messages.ConsoleError($"O ficheiro não foi importado: {ex.Message}\n");
                return;
            }
        }
    }
}
