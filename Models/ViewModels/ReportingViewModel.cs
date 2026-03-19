using System;
using System.Collections.Generic;

namespace CVM_FinalProject.Models.ViewModels
{
    /// <summary>
    /// Base view model for all reports
    /// </summary>
    public class BaseReportViewModel
    {
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        public string ReportTitle { get; set; } = string.Empty;
        public string GeneratedBy { get; set; } = string.Empty;
    }

    /// <summary>
    /// Report for operational processes by department
    /// </summary>
    public class OperationalProcessesByDepartmentViewModel : BaseReportViewModel
    {
        public List<DepartmentProcessData> Departments { get; set; } = new();
        public int TotalProcesses { get; set; }
        public int CompletedProcesses { get; set; }
        public int PendingProcesses { get; set; }
        public decimal CompletionRate { get; set; }

        public OperationalProcessesByDepartmentViewModel()
        {
            ReportTitle = "Operational Processes by Department";
        }
    }

    public class DepartmentProcessData
    {
        public string DepartmentName { get; set; } = string.Empty;
        public int TotalCount { get; set; }
        public int CompletedCount { get; set; }
        public int PendingCount { get; set; }
        public int ApprovedCount { get; set; }
        public decimal CompletionPercentage { get; set; }
    }

    /// <summary>
    /// Report for employee task performance
    /// </summary>
    public class EmployeeTaskPerformanceViewModel : BaseReportViewModel
    {
        public List<EmployeePerformanceData> Employees { get; set; } = new();
        public int TotalEmployees { get; set; }
        public int TotalProcessesAssigned { get; set; }
        public decimal AverageCompletionRate { get; set; }

        public EmployeeTaskPerformanceViewModel()
        {
            ReportTitle = "Employee Task Performance";
        }
    }

    public class EmployeePerformanceData
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int ProcessesAssigned { get; set; }
        public int ProcessesCompleted { get; set; }
        public int ProcessesPending { get; set; }
        public decimal CompletionRate { get; set; }
        public int AverageDaysToComplete { get; set; }
    }

    /// <summary>
    /// Report comparing completed vs pending processes
    /// </summary>
    public class ProcessStatusComparisonViewModel : BaseReportViewModel
    {
        public int CompletedCount { get; set; }
        public int PendingCount { get; set; }
        public int ApprovedCount { get; set; }
        public int TotalProcesses { get; set; }
        public List<MonthlyProcessData> MonthlyData { get; set; } = new();
        public decimal CompletionPercentage { get; set; }

        public ProcessStatusComparisonViewModel()
        {
            ReportTitle = "Completed vs Pending Processes";
        }
    }

    public class MonthlyProcessData
    {
        public string Month { get; set; } = string.Empty;
        public int Completed { get; set; }
        public int Pending { get; set; }
        public int Approved { get; set; }
    }

    /// <summary>
    /// Report for department activity summary
    /// </summary>
    public class DepartmentActivitySummaryViewModel : BaseReportViewModel
    {
        public List<DepartmentActivityData> Departments { get; set; } = new();
        public int TotalDepartments { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalProcesses { get; set; }

        public DepartmentActivitySummaryViewModel()
        {
            ReportTitle = "Department Activity Summary";
        }
    }

    public class DepartmentActivityData
    {
        public string DepartmentName { get; set; } = string.Empty;
        public int EmployeeCount { get; set; }
        public int ProcessCount { get; set; }
        public int CompletedCount { get; set; }
        public int PendingCount { get; set; }
        public decimal BudgetAllocated { get; set; }
        public decimal BudgetUsed { get; set; }
        public decimal ActivityIndex { get; set; } // Metric for activity level
    }

    /// <summary>
    /// Dashboard containing all report summaries
    /// </summary>
    public class ReportDashboardViewModel
    {
        public OperationalProcessesByDepartmentViewModel ProcessesByDepartment { get; set; } = new();
        public EmployeeTaskPerformanceViewModel EmployeePerformance { get; set; } = new();
        public ProcessStatusComparisonViewModel StatusComparison { get; set; } = new();
        public DepartmentActivitySummaryViewModel ActivitySummary { get; set; } = new();
        
        // Overall metrics
        public int TotalProcesses { get; set; }
        public int CompletedProcesses { get; set; }
        public int PendingProcesses { get; set; }
        public decimal OverallCompletionRate { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalDepartments { get; set; }
    }
}
