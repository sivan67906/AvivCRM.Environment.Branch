#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class FinanceInvoiceTemplateSetting : BaseEntity, IEntity
{
    public string FIRBTemplateJsonSettings { get; set; } = "[]";
}