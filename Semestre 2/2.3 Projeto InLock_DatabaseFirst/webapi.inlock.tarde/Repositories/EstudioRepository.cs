using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        readonly InLockContext ctx = new();
        public void Atualizar(Guid id, Estudio estudioEdit)
        {
            BuscarPorId(id).Nome = estudioEdit.Nome;
            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id) => ListarComJogos().First(estudio => estudio.IdEstudio == id);

        public void Cadastrar(Estudio estudioCadastrar)
        {
            ctx.Estudios.Add(estudioCadastrar);
            ctx.SaveChanges();
        }

        public void DeletarPorId(Guid id)
        {
            ctx.Estudios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Estudio> Listar() => ctx.Estudios.ToList();

        public List<Estudio> ListarComJogos() => ctx.Estudios.Include(e => e.Jogos).ToList();
    }
}
