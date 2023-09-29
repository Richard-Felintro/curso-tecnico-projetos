using Microsoft.AspNetCore.Mvc;
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
        public Paciente BuscarPorIdComUsuario(Guid IdUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Guid IdUsuario)
        {
            Paciente paci = new()
            {
                IdUsuario = IdUsuario
            };
            Contexto.Paciente.Add(paci);
            Contexto.SaveChanges();
        }

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
