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
    /// Controller resposável pelo CRUD de Consultas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private ConsultaRepository _Repository { get; set; }
        /// <summary>
        /// Declara o _Repository como uma ConsultaController quando o Controller é chamado
        /// </summary>
        public ConsultaController()
        {
            _Repository = new();
        }

        /// <summary>
        /// Cadastra a Consulta no parametro e o adiciona ao banco de dados
        /// </summary>
        /// <param name="espi"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com uma mensagem em referência ao sucesso da operação e a Consulta cadastrada, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro</returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpPost]
        public IActionResult Post(ConsultaViewModel espi)
        {
            try
            {
                Consulta esper = _Repository.Cadastrar(espi);
                return Created($"Nova Consulta cadastrada com sucesso", esper);
            }
            catch (Exception erro)
            {
                return (BadRequest(erro.Message));
            }
        }

        /// <summary>
        /// Busca uma Consulta pelo seu IdConsulta e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com uma mensagem em referência, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro, se a ação falhar por outro erro retorna Status Code 400 com a mensagem de erro</returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Consulta espi = _Repository.BuscarPorId(id);
                if (espi != null)
                {
                    _Repository.DeletarPorID(id);
                    return Ok($"Consulta deletada com sucesso");
                }
                return NotFound("O Id informado não coincide com nenhuma Consulta cadastrada");
            }
            catch (Exception erro)
            {
                return (BadRequest(erro.Message));
            }
        }

        /// <summary>
        /// Transforma a tabela Consulta em uma lista e a retorna
        /// </summary>
        /// <returns> Se suceder, retorna um Status Code 200 Ok com a lista que inclui a tabela Consulta, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro </returns>
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
        /// Busca uma Consulta pelo seu IdConsulta
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com a Consulta encontrada, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro </returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Consulta espi = _Repository.BuscarPorId(id);
                return Ok(espi);
            }
            catch (Exception)
            {
                return NotFound("O Id informado não coincide com nenhuma Consulta cadastrada");
            }
        }

        /// <summary>
        /// Busca uma Consulta pelo seu IdConsulta, se ela for encontrada a edita usando a Consulta parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="espi"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com a Consulta edita e uma mensagem em referência ao sucesso da ação, se a operação falhar retorna Status Code 404 (Not Found) com sua mensagem de erro </returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, ConsultaViewModel espi)
        {
            try
            {
                if (_Repository.BuscarPorId(id) != null)
                {
                    Consulta esper = _Repository.AtualizarPorId(id, espi);
                    return Created($"Consulta editada com sucesso", esper);
                }
                return NotFound("O Id informado não coincide com nenhuma Consulta cadastrada");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
