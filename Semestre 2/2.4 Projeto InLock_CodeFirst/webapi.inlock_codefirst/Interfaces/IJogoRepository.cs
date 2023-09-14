using webapi.inlock_codefirst.Domains;

namespace webapi.inlock_codefirst.Interfaces
{
    public interface IJogoRepository
    {
        // Lista todos os jogos
        public List<Jogo> ListarJogos();

        // Busca um jogo por IdJogo
        public Jogo BuscarJogoPorId(Guid id);

        // Busca um jogo e seus jogos por IdJogo
        public Jogo BuscarJogo(Guid id);

        // Cadastra um novo jogo
        public void CadastrarJogo(Jogo jogo);

        // Busca um jogo pelo Id e o atualiza
        public void AtualizarEstudio(Jogo jogo, Guid id);

        // Busca um jogo por Id e o deleta
        public void DeletarJogoPorId(Guid id);
    }
}
