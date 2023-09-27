using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Repositories;

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
        [HttpPost]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _Repository.Cadastrar(clinica);
                return Created("Nova clínica, " + clinica.RazaoSocial + " cadastrada com sucesso", clinica);
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
        /// <returns> Se a ação suceder, Status Code 200 Ok com uma mensagem em referência, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro </returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Clinica clinica = _Repository.BuscarPorId(id);
                if (clinica != null)
                {
                    _Repository.DeletarPorID(id);
                    return Ok("Clínica, " + clinica.RazaoSocial + " deletada com sucesso");
                }
                return NotFound("O Id informado não coincide com nenhuma clínica cadastrada");
            }
            catch (Exception)
            {
                return NotFound("O Id informado não coincide com nenhuma clínica cadastrada");
            }
        }

        /// <summary>
        /// Transforma a tabela de Clinicas em uma lista e a retorna
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
        /// Busca uma Clinica pelo seu IdClinica
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com a Clinica encontrada, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Clinica clinica = _Repository.BuscarPorId(id);
                return Ok(clinica);
            }
            catch (Exception)
            {
                return NotFound("O Id informado não coincide com nenhuma clínica cadastrada");
            }
        }
        /// <summary>
        /// Busca uma Clinica pelo seu IdClinica, se ela for encontrada a edita usando a Clinica parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinica"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com a Clinica edita e uma mensagem em referência ao sucesso da ação, se a operação falhar retorna Status Code 404 (Not Found) com sua mensagem de erro </returns>
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, Clinica clinica)
        {
            try
            {
                if (_Repository.BuscarPorId(id) != null)
                {
                    _Repository.AtualizarPorId(id, clinica);
                    return Created("Clínica, " + clinica.RazaoSocial + " editada com sucesso", clinica);
                }
                return NotFound("O Id informado não coincide com nenhuma clínica cadastrada");
            }
            catch (Exception)
            {
                return NotFound("O Id informado não coincide com nenhuma clínica cadastrada");
            }
        }
    }
}
