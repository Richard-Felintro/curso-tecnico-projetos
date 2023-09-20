using eventplus_codefirst.Domains;
using eventplus_codefirst.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventplus_codefirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {
        private InstituicaoRepository _InstituicaoRepository { get; set; }
        public InstituicaoController()
        {
            _InstituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="instituicao"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _InstituicaoRepository.Cadastrar(instituicao);
                return Created("Instituição cadastrada com sucesso.", instituicao);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca uma Instituição que coincide com um IdInstituicao informado e o deleta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _InstituicaoRepository.Deletar(id);
                return Ok("Instituição deletada com sucesso.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca Instituicao que coincide com um IdInstituicao e a atualiza com os dados da Instituicao informado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ins"></param>
        /// <returns>Instituicão editada</returns>
        [HttpPatch]
        public IActionResult UpdateById(Guid id, Instituicao ins)
        {
            try
            {
                return Ok(_InstituicaoRepository.BuscarIdEAtualizar(id, ins));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as instituições
        /// </summary>
        /// <returns>Lista com todas as instituições</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_InstituicaoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as instituições incluindo seus eventos
        /// </summary>
        /// <returns>Lista de todas as instituições com seus eventos</returns>
        [HttpGet("ListarComEventos")]
        public IActionResult GetWithEvents()
        {
            try
            {
                return Ok(_InstituicaoRepository.ListarTodosComEventos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Buscar Instituição que coincide com um Id informado (IdInstituicao)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Instituição selectionada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_InstituicaoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Buscar Instituição que coincide com um Id informado (IdInstituicao) incluindo seus eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Instituição selecionada com seus eventos</returns>
        [HttpGet("ListarComEventos{id}")]
        public IActionResult GetByIdWithEvents(Guid id)
        {
            try
            {
                return Ok(_InstituicaoRepository.BuscarPorIdComEventos(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
