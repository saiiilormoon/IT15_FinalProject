using CVM_FinalProject.Models.ViewModels;
using System.Text;

namespace CVM_FinalProject.Services
{
    public class ReportExportService
    {
        /// <summary>
        /// Export operational processes report to CSV (Excel compatible)
        /// </summary>
        public byte[] ExportOperationalProcessesToCsv(OperationalProcessesByDepartmentViewModel report)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Operational Processes by Department Report");
            csv.AppendLine($"Generated: {report.GeneratedAt:yyyy-MM-dd HH:mm:ss}");
            csv.AppendLine();
            csv.AppendLine("Summary");
            csv.AppendLine($"Total Processes,{report.TotalProcesses}");
            csv.AppendLine($"Completed,{report.CompletedProcesses}");
            csv.AppendLine($"Pending,{report.PendingProcesses}");
            csv.AppendLine($"Completion Rate,{report.CompletionRate:F2}%");
            csv.AppendLine();
            csv.AppendLine("Department Details");
            csv.AppendLine("Department,Total,Completed,Pending,Approved,Completion %");

            foreach (var dept in report.Departments)
            {
                csv.AppendLine($"\"{dept.DepartmentName}\",{dept.TotalCount},{dept.CompletedCount},{dept.PendingCount},{dept.ApprovedCount},{dept.CompletionPercentage:F2}");
            }

            return Encoding.UTF8.GetBytes(csv.ToString());
        }

        /// <summary>
        /// Export employee performance report to CSV
        /// </summary>
        public byte[] ExportEmployeePerformanceToCsv(EmployeeTaskPerformanceViewModel report)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Employee Task Performance Report");
            csv.AppendLine($"Generated: {report.GeneratedAt:yyyy-MM-dd HH:mm:ss}");
            csv.AppendLine();
            csv.AppendLine("Summary");
            csv.AppendLine($"Total Employees,{report.TotalEmployees}");
            csv.AppendLine($"Total Processes Assigned,{report.TotalProcessesAssigned}");
            csv.AppendLine($"Average Completion Rate,{report.AverageCompletionRate:F2}%");
            csv.AppendLine();
            csv.AppendLine("Employee Details");
            csv.AppendLine("Employee Name,Department,Assigned,Completed,Pending,Completion %,Avg Days");

            foreach (var emp in report.Employees)
            {
                csv.AppendLine($"\"{emp.EmployeeName}\",\"{emp.Department}\",{emp.ProcessesAssigned},{emp.ProcessesCompleted},{emp.ProcessesPending},{emp.CompletionRate:F2},{emp.AverageDaysToComplete}");
            }

            return Encoding.UTF8.GetBytes(csv.ToString());
        }

        /// <summary>
        /// Export status comparison report to CSV
        /// </summary>
        public byte[] ExportStatusComparisonToCsv(ProcessStatusComparisonViewModel report)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Process Status Comparison Report");
            csv.AppendLine($"Generated: {report.GeneratedAt:yyyy-MM-dd HH:mm:ss}");
            csv.AppendLine();
            csv.AppendLine("Summary");
            csv.AppendLine($"Completed,{report.CompletedCount}");
            csv.AppendLine($"Pending,{report.PendingCount}");
            csv.AppendLine($"Approved,{report.ApprovedCount}");
            csv.AppendLine($"Total,{report.TotalProcesses}");
            csv.AppendLine($"Completion Rate,{report.CompletionPercentage:F2}%");
            csv.AppendLine();
            csv.AppendLine("Monthly Trend");
            csv.AppendLine("Month,Completed,Pending,Approved");

            foreach (var month in report.MonthlyData)
            {
                csv.AppendLine($"{month.Month},{month.Completed},{month.Pending},{month.Approved}");
            }

            return Encoding.UTF8.GetBytes(csv.ToString());
        }

        /// <summary>
        /// Export department activity summary to CSV
        /// </summary>
        public byte[] ExportActivitySummaryToCsv(DepartmentActivitySummaryViewModel report)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Department Activity Summary Report");
            csv.AppendLine($"Generated: {report.GeneratedAt:yyyy-MM-dd HH:mm:ss}");
            csv.AppendLine();
            csv.AppendLine("Summary");
            csv.AppendLine($"Total Departments,{report.TotalDepartments}");
            csv.AppendLine($"Total Employees,{report.TotalEmployees}");
            csv.AppendLine($"Total Processes,{report.TotalProcesses}");
            csv.AppendLine();
            csv.AppendLine("Department Details");
            csv.AppendLine("Department,Employees,Processes,Completed,Pending,Budget Allocated,Budget Used,Activity Index");

            foreach (var dept in report.Departments)
            {
                csv.AppendLine($"\"{dept.DepartmentName}\",{dept.EmployeeCount},{dept.ProcessCount},{dept.CompletedCount},{dept.PendingCount},{dept.BudgetAllocated:F2},{dept.BudgetUsed:F2},{dept.ActivityIndex:F2}");
            }

            return Encoding.UTF8.GetBytes(csv.ToString());
        }

        /// <summary>
        /// Export all reports as HTML (can be printed to PDF)
        /// </summary>
        public byte[] ExportAllReportsAsHtml(ReportDashboardViewModel dashboard)
        {
            var html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset=\"utf-8\">");
            html.AppendLine("<title>Management Information System - Complete Report</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: Arial, sans-serif; margin: 20px; background: #f5f5f5; }");
            html.AppendLine(".report-section { background: white; padding: 20px; margin-bottom: 20px; border-radius: 8px; page-break-inside: avoid; }");
            html.AppendLine("h1 { color: #1e3c72; border-bottom: 3px solid #2a5298; padding-bottom: 10px; }");
            html.AppendLine("h2 { color: #2a5298; margin-top: 20px; }");
            html.AppendLine("table { width: 100%; border-collapse: collapse; margin: 15px 0; }");
            html.AppendLine("th, td { border: 1px solid #ddd; padding: 12px; text-align: left; }");
            html.AppendLine("th { background-color: #f2f2f2; font-weight: bold; }");
            html.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
            html.AppendLine(".summary { display: grid; grid-template-columns: repeat(4, 1fr); gap: 15px; margin: 20px 0; }");
            html.AppendLine(".summary-card { background: linear-gradient(135deg, #1e3c72, #2a5298); color: white; padding: 15px; border-radius: 8px; }");
            html.AppendLine(".summary-card h3 { margin: 0; font-size: 24px; }");
            html.AppendLine(".summary-card p { margin: 5px 0 0 0; opacity: 0.9; }");
            html.AppendLine(".metric-value { font-size: 28px; font-weight: bold; color: white; }");
            html.AppendLine("@media print { .summary { grid-template-columns: repeat(2, 1fr); } }");
            html.AppendLine("</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");

            html.AppendLine("<h1>?? Management Information System - Complete Report</h1>");
            html.AppendLine($"<p><strong>Generated:</strong> {DateTime.UtcNow:dddd, MMMM dd, yyyy HH:mm:ss}</p>");

            // Overall Metrics
            html.AppendLine("<div class=\"report-section\">");
            html.AppendLine("<h2>Overall Metrics</h2>");
            html.AppendLine("<div class=\"summary\">");
            html.AppendLine($"<div class=\"summary-card\"><h3>Total Processes</h3><p class=\"metric-value\">{dashboard.TotalProcesses}</p></div>");
            html.AppendLine($"<div class=\"summary-card\"><h3>Completed</h3><p class=\"metric-value\">{dashboard.CompletedProcesses}</p></div>");
            html.AppendLine($"<div class=\"summary-card\"><h3>Pending</h3><p class=\"metric-value\">{dashboard.PendingProcesses}</p></div>");
            html.AppendLine($"<div class=\"summary-card\"><h3>Completion Rate</h3><p class=\"metric-value\">{dashboard.OverallCompletionRate:F1}%</p></div>");
            html.AppendLine("</div>");
            html.AppendLine("</div>");

            // Operational Processes by Department
            html.AppendLine("<div class=\"report-section\">");
            html.AppendLine("<h2>Operational Processes by Department</h2>");
            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Department</th><th>Total</th><th>Completed</th><th>Pending</th><th>Approved</th><th>Completion %</th></tr>");
            foreach (var dept in dashboard.ProcessesByDepartment.Departments)
            {
                html.AppendLine($"<tr><td>{dept.DepartmentName}</td><td>{dept.TotalCount}</td><td>{dept.CompletedCount}</td><td>{dept.PendingCount}</td><td>{dept.ApprovedCount}</td><td>{dept.CompletionPercentage:F2}%</td></tr>");
            }
            html.AppendLine("</table>");
            html.AppendLine("</div>");

            // Employee Performance
            html.AppendLine("<div class=\"report-section\">");
            html.AppendLine("<h2>Top Employee Performance</h2>");
            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Employee</th><th>Department</th><th>Assigned</th><th>Completed</th><th>Pending</th><th>Completion %</th><th>Avg Days</th></tr>");
            foreach (var emp in dashboard.EmployeePerformance.Employees.Take(10))
            {
                html.AppendLine($"<tr><td>{emp.EmployeeName}</td><td>{emp.Department}</td><td>{emp.ProcessesAssigned}</td><td>{emp.ProcessesCompleted}</td><td>{emp.ProcessesPending}</td><td>{emp.CompletionRate:F2}%</td><td>{emp.AverageDaysToComplete}</td></tr>");
            }
            html.AppendLine("</table>");
            html.AppendLine("</div>");

            // Department Activity
            html.AppendLine("<div class=\"report-section\">");
            html.AppendLine("<h2>Department Activity Summary</h2>");
            html.AppendLine("<table>");
            html.AppendLine("<tr><th>Department</th><th>Employees</th><th>Processes</th><th>Completed</th><th>Pending</th><th>Budget Used</th><th>Activity Index</th></tr>");
            foreach (var dept in dashboard.ActivitySummary.Departments)
            {
                html.AppendLine($"<tr><td>{dept.DepartmentName}</td><td>{dept.EmployeeCount}</td><td>{dept.ProcessCount}</td><td>{dept.CompletedCount}</td><td>{dept.PendingCount}</td><td>${dept.BudgetUsed:F2}</td><td>{dept.ActivityIndex:F2}</td></tr>");
            }
            html.AppendLine("</table>");
            html.AppendLine("</div>");

            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return Encoding.UTF8.GetBytes(html.ToString());
        }
    }
}
