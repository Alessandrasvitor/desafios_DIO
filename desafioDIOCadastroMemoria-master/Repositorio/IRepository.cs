using System.Collections.Generic;

namespace series.Repositorio
{
    public interface IRepository<T>
    {
        void Atualizar(long id, T entidade);
        void Excluir(long id);
        void Inserir(T entidade);
        List<T> Listar();
        T PesquisaId(long id);

    }
}
