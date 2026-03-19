-- Add Archive Columns to Departments Table
-- This script adds the necessary columns for the archive functionality

IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Departments' AND COLUMN_NAME = 'IsArchived'
)
BEGIN
    ALTER TABLE [Departments] ADD [IsArchived] [bit] NOT NULL DEFAULT 0;
    PRINT 'Added IsArchived column to Departments table'
END

IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Departments' AND COLUMN_NAME = 'ArchivedAt'
)
BEGIN
    ALTER TABLE [Departments] ADD [ArchivedAt] [datetime2] NULL;
    PRINT 'Added ArchivedAt column to Departments table'
END

IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Departments' AND COLUMN_NAME = 'ArchiveReason'
)
BEGIN
    ALTER TABLE [Departments] ADD [ArchiveReason] [nvarchar](250) NULL;
    PRINT 'Added ArchiveReason column to Departments table'
END

PRINT 'Department archive columns added successfully!'
