using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.Contexts;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Interfaces;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Repositories
{
    /// <summary>
    /// O repositório por trás da tabela Comentario
    /// </summary>
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly ClinicContext Contexto;
        /// <summary>
        /// Quando um repositório é instanciado o Contexto é declarado como um ClinicContext
        /// </summary>
        public ComentarioRepository()
        {
            Contexto = new();
        }

        /// <summary> Busca uma Comentario, comparando seu IdComentario com o parametro id, se esta Comentario for achada, todos seus dados, exceto (IdComentario) serão subtituídos com os dados informado no parametro "atualizar" </summary> 
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns> A Comentario atualizada </returns>
        public Comentario AtualizarPorId(Guid id, ComentarioViewModel atualizar)
        {
            try
            {
                Comentario alvo = BuscarPorId(id);
                if (alvo != null)
                {
                    alvo.Conteudo = atualizar.Conteudo;
                    alvo.IdConsulta = atualizar.IdConsulta;
                    alvo.IdPaciente = atualizar.IdPaciente;
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
        /// Busca uma Comentario, comparando seu IdComentario com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A Comentario buscada </returns>
        public Comentario BuscarPorId(Guid id)
        {
            try
            {
                Comentario Comentario = Contexto.Comentario.First(x => x.IdComentario == id);
                return Comentario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra uma nova Comentario com os dados do parametro cadastrado
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns> A Comentario cadastrada </returns>
        public Comentario Cadastrar(ComentarioViewModel cadastrado)
        {
            try
            {
                Comentario com = new()
                {
                    Conteudo = cadastrado.Conteudo,
                    IdConsulta = cadastrado.IdConsulta,
                    IdPaciente = cadastrado.IdPaciente
                };
                Contexto.Comentario.Add(com);
                Contexto.SaveChanges();
                return com;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca uma Comentario pelo seu Id e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id)
        {
            try
            {
                Contexto.Comentario.Remove(BuscarPorId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Transforma a tabela de Comentario em uma List de Comentario e a retorna
        /// </summary>
        /// <returns> Uma lista com todas as Comentario cadastradas </returns>
        public List<Comentario> ListarTodos()
        {
            return Contexto.Comentario.ToList();
        }
    }
}
