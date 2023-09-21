using eventplus_codefirst.Domains;

namespace eventplus_codefirst.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);
        void Deletar(Guid id);
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId(Guid id);
        TipoUsuario Atualizar(Guid id, TipoUsuario tipoUsuario);
    }
}
