using webapi.healthclinic.Contexts;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Interfaces;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Repositories
{
    /// <summary>
    /// O repositório por trás da tabela Especialidade
    /// </summary>
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ClinicContext Contexto;
        /// <summary>
        /// Quando um repositório é instanciado o Contexto é declarado como um ClinicContext
        /// </summary>
        public EspecialidadeRepository()
        {
            Contexto = new();
        }

        /// <summary> Busca uma Especialidade, comparando seu IdEspecialidade com o parametro id, se esta Especialidade for achada, todos seus dados, exceto (IdEspecialidade) serão subtituídos com os dados informado no parametro "atualizar" </summary> 
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns> A Especialidade atualizada </returns>
        public Especialidade AtualizarPorId(Guid id, EspecialidadeViewModel atualizar)
        {
            Especialidade espi = BuscarPorId(id);
            if (espi != null) 
            {
                espi.Titulo = atualizar.Titulo;
                Contexto.SaveChanges();
                return espi;
            }
#pragma warning disable CS8603 // Possible null reference return.
            return null;
        }

        /// <summary>
        /// Busca uma Especialidade, comparando seu IdEspecialidade com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A Especialidade buscada </returns>
        public Especialidade BuscarPorId(Guid id)
        {
            try
            {
                Especialidade esp = Contexto.Especialidade.First(x => x.IdEspecialidade == id);
                return esp;
            }
            catch (Exception)
            {
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        /// <summary>
        /// Cadastra uma nova Especialidade com os dados do parametro cadastrado
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns> A Especialidade cadastrada </returns>
        public Especialidade Cadastrar(EspecialidadeViewModel cadastrado)
        {
            try
            {
                Especialidade espi = new()
                {
                    Titulo = cadastrado.Titulo,
                };
                Contexto.Especialidade.Add(espi);
                Contexto.SaveChanges();
                return espi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca uma Especialidade pelo seu Id e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id)
        {
            Contexto.Especialidade.Remove(BuscarPorId(id));
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Transforma a tabela de Especialidade em uma List de Especialidade e a retorna
        /// </summary>
        /// <returns> Uma lista com todas as Especialidade cadastradas </returns>
        public List<Especialidade> ListarTodos()
        {
            return Contexto.Especialidade.ToList();
        }
    }
}
