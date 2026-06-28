using System.Text.Json;

namespace ScreenSoundAPI.Modelos;

internal class MusicasPreferidas
{
    public string? Nome { get; set; }
    public List<Musica> ListaDeMusicasFavoritas { get; set; }

    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        ListaDeMusicasFavoritas = new List<Musica>();
    }

    public void AdicionarMusicasFavoritas(Musica musica)
    {
        ListaDeMusicasFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Músicas favoritas de {Nome}");

        foreach (var musica in ListaDeMusicasFavoritas)
            Console.WriteLine($"{musica.Nome} - {musica.Artista}");
    }

    public void GerarAquivoJson()
    {
        var json = JsonSerializer.Serialize(this);

        File.WriteAllText($"musicas-{Nome}.json", json);
    }
}
