using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvivCRM.Environment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SivanInitial_Deployment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "aviv");

            migrationBuilder.CreateTable(
                name: "tblAttendanceSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceSettingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendanceSettingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAttendanceSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblClient",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblContract",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractNumberSeprator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractNumberDigits = table.Column<int>(type: "int", nullable: false),
                    ContractNumberExample = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCurrency",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCryptocurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USDPrice = table.Column<int>(type: "int", nullable: false),
                    ExchangeRate = table.Column<int>(type: "int", nullable: false),
                    CurrencyPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThousandSeparator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecimalSeparator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberofDecimals = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomQuestionCategory",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomQuestionCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomQuestionType",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomQuestionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployee",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFinanceInvoiceSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FILogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILogoImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FIAuthorisedImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FIAuthorisedImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FILanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIDueAfter = table.Column<int>(type: "int", nullable: false),
                    FISendReminderBefore = table.Column<int>(type: "int", nullable: false),
                    FISendReminderAfterEveryId = table.Column<int>(type: "int", nullable: false),
                    FISendReminderAfterEvery = table.Column<int>(type: "int", nullable: false),
                    FICBGeneralJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FICBClientInfoJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FITerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FIOtherInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinanceInvoiceSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFinanceInvoiceTemplateSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIRBTemplateJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinanceInvoiceTemplateSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFinancePrefixSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FICBPrefixJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinancePrefixSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFinanceUnitSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinanceUnitSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblJobApplicationCategory",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobApplicationCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblJobApplicationPosition",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobApplicationPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLanguage",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLeadAgent",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeadAgent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLeadCategory",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeadCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLeadSource",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeadSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLeadStatus",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeadStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMessage",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllowChatClientEmployee = table.Column<bool>(type: "bit", nullable: false),
                    All = table.Column<bool>(type: "bit", nullable: false),
                    OnlyProjectMembercanwithclient = table.Column<bool>(type: "bit", nullable: false),
                    Allowchatclientadmin = table.Column<bool>(type: "bit", nullable: false),
                    SoundNotifyAlert = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblNotification",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractSigned = table.Column<bool>(type: "bit", nullable: false),
                    EstimateDeclined = table.Column<bool>(type: "bit", nullable: false),
                    EventInvite = table.Column<bool>(type: "bit", nullable: false),
                    ModulesEmailNotificationEventInviteNew = table.Column<bool>(type: "bit", nullable: false),
                    RecurringExpenseStatusUpdated = table.Column<bool>(type: "bit", nullable: false),
                    NewExpenseAddedbyAdmin = table.Column<bool>(type: "bit", nullable: false),
                    NewExpenseAddedbyMember = table.Column<bool>(type: "bit", nullable: false),
                    Leadnotification = table.Column<bool>(type: "bit", nullable: false),
                    NewOrder = table.Column<bool>(type: "bit", nullable: false),
                    OrderUpdated = table.Column<bool>(type: "bit", nullable: false),
                    NewProductPurchase = table.Column<bool>(type: "bit", nullable: false),
                    NewNoticePublished = table.Column<bool>(type: "bit", nullable: false),
                    UserJoinViaInvitation = table.Column<bool>(type: "bit", nullable: false),
                    NoticeUpdated = table.Column<bool>(type: "bit", nullable: false),
                    UserRegistrationAddedbyAdmin = table.Column<bool>(type: "bit", nullable: false),
                    ModulesEmailNotificationTestNotification = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorCode = table.Column<bool>(type: "bit", nullable: false),
                    NewLeaveApplication = table.Column<bool>(type: "bit", nullable: false),
                    NewLeaveRequest = table.Column<bool>(type: "bit", nullable: false),
                    LeaveApproved = table.Column<bool>(type: "bit", nullable: false),
                    LeaveRejected = table.Column<bool>(type: "bit", nullable: false),
                    LeaveUpdated = table.Column<bool>(type: "bit", nullable: false),
                    MultipleLeaveApplication = table.Column<bool>(type: "bit", nullable: false),
                    NewMultipleLeaveApplication = table.Column<bool>(type: "bit", nullable: false),
                    ProposalApproved = table.Column<bool>(type: "bit", nullable: false),
                    ProposalRejected = table.Column<bool>(type: "bit", nullable: false),
                    NewProposal = table.Column<bool>(type: "bit", nullable: false),
                    RecurringInvoiceStatusUpdated = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceReminder = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceCreated = table.Column<bool>(type: "bit", nullable: false),
                    NewPropoInvoiceUpdatedsal = table.Column<bool>(type: "bit", nullable: false),
                    NewRecurringInvoice = table.Column<bool>(type: "bit", nullable: false),
                    NewPayment = table.Column<bool>(type: "bit", nullable: false),
                    PaymentReceived = table.Column<bool>(type: "bit", nullable: false),
                    PaymentReminder = table.Column<bool>(type: "bit", nullable: false),
                    NewTask = table.Column<bool>(type: "bit", nullable: false),
                    TaskUpdated = table.Column<bool>(type: "bit", nullable: false),
                    TaskCompletedClient = table.Column<bool>(type: "bit", nullable: false),
                    TaskCompleted = table.Column<bool>(type: "bit", nullable: false),
                    NewClientTask = table.Column<bool>(type: "bit", nullable: false),
                    TaskUpdateClient = table.Column<bool>(type: "bit", nullable: false),
                    SubTaskAssigneeAdded = table.Column<bool>(type: "bit", nullable: false),
                    SubTaskCompleted = table.Column<bool>(type: "bit", nullable: false),
                    TaskComment = table.Column<bool>(type: "bit", nullable: false),
                    TaskNote = table.Column<bool>(type: "bit", nullable: false),
                    TaskReminder = table.Column<bool>(type: "bit", nullable: false),
                    AutoTaskReminder = table.Column<bool>(type: "bit", nullable: false),
                    NewTicketRequest = table.Column<bool>(type: "bit", nullable: false),
                    NewSupportTicketRequest = table.Column<bool>(type: "bit", nullable: false),
                    AgentTicket = table.Column<bool>(type: "bit", nullable: false),
                    NewTicketReply = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeAssigntoProject = table.Column<bool>(type: "bit", nullable: false),
                    NewFileUploadedtoProject = table.Column<bool>(type: "bit", nullable: false),
                    ProjectReminder = table.Column<bool>(type: "bit", nullable: false),
                    NewProject = table.Column<bool>(type: "bit", nullable: false),
                    AttendanceReminder = table.Column<bool>(type: "bit", nullable: false),
                    FollowUpReminder = table.Column<bool>(type: "bit", nullable: false),
                    EventReminder = table.Column<bool>(type: "bit", nullable: false),
                    ModulesEmailNotificationEventReminderNew = table.Column<bool>(type: "bit", nullable: false),
                    ModulesEmailNotificationAttendanceReminderNew = table.Column<bool>(type: "bit", nullable: false),
                    RemovalRequestAdminNotification = table.Column<bool>(type: "bit", nullable: false),
                    RemovalRequestApproved = table.Column<bool>(type: "bit", nullable: false),
                    RemovalRequestReject = table.Column<bool>(type: "bit", nullable: false),
                    RemovalRequestApprovedLead = table.Column<bool>(type: "bit", nullable: false),
                    RemovalRequestRejectLead = table.Column<bool>(type: "bit", nullable: false),
                    RemovalRequestRejectUser = table.Column<bool>(type: "bit", nullable: false),
                    RemovalRequestApprovedUser = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNotification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblNotificationMain",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommonNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposalNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReminderNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestNotificationMainJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNotificationMain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPayment",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPlanning",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanPrice = table.Column<float>(type: "real", nullable: false),
                    Validity = table.Column<int>(type: "int", nullable: false),
                    Employee = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<int>(type: "int", nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPlanning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProjectCategory",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjectCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProjectReminderPerson",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjectReminderPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProjectSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSendReminder = table.Column<bool>(type: "bit", nullable: false),
                    ProjectReminderPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemindBefore = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjectSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProjectStatus",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefaultStatus = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPurchaseSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchasePrefixJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurchaseSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitCustomQuestionSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitCustomQuestionSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruiterSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruiterSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitFooterSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitFooterSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitGeneralSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuplJobApplnRestrictDays = table.Column<int>(type: "int", nullable: false),
                    OLReminderToCandidate = table.Column<int>(type: "int", nullable: false),
                    BGLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BGLogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BGLogoImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BGColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitGeneralSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitJobApplicationStatusSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsModelChecked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitJobApplicationStatusSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitNotificationSetting",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMailJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMailNotificationJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitNotificationSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTask",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeforeXDate = table.Column<int>(type: "int", nullable: false),
                    SendReminderDueDate = table.Column<bool>(type: "bit", nullable: false),
                    AfterXDate = table.Column<int>(type: "int", nullable: false),
                    Statuss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskboardLength = table.Column<int>(type: "int", nullable: false),
                    TaskCategory = table.Column<bool>(type: "bit", nullable: false),
                    Project = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<bool>(type: "bit", nullable: false),
                    AssignedTo = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<bool>(type: "bit", nullable: false),
                    AssignedBy = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<bool>(type: "bit", nullable: false),
                    MakePrivate = table.Column<bool>(type: "bit", nullable: false),
                    TimeEstimate = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<bool>(type: "bit", nullable: false),
                    AddFile = table.Column<bool>(type: "bit", nullable: false),
                    SubTask = table.Column<bool>(type: "bit", nullable: false),
                    Timesheet = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<bool>(type: "bit", nullable: false),
                    History = table.Column<bool>(type: "bit", nullable: false),
                    HoursLogged = table.Column<bool>(type: "bit", nullable: false),
                    CustomFields = table.Column<bool>(type: "bit", nullable: false),
                    CopyTaskLink = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTax",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTicketAgent",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTicketAgent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTicketChannel",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTicketChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTicketGroup",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTicketGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTicketReplyTemplate",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTicketReplyTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTicketType",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTicketType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTimeLog",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CBTimeLogJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTimeTrackerReminderEnabled = table.Column<bool>(type: "bit", nullable: false),
                    TLTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDailyTimeLogReportEnabled = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTimeLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTimesheet",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTimesheet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblApplication",
                schema: "aviv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultTimezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatatableRowLimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCanExportData = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblApplication_tblCurrency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "aviv",
                        principalTable: "tblCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblApplication_CurrencyId",
                schema: "aviv",
                table: "tblApplication",
                column: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblApplication",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblAttendanceSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblClient",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblContract",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblCustomQuestionCategory",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblCustomQuestionType",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblEmployee",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblFinanceInvoiceSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblFinanceInvoiceTemplateSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblFinancePrefixSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblFinanceUnitSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblJobApplicationCategory",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblJobApplicationPosition",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblLanguage",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblLeadAgent",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblLeadCategory",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblLeadSource",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblLeadStatus",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblMessage",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblNotification",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblNotificationMain",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblPayment",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblPlanning",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblProjectCategory",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblProjectReminderPerson",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblProjectSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblProjectStatus",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblPurchaseSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblRecruitCustomQuestionSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblRecruiterSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblRecruitFooterSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblRecruitGeneralSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblRecruitJobApplicationStatusSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblRecruitNotificationSetting",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblTask",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblTax",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblTicketAgent",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblTicketChannel",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblTicketGroup",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblTicketReplyTemplate",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblTicketType",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblTimeLog",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblTimesheet",
                schema: "aviv");

            migrationBuilder.DropTable(
                name: "tblCurrency",
                schema: "aviv");
        }
    }
}
