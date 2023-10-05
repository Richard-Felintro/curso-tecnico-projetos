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
    /// Controller responsável pela gerenciação de Usuario, Paciente e Medico
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private UsuarioRepository UsuarioR { get; set; }
        private PacienteRepository PacienteR { get; set; }

        /// <summary>
        /// Método construtor que declara todos os repositórios quando o Controller é iniciado
        /// </summary>
        public PacienteController()
        {
            UsuarioR = new();
            PacienteR = new();
        }

        /// <summary>
        /// Cadastra um novo Usuario do tipo Paciente
        /// </summary>
        /// <param name="user"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com uma mensagem em referência ao sucesso da operação e o Usuario cadastrada, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro</returns>
        [HttpPost("CadastrarPaciente")]
        public IActionResult PostPaciente(UsuarioViewModel user)
        {
            try
            {
                Usuario usuario = UsuarioR.CadastrarUsuario(user, "Paciente");
                PacienteR.Cadastrar(usuario.IdUsuario);
                return Created("Novo paciente cadastrado com sucesso", usuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma Clinica pelo seu IdClinica e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com uma mensagem em referência, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro, se a ação falhar por outro erro retorna Status Code 400 com a mensagem de erro</returns>
        [HttpDelete("{id}", Name = "DeletarPorId")]
        public IActionResult DeletePaciente(Guid id)
        {
            try
            {
                PacienteR.Deletar(id);
                UsuarioR.DeletarPorID(id);
                return Ok("Paciente deletado om sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um Paciente e o deleta da database se for encontrado
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com uma mensagem em referência, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro, se a ação falhar por outro erro retorna Status Code 400 com a mensagem de erro</returns>
        [HttpPatch("{id}", Name = "AtualizarPorId")]
        public IActionResult UpdatePaciente(UsuarioViewModel user, Guid id)
        {
            try
            {
                UsuarioR.AtualizarPorId(id,user);
                return Created("Paciente atualizado com sucesso", user);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra o Paciente no parametro e o adiciona ao banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com uma mensagem em referência ao sucesso da operação e o Paciente cadastrada, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro</returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpGet("{id}", Name = "BuscarPorId")]
        public IActionResult GetPaciente(Guid id) 
        {
            try
            {
                Usuario user = UsuarioR.BuscarPorId(id);
                return Ok(user);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
