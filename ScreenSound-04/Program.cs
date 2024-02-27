using ScreenSound_04.Filtros;
using ScreenSound_04.Modelos;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        //É UTILIZADO O ASYNC PORQUE A GENTE NÃO SABE QUANTOS RECURSOS VAI RECEBER
        //ENTÃO É NECESSÁRIO A SUA UTILIZAÇÃO POIS O BANCO DE DADOS PODE DEMORAR A
        //ENVIAR UMA RESPOSTA, COM A UTILIZAÇÃO DO ASYNC É GARANTIDO QUE ENQUANTO ELE
        //NÃO RECEBER TODOS OS DADOS, ELE NÃO PASSA PARA PROXIMA LINHA DE CÓDIGO

        // O AWAIT É UTILIZADO PARA DE FATO ESPERAR A RESPOSTA DA API
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

        Console.WriteLine(resposta);

        //A desserialização é utilizada para pegar o o json e converter em um objeto que é manipulado no c#
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta);
        Console.WriteLine(string.Format("Quantidade de músicas: {0}", musicas.Count));

        musicas[1998].ExibirDetalhesDaMusica();

        LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);

        LinqOrder.ExibirLitaDeArtistasOrdenados(musicas);

        LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");

        LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Travis Scott");



        var musicasPreferidasDoMatheus = new MusicasPreferidas("Matheus");
        musicasPreferidasDoMatheus.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasDoMatheus.AdicionarMusicasFavoritas(musicas[5]);
        musicasPreferidasDoMatheus.AdicionarMusicasFavoritas(musicas[13]);
        musicasPreferidasDoMatheus.AdicionarMusicasFavoritas(musicas[12]);
        musicasPreferidasDoMatheus.AdicionarMusicasFavoritas(musicas[43]);

        musicasPreferidasDoMatheus.ExibirMusicasFavoritas();

        musicasPreferidasDoMatheus.GerarArquivoJson();
    }
    catch (Exception ex)
    {
        //SE EU TIRAR UMA PARTE DO LINK ELE VAI TRATAR MELHOR E EXIBIR QUAL VAI SER O PROBLEMA
        //EX: 404 NOT FOUND
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}