using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositório responsável pela classe Jogo
    /// </summary>
    public class JogoRepository : IJogoRepository
    {
        // String de Conexão para acessar o banco
        public string StringConexao = "Data Source = NOTE01-S15; Initial Catalog = inLockTarde; User ID = sa; Pwd = Senai@134";
        /// <summary>
        /// Método que cadastra um novo jogo, utilizando parametros um JogoDomain
        /// </summary>
        /// <param name="novoJogo"></param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            // Cria conexão com o banco usando o StringConexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Query DML para inserir os dados do jogo
                string QueryPostJogo = "INSERT INTO Jogo VALUES (@IdEstudio,@Titulo,@Descricao,@DataLancamento,@Preco)";
                // Abre a conexão
                con.Open();
                // Declara o novo comando, usando a conexão aberta e a QueryPostJogo
                using (SqlCommand cmd = new SqlCommand(QueryPostJogo, con))
                {
                    // Determina os parâmetros do jogo
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Titulo", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Preco", novoJogo.Valor);
                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListarTodos()
        {
            //Cria uma lista de gêneros aonde seram armazenados os dados
            List<JogoDomain> ListaJogos = new List<JogoDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada.
                string QueryListarTodos = "SELECT Jogo.IdJogo, Jogo.IdEstudio, Jogo.Nome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor, Estudio.Nome FROM Jogo INNER JOIN Estudio ON Estudio.IdEstudio = Jogo.IdEstudio";
                //Abre a conexão com o branco de dado.
                con.Open();

                //Declara o SqlDataReader para ler a tabela no banco de dados
                SqlDataReader Leitor;

                //Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(QueryListarTodos, con))
                {
                    //Executa a query e armazena os dados no Leitor
                    Leitor = cmd.ExecuteReader();

                    //Enquanto houverem registros a serem lidos no Leitor
                    while (Leitor.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            // Atributos do jogo
                            IdJogo = Convert.ToInt32(Leitor[0]),
                            IdEstudio = Convert.ToInt32(Leitor[1]),
                            Nome = Convert.ToString(Leitor[2]),
                            Descricao = Convert.ToString(Leitor[3]),
                            DataLancamento = Convert.ToDateTime(Leitor[4]),
                            Valor = Convert.ToDecimal(Leitor[5]),
                            // Novo estúdio é criado para ser exibido
                            Estudio = new EstudioDomain()
                            {
                                // Atributos do estúdio
                                IdEstudio = Convert.ToInt32(Leitor[1]),
                                Nome = Convert.ToString(Leitor[6]),
                            }
                        };
                        // Adiciona o jogo a lista em cada loop
                        ListaJogos.Add(jogo);
                    }
                }
            }
            return ListaJogos;
        }
    }
}
