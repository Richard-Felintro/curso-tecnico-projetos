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
    /// Controller responsável pelo CRUD da tabela Clinica
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private ClinicaRepository _Repository { get; set; }
        /// <summary>
        /// Quando o controller é acionado uma ClinicaRepository é declarada para poder usar seus métodos
        /// </summary>
        public ClinicaController() 
        { 
            _Repository = new();
        }

        /// <summary>
        /// Cadastra a Clinica no parametro e o adiciona ao banco de dados
        /// </summary>
        /// <param name="clinica"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com uma mensagem em referência ao sucesso da operação e a Clinica cadastrada, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro</returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpPost]
        public IActionResult Post(ClinicaViewModel clinica)
        {
            try
            {
                _Repository.Cadastrar(clinica);
                return Created($"Nova clinica cadastrada com sucesso", clinica);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca uma Clinica pelo seu IdClinica e a deleta da database se for encontrada
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
                Clinica clinica = _Repository.BuscarPorId(id);
                if (clinica != null)
                {
                    _Repository.DeletarPorID(id);
                    return Ok($"Clinica deletada com sucesso");
                }
                return NotFound("O Id informado não coincide com nenhuma clínica cadastrada");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Transforma a tabela de Clinicas em uma lista e a retorna
        /// </summary>
        /// <returns> Se suceder, retorna um Status Code 200 Ok com a lista que inclui a tabela Clinica, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro </returns>

        [Authorize]
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
        /// Busca uma Clinica pelo seu IdClinica
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com a Clinica encontrada, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro </returns>

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Clinica clinica = _Repository.BuscarPorId(id);
                return Ok(clinica);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca uma Clinica pelo seu IdClinica, se ela for encontrada a edita usando a Clinica parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinica"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com a Clinica edita e uma mensagem em referência ao sucesso da ação, se a operação falhar retorna Status Code 404 (Not Found) com sua mensagem de erro </returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, ClinicaViewModel clinica)
        {
            try
            {
                if (_Repository.BuscarPorId(id) != null)
                {
                    _Repository.AtualizarPorId(id, clinica);
                    return Created($"Clinica editada com sucesso", clinica);

                    //return Created("Nova clinica, " + clinica.RazaoSocial + " cadastrada com sucesso", clinica);
                }
                return NotFound("O Id informado não coincide com nenhuma clínica cadastrada");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}