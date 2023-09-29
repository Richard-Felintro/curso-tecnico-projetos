using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.Contexts;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Interfaces;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Repositories
{
    /// <summary>
    /// O repositório por trás da tabela Clinica
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly ClinicContext Contexto;
        /// <summary>
        /// Quando um repositório é instanciado o Contexto é declarado como um ClinicContext
        /// </summary>
        public ClinicaRepository()
        {
            Contexto = new();
        }

        /// <summary> Busca uma Clinica, comparando seu IdClinica com o parametro id, se esta clinica for achada, todos seus dados, exceto (IdClinica) serão subtituídos com os dados informado no parametro "atualizar" </summary> 
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns> A Clinica atualizada </returns>
        public Clinica AtualizarPorId(Guid id, ClinicaViewModel atualizar)
        {
            try
            {
                Clinica alvo = BuscarPorId(id);
                if (alvo != null)
                {
                    alvo.RazaoSocial = atualizar.RazaoSocial;
                    alvo.NomeFantasia = atualizar.NomeFantasia;
                    alvo.AtendimentoInicio = TimeOnly.Parse(atualizar.AtendimentoInicio!);
                    alvo.AtendimentoFim = TimeOnly.Parse(atualizar.AtendimentoFim!);
                    alvo.Endereco = alvo.Endereco;
                    Contexto.SaveChanges();
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
                Clinica clinica = Contexto.Clinica.First(x => x.IdClinica == id);
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
        public Clinica Cadastrar(ClinicaViewModel cadastrado)
        {
            try
            {
                Clinica cli = new()
                {
                    CNPJ = cadastrado.CNPJ,
                    RazaoSocial = cadastrado.RazaoSocial,
                    NomeFantasia = cadastrado.NomeFantasia,
                    Endereco = cadastrado.Endereco,
                    AtendimentoInicio = TimeOnly.Parse(cadastrado.AtendimentoInicio!),
                    AtendimentoFim = TimeOnly.Parse(cadastrado.AtendimentoFim!)
                };
                Contexto.Clinica.Add(cli);
                Contexto.SaveChanges();
                return cli;
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
                Contexto.Clinica.Remove(BuscarPorId(id));
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
            return Contexto.Clinica.ToList();
        }
    }
}
