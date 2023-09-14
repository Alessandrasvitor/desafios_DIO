using series.Servico;
using System;

namespace series
{
    class Program
    {

        static SerieServico servico = new SerieServico();
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao cadastro de séries!");
            servico.IniciarPrograma();

        }
    }
}
