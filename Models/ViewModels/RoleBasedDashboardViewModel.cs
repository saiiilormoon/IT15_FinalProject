namespace CVM_FinalProject.Models.ViewModels
{
    /// <summary>
    /// Dashboard view model that provides role-specific data visibility
    /// </summary>
    public class RoleBasedDashboardViewModel
    {
        public string UserRole { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        // KPI Metrics
        public int TotalEmployees { get; set; }
        public int TotalDepartments { get; set; }
        public int ActiveProcesses { get; set; }
        public int CompletedProcesses { get; set; }
        public int PendingRequests { get; set; }

        // Financial Metrics (Accountant View)
        public decimal TotalBudgetAllocated { get; set; }
        public decimal TotalBudgetUsed { get; set; }
        public decimal BudgetUtilizationRate { get; set; }
        public List<DepartmentBudgetSummary> DepartmentBudgets { get; set; } = new();

        // HR Metrics (HR View)
        public int EmployeesPerDepartment { get; set; }
        public decimal AveragePerformanceRating { get; set; }
        public int HighPerformers { get; set; }
        public List<DepartmentPerformanceSummary> DepartmentPerformance { get; set; } = new();

        // Chart Data
        public List<string> ProcessDeptLabels { get; set; } = new();
        public List<int> ProcessDeptCounts { get; set; } = new();

        public List<string> RequestStatusLabels { get; set; } = new();
        public List<int> RequestStatusCounts { get; set; } = new();

        public List<string> MonthlyRequestLabels { get; set; } = new();
        public List<int> MonthlyRequestCounts { get; set; } = new();

        public List<string> ProcessStatusLabels { get; set; } = new();
        public List<int> ProcessStatusCounts { get; set; } = new();

        public List<string> DeptPerformanceLabels { get; set; } = new();
        public List<int> DeptPerformanceCounts { get; set; } = new();

        // Role-based visibility flags
        public Dictionary<string, bool> DataVisibility { get; set; } = new();

        // Audit Metrics (Auditor View)
        public int TotalAuditLogs { get; set; }
        public int CriticalAnomalies { get; set; }
        public DateTime LastAuditDate { get; set; }
        public List<AuditSummary> RecentAuditActivity { get; set; } = new();
    }

    public class DepartmentBudgetSummary
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public decimal AllocatedAmount { get; set; }
        public decimal UsedAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal UtilizationPercentage { get; set; }
    }

    public class DepartmentPerformanceSummary
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int EmployeeCount { get; set; }
        public decimal AverageRating { get; set; }
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
    }

    public class AuditSummary
    {
        public int AuditLogId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string PerformedBy { get; set; } = string.Empty;
        public DateTime PerformedAt { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}
