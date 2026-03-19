-- Remove bad migration from history
DELETE FROM [__EFMigrationsHistory] 
WHERE [MigrationId] = '20260310090951_AddDepartmentArchiveColumns';

PRINT 'Bad migration removed from history'
