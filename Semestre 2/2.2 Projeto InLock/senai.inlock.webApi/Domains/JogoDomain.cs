using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe determinante da entidade Jogo
    /// </summary>
    public class JogoDomain
    {
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }
        public string? Estudio { get; set; }
        [Required(ErrorMessage = "Nome de jogo não determinado.")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Descrição de jogo não determinada.")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "Data de lançamento não determinada.")]
        public DateTime? DataLancamento { get; set; }
        [Required(ErrorMessage = "Valor de jogo não determinado.")]
        public Decimal? Valor { get; set; }
    }
}
