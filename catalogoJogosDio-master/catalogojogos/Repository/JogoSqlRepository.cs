using catalogojogos.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace catalogojogos.Repository
{
    public class JogoSqlRepository : IJogoRepository
    {

        private readonly SqlConnection sqlConnection;

        public JogoSqlRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task Atualizar(Jogo jogo)
        {
            var comando = $"update Jogos set Nome = {jogo.Nome}, Produtora = {jogo.Produtora}, Preco = {jogo.Preco.ToString().Replace(",", ".")}  where id = {jogo.Id}";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQueryAsync();
            await sqlConnection.CloseAsync();
        }

        public async Task Excluir(long id)
        {
            var comando = $"delete from Jogos where id = {id}";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQueryAsync();
            await sqlConnection.CloseAsync();
        }

        public async Task Inserir(Jogo jogo)
        {
            var comando = $"insert Jogos (Id, Nome, Produtora, Preco) values ('{jogo.Id}', '{jogo.Nome}', '{jogo.Produtora}', {jogo.Preco.ToString().Replace(",", ".")})";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task<List<Jogo>> Obter(int pagina, int qtd)
        {
            var jogos = new List<Jogo>();
            var comando = $"select * from Jogos order by id offset {((pagina - 1) * qtd)} rows fetch next {qtd} rows only";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (long)reader["Id"],
                    Nome = (string)reader["Nome"],
                    Produtora = (string)reader["Produtora"],
                    Preco = (double)reader["Preco"]
                });
            }

            await sqlConnection.CloseAsync();
            return jogos;

        }

        public async Task<Jogo> Obter(long id)
        {
            Jogo jogo = null;

            var comando = $"select * from Jogos where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                jogo = new Jogo
                {
                    Id = (long)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    Produtora = (string)sqlDataReader["Produtora"],
                    Preco = (double)sqlDataReader["Preco"]
                };
            }

            await sqlConnection.CloseAsync();
            return jogo;
        }

        public async Task<List<Jogo>> Obter(string nome, string produtora)
        {
            var jogos = new List<Jogo>();
            var comando = $"select * from Jogos where Nome = {nome} and produtora = {produtora} order by id";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (long)reader["Id"],
                    Nome = (string)reader["Nome"],
                    Produtora = (string)reader["Produtora"],
                    Preco = (double)reader["Preco"]
                });
            }

            await sqlConnection.CloseAsync();
            return jogos;
        }

        public async Task<long> MaxId()
        {
            var max = 0;
            var comando = $"select max(id) as Id from Jogos";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();


            while (reader.Read())
            {
                max = (int)(long) reader["Id"];
            }
            await sqlConnection.CloseAsync();

            return max;
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }
}
