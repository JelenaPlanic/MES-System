
using MES.Domain.Common;

namespace MES.Domain.Entities
{
    public class Shift : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; } // vreme u toku radnog dana
        public TimeSpan EndTime { get; set; }
    }
}
