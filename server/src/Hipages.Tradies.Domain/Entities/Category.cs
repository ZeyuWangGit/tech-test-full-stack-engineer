using Hipages.Tradies.Domain.Common;

namespace Hipages.Tradies.Domain.Entities;

public class Category: Entity
{ 
    public string Name { get; set; } = string.Empty;
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
}