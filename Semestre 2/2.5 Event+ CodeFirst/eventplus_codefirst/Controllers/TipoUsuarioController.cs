using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;
using eventplus_codefirst.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace eventplus_codefirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um TipoUsuario que coincide com um IdTipoUsuario informado e o deleta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return Ok("TipoUsuario deletado com sucesso.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um TipoUsuario que coincide com um IdTipoUsuario e o atualiza com os dados da TipoUsuario informado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TipoUsuario"></param>
        /// <returns>O TipoUsuario editado</returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, TipoUsuario TipoUsuario)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Atualizar(id, TipoUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os TipoUsuarios
        /// </summary>
        /// <returns>Lista com todos os TipoUsuarios</returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Buscar um TipoUsuario que coincide com um IdTipoUsuario informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TipoUsuario selecionado</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
