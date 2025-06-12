using MultimediaFilmes.Filmes;

namespace MultimediaFilmes.Realizadores
{
    internal class RemoverRl
    {
        public static void Remover(
            Dictionary<string, Realizador> Realizadores,
            Dictionary<string, Filme> Filmes
        )
        {
            if (Realizadores.Count == 0)
            {
                Messages.ConsoleError("Nenhum realizador encontrado...\n");
                return;
            }

            string nome = Realizador.SelectRealizador(Realizadores);

            // procurar filmes associados ao realizador selecionado, caso existam
            List<Filme> FilmesDoRealizador = [.. Filmes.Values.Where(f => f.Realizador == nome)];

            // se o realizador possuir filmes associados, não pode ser removido
            if (FilmesDoRealizador.Count != 0)
            {
                Messages.ConsoleError(
                    $"Realizador não removido: Possui {FilmesDoRealizador.Count} filme/s associado/s\n"
                );
                return;
            }

            Realizadores.Remove(nome);

            Messages.ConsoleSuccess("Realizador removido com sucesso!\n");
        }
    }
}
