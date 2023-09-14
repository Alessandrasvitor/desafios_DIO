using catalogojogos.DTO.InputModel;
using catalogojogos.Exceptions;
using catalogojogos.Model;
using catalogojogos.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace catalogojogos.Services
{
    public class JogoService : IJogoService
    {

        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task Atualizar(long id, JogoInputDTO jogo)
        {
            var duplicado = await _jogoRepository.Obter(jogo.Nome, jogo.Produtora);
            if (duplicado != null && duplicado.Count > 0)
            {
                throw new DuplicacaoException();
            }

            var entidade = await _jogoRepository.Obter(id);

            if (entidade == null)
            {
                throw new NaoEncontradoException();
            }

            entidade.Nome = jogo.Nome;
            entidade.Produtora = jogo.Produtora;
            entidade.Preco = jogo.Preco;

            await _jogoRepository.Atualizar(entidade);

        }

        public async Task Atualizar(long id, double preco)
        {
            var entidade = await _jogoRepository.Obter(id);

            if (entidade == null)
            {
                throw new NaoEncontradoException();
            }

            entidade.Preco = preco;

            await _jogoRepository.Atualizar(entidade);
        }

        public async Task Excluir(long id)
        {
            var entidade = await _jogoRepository.Obter(id);

            if (entidade == null)
            {
                throw new NaoEncontradoException();
            }
            await _jogoRepository.Excluir(id);
        }

        public async Task<Jogo> Inserir(JogoInputDTO jogo)
        {
            var duplicado = await _jogoRepository.Obter(jogo.Nome, jogo.Produtora);
            if (duplicado.Count > 0)
            {
                throw new DuplicacaoException();
            }

            var entidade = new Jogo(jogo);
            var maxId = await _jogoRepository.MaxId();
            entidade.Id = maxId +1;

            await _jogoRepository.Inserir(entidade);
            return entidade;
        }

        public async Task<List<Jogo>> Obter(int pagina, int qtd)
        {
            var entidade = await _jogoRepository.Obter(pagina, qtd);

            if(entidade == null)
            {
                throw new NaoEncontradoException();
            }

            return entidade;
        }

        public async Task<Jogo> Obter(long id)
        {
            try
            {
                return await _jogoRepository.Obter(id);

            } catch (NullReferenceException)
            {
                throw new NaoEncontradoException();
            }
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }
    }
}
