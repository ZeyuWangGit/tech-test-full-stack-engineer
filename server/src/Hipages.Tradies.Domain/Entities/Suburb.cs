using Hipages.Tradies.Domain.Common;

namespace Hipages.Tradies.Domain.Entities;

public class Suburb: Entity
{
    public string Name { get; set; } = string.Empty;
    public string Postcode { get; set; } = string.Empty;
}