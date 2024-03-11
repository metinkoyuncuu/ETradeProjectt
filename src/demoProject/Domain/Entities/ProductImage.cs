﻿using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductImage: Entity<int>
{
    public int ProductId { get; set; }
    public int ImageId { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Image? Image { get; set; }
}
