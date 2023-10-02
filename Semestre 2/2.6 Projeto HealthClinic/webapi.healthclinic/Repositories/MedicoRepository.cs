using webapi.healthclinic.Contexts;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Interfaces;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Repositories
{
    /// <summary>
    /// O repositório por trás da tabela Medico
    /// </summary>
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClinicContext Contexto;
        /// <summary>
        /// Quando um repositório é instanciado o Contexto é declarado como um ClinicContext
        /// </summary>
        public MedicoRepository()
        {
            Contexto = new();
        }

        /// <summary>
        /// Buscar as informações de Medico de um usuário utilizando o IdUsuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Medico BuscarPorIdComUsuario(Guid IdUsuario)
        {
            try
            {
                Medico medi = Contexto.Medico.First(x => x.IdUsuario == IdUsuario);
                return medi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra um novo usuário com a ForeignKey do Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="med"></param>
        public void Cadastrar(Guid id, MedicoViewModel med)
        {
            Medico medi = new()
            {
                IdUsuario = id,
                CRM = med.CRM,
                IdEspecialidade = med.IdEspecialidade,
                IdClinica = med.IdClinica
            };
            Contexto.Medico.Add(medi);
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Deleta as informações de Medico de um usuário usando seu IdUsuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        public void Deletar(Guid IdUsuario)
        {
            try
            {
                Medico medi = Contexto.Medico.First(x => x.IdUsuario == IdUsuario);
                Contexto.Medico.Remove(medi);
                Contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
