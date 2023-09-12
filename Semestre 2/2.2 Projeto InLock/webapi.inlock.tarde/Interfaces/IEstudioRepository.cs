using webapi.inlock.tarde.Domains;

namespace webapi.inlock.tarde.Interfaces
{
    public interface IEstudioRepository
    {
        // Lista todos os estúdios
        List<Estudio> Listar();

        // Busca estúdio por ID e listá-lo
        Estudio BuscarPorId(Guid id);

        // Cadastra um novo estúdio
        void Cadastrar(Estudio estudioCadastrar);

        // Busca estúdio por ID e o atualiza usando o estudio como base
        void Atualizar(Guid id, Estudio estudioEdit);

        // Busca estúdio por ID e o deleta
        void DeletarPorId(Guid id);

        // Lista todos os estúdios com seus jogos relacionados
        List<Estudio> ListarComJogos();
    }
}
