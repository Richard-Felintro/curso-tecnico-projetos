using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid id, Estudio estudioEdit)
        {
            BuscarPorId(id).Nome = estudioEdit.Nome;
        }

        public Estudio BuscarPorId(Guid id) => Listar().First(estudio => estudio.IdEstudio == id);

        public void Cadastrar(Estudio estudioCadastrar)
        {
            throw new NotImplementedException();
        }

        public void DeletarPorId(Guid id)
        {
            ctx.Estudios.Remove(BuscarPorId(id));
        }

        public List<Estudio> Listar() => ctx.Estudios.ToList();

        public List<Estudio> ListarComJogos()
        {
            ctx.Estudios.Include(ctx.Jogos(Estudio => Estudio.IdEstudio == Jogos.id));
        }
    }
}
