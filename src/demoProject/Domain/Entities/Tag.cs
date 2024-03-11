﻿using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Tag : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
}

