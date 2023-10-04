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
    /// Controller responsável pela gerenciação de Usuarios tipo Medico
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private UsuarioRepository UsuarioR { get; set; }
        private MedicoRepository MedicoR { get; set; }

        /// <summary>
        /// Método construtor que declara todos os repositórios quando o Controller é iniciado
        /// </summary>
        public MedicoController()
        {
            UsuarioR = new();
            MedicoR = new();
        }

        /// <summary>
        /// Cadastra um novo Usuario do tipo Médico
        /// </summary>
        /// <param name="user"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com uma mensagem em referência ao sucesso da operação e o Medico cadastrada, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro</returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpPost("CadastrarMedico")]
        public IActionResult PostMedico(MedicoViewModel user)
        {
            try
            {
                Usuario usuario = UsuarioR.CadastrarMedico(user);
                MedicoR.Cadastrar(usuario.IdUsuario, user);
                return Created("Novo medico cadastrado com sucesso", usuario);
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
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpDelete("{id}", Name = "DeletarMedicoPorId")]
        public IActionResult DeleteMedico(Guid id)
        {
            try
            {
                MedicoR.Deletar(id);
                UsuarioR.DeletarPorID(id);
                return Ok("Medico deletado om sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um Medico e o deleta da database se for encontrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 200 Ok com uma mensagem em referência, se a operação falhar retorna Status Code 404 (Not Found) com a mensagem de erro, se a ação falhar por outro erro retorna Status Code 400 com a mensagem de erro</returns>
        // Exclusivamente utilizável por administradores
        [Authorize(Roles = "D172574C-87B3-4B3A-AF1A-B36DEC8DDC60")]
        [HttpPatch("{id}", Name = "AtualizarMedicoPorId")]
        public IActionResult UpdateMedico(UsuarioViewModel user, Guid id)
        {
            try
            {
                UsuarioR.AtualizarPorId(id, user);
                return Created("Medico atualizado com sucesso", user);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra o Medico no parametro e o adiciona ao banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Se a ação suceder, Status Code 201 Created com uma mensagem em referência ao sucesso da operação e o Medico cadastrada, se a operação falhar retorna Status Code 400 (Bad Request) com a mensagem de erro</returns>
        [Authorize]
        [HttpGet("{id}", Name = "BuscarMedicoPorId")]
        public IActionResult GetMedico(Guid id)
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
