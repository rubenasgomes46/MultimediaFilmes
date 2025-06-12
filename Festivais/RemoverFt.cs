namespace MultimediaFilmes.Festivais
{
    internal class RemoverFt
    {
        public static void Remover(Dictionary<string, Festival> Festivais)
        {
            if (Festivais.Count == 0)
            {
                Messages.ConsoleError("Nenhum festival encontrado...\n");
                return;
            }

            string nome = Festival.SelectFestival(Festivais);

            Festivais.Remove(nome);

            Messages.ConsoleSuccess("Festival removido com sucesso!\n");
        }
    }
}
