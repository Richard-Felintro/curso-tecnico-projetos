using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Repositories;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Controllers
{
    /// <summary>
    /// Controller resposável pelo CRUD de especialidades
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EspecialidadeController : ControllerBase
    {
        private EspecialidadeRepository _Repository { get; set; }
        /// <summary>
        /// Declara o _Repository como uma EspecialidadeController quando o Controller é chamado
        /// </summary>
        public EspecialidadeController() 
        {
            _Repository = new();
        }

        /// <summary>
        /// Cadastra a Especialidade no parametro e o adiciona ao banco de dados
        /// </summary>
        /// <param name="espi"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com uma mensagem em referência ao sucesso da operação e a Especialidade cadastrada, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro</returns>
        [HttpPost]
        public IActionResult Post (EspecialidadeViewModel espi)
        {
            try
            {
                Especialidade esper = _Repository.Cadastrar(espi);
                return Created($"Nova especialidade cadastrada com sucesso", esper);
            }
            catch (Exception erro)
            {
                return (BadRequest(erro.Message));
            }
        }

        /// <summary>
        /// Busca uma Clinica pelo seu IdClinica e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com uma mensagem em referência, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro, se a ação falhar por outro erro retorna Status Code 400 com a mensagem de erro</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Especialidade espi = _Repository.BuscarPorId(id);
                if (espi != null)
                {
                    _Repository.DeletarPorID(id);
                    return Ok($"Especialidade deletada com sucesso");
                }
                return NotFound("O Id informado não coincide com nenhuma especialidade cadastrada");
            }
            catch (Exception erro)
            {
                return (BadRequest(erro.Message));
            }
        }

        /// <summary>
        /// Transforma a tabela Especialidade em uma lista e a retorna
        /// </summary>
        /// <returns> Se suceder, retorna um Status Code 200 Ok com a lista que inclui a tabela Clinica, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro </returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_Repository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca uma Especialidade pelo seu IdEspecialidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com a Especialidade encontrada, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Especialidade espi = _Repository.BuscarPorId(id);
                return Ok(espi);
            }
            catch (Exception)
            {
                return NotFound("O Id informado não coincide com nenhuma especialidade cadastrada");
            }
        }

        /// <summary>
        /// Busca uma Especialidade pelo seu IdEspecialidade, se ela for encontrada a edita usando a Especialidade parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="espi"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com a Especialidade edita e uma mensagem em referência ao sucesso da ação, se a operação falhar retorna Status Code 404 (Not Found) com sua mensagem de erro </returns>
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, EspecialidadeViewModel espi)
        {
            try
            {
                if (_Repository.BuscarPorId(id) != null)
                {
                    Especialidade esper = _Repository.AtualizarPorId(id, espi);
                    return Created($"Especialidade editada com sucesso", esper);
                }
                return NotFound("O Id informado não coincide com nenhuma especialidade cadastrada");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
