using eventplus_codefirst.Domains;
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
    public class TipoEventoController : ControllerBase
    {
        private TipoEventoRepository _TipoEventoRepository { get; set; }
        public TipoEventoController()
        {
            _TipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="tipoEvento"></param>
        /// <returns></returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _TipoEventoRepository.Cadastrar(tipoEvento);
                return Created("Tipo de evento cadastrado com sucesso.", tipoEvento);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário que coincide com o IdTipoUsuario informado e o deleta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _TipoEventoRepository.Deletar(id);
                return Ok("Tipo de evento deletado com sucesso.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário que coincide com o IdTipoUsuario informado e o atualiza com os dados do TipoUsuario informado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ins"></param>
        /// <returns>O tipo de usuário editado</returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, TipoEvento ins)
        {
            try
            {
                return Ok(_TipoEventoRepository.BuscarIdEAtualizar(id, ins));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Lista com todos os tipos de evento</returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_TipoEventoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os tipos de usuário incluindo seus eventos
        /// </summary>
        /// <returns>Lista com todos os tipos de evento e seus eventos</returns>
        
        [Authorize]
        [HttpGet("ListarComEventos")]
        public IActionResult GetWithEvents()
        {
            try
            {
                return Ok(_TipoEventoRepository.ListarTodosComEventos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário que coincide com o IdTipoUsuario informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tipo de usuário selecionado</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_TipoEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário que coincide com um IdTipoUsuario informado incluindo seus eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tipo de usuário selecionado incluindo seus eventos</returns>
        [Authorize]
        [HttpGet("ListarComEventos{id}")]
        public IActionResult GetByIdWithEvents(Guid id)
        {
            try
            {
                return Ok(_TipoEventoRepository.BuscarPorIdComEventos(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
