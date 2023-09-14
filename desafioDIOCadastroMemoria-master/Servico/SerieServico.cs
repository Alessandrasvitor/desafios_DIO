using series.Constantes;
using series.Model;
using series.Repositorio;
using System;

namespace series.Servico
{
    public class SerieServico
    {
        static SerieRepository repositorio = new SerieRepository();

        internal void IniciarPrograma()
        {
            string opcao = "";
            do
            {
                MenuPincipal();
                opcao = Console.ReadLine();
                try
                {
                    switch (opcao)
                    {
                        case "1":
                            Listar();
                            break;
                        case "2":
                            Inserir();
                            break;
                        case "3":
                            Atualizar();
                            break;
                        case "4":
                            Excluir();
                            break;
                        case "5":
                            Visualizar();
                            break;
                        case "6":
                            Console.Clear();
                            break;
                    }
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine();
            } while (opcao != "0");
        }

        private void Listar()
        {
            var series = repositorio.Listar();
            if(series.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (Serie serie in repositorio.Listar())
            {
                Console.WriteLine(serie);
            }
        }

        private void MenuPincipal()
        {
            Console.WriteLine("Escolha uma opção para continuar!");

            Console.WriteLine(Environment.NewLine + "1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Limpar Tela");
            Console.WriteLine("0- Sair"+ Environment.NewLine);
        }

        private void salvar(long id, Serie serie)
        {
            if(id == 0)
            {
                repositorio.Inserir(serie);
            } else
            {
                repositorio.Atualizar(id, serie);
            }

        }

        private void Visualizar()
        {
            long idSerie = menuId();
            Serie serie = repositorio.PesquisaId(idSerie);
            Console.WriteLine(serie);
        }

        private void Excluir()
        {
            long idSerie = menuId();
            repositorio.Excluir(idSerie);
        }

        private long menuId()
        {
            Console.Write("Digite o id da série: ");
            long idSerie = long.Parse(Console.ReadLine());
            return idSerie;
        }

        private void Atualizar()
        {
            long idSerie = menuId();
            Serie serie = menuCadastro();
            salvar(idSerie, serie);
        }

        private void Inserir()
        {
            Serie serie = menuCadastro();
            salvar(0, serie);
        }

        private Serie menuCadastro()
        {
            Console.Write("Digite o Título da Série: ");
            string titulo = Console.ReadLine();

            menuGenero();
            Console.Write("Digite o gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Ano de Início da Série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string descricao = Console.ReadLine();

            return new Serie(titulo, (Genero)genero, ano, descricao);
        }

        private void menuGenero()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
        }
    }
}
