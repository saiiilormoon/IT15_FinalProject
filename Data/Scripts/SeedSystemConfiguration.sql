-- Insert System Configuration Data for CVM Application
-- This script adds default configuration values to the SystemConfigurations table

-- Clear existing data (optional, comment out if you want to preserve existing data)
-- DELETE FROM [SystemConfigurations];

-- Insert Logo Configuration
INSERT INTO [SystemConfigurations] ([ConfigKey], [ConfigValue], [Description], [CreatedAt], [UpdatedAt])
VALUES 
    ('LogoPath', '~/images/logo_MIS.svg', 'Logo path for the application', GETUTCDATE(), GETUTCDATE()),
    ('CompanyName', 'CVM - Centralized Organizational Management', 'Company name displayed in the application', GETUTCDATE(), GETUTCDATE()),
    ('ApplicationTitle', 'CVM - Management Information System', 'Application title shown in browser tab and header', GETUTCDATE(), GETUTCDATE()),
    ('FiscalYear', '2026', 'Current fiscal year for budget calculations', GETUTCDATE(), GETUTCDATE()),
    ('DefaultCurrency', 'PHP', 'Default currency for budget and financial data', GETUTCDATE(), GETUTCDATE()),
    ('MaxUploadSize', '10485760', 'Maximum file upload size in bytes (10 MB)', GETUTCDATE(), GETUTCDATE()),
    ('AuditLogRetentionDays', '365', 'Number of days to retain audit logs', GETUTCDATE(), GETUTCDATE()),
    ('PasswordExpiryDays', '90', 'Number of days before password expires', GETUTCDATE(), GETUTCDATE()),
    ('SessionTimeoutMinutes', '30', 'Session timeout in minutes', GETUTCDATE(), GETUTCDATE()),
    ('EnableEmailNotifications', 'true', 'Enable or disable email notifications', GETUTCDATE(), GETUTCDATE()),
    ('EnableTwoFactorAuth', 'true', 'Enable or disable two-factor authentication', GETUTCDATE(), GETUTCDATE()),
    ('BudgetAlertThreshold', '80', 'Budget usage percentage to trigger alerts', GETUTCDATE(), GETUTCDATE());

-- Verify inserted data
SELECT * FROM [SystemConfigurations];