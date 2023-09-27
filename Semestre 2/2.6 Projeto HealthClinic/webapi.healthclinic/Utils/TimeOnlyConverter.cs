using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace webapi.healthclinic.Utils
{
    /// <summary>
    /// Convertor de unidades que converte o TimeOnly para uma variável usável
    /// </summary>
    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        /// <summary>
        /// Método para quando o covnersor é ativado
        /// </summary>
        public TimeOnlyConverter() : base(
            timeOnly => timeOnly.ToTimeSpan(),
            timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        { }
    }
}
