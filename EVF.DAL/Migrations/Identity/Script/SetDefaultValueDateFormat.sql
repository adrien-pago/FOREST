BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Parametrage]') AND [c].[name] = N'FormatDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Parametrage] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Parametrage] ADD DEFAULT N'yyyy/MM/dd' FOR [FormatDate];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240716113749_SetDefaultValueToFormatDateColumn', N'7.0.15');
GO

COMMIT;
GO

