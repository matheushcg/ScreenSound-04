using ScreenSound_04.Modelos;

namespace ScreenSound_04.Filtros;

internal class LinqFilter
{
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        //Ele vai selecionar todos os generos distintos da lista
        var todosOsGenerosMusicais = musicas.Select(generos => generos.Genero).Distinct().ToList();

        foreach(var genero in todosOsGenerosMusicais)
        {
            Console.WriteLine(string.Format("- {0}", genero));
        }
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistasPorGeneroMusical = musicas.Where(musica => musica.Genero.Contains(genero))
            .Select(musica => musica.Artista).Distinct().ToList();

        Console.WriteLine(string.Format("Exibindo artistas por gênero músical >>>, {0}", genero));

        foreach(var artista in artistasPorGeneroMusical)
        {
            Console.WriteLine(string.Format("- {0}", artista));
        }
    }

    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeArtista)
    {
        var musicasDoArtista = musicas.Where(musica => musica.Artista.Equals(nomeArtista)).ToList();

        Console.WriteLine(nomeArtista);

        foreach(var musica in musicasDoArtista)
        {
            Console.WriteLine(string.Format("- {0}", musica.Nome));
        }

    }
}
