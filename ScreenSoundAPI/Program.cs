using (var client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        Console.WriteLine(resposta);
    }
    catch (Exception ex) 
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}