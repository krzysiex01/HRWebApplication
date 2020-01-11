IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191123234814_Initial')
BEGIN
    CREATE TABLE [Companies] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Location] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191123234814_Initial')
BEGIN
    CREATE TABLE [JobOffers] (
        [Id] int NOT NULL IDENTITY,
        [CompanyId] int NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Overview] nvarchar(100) NOT NULL,
        [SalaryFrom] int NOT NULL,
        [SalaryTo] int NOT NULL,
        [Currency] int NOT NULL,
        [Location] nvarchar(max) NULL,
        [AddedOn] datetime2 NOT NULL,
        [ValidUntil] datetime2 NULL,
        [Specialization] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_JobOffers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_JobOffers_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191123234814_Initial')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [CompanyId] int NULL,
        [ProviderName] nvarchar(max) NULL,
        [ProviderUserId] nvarchar(max) NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [EmailAddress] nvarchar(max) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191123234814_Initial')
BEGIN
    CREATE TABLE [JobApplications] (
        [Id] int NOT NULL IDENTITY,
        [JobOfferId] int NOT NULL,
        [UserId] int NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [EmailAddress] nvarchar(max) NOT NULL,
        [ContactAgreement] bit NOT NULL,
        [CvUrl] nvarchar(max) NULL,
        [CreatedOn] datetime2 NOT NULL,
        CONSTRAINT [PK_JobApplications] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_JobApplications_JobOffers_JobOfferId] FOREIGN KEY ([JobOfferId]) REFERENCES [JobOffers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_JobApplications_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191123234814_Initial')
BEGIN
    CREATE INDEX [IX_JobApplications_JobOfferId] ON [JobApplications] ([JobOfferId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191123234814_Initial')
BEGIN
    CREATE INDEX [IX_JobApplications_UserId] ON [JobApplications] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191123234814_Initial')
BEGIN
    CREATE INDEX [IX_JobOffers_CompanyId] ON [JobOffers] ([CompanyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191123234814_Initial')
BEGIN
    CREATE INDEX [IX_Users_CompanyId] ON [Users] ([CompanyId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191123234814_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191123234814_Initial', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191205234839_userUpdated')
BEGIN
    ALTER TABLE [Users] ADD [City] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191205234839_userUpdated')
BEGIN
    ALTER TABLE [Users] ADD [Country] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191205234839_userUpdated')
BEGIN
    ALTER TABLE [Users] ADD [Role] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191205234839_userUpdated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191205234839_userUpdated', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191207101840_JobApplicationUpdated')
BEGIN
    ALTER TABLE [JobApplications] ADD [ApplicationState] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191207101840_JobApplicationUpdated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191207101840_JobApplicationUpdated', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101193144_InitialDataAdded')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
        SET IDENTITY_INSERT [Companies] ON;
    INSERT INTO [Companies] ([Id], [Description], [Location], [Name])
    VALUES (2, N'DES..', N'Warsaw', N'Apple');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
        SET IDENTITY_INSERT [Companies] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101193144_InitialDataAdded')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    INSERT INTO [Users] ([Id], [City], [CompanyId], [Country], [EmailAddress], [FirstName], [LastName], [ProviderName], [ProviderUserId], [Role])
    VALUES (1, N'Warsaw', NULL, N'Poland', N'krzysiex01@wp.pl', N'Krzysztof', N'Oniszczuk', N'AZURE_AD_B2C', N'f484c79c-dd70-4dab-82bb-fdf4d5687a64', N'Admin');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101193144_InitialDataAdded')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    INSERT INTO [Users] ([Id], [City], [CompanyId], [Country], [EmailAddress], [FirstName], [LastName], [ProviderName], [ProviderUserId], [Role])
    VALUES (1002, N'Warsaw', NULL, N'Poland', N'hrwebapplication.user@wp.pl', N'Andrzej', N'Powała', N'AZURE_AD_B2C', N'd9fa8c96-873b-481d-8194-78ff752f32d6', N'User');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101193144_InitialDataAdded')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    INSERT INTO [Users] ([Id], [City], [CompanyId], [Country], [EmailAddress], [FirstName], [LastName], [ProviderName], [ProviderUserId], [Role])
    VALUES (1003, N'Warsaw', 2, N'Poland', N'hrwebapplication.hruser@wp.pl', N'Jan', N'Kowalski', N'AZURE_AD_B2C', N'0c198acb-ac45-47ac-9b49-46dc37c373b4', N'HRUser');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101193144_InitialDataAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200101193144_InitialDataAdded', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101203735_TestMigration')
BEGIN
    DELETE FROM [Users]
    WHERE [Id] = 1002;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101203735_TestMigration')
BEGIN
    DELETE FROM [Users]
    WHERE [Id] = 1003;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101203735_TestMigration')
BEGIN
    DELETE FROM [Companies]
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101203735_TestMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
        SET IDENTITY_INSERT [Companies] ON;
    INSERT INTO [Companies] ([Id], [Description], [Location], [Name])
    VALUES (1, N'Some desctiption', N'Warsaw', N'Apple');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
        SET IDENTITY_INSERT [Companies] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101203735_TestMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    INSERT INTO [Users] ([Id], [City], [CompanyId], [Country], [EmailAddress], [FirstName], [LastName], [ProviderName], [ProviderUserId], [Role])
    VALUES (2, N'Warsaw', NULL, N'Poland', N'hrwebapplication.user@wp.pl', N'Andrzej', N'Powała', N'AZURE_AD_B2C', N'd9fa8c96-873b-481d-8194-78ff752f32d6', N'User');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101203735_TestMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    INSERT INTO [Users] ([Id], [City], [CompanyId], [Country], [EmailAddress], [FirstName], [LastName], [ProviderName], [ProviderUserId], [Role])
    VALUES (3, N'Warsaw', 1, N'Poland', N'hrwebapplication.hruser@wp.pl', N'Jan', N'Kowalski', N'AZURE_AD_B2C', N'0c198acb-ac45-47ac-9b49-46dc37c373b4', N'HRUser');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'City', N'CompanyId', N'Country', N'EmailAddress', N'FirstName', N'LastName', N'ProviderName', N'ProviderUserId', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200101203735_TestMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200101203735_TestMigration', N'3.0.0');
END;

GO

