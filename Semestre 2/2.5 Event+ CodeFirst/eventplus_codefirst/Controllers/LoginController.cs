using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;
using eventplus_codefirst.Repositories;
using eventplus_codefirst.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace eventplus_codefirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Login (LoginViewModel user)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(user.Email!, user.Senha!);
                if (usuarioBuscado == null)
                {
                    return Unauthorized("Endereço de email ou senha incorretos.");
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
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("EventPlus_CodeFirst-ABCDEFGHIJKLMNOP"));

                // Definir as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gerar o token
                var token = new JwtSecurityToken
                (
                    // Emissor do token
                    issuer: "eventplus_codefirst",
                    // Destinatário
                    audience: "eventplus_codefirst",

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
