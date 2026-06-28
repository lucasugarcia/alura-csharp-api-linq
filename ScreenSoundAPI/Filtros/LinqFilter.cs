using ScreenSoundAPI.Modelos;

namespace ScreenSoundAPI.Filtros;

internal class LinqFilter
{
    public static List<string> FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        return musicas.SelectMany(m => m.Genero.Trim().Split(","))
            .SelectMany(g => g.Trim().Split("/"))
            .Distinct()
            .ToList();
    }

    public static List<string> FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeDoArtista)
    {
        return musicas.Where(m => m.Artista!.Equals(nomeDoArtista))
            .Select(m => m.Nome.Trim())
            .Distinct()
            .Order()
            .ToList();
    }

    internal static List<string> FiltrarMusicasNoTom(List<Musica> musicas, string tom)
    {
        return musicas.Where(m => m.Tom.Equals(tom))
            .Select(m => m.Nome.Trim())
            .ToList();
    }
}
