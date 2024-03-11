using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Shipping : Entity<int>
{
    public int OrderId { get; set; }
    public string Header { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public virtual Order? Order { get; set; }
    public virtual City? City { get; set; }
    public virtual District? District { get; set; }
}

