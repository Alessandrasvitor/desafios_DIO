using catalogojogos.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace catalogojogos.Repository
{
    public interface IJogoRepository : IDisposable
    {
        Task<List<Jogo>> Obter(int pagina, int qtd);
        Task<Jogo> Obter(long id);
        Task<List<Jogo>> Obter(string nome, string produtora);
        Task Inserir(Jogo jogo);
        Task Atualizar(Jogo jogo);
        Task Excluir(long id);

        Task<long> MaxId();

    }
}
