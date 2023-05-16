using Hipages.Tradies.Domain.Common;
using Hipages.Tradies.Domain.Enums;

namespace Hipages.Tradies.Domain.Entities;

public class Job: AuditableEntity
{
    public JobStatus Status { get; set; }
    public Suburb Suburb { get; set; }
    public Category Category { get; set; }
    public Contact Contact { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
}