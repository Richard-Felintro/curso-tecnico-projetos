using webapi.inlock.tarde.Domains;

namespace webapi.inlock.tarde.Interfaces
{
    public interface IJogoRepository
    {
        // Lista todos os jogos
        List<Estudio> Listar();

        // Busca jogo por ID e listá-lo
        Estudio BuscarPorId(Guid id);

        // Cadastra um novo jogo
        void Cadastrar(Jogo jogoCadastrar);

        // Busca jogo por ID e o atualiza usando o estudio como base
        void Atualizar(Guid id, Jogo jogoEdit);

        // Busca jogo por ID e o deleta
        void DeletarPorId(Guid id);
    }
}
