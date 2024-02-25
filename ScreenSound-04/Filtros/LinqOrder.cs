using ScreenSound_04.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound_04.Filtros
{
    internal class LinqOrder
    {
        public static void ExibirLitaDeArtistasOrdenados(List<Musica> musicas)
        {
            //ORDENA TODOS AS MÚSICAS COM BASE NO ARTISTA E DEPOIS TRAZ A SELEÇÃO DESSES ARTISTAS COM DISTINCT
            //PARA TRAZER SEM REPETIR
            var artistasOrdenados = musicas.OrderBy(musica => musica.Artista).Select(musica => musica.Artista)
                .Distinct().ToList();

            Console.WriteLine("Lista de artistas ordenados");
            foreach(var artista in artistasOrdenados)
            {
                Console.WriteLine(string.Format("- {0}", artista));
            }
        }
    }
}
