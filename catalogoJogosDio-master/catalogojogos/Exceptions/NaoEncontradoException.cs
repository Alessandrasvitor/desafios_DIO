using System;

namespace catalogojogos.Exceptions
{
    public class NaoEncontradoException : Exception
    {
        public NaoEncontradoException() : base("Registro não encontrado na base de dados")
        { }
    }
}
