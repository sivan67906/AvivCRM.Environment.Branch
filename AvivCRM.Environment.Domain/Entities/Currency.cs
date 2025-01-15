#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Currency : BaseEntity, IEntity
{
    public string? CurrencyName { get; set; } = default!;
    public string? CurrencySymbol { get; set; } = default!;
    public string? CurrencyCode { get; set; } = default!;
    public string? IsCryptocurrency { get; set; } = default!;
    public int USDPrice { get; set; }
    public int ExchangeRate { get; set; }
    public string? CurrencyPosition { get; set; }
    public string? ThousandSeparator { get; set; }
    public string? DecimalSeparator { get; set; }
    public int NumberofDecimals { get; set; }
    public ICollection<Applications> Application { get; set; } = [];
}