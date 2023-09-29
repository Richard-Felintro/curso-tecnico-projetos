using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace webapi.healthclinic.ViewModels
{
    /// <summary>
    /// ViewModel contendo todos os dados relevantes para cadastrar uma nova Clinica
    /// </summary>
    public class ClinicaViewModel
    {
        /// <summary>
        /// O CNPJ (Cadastro Nacional de Pessoas Jurídicas) da clínica em questão
        /// </summary>
        [DefaultValue("14 caracteres")]
        [StringLength(14, MinimumLength = 14)]
        public string? CNPJ { get; set; }

        /// <summary>
        /// Razão social (nome formal) da Clinica
        /// </summary>
        public string? RazaoSocial { get; set; }

        /// <summary>
        /// Nome fantasia (nome informal) da Clinica
        /// </summary>
        public string? NomeFantasia { get; set; }

        /// <summary>
        /// Endereço da Clinica
        /// </summary>
        public string? Endereco { get; set; }

        /// <summary>
        /// Horário no qual a Clinica em questao abre diariamente
        /// </summary>
        [DefaultValue("HH:MM:SS")]
        public string? AtendimentoInicio { get; set; }

        /// <summary>
        /// Horário no qual a Clinica em questao fecha diariamente
        /// </summary>
        [DefaultValue("HH:MM:SS")]
        public string? AtendimentoFim { get; set; }
    }
}
