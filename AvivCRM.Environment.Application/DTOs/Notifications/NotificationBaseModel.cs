namespace AvivCRM.Environment.Application.DTOs.Notifications;

public class NotificationBaseModel
{
    public bool ContractSigned { get; set; }
    public bool EstimateDeclined { get; set; }
    public bool EventInvite { get; set; }
    public bool ModulesEmailNotificationEventInviteNew { get; set; }
    public bool RecurringExpenseStatusUpdated { get; set; }
    public bool NewExpenseAddedbyAdmin { get; set; }
    public bool NewExpenseAddedbyMember { get; set; }
    public bool Leadnotification { get; set; }
    public bool NewOrder { get; set; }
    public bool OrderUpdated { get; set; }
    public bool NewProductPurchase { get; set; }
    public bool NewNoticePublished { get; set; }
    public bool UserJoinViaInvitation { get; set; }
    public bool NoticeUpdated { get; set; }
    public bool UserRegistrationAddedbyAdmin { get; set; }
    public bool ModulesEmailNotificationTestNotification { get; set; }
    public bool TwoFactorCode { get; set; }

    // Leave
    public bool NewLeaveApplication { get; set; }
    public bool NewLeaveRequest { get; set; }
    public bool LeaveApproved { get; set; }
    public bool LeaveRejected { get; set; }
    public bool LeaveUpdated { get; set; }
    public bool MultipleLeaveApplication { get; set; }
    public bool NewMultipleLeaveApplication { get; set; }

    // Proposal
    public bool ProposalApproved { get; set; }
    public bool ProposalRejected { get; set; }
    public bool NewProposal { get; set; }

    // Invoice
    public bool RecurringInvoiceStatusUpdated { get; set; }
    public bool InvoiceReminder { get; set; }
    public bool InvoiceCreated { get; set; }
    public bool NewPropoInvoiceUpdatedsal { get; set; }
    public bool NewRecurringInvoice { get; set; }

    // Payment
    public bool NewPayment { get; set; }
    public bool PaymentReceived { get; set; }
    public bool PaymentReminder { get; set; }

    //Task
    public bool NewTask { get; set; }
    public bool TaskUpdated { get; set; }
    public bool TaskCompletedClient { get; set; }
    public bool TaskCompleted { get; set; }
    public bool NewClientTask { get; set; }
    public bool TaskUpdateClient { get; set; }
    public bool SubTaskAssigneeAdded { get; set; }
    public bool SubTaskCompleted { get; set; }
    public bool TaskComment { get; set; }
    public bool TaskNote { get; set; }
    public bool TaskReminder { get; set; }
    public bool AutoTaskReminder { get; set; }

    // Ticket
    public bool NewTicketRequest { get; set; }
    public bool NewSupportTicketRequest { get; set; }
    public bool AgentTicket { get; set; }
    public bool NewTicketReply { get; set; }

    // Project
    public bool EmployeeAssigntoProject { get; set; }
    public bool NewFileUploadedtoProject { get; set; }
    public bool ProjectReminder { get; set; }
    public bool NewProject { get; set; }

    // Remainder
    public bool AttendanceReminder { get; set; }
    public bool FollowUpReminder { get; set; }
    public bool EventReminder { get; set; }
    public bool ModulesEmailNotificationEventReminderNew { get; set; }
    public bool ModulesEmailNotificationAttendanceReminderNew { get; set; }

    // Removal Request
    public bool RemovalRequestAdminNotification { get; set; }
    public bool RemovalRequestApproved { get; set; }
    public bool RemovalRequestReject { get; set; }
    public bool RemovalRequestApprovedLead { get; set; }
    public bool RemovalRequestRejectLead { get; set; }
    public bool RemovalRequestRejectUser { get; set; }
    public bool RemovalRequestApprovedUser { get; set; }
}