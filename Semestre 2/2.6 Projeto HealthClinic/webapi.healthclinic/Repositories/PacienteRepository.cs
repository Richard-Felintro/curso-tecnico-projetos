﻿using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.Contexts;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Interfaces;

namespace webapi.healthclinic.Repositories
{
    /// <summary>
    /// O repositório por trás da tabela Paciente
    /// </summary>
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ClinicContext Contexto;
        /// <summary>
        /// Quando um repositório é instanciado o Contexto é declarado como um ClinicContext
        /// </summary>
        public PacienteRepository()
        {
            Contexto = new();
        }

        /// <summary>
        /// Buscar as informações de paciente de um usuário utilizando o IdUsuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Paciente BuscarPorIdComUsuario(Guid IdUsuario)
        {
            try
            {
                Paciente paci = Contexto.Paciente.First(x => x.IdUsuario == IdUsuario);
                return paci;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra um novo usuário com a ForeignKey do Usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        public void Cadastrar(Guid IdUsuario)
        {
            Paciente paci = new()
            {
                IdUsuario = IdUsuario
            };
            Contexto.Paciente.Add(paci);
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Deleta as informações de Paciente de um usuário usando seu IdUsuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        public void Deletar(Guid IdUsuario)
        {
            try
            {
                Paciente paci = Contexto.Paciente.First(x => x.IdUsuario == IdUsuario);
                Contexto.Paciente.Remove(paci);
                Contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
