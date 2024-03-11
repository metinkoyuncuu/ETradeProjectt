using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Image : Entity<int>
{
    public string Url { get; set; } = string.Empty;
}

