using eventplus_codefirst.Domains;
using eventplus_codefirst.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eventplus_codefirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
    {
        private PresencaEventoRepository _PresencaEventoRepository { get; set; }
        public PresencaEventoController()
        {
            _PresencaEventoRepository = new();
        }

        /// <summary>
        /// Cadastra um novo PresencaEvento
        /// </summary>
        /// <param name="PresencaEventoCadastrado"></param>
        /// <returns>O PresencaEvento criada</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(PresencaEvento PresencaEventoCadastrado)
        {
            try
            {
                _PresencaEventoRepository.Cadastrar(PresencaEventoCadastrado);
                return Created("Presenca em evento cadastrada com sucesso.", PresencaEventoCadastrado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um PresencaEvento que coincide com um IdPresencaEvento informado e o deleta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _PresencaEventoRepository.Deletar(id);
                return Ok("Presenca em evento deletada com sucesso.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um PresencaEvento que coincide com um IdPresencaEvento e o atualiza com os dados da PresencaEvento informado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PresencaEvento"></param>
        /// <returns>Presença em evento editada</returns>
        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, PresencaEvento PresencaEvento)
        {
            try
            {
                return Ok(_PresencaEventoRepository.BuscarIdEAtualizar(id, PresencaEvento));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os PresencaEventos
        /// </summary>
        /// <returns>Lista com todas as presenças de eventos</returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_PresencaEventoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Buscar um PresencaEvento que coincide com um IdPresencaEvento informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Presença de evento selectionada</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_PresencaEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Buscar Todas presencas em evento de um usuário com o IdUsuario que coincide com o id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista com as presenças de evento do usuário que coincide com o IdMencionado</returns>
        [Authorize]
        [HttpGet("ListarMinhasPresencas{id}")]
        public IActionResult GetMine(Guid id)
        {
            try
            {
                return Ok(_PresencaEventoRepository.ListarMinhas(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
