namespace webapi.healthclinic.Utils
{
    /// <summary>
    /// Classe estática responsável por dois métodos essenciais a criptografia
    /// </summary>
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma hash utilizando a senha informada no parametro
        /// </summary>
        /// <param name="senha"></param>
        /// <returns>Senha criptografada</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Compara a versão criptografada a senha informada pelo usuário e a do usuário no qual ele está tentando logar
        /// </summary>
        /// <param name="senhaForm"></param>
        /// <param name="senhaBanco"></param>
        /// <returns>True se elas coincidem, false se não</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
