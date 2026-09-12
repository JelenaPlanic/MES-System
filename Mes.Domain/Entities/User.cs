using MES.Domain.Common;
using System;
using Microsoft.AspNetCore.Identity;

namespace MES.Domain.Entities
{
    public enum UserRole
    {
        Operator,
        Manager,
        Admin
    }
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
    }
}
