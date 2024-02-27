using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScreenSound_04.Modelos
{
    internal class MusicasPreferidas
    {
        public string Nome { get; set; }
        public List<Musica> ListaDeMusicasFavoritas { get; }

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
            Console.WriteLine(string.Format("Essas são as músicas favoritas {0}", Nome));
            foreach (var musica in ListaDeMusicasFavoritas)
            {
                Console.WriteLine(string.Format("{0} de {1}", musica.Nome, musica.Artista));
            }
            Console.WriteLine();
        }

        //Serealizar um dado - o oposto da deserealização da api
        public void GerarArquivoJson()
        {
            //objeto anônimo ou seja sem tipo
            string json = JsonSerializer.Serialize( new
            {
                nome = Nome,
                musicas = ListaDeMusicasFavoritas
            });

            string nomeDoArquivo = string.Format("músicas-favoritas-{0}.json", Nome);

            File.WriteAllText(nomeDoArquivo, json);
            Console.WriteLine(string.Format("O Arquivo Json foi criado com sucesso! {0}", Path.GetFullPath(nomeDoArquivo)));
        }
    }
}