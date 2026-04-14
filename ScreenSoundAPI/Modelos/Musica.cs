using System.Text.Json.Serialization;

namespace ScreenSoundAPI.Modelos;

internal class Musica
{
    [JsonPropertyName("song")]
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]
    public string? Artista { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }

    public void ExibirDetalhesDaMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Genero: {Genero}");
        Console.WriteLine($"Duracao em segundos: {Duracao / 1000}");
    }
}
