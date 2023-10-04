using Microsoft.EntityFrameworkCore.Migrations.Operations;
using webapi.healthclinic.Contexts;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Interfaces;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Repositories
{
    /// <summary>
    /// O repositório por trás da tabela Consulta
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ClinicContext Contexto;
        /// <summary>
        /// Quando um repositório é instanciado o Contexto é declarado como um ClinicContext
        /// </summary>
        public ConsultaRepository()
        {
            Contexto = new();
        }

        /// <summary> Busca uma Consulta, comparando seu IdConsulta com o parametro id, se esta Consulta for achada, todos seus dados, exceto (IdConsulta) serão subtituídos com os dados informado no parametro "atualizar" </summary> 
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns> A Consulta atualizada </returns>
        public Consulta AtualizarPorId(Guid id, ConsultaViewModel atualizar)
        {
            try
            {
                Consulta alvo = BuscarPorId(id);
                if (alvo != null)
                {
                    alvo.DataAtendimento = DateTime.Parse(atualizar.DataAtendimento!);
                    alvo.HoraAtendimento = TimeOnly.Parse(atualizar.HoraAtendimento!);
                    alvo.IdPaciente = atualizar.IdPaciente;
                    alvo.IdMedico = atualizar.IdMedico;
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
        /// Busca uma Consulta, comparando seu IdConsulta com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A Consulta buscada </returns>
        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                Consulta Consulta = Contexto.Consulta.First(x => x.IdConsulta == id);
                return Consulta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra uma nova Consulta com os dados do parametro cadastrado
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns> A Consulta cadastrada </returns>
        public Consulta Cadastrar(ConsultaViewModel cadastrado)
        {
            try
            {
                Consulta cli = new()
                {
                    DataAtendimento = DateTime.Parse(cadastrado.DataAtendimento!),
                    HoraAtendimento = TimeOnly.Parse(cadastrado.HoraAtendimento!),
                    IdPaciente = cadastrado.IdPaciente,
                    IdMedico = cadastrado.IdMedico,
            };
                Contexto.Consulta.Add(cli);
                Contexto.SaveChanges();
                return cli;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca uma Consulta pelo seu Id e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id)
        {
            try
            {
                Contexto.Consulta.Remove(BuscarPorId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Transforma a tabela de Consulta em uma List de Consulta e a retorna
        /// </summary>
        /// <returns> Uma lista com todas as Consulta cadastradas </returns>
        public List<Consulta> ListarTodos()
        {
            return Contexto.Consulta.ToList();
        }
    }
}
