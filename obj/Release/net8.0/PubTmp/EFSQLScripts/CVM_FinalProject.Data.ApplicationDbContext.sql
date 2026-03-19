IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260212151330_IdentityDetails'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260212151330_IdentityDetails', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260215083320_AddApplicationUserFields'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260215083320_AddApplicationUserFields'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FirstName] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260215083320_AddApplicationUserFields'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [IsApproved] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260215083320_AddApplicationUserFields'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LastName] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260215083320_AddApplicationUserFields'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260215083320_AddApplicationUserFields', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260220103108_AddUserArchiveFields'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ArchivedAt] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260220103108_AddUserArchiveFields'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ArchivedBy] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260220103108_AddUserArchiveFields'
)
BEGIN
    ALTER TABLE [AspNetUsers] ADD [IsArchived] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260220103108_AddUserArchiveFields'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260220103108_AddUserArchiveFields', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260222062023_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260222062023_InitialCreate', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260304152538_AddOperationalProcesses'
)
BEGIN
    CREATE TABLE [OperationalProcesses] (
        [Id] nvarchar(450) NOT NULL,
        [ProcessId] nvarchar(50) NOT NULL,
        [Name] nvarchar(200) NOT NULL,
        [Department] nvarchar(100) NOT NULL,
        [AssignedTo] nvarchar(100) NOT NULL,
        [Status] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [ApprovedAt] datetime2 NULL,
        [CompletedAt] datetime2 NULL,
        [Notes] nvarchar(500) NULL,
        CONSTRAINT [PK_OperationalProcesses] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260304152538_AddOperationalProcesses'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260304152538_AddOperationalProcesses', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE TABLE [Departments] (
        [Department_ID] int NOT NULL IDENTITY,
        [DepartmentName] nvarchar(100) NOT NULL,
        [Status] nvarchar(50) NULL,
        CONSTRAINT [PK_Departments] PRIMARY KEY ([Department_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE TABLE [Reports] (
        [Report_ID] int NOT NULL IDENTITY,
        [ReportType] nvarchar(100) NOT NULL,
        [generated_by] nvarchar(450) NULL,
        [generated_at] datetime2 NOT NULL,
        [report_data] nvarchar(max) NULL,
        CONSTRAINT [PK_Reports] PRIMARY KEY ([Report_ID]),
        CONSTRAINT [FK_Reports_AspNetUsers_generated_by] FOREIGN KEY ([generated_by]) REFERENCES [AspNetUsers] ([Id]) ON DELETE SET NULL
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE TABLE [Roles] (
        [Role_ID] int NOT NULL IDENTITY,
        [RoleName] nvarchar(100) NOT NULL,
        [Description] nvarchar(500) NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Role_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE TABLE [SystemConfigurations] (
        [Id] int NOT NULL IDENTITY,
        [ConfigKey] nvarchar(max) NOT NULL,
        [ConfigValue] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_SystemConfigurations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE TABLE [Budgets] (
        [Budget_ID] int NOT NULL IDENTITY,
        [department_ID] int NOT NULL,
        [BudgetPeriod] nvarchar(100) NULL,
        [allocated_amount] decimal(18,2) NOT NULL,
        [used_amount] decimal(18,2) NOT NULL,
        [remaining_amount] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Budgets] PRIMARY KEY ([Budget_ID]),
        CONSTRAINT [FK_Budgets_Departments_department_ID] FOREIGN KEY ([department_ID]) REFERENCES [Departments] ([Department_ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE TABLE [Employees] (
        [Employee_ID] nvarchar(450) NOT NULL,
        [user_ID] nvarchar(450) NOT NULL,
        [department_ID] int NOT NULL,
        [Position] nvarchar(100) NULL,
        [EmployeeStatus] nvarchar(50) NULL,
        [date_hired] datetime2 NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Employee_ID]),
        CONSTRAINT [FK_Employees_AspNetUsers_user_ID] FOREIGN KEY ([user_ID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Employees_Departments_department_ID] FOREIGN KEY ([department_ID]) REFERENCES [Departments] ([Department_ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE TABLE [AuditLogs] (
        [Audit_ID] int NOT NULL IDENTITY,
        [user_ID] nvarchar(450) NOT NULL,
        [role_ID] int NULL,
        [Action] nvarchar(200) NOT NULL,
        [assigned_at] datetime2 NOT NULL,
        [IPAddress] nvarchar(50) NULL,
        CONSTRAINT [PK_AuditLogs] PRIMARY KEY ([Audit_ID]),
        CONSTRAINT [FK_AuditLogs_AspNetUsers_user_ID] FOREIGN KEY ([user_ID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AuditLogs_Roles_role_ID] FOREIGN KEY ([role_ID]) REFERENCES [Roles] ([Role_ID]) ON DELETE SET NULL
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE TABLE [PerformanceRecords] (
        [Performance_ID] int NOT NULL IDENTITY,
        [employee_ID] nvarchar(450) NOT NULL,
        [EvaluationPeriod] nvarchar(100) NULL,
        [Remarks] nvarchar(500) NULL,
        [recorded_at] datetime2 NOT NULL,
        CONSTRAINT [PK_PerformanceRecords] PRIMARY KEY ([Performance_ID]),
        CONSTRAINT [FK_PerformanceRecords_Employees_employee_ID] FOREIGN KEY ([employee_ID]) REFERENCES [Employees] ([Employee_ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE INDEX [IX_AuditLogs_role_ID] ON [AuditLogs] ([role_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE INDEX [IX_AuditLogs_user_ID] ON [AuditLogs] ([user_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE INDEX [IX_Budgets_department_ID] ON [Budgets] ([department_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE INDEX [IX_Employees_department_ID] ON [Employees] ([department_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE INDEX [IX_Employees_user_ID] ON [Employees] ([user_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE INDEX [IX_PerformanceRecords_employee_ID] ON [PerformanceRecords] ([employee_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    CREATE INDEX [IX_Reports_generated_by] ON [Reports] ([generated_by]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260305120203_AddSystemConfiguration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260305120203_AddSystemConfiguration', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260306142140_AddEmployeeRequests'
)
BEGIN
    CREATE TABLE [EmployeeRequests] (
        [Id] nvarchar(450) NOT NULL,
        [RequestId] nvarchar(50) NOT NULL,
        [Title] nvarchar(200) NOT NULL,
        [Department] nvarchar(100) NOT NULL,
        [RequestType] nvarchar(100) NOT NULL,
        [Description] nvarchar(1000) NULL,
        [Status] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [ApprovedAt] datetime2 NULL,
        [CompletedAt] datetime2 NULL,
        [SubmittedByUserId] nvarchar(max) NOT NULL,
        [SubmittedByName] nvarchar(200) NULL,
        [ApprovedByUserId] nvarchar(max) NULL,
        [ApprovedByName] nvarchar(200) NULL,
        [CompletedByUserId] nvarchar(max) NULL,
        [CompletedByName] nvarchar(200) NULL,
        [AdminNotes] nvarchar(500) NULL,
        CONSTRAINT [PK_EmployeeRequests] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260306142140_AddEmployeeRequests'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260306142140_AddEmployeeRequests', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260306163146_CreateEmployeeRequestsTable'
)
BEGIN
    ALTER TABLE [OperationalProcesses] ADD [Priority] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260306163146_CreateEmployeeRequestsTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260306163146_CreateEmployeeRequestsTable', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310092000_AddDepartmentArchiveFieldsOnly'
)
BEGIN
    ALTER TABLE [Departments] ADD [IsArchived] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310092000_AddDepartmentArchiveFieldsOnly'
)
BEGIN
    ALTER TABLE [Departments] ADD [ArchivedAt] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310092000_AddDepartmentArchiveFieldsOnly'
)
BEGIN
    ALTER TABLE [Departments] ADD [ArchiveReason] nvarchar(250) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310092000_AddDepartmentArchiveFieldsOnly'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260310092000_AddDepartmentArchiveFieldsOnly', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310103000_AddEmployeeArchiveFieldsOnly'
)
BEGIN
    ALTER TABLE [Employees] ADD [is_archived] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310103000_AddEmployeeArchiveFieldsOnly'
)
BEGIN
    ALTER TABLE [Employees] ADD [archive_date] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310103000_AddEmployeeArchiveFieldsOnly'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260310103000_AddEmployeeArchiveFieldsOnly', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310160000_AddExpensesTableOnly'
)
BEGIN
    CREATE TABLE [Expenses] (
        [ExpenseId] int NOT NULL IDENTITY,
        [Description] nvarchar(100) NOT NULL,
        [Amount] decimal(18,2) NOT NULL,
        [Category] nvarchar(50) NOT NULL,
        [Department] nvarchar(50) NOT NULL,
        [ExpenseDate] datetime2 NOT NULL,
        [Status] nvarchar(20) NOT NULL,
        [ApprovalNotes] nvarchar(500) NULL,
        [RequestedBy] nvarchar(100) NULL,
        [ApprovedBy] nvarchar(100) NULL,
        [ApprovedAt] datetime2 NULL,
        [ApprovedByUserId] nvarchar(450) NULL,
        [CreatedAt] datetime2 NOT NULL,
        [CompletedAt] datetime2 NULL,
        [CompletedBy] nvarchar(100) NULL,
        [IsArchived] bit NOT NULL,
        [ArchivedAt] datetime2 NULL,
        [ArchivedBy] nvarchar(100) NULL,
        CONSTRAINT [PK_Expenses] PRIMARY KEY ([ExpenseId]),
        CONSTRAINT [FK_Expenses_AspNetUsers_ApprovedByUserId] FOREIGN KEY ([ApprovedByUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE SET NULL
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310160000_AddExpensesTableOnly'
)
BEGIN
    CREATE INDEX [IX_Expenses_ApprovedByUserId] ON [Expenses] ([ApprovedByUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260310160000_AddExpensesTableOnly'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260310160000_AddExpensesTableOnly', N'8.0.24');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260320_AddPerformanceMonitoringFields'
)
BEGIN
    ALTER TABLE [PerformanceRecords] ADD [tasks_completed] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260320_AddPerformanceMonitoringFields'
)
BEGIN
    ALTER TABLE [PerformanceRecords] ADD [tasks_pending] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260320_AddPerformanceMonitoringFields'
)
BEGIN
    ALTER TABLE [PerformanceRecords] ADD [performance_rating] int NOT NULL DEFAULT 3;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260320_AddPerformanceMonitoringFields'
)
BEGIN
    EXEC(N'ALTER TABLE [PerformanceRecords] ADD CONSTRAINT [CK_PerformanceRating] CHECK ([performance_rating] >= 1 AND [performance_rating] <= 5)');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260320_AddPerformanceMonitoringFields'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260320_AddPerformanceMonitoringFields', N'8.0.24');
END;
GO

COMMIT;
GO

