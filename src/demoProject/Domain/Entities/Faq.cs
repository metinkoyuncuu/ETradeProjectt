using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Faq : Entity<int>
{
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}

