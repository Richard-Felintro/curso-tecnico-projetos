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
                var usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                if (usuarioBuscado != null)
                {
                    bool Achado = Criptografia.CompararHash(senha, usuarioBuscado.Senha);
                    if (Achado)
                    {
                        return usuarioBuscado;
                    }
                }
            return null;
        }
            
            catch (Exception)
            {

                throw;
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
