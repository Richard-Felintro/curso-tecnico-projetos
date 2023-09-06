using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositório responsável pela classe Estudio
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        public string StringConexao = "Data Source = NOTE01-S15; Initial Catalog = inLockTarde; User ID = sa; Pwd = Senai@134";
        public EstudioDomain ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> ListarTodos()
        {
            // Cria a lista que terá todos os jogos
            List<EstudioDomain> Lista = new List<EstudioDomain>();
            // Declara a conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Determina query para selecionar todos os jogos
                string QueryGetEstudio = "SELECT Estudio.Nome, Estudio.IdEstudio, Jogo.IdJogo, Jogo.Nome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor FROM Estudio LEFT JOIN Jogo ON Estudio.IdEstudio = Jogo.IdEstudio";
                // Abre a conexão
                con.Open();
                // Declara o comando com a Query e SqlConnection anteriormente determinados
                using (SqlCommand cmd = new SqlCommand(QueryGetEstudio, con))
                {
                    // Declara um leitor para ler a lista
                    SqlDataReader Leitor;
                    // Executa a leitura da Query
                    Leitor = cmd.ExecuteReader();
                    // Enquanto está sendo lido
                    while (Leitor.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            Nome = Convert.ToString(Leitor[0]),
                            IdEstudio = Convert.ToInt32(Leitor[1]),
                        };

                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(Leitor[2]),
                            Nome = Convert.ToString(Leitor[3]),
                            Descricao = Convert.ToString(Leitor[4]),
                            DataLancamento = Convert.ToDateTime(Leitor[5]),
                            Valor = Convert.ToDecimal(Leitor[6]),
                        };
                        // Adiciona o jogo a lista em cada loop
                        Lista.Add(estudio);
                    }
                }
            }
            return Lista;
        }
    }
}

