using eventplus_codefirst.Domains;
using eventplus_codefirst.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventplus_codefirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private ComentarioEventoRepository _ComentarioEventoRepository { get; set; }
        public ComentarioEventoController()
        {
            _ComentarioEventoRepository = new ();
        }

        /// <summary>
        /// Cadastra um novo ComentarioEvento
        /// </summary>
        /// <param name="ComentarioEventoCadastrado"></param>
        /// <returns>O comentário criado</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ComentarioEvento ComentarioEventoCadastrado)
        {
            try
            {
                _ComentarioEventoRepository.Cadastrar(ComentarioEventoCadastrado);
                return Created("ComentarioEvento cadastrado com sucesso.", ComentarioEventoCadastrado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um ComentarioEvento que coincide com um IdComentarioEvento informado e o deleta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _ComentarioEventoRepository.Deletar(id);
                return Ok("ComentarioEvento deletado com sucesso.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um ComentarioEvento que coincide com um IdComentarioEvento e altera seu estado de exibição
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id)
        {
            try
            {
                _ComentarioEventoRepository.AlterarExibicao(id);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os ComentarioEventos
        /// </summary>
        /// <returns>Lista com todos os ComentarioEventos</returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_ComentarioEventoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Buscar um ComentarioEvento que coincide com um IdComentarioEvento informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ComentarioEvento selecionado</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_ComentarioEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
