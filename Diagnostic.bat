@echo off
REM ========================================
REM CVM Diagnostic Tool
REM ========================================

cls
echo.
echo ========================================
echo   CVM DIAGNOSTIC TOOL
echo ========================================
echo.

REM Check .NET
echo [1] Checking .NET SDK...
dotnet --version
if errorlevel 1 (
    echo   [FAILED] .NET SDK not installed
) else (
    echo   [OK] .NET SDK found
)

echo.
echo [2] Checking SQL Server Connection...
REM Test connection without encryption issues
sqlcmd -S LAPTOP-K5FUDO37\SQLEXPRESS03 -E -Q "SELECT @@VERSION" 2>nul
if errorlevel 1 (
    echo   [FAILED] Cannot connect to SQL Server
    echo   Make sure SQLEXPRESS03 is running
) else (
    echo   [OK] SQL Server is running
)

echo.
echo [3] Checking Project Structure...
cd /d "C:\Users\Admin\source\repos\CVM_FinalProject"
if exist "CVM_FinalProject.csproj" (
    echo   [OK] Project file found
) else (
    echo   [FAILED] Project file not found
)

if exist "appsettings.json" (
    echo   [OK] Configuration file found
) else (
    echo   [FAILED] Configuration file not found
)

echo.
echo [4] Checking Database...
REM Note: This check is informational only
echo   Database: Db_CVM
echo   Server: LAPTOP-K5FUDO37\SQLEXPRESS03
echo.

echo [5] Building Project...
dotnet build -c Release 2>&1 | find /C "error" >nul
if errorlevel 1 (
    echo   [OK] Build succeeded (no errors found)
) else (
    echo   [WARNING] Check build output above for errors
)

echo.
echo ========================================
echo   DIAGNOSTICS COMPLETE
echo ========================================
echo.
echo Next Steps:
echo.
echo Option 1 - Start Application:
echo   Double-click: RunApp.bat
echo.
echo Option 2 - Manual Start:
echo   1. Open Command Prompt
echo   2. Run: cd C:\Users\Admin\source\repos\CVM_FinalProject
echo   3. Run: dotnet run
echo.
echo Option 3 - Using Visual Studio:
echo   1. Open: CVM_FinalProject.sln
echo   2. Press: F5
echo.

pause
