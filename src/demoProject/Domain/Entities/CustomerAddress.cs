using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerAddress : Entity<int>
{
    public int CustomerId { get; set; }
    public string Header { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Address { get; set; } = string.Empty;
    public virtual City? Gender { get; set; }
    public virtual District? District { get; set; }
    public virtual Customer? Customer { get; set; }
}