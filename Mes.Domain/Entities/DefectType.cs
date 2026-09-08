using MES.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entities
{
    public class DefectType: BaseEntity
    {
        public string Code { get; set; } = string.Empty; // SCRATCH, CRACK, MISALIGN
        public string Description { get; set; } = string.Empty;

        public ICollection<Defect> Defects { get; set; } = new List<Defect>();
    }
}
