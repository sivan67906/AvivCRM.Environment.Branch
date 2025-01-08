#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class CustomQuestionType : BaseEntity, IEntity
{
    public string? Name { get; set; }
}