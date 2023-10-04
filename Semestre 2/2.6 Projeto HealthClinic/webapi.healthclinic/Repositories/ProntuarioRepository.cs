using webapi.healthclinic.Contexts;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Interfaces;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Repositories
{
    /// <summary>
    /// O repositório por trás da tabela Prontuario
    /// </summary>
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly ClinicContext Contexto;
        /// <summary>
        /// Quando um repositório é instanciado o Contexto é declarado como um ClinicContext
        /// </summary>
        public ProntuarioRepository()
        {
            Contexto = new();
        }

        /// <summary> Busca uma Prontuario, comparando seu IdProntuario com o parametro id, se esta Prontuario for achada, todos seus dados, exceto (IdProntuario) serão subtituídos com os dados informado no parametro "atualizar" </summary> 
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns> A Prontuario atualizada </returns>
        public Prontuario AtualizarPorId(Guid id, ProntuarioViewModel atualizar)
        {
            try
            {
                Prontuario alvo = BuscarPorId(id);
                if (alvo != null)
                {
                    alvo.Conteudo = atualizar.Conteudo;
                    alvo.IdConsulta = atualizar.IdConsulta;
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
        /// Busca uma Prontuario, comparando seu IdProntuario com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A Prontuario buscada </returns>
        public Prontuario BuscarPorId(Guid id)
        {
            try
            {
                Prontuario Prontuario = Contexto.Prontuario.First(x => x.IdProntuario == id);
                return Prontuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra uma nova Prontuario com os dados do parametro cadastrado
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns> A Prontuario cadastrada </returns>
        public Prontuario Cadastrar(ProntuarioViewModel cadastrado)
        {
            try
            {
                Prontuario cli = new()
                {
                    Conteudo = cadastrado.Conteudo,
                    IdConsulta = cadastrado.IdConsulta
                };
                Contexto.Prontuario.Add(cli);
                Contexto.SaveChanges();
                return cli;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca uma Prontuario pelo seu Id e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id)
        {
            try
            {
                Contexto.Prontuario.Remove(BuscarPorId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Transforma a tabela de Prontuario em uma List de Prontuario e a retorna
        /// </summary>
        /// <returns> Uma lista com todas as Prontuario cadastradas </returns>
        public List<Prontuario> ListarTodos()
        {
            return Contexto.Prontuario.ToList();
        }
    }
}
