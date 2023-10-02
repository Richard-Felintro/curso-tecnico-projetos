using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
