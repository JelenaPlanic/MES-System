using MES.Domain.Entities;

namespace MES.Application.DTOs;

public class MachineDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public MachineStatus Status { get; set; } // enum 0,1,2,3
}
