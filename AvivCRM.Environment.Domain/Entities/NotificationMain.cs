#region

using AvivCRM.Environment.Domain.Entities.Common;

#endregion

namespace AvivCRM.Environment.Domain.Entities;
public sealed class NotificationMain : BaseEntity, IEntity
{
    public string? CommonNotificationMainJson { get; set; }
    public string? LeaveNotificationMainJson { get; set; }
    public string? ProposalNotificationMainJson { get; set; }
    public string? InvoiceNotificationMainJson { get; set; }
    public string? PaymentNotificationMainJson { get; set; }
    public string? TaskNotificationMainJson { get; set; }
    public string? TicketNotificationMainJson { get; set; }
    public string? ProjectNotificationMainJson { get; set; }
    public string? ReminderNotificationMainJson { get; set; }
    public string? RequestNotificationMainJson { get; set; }
}