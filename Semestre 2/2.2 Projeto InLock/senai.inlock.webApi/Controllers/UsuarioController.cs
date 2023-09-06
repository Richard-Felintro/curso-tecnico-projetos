using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
{
    // Determina que este controller é um Controller de API
    [ApiController]
    // Determina a rota deste controller na API
    [Route("api/[controller]")]
    // Determina o que este controller produzirá
    [Produces("application/json")]

    // Herda as propriedades de ControllerBase ao JogoController
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Faz login de uma conta e gerar seu token.
        /// </summary>
        /// <param name="usuarioLogin"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Login(UsuarioDomain usuarioLogin)
        {
            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(usuarioLogin.Email,usuarioLogin.Senha);
                // Se o usuário for nulo (inexistente)
                if (usuario == null)
                {
                    // Retornar não encontrado
                    return NotFound("Usuário não encontrado. Senha ou email inválidos.");
                }
                // Caso encontre o usuário buscado, prossegue para a criação do Token

                // Definir as claims que serão fornecidos no Token
                var claims = new[]
                {
                    // Formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioLogin.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioLogin.Email.ToString()),
                    new Claim(ClaimTypes.Role,usuario.IdTipoUsuario.ToString()),
                    // Claims customizadas existem
                    // new Claim("Custom claim name", "Claim value")
                };
                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao-senai.inlock.webApi"));

                // Definir as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gerar o token
                var token = new JwtSecurityToken
                (
                    // Emissor do token
                    issuer: "senai.inlock.webApi",
                    // Destinatário
                    audience: "senai.inlock.webApi",

                    // Dados definidos nas Claims
                    claims: claims,

                    // Tempo de expiração
                    expires: DateTime.Now.AddMinutes(10),

                    // Credenciais do token
                    signingCredentials: creds
                );

                // Retorna o token criado
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                // return Ok(usuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
