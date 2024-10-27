﻿namespace SalesMind.Domain.Entities;
public class Category : Entity<int>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int ParentCategoryId { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
