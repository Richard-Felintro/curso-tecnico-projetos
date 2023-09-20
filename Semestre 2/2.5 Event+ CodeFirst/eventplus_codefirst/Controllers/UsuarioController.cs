using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;
using eventplus_codefirst.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventplus_codefirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioRepository _UsuarioRepository { get; set; }
        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(usuario);
                return Created("Usuário deletado com sucesso.",usuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        // Autorizado apenas para administradores (IdTipoUsuario de admin)
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _UsuarioRepository.Deletar(id);
                return Ok("Usuário deletado com sucesso.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
