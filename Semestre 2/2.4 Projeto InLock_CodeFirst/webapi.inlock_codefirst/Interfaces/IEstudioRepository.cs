using webapi.inlock_codefirst.Domains;

namespace webapi.inlock_codefirst.Interfaces
{
    public interface IEstudioRepository
    {
        // Lista todos os estúdios
        public List<Estudio> ListarEstudios();

        // Lista todos os estúdios com seus jogos
        public List<Estudio> ListarEstudiosComJogos();

        // Busca um estúdio por IdEstudio
        public Estudio BuscarEstudioPorId(Guid id);

        // Busca um estúdio e seus jogos por IdEstudio
        public Estudio BuscarEstudioComJogos(Guid id);

        // Cadastra um novo estúdio 
        public void CadastrarEstudio(Estudio estudio);

        // Busca um estúdio pelo Id e o atualiza
        public void AtualizarEstudio(Estudio estudio, Guid id);

        // Busca um estúdio por Id e o deleta
        public void DeletarEstudioPorId(Guid id);
    }
}
