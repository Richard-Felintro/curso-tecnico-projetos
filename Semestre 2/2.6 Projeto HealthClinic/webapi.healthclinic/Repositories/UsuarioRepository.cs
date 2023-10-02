using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.Contexts;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Interfaces;
using webapi.healthclinic.Utils;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Repositories
{
    /// <summary>
    /// O repositório por trás da tabela Usuário
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClinicContext Contexto;
        /// <summary>
        /// Quando um repositório é instanciado o Contexto é declarado como um ClinicContext
        /// </summary>
        public UsuarioRepository()
        {
            Contexto = new();
        }

        /// <summary>
        /// Busca um Usuario, comparando seu IdUsuario com o parametro id e o edita usando o parametro 'atualizar' para determinar seus novos parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns>O usuário atualizado</returns>
        public Usuario AtualizarPorId(Guid id, UsuarioViewModel atualizar)
        {
            try
            {
                Usuario user = BuscarPorId(id);
                if (user != null)
                {
                    user.Nome = atualizar.Nome;
                    user.Email = atualizar.Email;
                    user.Senha = Criptografia.GerarHash(atualizar.Senha!);
                    Contexto.SaveChanges();
                    return user;
                }
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca um Usuario baseado em sua Senha e Email para saber se o login coincide
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>O Usuario que coincide com o email e senha, nulo se nenhum for achado</returns>
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario user = Contexto.Usuario.First(x => x.Email == email);
                if (user == null && Criptografia.CompararHash(senha, user!.Senha!))
                {
                    return user;
                }
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca um Usuario, comparando seu IdUsuario com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O Usuario buscado</returns>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario user = Contexto.Usuario.First(x => x.IdUsuario == id);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra um novo Usuario do tipo Médico
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns>O Usuario cadastrado</returns>
        public Usuario CadastrarMedico(MedicoViewModel cadastrado)
        {
            try
            {
                Usuario user = new()
                {
                    Nome = cadastrado.Nome,
                    Email = cadastrado.Email,
                    Senha = Criptografia.GerarHash(cadastrado.Senha!),
                    IdTipoUsuario = Contexto.TipoUsuario.First(x => x.Titulo == "Médico").IdTipoUsuario
                };
                Contexto.Usuario.Add(user);
                Contexto.SaveChanges();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cadastra um novo Usuario do tipo Paciente ou Administrador
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <param name="UserType"></param>
        /// <returns>O Usuario cadastrado</returns>
        public Usuario CadastrarUsuario(UsuarioViewModel cadastrado, string UserType)
        {
            try
            {
                Usuario user = new()
                {
                    Nome = cadastrado.Nome,
                    Email = cadastrado.Email,
                    Senha = Criptografia.GerarHash(cadastrado.Senha!),
                    IdTipoUsuario = Contexto.TipoUsuario.First(x => x.Titulo == UserType).IdTipoUsuario
                };
                Contexto.Usuario.Add(user);
                Contexto.SaveChanges();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca um Usuario, comparando seu IdUsuario com o parametro id e o deleta da database
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id)
        {
            try
            {
                Usuario user = BuscarPorId(id);
                if(user != null)
                {
                    Contexto.Usuario.Remove(user);
                    Contexto.SaveChanges(true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
