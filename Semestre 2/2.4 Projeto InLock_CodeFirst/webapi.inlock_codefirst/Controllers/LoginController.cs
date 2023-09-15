using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;
using webapi.inlock_codefirst.Repositories;
using webapi.inlock_codefirst.ViewModels;

namespace webapi.inlock_codefirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public LoginController()
        {
            usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = usuarioRepository.BuscarUsuario(usuario.Email, usuario.Senha);
                if (usuarioBuscado == null)
                {
                    return Unauthorized("Email ou senha inválidos.");
                }
                // Caso encontre o usuário buscado, prossegue para a criação do Token

                // Definir as claims que serão fornecidos no Token
                var claims = new[]
                {
                    // Formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email.ToString()),
                    new Claim(ClaimTypes.Role,usuarioBuscado.IdTipoUsuario.ToString()),
                    // Claims customizadas existem
                    // new Claim("Custom claim name", "Claim value")
                };
                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock-CodeFirst-DeCria1234567890"));

                // Definir as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gerar o token
                var token = new JwtSecurityToken
                (
                    // Emissor do token
                    issuer: "webapi.inlock_codefirst",
                    // Destinatário
                    audience: "webapi.inlock_codefirsts",

                    // Dados definidos nas Claims
                    claims: claims,

                    // Tempo de expiração
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
