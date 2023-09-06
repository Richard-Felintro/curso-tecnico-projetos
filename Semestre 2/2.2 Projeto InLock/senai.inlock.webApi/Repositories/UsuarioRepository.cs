using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public string StringConexao = "Data Source = NOTE01-S15; Initial Catalog = inLockTarde; User ID = sa; Pwd = Senai@134";
        /// <summary>
        /// Envia o email e a senha de um usuário e os compara as contas existentes.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Uma conta que corresponde com as informações inviadas.</returns>
        public UsuarioDomain? Login(string email, string password)
        {
            // Determina uma conexão utilizando a StringConexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // A query de cadastro é determinada em uma variável String
                string QueryLogin = "SELECT IdUsuario,IdTipoUsuario,Email,Senha FROM Usuario WHERE Email = @email AND Senha = @senha";
                // Abre a conexão
                con.Open();
                // Declara um comando usando a QueryLogin e a conexão previamente declarados
                using (SqlCommand cmd = new SqlCommand(QueryLogin, con)) 
                {
                    // Determina os parâmetros para a QueryLogin
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("senha", password);
                    // Cria um novo SqlDataReader e lê
                    SqlDataReader Leitor;
                    Leitor = cmd.ExecuteReader();
                    while (Leitor.Read())
                    {
                        // Cria um novo usuário com os dados obtidos
                        UsuarioDomain userLogin = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(Leitor[0]),
                            IdTipoUsuario = Convert.ToInt32(Leitor[1]),
                            Email = Convert.ToString(Leitor[2]),
                            Senha = Convert.ToString(Leitor[3]),
                        };
                        return userLogin;
                    }
                    return null;
                }
            }
        }
    }
}
