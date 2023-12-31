﻿using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;
using eventplus_codefirst.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace eventplus_codefirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private EventoRepository _EventoRepository { get; set; }
        public EventoController()
        {
            _EventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Cadastra um novo Evento
        /// </summary>
        /// <param name="eventoCadastrado"></param>
        /// <returns>O evento criado</returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpPost]
        public IActionResult Post(Evento eventoCadastrado)
        {
            try
            {
                _EventoRepository.Cadastrar(eventoCadastrado);
                return Created("Evento cadastrado com sucesso.", eventoCadastrado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um Evento que coincide com um IdEvento informado e o deleta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _EventoRepository.Deletar(id);
                return Ok("Evento deletado com sucesso.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um Evento que coincide com um IdEvento e o atualiza com os dados da Evento informado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="evento"></param>
        /// <returns>Evento editado</returns>
        [Authorize(Roles = "C2100659-A7D7-4A0B-A513-B5D3FE4E416D")]
        [HttpPatch("{id}")]
        public IActionResult UpdateById(Guid id, Evento evento)
        {
            try
            {
                return Ok(_EventoRepository.BuscarIdEAtualizar(id, evento));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Lista com todos os eventos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_EventoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Buscar um Evento que coincide com um IdEvento informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Evento selecionado</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_EventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
