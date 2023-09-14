using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;
using webapi.inlock_codefirst.Repositories;
using webapi.inlock_codefirst.Utils;

namespace webapi.inlock_codefirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }
        public UsuarioController()
        {
            UsuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                UsuarioRepository.CadastrarUsuario(usuario);
                return Ok(usuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        public IActionResult GetByEmailAndPassword() 
        {
            try
            {

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
