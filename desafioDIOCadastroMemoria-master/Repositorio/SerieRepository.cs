using System;
using series.Model;
using System.Collections.Generic;

namespace series.Repositorio
{
    public class SerieRepository : IRepository<Serie>
    {
        static int IdSerie;
        private List<Serie> series = new List<Serie>();
        public void Atualizar(long id, Serie novaSerie)
        {
            Serie serie = PesquisaId(id);
            series.Remove(serie);
            novaSerie.Id = id;
            series.Add(novaSerie);
            Console.WriteLine($"A série com o id: {id} foi atualizada com sucesso" + Environment.NewLine);
        }

        public void Excluir(long id)
        {
            Serie serie = PesquisaId(id);
            series.Remove(serie);
        }

        public void Inserir(Serie serie)
        {
            IdSerie++;
            serie.Id = IdSerie;
            series.Add(serie);
        }

        public List<Serie> Listar()
        {
            return this.series;
        }

        public Serie PesquisaId(long id)
        {
            Serie serie = series.Find(s => s.Id == id);
            if (serie == null)
            {
                throw new KeyNotFoundException($"A série com o id: {id} não foi encontrada");
            }
            return serie;
        }

    }
}
