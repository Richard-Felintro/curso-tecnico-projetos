using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    // Determina que este controller é um Controller de API
    [ApiController]
    // Determina a rota deste controller na API
    [Route("api/[controller]")]
    // Determina o que este controller produzirá
    [Produces("application/json")]

    // Herda as propriedades de ControllerBase ao JogoController
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<EstudioDomain> ListaDeEstudios = _estudioRepository.ListarTodos();
                return Ok(ListaDeEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
