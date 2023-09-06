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
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }
        /// <summary>
        /// Cadastrar um novo jogo. Somente para Administradores.
        /// </summary>
        /// <param name="Jogo"></param>
        [Authorize (Roles = "2")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);
                return Created("Novo jogo cadastrado com sucesso!", novoJogo);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Exibe todos os jogos cadastrados e seus respectivos estúdios.
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<JogoDomain> ListaDeJogos = _jogoRepository.ListarTodos();
                return Ok(ListaDeJogos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
