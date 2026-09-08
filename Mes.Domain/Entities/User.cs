using MES.Domain.Common;
using System;

namespace MES.Domain.Entities
{
    public enum UserRole
    {
        Operator,
        Manager,
        Admin
    }
    public class User : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // unique
        public UserRole Role { get; set; }

        public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
    }
}
