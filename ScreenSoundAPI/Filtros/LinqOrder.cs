using ScreenSoundAPI.Modelos;

namespace ScreenSoundAPI.Filtros;

internal class LinqOrder
{
    public static List<string> ExibirListaDeArtistasOrdenados(List<Musica> musicas)
    {
        return musicas.Select(m => m.Artista.Trim())
            .Distinct()
            .Order()
            .ToList();
    }
}
