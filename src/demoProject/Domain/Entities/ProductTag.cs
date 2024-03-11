﻿using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductTag : Entity<int>
{
    public int ProductId { get; set; }
    public int TagId { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Tag? Tag { get; set; }
}