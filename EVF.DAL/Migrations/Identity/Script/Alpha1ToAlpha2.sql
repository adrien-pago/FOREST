BEGIN TRANSACTION;
GO

--IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240524222024_RecreateAdminAccount')
--BEGIN
--    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'IdPersonnel', N'LockoutEnabled', N'LockoutEnd', N'Nom', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
--        SET IDENTITY_INSERT [AspNetUsers] ON;
--    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [IdPersonnel], [LockoutEnabled], [LockoutEnd], [Nom], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
--    VALUES (N''075428ed-8c0d-4abf-8284-ff3a5ecc0924'', 0, N''0e222177-ed2d-4cbb-8afa-bafd0ca53d4c'', NULL, CAST(0 AS bit), NULL, CAST(0 AS bit), NULL, NULL, NULL, N''EAVF$2'', N''AQAAAAIAAYagAAAAEAsB5j+SOWTqlOed2/hkC8goVfXnrn9+uRjKFr/xZUh/sLp9OW+4qmig25AHfxvqWw=='', NULL, CAST(0 AS bit), N''7502f24b-6ced-4cfe-b65e-3e22ff777835'', CAST(0 AS bit), N''EAVF$2'')');
--    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'IdPersonnel', N'LockoutEnabled', N'LockoutEnd', N'Nom', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
--        SET IDENTITY_INSERT [AspNetUsers] OFF;
--END;
--GO

--IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240524222024_RecreateAdminAccount')
--BEGIN
--    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
--        SET IDENTITY_INSERT [AspNetUserRoles] ON;
--    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
--    VALUES (N''3'', N''075428ed-8c0d-4abf-8284-ff3a5ecc0924'')');
--    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
--        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
--END;
--GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240524222024_RecreateAdminAccount')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240524222024_RecreateAdminAccount', N'7.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240603095542_CreateVuMAJColumnParametrage')
BEGIN
    ALTER TABLE [Parametrage] ADD [VuMAJ] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240603095542_CreateVuMAJColumnParametrage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240603095542_CreateVuMAJColumnParametrage', N'7.0.15');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240613135010_CreateFormatDateColumnParametrage')
BEGIN
    ALTER TABLE [Parametrage] ADD [FormatDate] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240613135010_CreateFormatDateColumnParametrage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240613135010_CreateFormatDateColumnParametrage', N'7.0.15');
END;
GO

COMMIT;
GO

