using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe representante da entidade Estudio
    /// </summary>
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }
        [Required (ErrorMessage = "Nome de estúdio não determinado.")]
        public string? Nome { get; set; }
    }
}
