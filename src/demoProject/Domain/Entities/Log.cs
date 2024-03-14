
using Core.Persistence.Repositories;
using System.Security.Cryptography;

namespace Domain.Entities;
public class Log:Entity<int>
{
    public string FullName { get; set; } = string.Empty;
    public int UserId { get; set; } 
    public string Operation { get; set; } = string.Empty;
    public string MethodName { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public bool? IsReaded { get; set; }
}
