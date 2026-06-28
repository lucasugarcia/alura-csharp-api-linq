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

    private static readonly string[] tons = ["C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"];

    [JsonPropertyName("key")]
    public int Tonalidade { get; set; }

    public string Tom { get{ return tons[Tonalidade]; } }

    public void ExibirDetalhesDaMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Genero: {Genero}");
        Console.WriteLine($"Tom: {Tom}");
        Console.WriteLine($"Duracao em segundos: {Duracao / 1000}");
    }
}