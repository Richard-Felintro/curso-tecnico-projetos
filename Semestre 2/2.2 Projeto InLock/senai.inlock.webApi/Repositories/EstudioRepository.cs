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
            List<EstudioDomain> ListaEstudios = new List<EstudioDomain>();
            // Declara a conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Determina query para os atributos dos estudios
                string QueryGetEstudio = "SELECT Nome,IdEstudio FROM Estudio";
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
                        // Declara um novo estúdio com os atributos determinados
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            Nome = Convert.ToString(Leitor[0]),
                            IdEstudio = Convert.ToInt32(Leitor[1]),
                            Jogos = new List<JogoDomain>()
                        };
                        // Adiciona o estúdio a lista em cada loop
                        ListaEstudios.Add(estudio);
                    }
                }
            }
            // Nova conexão é declarada
            using (SqlConnection cone = new SqlConnection(StringConexao))
            {
                // Query para obter os dados dos jogos é declarada
                string QueryGetJogos = "SELECT Jogo.IdEstudio, Jogo.IdJogo, Jogo.Nome AS NomeJogo, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor,Estudio.Nome AS NomeEstudio FROM Estudio INNER JOIN Jogo ON Estudio.IdEstudio = Jogo.IdEstudio";
                // Nova conexão é aberta
                cone.Open();
                using (SqlCommand cmd2 = new SqlCommand(QueryGetJogos, cone))
                {
                    // Declara um leitor para passar pela lista
                    SqlDataReader Leitor2 = cmd2.ExecuteReader();
                    // Enquanto o Leitor2 está lendo:
                    while (Leitor2.Read())
                    {
                        // Para cada estúdio na lista de estúdios acima
                        foreach (EstudioDomain estudio in ListaEstudios)
                        {
                            // Verifica se o estúdio na lista tem o mesmo Id do estúdio do jogo
                            if (Convert.ToInt32(Leitor2[0]) == estudio.IdEstudio)
                            {
                                JogoDomain jogo = new JogoDomain()
                                {
                                    IdJogo = Convert.ToInt32(Leitor2[1]),
                                    IdEstudio = Convert.ToInt32(Leitor2[0]),
                                    Nome = Convert.ToString(Leitor2[2]),
                                    Descricao = Convert.ToString(Leitor2[3]),
                                    DataLancamento = Convert.ToDateTime(Leitor2[4]),
                                    Valor = Convert.ToDecimal(Leitor2[5]),
                                    Estudio = Convert.ToString(Leitor2[6])
                                };
                                estudio.Jogos.Add(jogo);
                            }
                        }
                    }
                }
            }
            return ListaEstudios;
        }
    }
}

