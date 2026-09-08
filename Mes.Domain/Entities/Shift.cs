using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entities
{
    public class Shift
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; } // vreme u toku radnog dana
        public TimeSpan EndTime { get; set; }
    }
}
