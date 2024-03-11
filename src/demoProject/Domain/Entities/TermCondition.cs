using Core.Persistence.Repositories;

namespace Domain.Entities;

public class TermCondition : Entity<int>
{
    public string Header { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}

