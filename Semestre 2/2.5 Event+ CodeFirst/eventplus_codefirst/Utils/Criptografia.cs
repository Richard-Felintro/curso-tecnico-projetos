namespace eventplus_codefirst.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma hash a partir da senha
        /// </summary>
        /// <param name="senha">Senha a ser criptografada</param>
        /// <returns>Senha criptografada</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a hash informada pelo usuário coincide com a hash do banco
        /// </summary>
        /// <param name="senhaForm"></param>
        /// <param name="senhaBanco"></param>
        /// <returns>True se coincidir ou False se não</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}