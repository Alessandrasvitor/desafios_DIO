
using catalogojogos.DTO.InputModel;

namespace catalogojogos.Model
{
    public class Jogo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }

        public Jogo()
        {

        }

        public Jogo(JogoInputDTO jogo)
        {
            this.Nome = jogo.Nome;
            this.Produtora = jogo.Produtora;
            this.Preco = jogo.Preco;
        }

        public Jogo(long id, string nome, string produtora, double preco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Produtora = produtora;
            this.Preco = preco;
        }



    }
}
