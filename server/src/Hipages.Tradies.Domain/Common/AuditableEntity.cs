namespace Hipages.Tradies.Domain.Common;

public class AuditableEntity: Entity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}