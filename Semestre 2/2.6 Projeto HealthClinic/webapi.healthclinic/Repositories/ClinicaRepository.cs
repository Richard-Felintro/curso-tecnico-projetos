using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.Contexts;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Interfaces;

namespace webapi.healthclinic.Repositories
{
    /// <summary>
    /// O repositório por trás da tabela de Clinica
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly ClinicContext _Context;
        /// <summary>
        /// Quando um repositório é instanciado o _Context é declarado como um ClinicContext
        /// </summary>
        public ClinicaRepository()
        {
            _Context = new();
        }

        /// <summary> Busca uma Clinica, comparando seu IdClinica com o parametro id, se esta clinica for achada, todos seus dados, exceto (IdClinica) serão subtituídos com os dados informado no parametro "atualizar" </summary> 
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns> A Clinica atualizada </returns>
        public Clinica AtualizarPorId(Guid id, Clinica atualizar)
        {
            try
            {
                Clinica alvo = BuscarPorId(id);
                if (alvo != null)
                {
                    alvo.RazaoSocial = atualizar.RazaoSocial;
                    alvo.NomeFantasia = atualizar.NomeFantasia;
                    alvo.AtendimentoInicio = atualizar.AtendimentoInicio;
                    alvo.AtendimentoFim = atualizar.AtendimentoFim;
                    alvo.Endereco = alvo.Endereco;
                    _Context.SaveChanges();
                    return alvo;
                }
#pragma warning disable CS8603 // Possible null reference return.
                return null;
            }
            catch (Exception)
            {
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        /// <summary>
        /// Busca uma Clinica, comparando seu IdClinica com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A Clinica buscada </returns>
        public Clinica BuscarPorId(Guid id)
        {
            try
            {
                Clinica clinica = _Context.Clinica.First(x => x.IdClinica == id);
                return clinica;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra uma nova Clinica com os dados do parametro cadastrado
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns> A Clinica cadastrada </returns>
        public Clinica Cadastrar(Clinica cadastrado)
        {
            try
            {
                _Context.Clinica.Add(cadastrado);
                _Context.SaveChanges();
                return cadastrado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca uma Clinica pelo seu Id e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id)
        {
            try
            {
                _Context.Clinica.Remove(BuscarPorId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Transforma a tabela de Clinica em uma List de Clinica e a retorna
        /// </summary>
        /// <returns> Uma lista com todas as Clinica cadastradas </returns>
        public List<Clinica> ListarTodos()
        {
            return _Context.Clinica.ToList();
        }
    }
}
