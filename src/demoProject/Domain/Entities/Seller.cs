using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Seller:Entity<int>
{
    public int UserId { get; set; }
    public string PersonalAddress { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string IdentityNumber { get; set; } = string.Empty;
    public int ImageId { get; set; }
    public bool IsVerified { get; set; }
    public DateTime BirthDate { get; set; }
    public int GenderId { get; set; }
    public virtual Gender? Gender { get; set; }
    public virtual Image? Image { get; set; }
    public virtual User? User { get; set; }
}
