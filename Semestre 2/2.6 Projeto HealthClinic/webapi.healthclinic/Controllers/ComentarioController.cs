using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Repositories;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Controllers
{
    /// <summary>
    /// Controller resposável pelo CRUD de Comentarios
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ComentarioController : ControllerBase
    {
        private ComentarioRepository _Repository { get; set; }
        /// <summary>
        /// Declara o _Repository como uma ComentarioController quando o Controller é chamado
        /// </summary>
        public ComentarioController()
        {
            _Repository = new();
        }

        /// <summary>
        /// Cadastra o Comentario no parametro e o adiciona ao banco de dados
        /// </summary>
        /// <param name="espi"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com uma mensagem em referência ao sucesso da operação e o Comentario cadastrada, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro</returns>
        
        // Exclusivamente utilizável por clientes
        [Authorize(Roles = "F83A2115-3661-41C3-B978-4A58E7D3A64D")]
        [HttpPost]
        public IActionResult Post(ComentarioViewModel espi)
        {
            try
            {
                Comentario esper = _Repository.Cadastrar(espi);
                return Created($"Nova Comentario cadastrada com sucesso", esper);
            }
            catch (Exception erro)
            {
                return (BadRequest(erro.Message));
            }
        }

        /// <summary>
        /// Busca um Comentario pelo seu IdClinica e a deleta da database se for encontrada
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
                Comentario espi = _Repository.BuscarPorId(id);
                if (espi != null)
                {
                    _Repository.DeletarPorID(id);
                    return Ok($"Comentario deletada com sucesso");
                }
                return NotFound("O Id informado não coincide com nenhuma Comentario cadastrada");
            }
            catch (Exception erro)
            {
                return (BadRequest(erro.Message));
            }
        }

        /// <summary>
        /// Transforma a tabela Comentario em uma lista e a retorna
        /// </summary>
        /// <returns> Se suceder, retorna um Status Code 200 Ok com a lista que inclui a tabela Comentario, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro </returns>
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
        /// Busca um Comentario pelo seu IdComentario
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com o Comentario encontrada, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro </returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Comentario espi = _Repository.BuscarPorId(id);
                return Ok(espi);
            }
            catch (Exception)
            {
                return NotFound("O Id informado não coincide com nenhuma Comentario cadastrada");
            }
        }

        /// <summary>
        /// Busca uma Comentario pelo seu IdComentario, se ela for encontrada a edita usando o Comentario parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="espi"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com a Comentario edita e uma mensagem em referência ao sucesso da ação, se a operação falhar retorna Status Code 404 (Not Found) com sua mensagem de erro </returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, ComentarioViewModel espi)
        {
            try
            {
                if (_Repository.BuscarPorId(id) != null)
                {
                    Comentario esper = _Repository.AtualizarPorId(id, espi);
                    return Created($"Comentario editada com sucesso", esper);
                }
                return NotFound("O Id informado não coincide com nenhuma Comentario cadastrada");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
