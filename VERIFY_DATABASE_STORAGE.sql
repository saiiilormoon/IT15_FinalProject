-- SQL Server Script to Verify Employee Performance Records Storage
-- Run this in SQL Server Management Studio (SSMS) to verify data is being stored

-- ============================================================
-- 1. CHECK IF TABLE EXISTS
-- ============================================================
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PerformanceRecords')
    PRINT '? PerformanceRecords table EXISTS'
ELSE
    PRINT '? PerformanceRecords table DOES NOT EXIST - Run migrations'

-- ============================================================
-- 2. VIEW ALL PERFORMANCE RECORDS
-- ============================================================
PRINT ''
PRINT '===== ALL PERFORMANCE RECORDS ====='
SELECT 
    PerformanceId,
    EmployeeId,
    EvaluationPeriod,
    TasksCompleted,
    TasksPending,
    PerformanceRating,
    Remarks,
    RecordedAt
FROM PerformanceRecords
ORDER BY RecordedAt DESC

-- ============================================================
-- 3. COUNT OF RECORDS
-- ============================================================
PRINT ''
PRINT '===== PERFORMANCE RECORDS COUNT ====='
SELECT COUNT(*) as TotalRecords FROM PerformanceRecords

-- ============================================================
-- 4. AVERAGE RATING
-- ============================================================
PRINT ''
PRINT '===== AVERAGE PERFORMANCE RATING ====='
SELECT 
    ROUND(AVG(CAST(PerformanceRating AS FLOAT)), 2) as AverageRating,
    MIN(PerformanceRating) as MinRating,
    MAX(PerformanceRating) as MaxRating
FROM PerformanceRecords

-- ============================================================
-- 5. RATINGS DISTRIBUTION
-- ============================================================
PRINT ''
PRINT '===== RATING DISTRIBUTION ====='
SELECT 
    PerformanceRating,
    COUNT(*) as CountOfRatings,
    CASE 
        WHEN PerformanceRating = 5 THEN 'Excellent'
        WHEN PerformanceRating = 4 THEN 'Good'
        WHEN PerformanceRating = 3 THEN 'Average'
        WHEN PerformanceRating = 2 THEN 'Below Average'
        WHEN PerformanceRating = 1 THEN 'Poor'
    END as RatingLabel
FROM PerformanceRecords
GROUP BY PerformanceRating
ORDER BY PerformanceRating DESC

-- ============================================================
-- 6. RECORDS PER EMPLOYEE
-- ============================================================
PRINT ''
PRINT '===== PERFORMANCE RECORDS PER EMPLOYEE ====='
SELECT 
    EmployeeId,
    COUNT(*) as RecordCount,
    ROUND(AVG(CAST(PerformanceRating AS FLOAT)), 2) as AvgRating,
    MAX(RecordedAt) as LastEvaluation
FROM PerformanceRecords
GROUP BY EmployeeId
ORDER BY RecordCount DESC

-- ============================================================
-- 7. RECORDS BY EVALUATION PERIOD
-- ============================================================
PRINT ''
PRINT '===== RECORDS BY EVALUATION PERIOD ====='
SELECT 
    EvaluationPeriod,
    COUNT(*) as CountInPeriod,
    ROUND(AVG(CAST(PerformanceRating AS FLOAT)), 2) as AvgRatingInPeriod
FROM PerformanceRecords
GROUP BY EvaluationPeriod
ORDER BY EvaluationPeriod DESC

-- ============================================================
-- 8. RECENT RECORDS (LAST 10)
-- ============================================================
PRINT ''
PRINT '===== LAST 10 RECORDED EVALUATIONS ====='
SELECT TOP 10
    PerformanceId,
    EmployeeId,
    EvaluationPeriod,
    PerformanceRating,
    RecordedAt
FROM PerformanceRecords
ORDER BY RecordedAt DESC

-- ============================================================
-- 9. CHECK FOR NULL VALUES
-- ============================================================
PRINT ''
PRINT '===== DATA QUALITY CHECK (NULL VALUES) ====='
SELECT 
    COUNT(*) as TotalRecords,
    SUM(CASE WHEN EmployeeId IS NULL THEN 1 ELSE 0 END) as NullEmployeeIds,
    SUM(CASE WHEN EvaluationPeriod IS NULL THEN 1 ELSE 0 END) as NullPeriods,
    SUM(CASE WHEN PerformanceRating IS NULL THEN 1 ELSE 0 END) as NullRatings,
    SUM(CASE WHEN RecordedAt IS NULL THEN 1 ELSE 0 END) as NullTimestamps
FROM PerformanceRecords

-- ============================================================
-- 10. PERFORMANCE RECORD WITH EMPLOYEE DETAILS
-- ============================================================
PRINT ''
PRINT '===== PERFORMANCE RECORDS WITH EMPLOYEE INFO ====='
SELECT 
    pr.PerformanceId,
    pr.EmployeeId,
    pr.EvaluationPeriod,
    pr.PerformanceRating as Rating,
    pr.TasksCompleted,
    pr.TasksPending,
    pr.RecordedAt,
    pr.Remarks
FROM PerformanceRecords pr
ORDER BY pr.RecordedAt DESC

-- ============================================================
-- 11. VERIFY DATABASE CONNECTIVITY
-- ============================================================
PRINT ''
PRINT '===== DATABASE INFORMATION ====='
SELECT 
    DB_NAME() as CurrentDatabase,
    GETDATE() as CurrentDateTime,
    SUSER_NAME() as CurrentUser,
    @@SERVERNAME as ServerName,
    @@VERSION as SQLVersion

-- ============================================================
-- If all queries return data, your database is working!
-- ============================================================
