using ScreenSoundAPI.Modelos;
using System.Text.Json;

using (var client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        #region Trazendo somente gêneros

        var generos = musicas.SelectMany(m => m.Genero.Trim().Split(",")).SelectMany(g => g.Trim().Split("/")).Distinct();

        Console.WriteLine($"Generos: - {string.Join(", ", generos)}");

        #endregion

        #region Ordenando artistas por nome

        var artistasOrdenados = musicas.Select(m => m.Artista.Trim()).Distinct().Order();

        Console.WriteLine($"Artistas:\n{string.Join("\n- ", artistasOrdenados)}");

        #endregion

        #region Trazendo artistas por gênero

        var genero = generos.Where(g => g.Contains("rock")).First();

        var artistasPorGenero = musicas.Where(m => m.Genero.Contains(genero)).Select(m => m.Artista).Distinct().Order();

        Console.WriteLine($"Artistas do gênero {genero}:\n- {string.Join("\n- ", artistasPorGenero)}");

        #endregion

        #region Trazendo músicas de um artista

        var artista = artistasPorGenero.First();

        var musicasArtista = musicas.Where(m => m.Artista == artista).Select(m => m.Nome.Trim()).Distinct().Order();

        Console.WriteLine($"Músicas do artista {artista}:\n- {string.Join("\n- ", musicasArtista)}");

        #endregion
    }
    catch (Exception ex) 
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}