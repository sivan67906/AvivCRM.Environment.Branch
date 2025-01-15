using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvivCRM.Environment.Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class SivanInitial_Deployment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sivan");

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "Sivan",
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
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseSettings",
                schema: "Sivan",
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
                    table.PrimaryKey("PK_PurchaseSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAttendanceSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceSettingCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AttendanceSettingName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAttendanceSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblClient",
                schema: "Sivan",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClient", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "tblContract",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractPrefix = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ContractNumberSeprator = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ContractNumberDigits = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    ContractNumberExample = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
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
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    IsCryptocurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    USDPrice = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    ExchangeRate = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    CurrencyPosition = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ThousandSeparator = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DecimalSeparator = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NumberofDecimals = table.Column<int>(type: "int", maxLength: 5, nullable: false),
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
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomQuestionCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomQuestionType",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomQuestionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDatePattern",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDatePattern", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployee",
                schema: "Sivan",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "tblFinanceInvoiceTemplateSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIRBTemplateJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinanceInvoiceTemplateSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFinancePrefixSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FICBPrefixJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinancePrefixSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFinanceUnitSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinanceUnitSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblJobApplicationCategory",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobApplicationCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblJobApplicationPosition",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobApplicationPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLanguage",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLeadAgent",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
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
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
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
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
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
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllowChatClientEmployee = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    All = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OnlyProjectMembercanwithclient = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Allowchatclientadmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                name: "tblNotificationMain",
                schema: "Sivan",
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
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblNotificationMain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPayment",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PlanPrice = table.Column<float>(type: "real", maxLength: 1000, nullable: false),
                    Validity = table.Column<int>(type: "int", maxLength: 24, nullable: false),
                    Employee = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Designation = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Department = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Company = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Roles = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Permission = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjectCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProjectReminderPerson",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjectReminderPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProjectSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsSendReminder = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ProjectReminderPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemindBefore = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjectSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProjectStatus",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsDefaultStatus = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitGeneralSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    BGColorCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CBJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitGeneralSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitNotificationSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMailJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMailNotificationJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitNotificationSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTask",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeforeXDate = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    SendReminderDueDate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AfterXDate = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Statuss = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TaskboardLength = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    TaskCategory = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Project = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    StartDate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DueDate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AssignedTo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Label = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AssignedBy = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Priority = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MakePrivate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeEstimate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Comment = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AddFile = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SubTask = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Timesheet = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Notes = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    History = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HoursLogged = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CustomFields = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CopyTaskLink = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Rate = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTicketChannel",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTicketChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTicketGroup",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTicketGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTimeLog",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CBTimeLogJsonSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTimeTrackerReminderEnabled = table.Column<bool>(type: "bit", nullable: false),
                    TLTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDailyTimeLogReportEnabled = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTimeLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTimesheet",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTimesheet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTimeZoneStandard",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTimeZoneStandard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblToggleValue",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblToggleValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketReplyTemplates",
                schema: "Sivan",
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
                    table.PrimaryKey("PK_TicketReplyTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                schema: "Sivan",
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
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "Sivan",
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
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_tblCurrency_Id",
                        column: x => x.Id,
                        principalSchema: "Sivan",
                        principalTable: "tblCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitJobApplicationStatusSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsModelChecked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitJobApplicationStatusSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRecruitJobApplicationStatusSetting_tblJobApplicationCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Sivan",
                        principalTable: "tblJobApplicationCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRecruitJobApplicationStatusSetting_tblJobApplicationPosition_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Sivan",
                        principalTable: "tblJobApplicationPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblFinanceInvoiceSetting",
                schema: "Sivan",
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
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinanceInvoiceSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblFinanceInvoiceSetting_tblLanguage_FILanguageId",
                        column: x => x.FILanguageId,
                        principalSchema: "Sivan",
                        principalTable: "tblLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitCustomQuestionSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitCustomQuestionSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRecruitCustomQuestionSetting_tblCustomQuestionCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Sivan",
                        principalTable: "tblCustomQuestionCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRecruitCustomQuestionSetting_tblCustomQuestionType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Sivan",
                        principalTable: "tblCustomQuestionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRecruitCustomQuestionSetting_tblToggleValue_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Sivan",
                        principalTable: "tblToggleValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruiterSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruiterSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRecruiterSetting_tblToggleValue_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Sivan",
                        principalTable: "tblToggleValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRecruitFooterSetting",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecruitFooterSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblRecruitFooterSetting_tblToggleValue_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Sivan",
                        principalTable: "tblToggleValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTicketAgent",
                schema: "Sivan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTicketAgent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTicketAgent_TicketTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Sivan",
                        principalTable: "TicketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblTicketAgent_tblTicketGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Sivan",
                        principalTable: "tblTicketGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblTicketAgent_tblToggleValue_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Sivan",
                        principalTable: "tblToggleValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblFinanceInvoiceSetting_FILanguageId",
                schema: "Sivan",
                table: "tblFinanceInvoiceSetting",
                column: "FILanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitCustomQuestionSetting_CategoryId",
                schema: "Sivan",
                table: "tblRecruitCustomQuestionSetting",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitCustomQuestionSetting_StatusId",
                schema: "Sivan",
                table: "tblRecruitCustomQuestionSetting",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitCustomQuestionSetting_TypeId",
                schema: "Sivan",
                table: "tblRecruitCustomQuestionSetting",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruiterSetting_StatusId",
                schema: "Sivan",
                table: "tblRecruiterSetting",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitFooterSetting_StatusId",
                schema: "Sivan",
                table: "tblRecruitFooterSetting",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitJobApplicationStatusSetting_CategoryId",
                schema: "Sivan",
                table: "tblRecruitJobApplicationStatusSetting",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecruitJobApplicationStatusSetting_PositionId",
                schema: "Sivan",
                table: "tblRecruitJobApplicationStatusSetting",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTicketAgent_GroupId",
                schema: "Sivan",
                table: "tblTicketAgent",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTicketAgent_StatusId",
                schema: "Sivan",
                table: "tblTicketAgent",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTicketAgent_TypeId",
                schema: "Sivan",
                table: "tblTicketAgent",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "PurchaseSettings",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblAttendanceSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblClient",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblContract",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblDatePattern",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblEmployee",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblFinanceInvoiceSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblFinanceInvoiceTemplateSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblFinancePrefixSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblFinanceUnitSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblLeadAgent",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblLeadCategory",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblLeadSource",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblLeadStatus",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblMessage",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblNotificationMain",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblPayment",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblPlanning",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblProjectCategory",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblProjectReminderPerson",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblProjectSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblProjectStatus",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblRecruitCustomQuestionSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblRecruiterSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblRecruitFooterSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblRecruitGeneralSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblRecruitJobApplicationStatusSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblRecruitNotificationSetting",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblTask",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblTax",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblTicketAgent",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblTicketChannel",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblTimeLog",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblTimesheet",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblTimeZoneStandard",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "TicketReplyTemplates",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblCurrency",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblLanguage",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblCustomQuestionCategory",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblCustomQuestionType",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblJobApplicationCategory",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblJobApplicationPosition",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "TicketTypes",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblTicketGroup",
                schema: "Sivan");

            migrationBuilder.DropTable(
                name: "tblToggleValue",
                schema: "Sivan");
        }
    }
}
