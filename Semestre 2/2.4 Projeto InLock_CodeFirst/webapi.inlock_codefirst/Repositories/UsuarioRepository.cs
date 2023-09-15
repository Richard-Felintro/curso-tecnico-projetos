using Microsoft.AspNetCore.Http.HttpResults;
using webapi.inlock_codefirst.Contexts;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;
using webapi.inlock_codefirst.Utils;

namespace webapi.inlock_codefirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly InLockContext ctx = new();
        public UsuarioRepository()
        {
            ctx = new InLockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {

            try
            {
                Usuario? usuarioBuscado = ctx.Usuario.First(u => u.Email == email);

                if (usuarioBuscado != null)
                {
                    bool hash = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (hash)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
