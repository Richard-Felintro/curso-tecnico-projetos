using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace webapi.healthclinic.Utils
{
    public class TimeOnlyComparer : ValueComparer<TimeOnly>
    {
        public TimeOnlyComparer() : base(
            (x, y) => x.Ticks == y.Ticks,
            timeOnly => timeOnly.GetHashCode())
        { }
    }
}
