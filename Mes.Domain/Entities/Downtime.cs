using MES.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entities
{
    public class Downtime : BaseEntity  // ONE TO MANY
    {
        public int WorkOrderId { get; set; }  // povezivanje zastoja sa konkretnim radnim nalogom
        public WorkOrder WorkOrder { get; set; } = null!;

        public int DowntimeReasonId { get; set; } // tabela sa ogranicenim skupom vrednosti lookup table
        public DowntimeReason DowntimeReason { get; set; } = null!;

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; } // zastoj u toku, jos uvek nema kvar
        public string? Notes { get; set; } // opciono napomene

       
    }
}
