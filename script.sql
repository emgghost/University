BEGIN TRANSACTION;
GO

ALTER TABLE [InvoiceBodies] ADD [Pspd] decimal(18,2) NULL;
GO

UPDATE [UserConfigurationKeys] SET [CreatedAt] = '2023-12-26T23:52:22.2001314+03:30'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [UserConfigurationKeys] SET [CreatedAt] = '2023-12-26T23:52:22.2001335+03:30'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-26T23:52:22.2001907+03:30'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-26T23:52:22.2001925+03:30'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-26T23:52:22.2001930+03:30'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-26T23:52:22.2001934+03:30'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-26T23:52:22.2001938+03:30'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231227091845_AddPspd', N'6.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Users] ADD [UserGroupId] int NULL;
GO

CREATE TABLE [UserGroups] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    [Description] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_UserGroups] PRIMARY KEY ([Id])
);
GO

UPDATE [UserConfigurationKeys] SET [CreatedAt] = '2023-12-30T18:37:58.5834265+03:30'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [UserConfigurationKeys] SET [CreatedAt] = '2023-12-30T18:37:58.5834284+03:30'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'DeletedAt', N'Description', N'IsActive', N'IsDeleted', N'ModifiedAt', N'Name') AND [object_id] = OBJECT_ID(N'[UserGroups]'))
    SET IDENTITY_INSERT [UserGroups] ON;
INSERT INTO [UserGroups] ([Id], [CreatedAt], [DeletedAt], [Description], [IsActive], [IsDeleted], [ModifiedAt], [Name])
VALUES (1, '2023-12-30T18:37:58.5834609+03:30', NULL, NULL, CAST(1 AS bit), CAST(0 AS bit), NULL, N'Administrator'),
(2, '2023-12-30T18:37:58.5834651+03:30', NULL, NULL, CAST(1 AS bit), CAST(0 AS bit), NULL, N'Customer');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'DeletedAt', N'Description', N'IsActive', N'IsDeleted', N'ModifiedAt', N'Name') AND [object_id] = OBJECT_ID(N'[UserGroups]'))
    SET IDENTITY_INSERT [UserGroups] OFF;
GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T18:37:58.5834755+03:30'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T18:37:58.5834783+03:30'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T18:37:58.5834785+03:30'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T18:37:58.5834786+03:30'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T18:37:58.5834788+03:30'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'DeletedAt', N'Description', N'IsActive', N'IsDeleted', N'ModifiedAt', N'Title') AND [object_id] = OBJECT_ID(N'[WebPages]'))
    SET IDENTITY_INSERT [WebPages] ON;
INSERT INTO [WebPages] ([Id], [CreatedAt], [DeletedAt], [Description], [IsActive], [IsDeleted], [ModifiedAt], [Title])
VALUES (6, '2023-12-30T18:37:58.5834792+03:30', NULL, NULL, CAST(1 AS bit), CAST(0 AS bit), NULL, N'Administrator');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'DeletedAt', N'Description', N'IsActive', N'IsDeleted', N'ModifiedAt', N'Title') AND [object_id] = OBJECT_ID(N'[WebPages]'))
    SET IDENTITY_INSERT [WebPages] OFF;
GO

CREATE INDEX [IX_Users_UserGroupId] ON [Users] ([UserGroupId]);
GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_UserGroups_UserGroupId] FOREIGN KEY ([UserGroupId]) REFERENCES [UserGroups] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231230150759_AddUserGroup', N'6.0.20');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [UserConfigurationKeys] SET [CreatedAt] = '2023-12-30T19:31:23.6586454+03:30'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [UserConfigurationKeys] SET [CreatedAt] = '2023-12-30T19:31:23.6586476+03:30'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [UserGroups] SET [CreatedAt] = '2023-12-30T19:31:23.6586879+03:30'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [UserGroups] SET [CreatedAt] = '2023-12-30T19:31:23.6586928+03:30'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T19:31:23.6587029+03:30'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T19:31:23.6587056+03:30'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T19:31:23.6587058+03:30'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T19:31:23.6587059+03:30'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T19:31:23.6587060+03:30'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [WebPages] SET [CreatedAt] = '2023-12-30T19:31:23.6587066+03:30'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231230160124_AddUserGroup2', N'6.0.20');
GO

COMMIT;
GO

