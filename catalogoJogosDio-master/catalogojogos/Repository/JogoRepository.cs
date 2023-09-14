using catalogojogos.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogojogos.Repository
{
    public class JogoRepository : IJogoRepository
    {

        private static Dictionary<long, Jogo> jogos = new Dictionary<long, Jogo>()
        {
            { 1, new Jogo(1, "God of War", "Sony", 150.0) },
            { 2, new Jogo(2, "PES", "Konami", 120.0) },
            { 3, new Jogo(3, "GTA", "Rockstar", 190.0) },
            { 4, new Jogo(4, "The Sims", "EA Games", 85.0) },
            { 5, new Jogo(5, "Pokemon Go", "Niantic", 145.0) }
        };

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Excluir(long id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int qtd)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * qtd).Take(qtd).ToList());
        }

        public Task<Jogo> Obter(long id)
        {
            if(!jogos.ContainsKey(id))
            {
                return null;
            }

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public async Task<long> MaxId()
        {
            var max = jogos.Max(jogo => jogo.Key);
            return max;
        }

        public void Dispose()
        {
            //
        }
    }
}
