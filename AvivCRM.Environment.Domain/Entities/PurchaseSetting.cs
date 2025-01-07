using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class PurchaseSetting : BaseEntity, IEntity
{
    public string PurchasePrefixJsonSettings { get; set; } = "[]"; // default! or required 
}













