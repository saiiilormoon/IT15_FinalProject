using CVM_FinalProject.Models;
using CVM_FinalProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CVM_FinalProject.Controllers
{
    [Authorize]
    public class ReportingController : Controller
    {
        private readonly ReportingService _reportingService;
        private readonly ReportExportService _exportService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReportingController(
            ReportingService reportingService,
            ReportExportService exportService,
            UserManager<ApplicationUser> userManager)
        {
            _reportingService = reportingService;
            _exportService = exportService;
            _userManager = userManager;
        }

        /// <summary>
        /// Main reporting dashboard with all reports
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.UserName = user?.FullName ?? "User";
            ViewBag.UserRole = (await _userManager.GetRolesAsync(user!)).FirstOrDefault() ?? "Employee";

            var dashboard = await _reportingService.GetReportDashboardAsync();
            return View(dashboard);
        }

        /// <summary>
        /// Operational processes by department report
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> OperationalProcessesByDepartment()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.UserName = user?.FullName ?? "User";

            var report = await _reportingService.GetOperationalProcessesByDepartmentAsync();
            report.GeneratedBy = user?.FullName ?? "System";
            return View(report);
        }

        /// <summary>
        /// Employee task performance report
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EmployeeTaskPerformance()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.UserName = user?.FullName ?? "User";

            var report = await _reportingService.GetEmployeeTaskPerformanceAsync();
            report.GeneratedBy = user?.FullName ?? "System";
            return View(report);
        }

        /// <summary>
        /// Process status comparison report
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ProcessStatusComparison()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.UserName = user?.FullName ?? "User";

            var report = await _reportingService.GetProcessStatusComparisonAsync();
            report.GeneratedBy = user?.FullName ?? "System";
            return View(report);
        }

        /// <summary>
        /// Department activity summary report
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> DepartmentActivitySummary()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.UserName = user?.FullName ?? "User";

            var report = await _reportingService.GetDepartmentActivitySummaryAsync();
            report.GeneratedBy = user?.FullName ?? "System";
            return View(report);
        }

        /// <summary>
        /// Export operational processes report
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> ExportOperationalProcesses(string format = "csv")
        {
            var report = await _reportingService.GetOperationalProcessesByDepartmentAsync();

            if (format.ToLower() == "csv")
            {
                var csvData = _exportService.ExportOperationalProcessesToCsv(report);
                return File(csvData, "text/csv", $"operational-processes-{DateTime.UtcNow:yyyy-MM-dd}.csv");
            }

            return BadRequest("Unsupported format");
        }

        /// <summary>
        /// Export employee performance report
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> ExportEmployeePerformance(string format = "csv")
        {
            var report = await _reportingService.GetEmployeeTaskPerformanceAsync();

            if (format.ToLower() == "csv")
            {
                var csvData = _exportService.ExportEmployeePerformanceToCsv(report);
                return File(csvData, "text/csv", $"employee-performance-{DateTime.UtcNow:yyyy-MM-dd}.csv");
            }

            return BadRequest("Unsupported format");
        }

        /// <summary>
        /// Export status comparison report
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> ExportStatusComparison(string format = "csv")
        {
            var report = await _reportingService.GetProcessStatusComparisonAsync();

            if (format.ToLower() == "csv")
            {
                var csvData = _exportService.ExportStatusComparisonToCsv(report);
                return File(csvData, "text/csv", $"process-status-{DateTime.UtcNow:yyyy-MM-dd}.csv");
            }

            return BadRequest("Unsupported format");
        }

        /// <summary>
        /// Export activity summary report
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> ExportActivitySummary(string format = "csv")
        {
            var report = await _reportingService.GetDepartmentActivitySummaryAsync();

            if (format.ToLower() == "csv")
            {
                var csvData = _exportService.ExportActivitySummaryToCsv(report);
                return File(csvData, "text/csv", $"activity-summary-{DateTime.UtcNow:yyyy-MM-dd}.csv");
            }

            return BadRequest("Unsupported format");
        }

        /// <summary>
        /// Export all reports as HTML (printable/convertible to PDF)
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> ExportAllReportsAsHtml()
        {
            var dashboard = await _reportingService.GetReportDashboardAsync();
            var htmlData = _exportService.ExportAllReportsAsHtml(dashboard);
            return File(htmlData, "text/html", $"complete-report-{DateTime.UtcNow:yyyy-MM-dd}.html");
        }

        /// <summary>
        /// API endpoint for Chart.js data - Operational processes by department
        /// </summary>
        [HttpGet]
        [Route("api/reports/processes-by-department")]
        public async Task<IActionResult> GetProcessesByDepartmentData()
        {
            var report = await _reportingService.GetOperationalProcessesByDepartmentAsync();

            var chartData = new
            {
                labels = report.Departments.Select(d => d.DepartmentName).ToList(),
                datasets = new object[]
                {
                    new
                    {
                        label = "Completed",
                        data = report.Departments.Select(d => d.CompletedCount).ToList(),
                        backgroundColor = "rgba(39, 174, 96, 0.5)",
                        borderColor = "rgba(39, 174, 96, 1)"
                    },
                    new
                    {
                        label = "Pending",
                        data = report.Departments.Select(d => d.PendingCount).ToList(),
                        backgroundColor = "rgba(241, 196, 15, 0.5)",
                        borderColor = "rgba(241, 196, 15, 1)"
                    },
                    new
                    {
                        label = "Approved",
                        data = report.Departments.Select(d => d.ApprovedCount).ToList(),
                        backgroundColor = "rgba(52, 152, 219, 0.5)",
                        borderColor = "rgba(52, 152, 219, 1)"
                    }
                }
            };

            return Json(chartData);
        }

        /// <summary>
        /// API endpoint for Chart.js data - Process status trends
        /// </summary>
        [HttpGet]
        [Route("api/reports/process-trends")]
        public async Task<IActionResult> GetProcessTrendsData()
        {
            var report = await _reportingService.GetProcessStatusComparisonAsync();

            var chartData = new
            {
                labels = report.MonthlyData.Select(m => m.Month).ToList(),
                datasets = new object[]
                {
                    new
                    {
                        label = "Completed",
                        data = report.MonthlyData.Select(m => m.Completed).ToList(),
                        borderColor = "rgba(39, 174, 96, 1)",
                        backgroundColor = "rgba(39, 174, 96, 0.1)",
                        fill = true
                    },
                    new
                    {
                        label = "Pending",
                        data = report.MonthlyData.Select(m => m.Pending).ToList(),
                        borderColor = "rgba(241, 196, 15, 1)",
                        backgroundColor = "rgba(241, 196, 15, 0.1)",
                        fill = true
                    },
                    new
                    {
                        label = "Approved",
                        data = report.MonthlyData.Select(m => m.Approved).ToList(),
                        borderColor = "rgba(52, 152, 219, 1)",
                        backgroundColor = "rgba(52, 152, 219, 0.1)",
                        fill = true
                    }
                }
            };

            return Json(chartData);
        }

        /// <summary>
        /// API endpoint for Chart.js data - Status distribution
        /// </summary>
        [HttpGet]
        [Route("api/reports/status-distribution")]
        public async Task<IActionResult> GetStatusDistributionData()
        {
            var report = await _reportingService.GetProcessStatusComparisonAsync();

            var chartData = new
            {
                labels = new[] { "Completed", "Pending", "Approved" },
                datasets = new object[]
                {
                    new
                    {
                        data = new[] { report.CompletedCount, report.PendingCount, report.ApprovedCount },
                        backgroundColor = new[] 
                        { 
                            "rgba(39, 174, 96, 0.8)",
                            "rgba(241, 196, 15, 0.8)",
                            "rgba(52, 152, 219, 0.8)"
                        },
                        borderColor = new[]
                        {
                            "rgba(39, 174, 96, 1)",
                            "rgba(241, 196, 15, 1)",
                            "rgba(52, 152, 219, 1)"
                        }
                    }
                }
            };

            return Json(chartData);
        }

        /// <summary>
        /// API endpoint for Chart.js data - Employee performance ranking
        /// </summary>
        [HttpGet]
        [Route("api/reports/employee-performance")]
        public async Task<IActionResult> GetEmployeePerformanceData()
        {
            var report = await _reportingService.GetEmployeeTaskPerformanceAsync();
            var topEmployees = report.Employees.Take(10).ToList();

            var chartData = new
            {
                labels = topEmployees.Select(e => e.EmployeeName).ToList(),
                datasets = new object[]
                {
                    new
                    {
                        label = "Completion Rate (%)",
                        data = topEmployees.Select(e => (int)e.CompletionRate).ToList(),
                        backgroundColor = "rgba(52, 152, 219, 0.5)",
                        borderColor = "rgba(52, 152, 219, 1)"
                    }
                }
            };

            return Json(chartData);
        }

        /// <summary>
        /// API endpoint for Chart.js data - Department activity
        /// </summary>
        [HttpGet]
        [Route("api/reports/department-activity")]
        public async Task<IActionResult> GetDepartmentActivityData()
        {
            var report = await _reportingService.GetDepartmentActivitySummaryAsync();

            var chartData = new
            {
                labels = report.Departments.Select(d => d.DepartmentName).ToList(),
                datasets = new object[]
                {
                    new
                    {
                        label = "Activity Index",
                        data = report.Departments.Select(d => (int)d.ActivityIndex).ToList(),
                        backgroundColor = "rgba(155, 89, 182, 0.5)",
                        borderColor = "rgba(155, 89, 182, 1)"
                    }
                }
            };

            return Json(chartData);
        }
    }
}
