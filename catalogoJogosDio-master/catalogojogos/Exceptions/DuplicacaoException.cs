using System;

namespace catalogojogos.Exceptions
{
    public class DuplicacaoException : Exception
    {

        public DuplicacaoException() : base("Registro já encontrado na base de dados")
        { }
    }
}
