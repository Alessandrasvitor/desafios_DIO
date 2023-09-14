using catalogojogos.DTO.InputModel;
using catalogojogos.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace catalogojogos.Services
{
    public interface IJogoService : IDisposable
    {

        Task<List<Jogo>> Obter(int pagina, int qtd);
        Task<Jogo> Obter(long id);
        Task<Jogo> Inserir(JogoInputDTO jogo);
        Task Atualizar(long id, JogoInputDTO jogo);
        Task Atualizar(long id, double preco);
        Task Excluir(long id);

    }
}
