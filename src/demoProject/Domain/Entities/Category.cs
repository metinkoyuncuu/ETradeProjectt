using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
    public virtual ICollection<SubCategory>? SubCategories { get; set; }
}



