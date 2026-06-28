using ScreenSoundAPI.Filtros;
using ScreenSoundAPI.Modelos;
using System.Text.Json;

using (var client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        #region Trazendo somente gêneros

        var generos = LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);

        Console.WriteLine($"Generos: - {string.Join(", ", generos)}");

        #endregion

        #region Ordenando artistas por nome

        var artistasOrdenados = LinqOrder.ExibirListaDeArtistasOrdenados(musicas);

        Console.WriteLine($"Artistas:\n- {string.Join("\n- ", artistasOrdenados)}");

        #endregion

        #region Trazendo artistas por gênero

        var genero = generos
            .Where(g => g.Contains("rock"))
            .First();

        var artistasPorGenero = musicas
            .Where(m => m.Genero.Contains(genero))
            .Select(m => m.Artista)
            .Distinct()
            .Order();

        Console.WriteLine($"Artistas do gênero {genero}:\n- {string.Join("\n- ", artistasPorGenero)}");

        #endregion

        #region Trazendo músicas de um artista

        var artista = artistasPorGenero.First();

        var musicasArtista = LinqFilter.FiltrarMusicasDeUmArtista(musicas, artista);

        Console.WriteLine($"Músicas do artista {artista}:\n- {string.Join("\n- ", musicasArtista)}");

        #endregion

        #region Filtrar músicas por tom

        var tom = "C#";
        var musicasNoTom = LinqFilter.FiltrarMusicasNoTom(musicas, tom);

        Console.WriteLine($"Músicas no tom de {tom}:\n- {string.Join("\n- ", musicasNoTom)}");

        #endregion

        var musicasLucas = new MusicasPreferidas("Lucas");
        musicasLucas.AdicionarMusicasFavoritas(musicas[1]);
        musicasLucas.AdicionarMusicasFavoritas(musicas[4]);
        musicasLucas.AdicionarMusicasFavoritas(musicas[6]);

        musicasLucas.ExibirMusicasFavoritas();
        musicasLucas.GerarAquivoJson();

        var musicasVanessa = new MusicasPreferidas("Vanessa");
        musicasVanessa.AdicionarMusicasFavoritas(musicas[2]);
        musicasVanessa.AdicionarMusicasFavoritas(musicas[5]);
        musicasVanessa.AdicionarMusicasFavoritas(musicas[7]);

        musicasVanessa.ExibirMusicasFavoritas();
        musicasVanessa.GerarAquivoJson();
    }
    catch (Exception ex) 
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}