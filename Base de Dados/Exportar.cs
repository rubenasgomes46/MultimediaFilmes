using System.IO.Compression;

namespace MultimediaFilmes.Base_de_Dados
{
    public class Exportar
    {
        public static void ExportarFicheiro()
        {
            try
            {
                // definição do caminho do ficheiro ZIP exportado
                string zipFilePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), // diretoria do utilizador
                    "Downloads", // subpasta onde o ficheiro irá ser exportado
                    "Ficheiros_Exportados.zip" // nome do ficheiro quando exportado/criado
                );

                // criação do ficheiro ZIP através da pasta "Ficheiros"
                ZipFile.CreateFromDirectory(
                    Path.Combine(Directory.GetCurrentDirectory(), "Ficheiros"), // caminho completo da pasta "Ficheiros"
                    zipFilePath
                );

                Messages.ConsoleSuccess($"Ficheiros exportados com sucesso: {zipFilePath}\n");
            }
            catch (Exception ex)
            {
                Messages.ConsoleError($"Os ficheiros não foram exportados: {ex.Message}\n");
                return;
            }
        }
    }
}
