namespace MultimediaFilmes
{
    internal class SaveData
    {
        // Guardar os dados dos dicionários para os respetivos ficheiros
        public SaveData()
        {
            try
            {
                File.WriteAllLines(
                    Program.fpfl, // caminho do ficheiro
                    Program.Filmes.Values.Select(fl =>
                        $"{fl.Titulo},{fl.AnoRealizacao},{fl.Duracao},{string.Join(";", fl.Generos)},{fl.Realizador}"
                    ) // parâmetros da classe
                );
                File.WriteAllLines(
                    Program.fprl,
                    Program.Realizadores.Values.Select(rl => $"{rl.Nome},{rl.Pais}")
                );
                File.WriteAllLines(
                    Program.fpft,
                    Program.Festivais.Values.Select(ft =>
                        $"{ft.Nome},{ft.Local},{ft.DtInicio.Date},{ft.DtFim.Date},{string.Join(";", ft.Filmes)}"
                    )
                );

                Messages.ConsoleSuccess("Dados guardados com sucesso!");
            }
            catch (Exception ex)
            {
                Messages.ConsoleError($"Os dados não foram guardados: {ex.Message}");
                return;
            }
        }
    }
}
