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

        /// <summary>
        /// Busca um Usuario que coincide com um IdUsuario e o atualiza com os dados da Usuario informado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns>Usuario editado</returns>
        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, Usuario Usuario)
        {
            try
            {
                return Ok(_UsuarioRepository.BuscarIdEAtualizar(id, Usuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Lista com todos os Usuarios</returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_UsuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Buscar um Usuario que coincide com um IdUsuario informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario selecionado</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_UsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
