using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Repositories;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Controllers
{
    /// <summary>
    /// Controller resposável pelo CRUD de Prontuarios
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProntuarioController : ControllerBase
    {
        private ProntuarioRepository _Repository { get; set; }
        /// <summary>
        /// Declara o _Repository como uma ProntuarioController quando o Controller é chamado
        /// </summary>
        public ProntuarioController()
        {
            _Repository = new();
        }

        /// <summary>
        /// Cadastra o Prontuario no parametro e o adiciona ao banco de dados
        /// </summary>
        /// <param name="espi"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com uma mensagem em referência ao sucesso da operação e o Prontuario cadastrada, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro</returns>
        // Exclusivamente utilizável por médicos
        [Authorize(Roles = "4979865D-4708-4279-9A76-539F74D9F73E")]
        [HttpPost]
        public IActionResult Post(ProntuarioViewModel espi)
        {
            try
            {
                Prontuario esper = _Repository.Cadastrar(espi);
                return Created($"Nova Prontuario cadastrada com sucesso", esper);
            }
            catch (Exception erro)
            {
                return (BadRequest(erro.Message));
            }
        }

        /// <summary>
        /// Busca um Prontuario pelo seu IdClinica e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com uma mensagem em referência, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro, se a ação falhar por outro erro retorna Status Code 400 com a mensagem de erro</returns>
        // Exclusivamente utilizável por médicos
        [Authorize(Roles = "4979865D-4708-4279-9A76-539F74D9F73E")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Prontuario espi = _Repository.BuscarPorId(id);
                if (espi != null)
                {
                    _Repository.DeletarPorID(id);
                    return Ok($"Prontuario deletada com sucesso");
                }
                return NotFound("O Id informado não coincide com nenhuma Prontuario cadastrada");
            }
            catch (Exception erro)
            {
                return (BadRequest(erro.Message));
            }
        }

        /// <summary>
        /// Transforma a tabela Prontuario em uma lista e a retorna
        /// </summary>
        /// <returns> Se suceder, retorna um Status Code 200 Ok com a lista que inclui a tabela Prontuario, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro </returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
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
        /// Busca um Prontuario pelo seu IdProntuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com o Prontuario encontrada, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro </returns>
        // Exclusivamente utilizável por médicos
        [Authorize(Roles = "4979865D-4708-4279-9A76-539F74D9F73E")]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Prontuario espi = _Repository.BuscarPorId(id);
                return Ok(espi);
            }
            catch (Exception)
            {
                return NotFound("O Id informado não coincide com nenhuma Prontuario cadastrada");
            }
        }

        /// <summary>
        /// Busca uma Prontuario pelo seu IdProntuario, se ela for encontrada a edita usando o Prontuario parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="espi"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com a Prontuario edita e uma mensagem em referência ao sucesso da ação, se a operação falhar retorna Status Code 404 (Not Found) com sua mensagem de erro </returns>
        // Exclusivamente utilizável por médicos
        [Authorize(Roles = "4979865D-4708-4279-9A76-539F74D9F73E")]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, ProntuarioViewModel espi)
        {
            try
            {
                if (_Repository.BuscarPorId(id) != null)
                {
                    Prontuario esper = _Repository.AtualizarPorId(id, espi);
                    return Created($"Prontuario editada com sucesso", esper);
                }
                return NotFound("O Id informado não coincide com nenhuma Prontuario cadastrada");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
