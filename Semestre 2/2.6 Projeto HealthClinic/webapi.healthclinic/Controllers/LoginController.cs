using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Repositories;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Controllers
{
    /// <summary>
    /// Controller resposável pelo login
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private UsuarioRepository _Repository { get; set; }
        /// <summary>
        /// Declara o repositório quando o Controller é utilizado
        /// </summary>
        public LoginController()
        {
            _Repository = new();
        }

        
        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel user)
        {
            try
            {
                Usuario usuario = _Repository.BuscarPorEmailESenha(user.Email!, user.Senha!);
                if (usuario == null)
                {
                    return Unauthorized("Endereço de email ou senha não encontrados");
                }
                // Caso encontre o usuário buscado, prossegue para a criação do Token

                // Definir as claims que serão fornecidos no Token
                var claims = new[]
                {
                    // Formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti,usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuario.Email.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name,usuario.Nome.ToString()),
                    new Claim(ClaimTypes.Role,usuario.IdTipoUsuario.ToString()),
                    // Claims customizadas existem
                    // new Claim("Custom claim name", "Claim value")
                };
                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("EventPlus_CodeFirst-ABCDEFGHIJKLMNOP"));

                // Definir as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gerar o token
                var token = new JwtSecurityToken
                (
                    // Emissor do token
                    issuer: "webapi.healthclinic",
                    // Destinatário
                    audience: "webapi.healthclinic",

                    // Dados definidos nas Claims
                    claims: claims,

                    // Tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(10),

                    // Credenciais do token
                    signingCredentials: creds
                );

                // Retorna o token criado
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
