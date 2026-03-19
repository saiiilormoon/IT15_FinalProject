using System.ComponentModel.DataAnnotations;

namespace CVM_FinalProject.Models.ViewModels
{
    /// <summary>
    /// ViewModel for employee performance monitoring
    /// </summary>
    public class EmployeePerformanceMonitorViewModel
    {
        public string EmployeeId { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int TasksCompleted { get; set; }
        public int TasksPending { get; set; }
        public int PerformanceRating { get; set; } // 1-5 scale
        public double ProductivityScore { get; set; } // Calculated score
        public string PerformanceStatus { get; set; } = string.Empty; // Excellent, Good, Average, Below Average
        public DateTime LastEvaluationDate { get; set; }
        public string LastEvaluationPeriod { get; set; } = string.Empty;
        public int TotalTasksAssigned { get; set; }
        public double TaskCompletionRate { get; set; } // Percentage
        public List<string> RecentRemarks { get; set; } = new();
    }

    /// <summary>
    /// ViewModel for employee performance statistics
    /// </summary>
    public class EmployeePerformanceStatsViewModel
    {
        public int TotalEmployees { get; set; }
        public int EmployeesEvaluated { get; set; }
        public double AverageProductivityScore { get; set; }
        public double AverageTaskCompletionRate { get; set; }
        public int HighPerformers { get; set; } // Rating 4-5
        public int AveragePerformers { get; set; } // Rating 3
        public int BelowAveragePerformers { get; set; } // Rating 1-2
        public int TotalTasksCompleted { get; set; }
        public int TotalTasksPending { get; set; }
        public double EvaluationCoverage { get; set; } // Percentage
        public List<EmployeePerformanceMonitorViewModel> EmployeePerformances { get; set; } = new();
        public List<DepartmentPerformanceAggregateViewModel> DepartmentPerformances { get; set; } = new();
    }

    /// <summary>
    /// ViewModel for department performance aggregates
    /// </summary>
    public class DepartmentPerformanceAggregateViewModel
    {
        public string DepartmentName { get; set; } = string.Empty;
        public int EmployeeCount { get; set; }
        public double AverageProductivityScore { get; set; }
        public double AverageTaskCompletionRate { get; set; }
        public int TotalTasksCompleted { get; set; }
        public int TotalTasksPending { get; set; }
        public int HighPerformers { get; set; }
        public int AveragePerformers { get; set; }
        public int BelowAveragePerformers { get; set; }
    }

    /// <summary>
    /// ViewModel for recording employee performance
    /// </summary>
    public class RecordPerformanceViewModel
    {
        [Required]
        public string EmployeeId { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string EvaluationPeriod { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int TasksCompleted { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TasksPending { get; set; }

        [Required]
        [Range(1, 5)]
        public int PerformanceRating { get; set; } = 3;

        [StringLength(500)]
        public string? Remarks { get; set; }
    }

    /// <summary>
    /// ViewModel for performance comparison
    /// </summary>
    public class PerformanceComparisonViewModel
    {
        public string EmployeeName { get; set; } = string.Empty;
        public double CurrentScore { get; set; }
        public double PreviousScore { get; set; }
        public double ScoreChange { get; set; }
        public string Trend { get; set; } = string.Empty; // Improving, Declining, Stable
        public int CurrentRating { get; set; }
        public int PreviousRating { get; set; }
    }

    /// <summary>
    /// ViewModel for employee rating summary
    /// </summary>
    public class EmployeeRatingSummaryViewModel
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public double AverageRating { get; set; }
        public int EvaluationCount { get; set; }
        public int HighestRating { get; set; }
        public int LowestRating { get; set; }
        public double AverageTaskCompletion { get; set; }
    }
}
