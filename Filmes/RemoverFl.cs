using MultimediaFilmes.Festivais;

namespace MultimediaFilmes.Filmes
{
    internal class RemoverFl
    {
        public static void Remover(
            Dictionary<string, Filme> Filmes,
            Dictionary<string, Festival> Festivais
        )
        {
            if (Filmes.Count == 0)
            {
                Messages.ConsoleError("Nenhum filme encontrado...\n");
                return;
            }

            // Selecionar filme
            string titulo = Filme.SelectFilme(Filmes);

            // procurar festivais em que o filme selecionado esteja inscrito, caso existam
            List<Festival> FestivaisComFilmes =
            [
                .. Festivais.Values.Where(ft => ft.Filmes.Contains(titulo)),
            ];

            // se o filme estiver inscrito em festivais, não pode ser removido
            if (FestivaisComFilmes.Count != 0)
            {
                Messages.ConsoleError(
                    $"Filme não removido: Está inscrito em {FestivaisComFilmes.Count} festival/ais\n"
                );
                return;
            }

            Filmes.Remove(titulo); // remove no dicionário

            Messages.ConsoleSuccess("Filme removido com sucesso!\n");
        }
    }
}
