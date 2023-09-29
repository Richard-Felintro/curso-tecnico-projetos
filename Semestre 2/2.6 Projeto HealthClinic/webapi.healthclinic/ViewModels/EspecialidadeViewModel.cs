using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.ViewModels
{
    /// <summary>
    /// ViewModel contendo todos os dados relevantes para cadastrar uma Especialidade
    /// </summary>
    public class EspecialidadeViewModel
    {
        /// <summary>
        /// Título (nome) da Especialidade
        /// </summary>
        public string? Titulo { get; set; }
    }
}
