using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CVM_FinalProject.Models;

namespace CVM_FinalProject.Helpers
{
    /// <summary>
    /// Helper class for role-based authorization checks
    /// Implements the RBAC policy guidelines for the CVM MIS system
    /// </summary>
    public class RoleBasedAuthorizationHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleBasedAuthorizationHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Define role hierarchy for cascading permissions
        /// SuperAdmin > Admin > Specialized Roles (Accountant, HR, Auditor) > Employee
        /// </summary>
        public static class RoleHierarchy
        {
            public const string SuperAdmin = "SuperAdmin";
            public const string Admin = "Admin";
            public const string Accountant = "Accountant";
            public const string HR = "HR";
            public const string Auditor = "Auditor";
            public const string Employee = "Employee";

            public static List<string> AllRoles => new()
            {
                SuperAdmin,
                Admin,
                Accountant,
                HR,
                Auditor,
                Employee
            };

            /// <summary>
            /// Check if a role has administrative privileges
            /// </summary>
            public static bool IsAdministrative(string role)
            {
                return role == SuperAdmin || role == Admin;
            }

            /// <summary>
            /// Check if a role can view audit information
            /// </summary>
            public static bool CanViewAudit(string role)
            {
                return role == SuperAdmin || role == Admin || role == Auditor;
            }

            /// <summary>
            /// Check if a role can manage users
            /// </summary>
            public static bool CanManageUsers(string role)
            {
                return role == SuperAdmin || role == Admin;
            }

            /// <summary>
            /// Check if a role can manage budgets
            /// </summary>
            public static bool CanManageBudgets(string role)
            {
                return role == SuperAdmin || role == Admin || role == Accountant;
            }

            /// <summary>
            /// Check if a role can manage HR functions
            /// </summary>
            public static bool CanManageHR(string role)
            {
                return role == SuperAdmin || role == Admin || role == HR;
            }

            /// <summary>
            /// Check if a role can approve requests
            /// </summary>
            public static bool CanApproveRequests(string role)
            {
                return role == SuperAdmin || role == Admin;
            }

            /// <summary>
            /// Check if a role can permanently delete users
            /// Only SuperAdmin can do this
            /// </summary>
            public static bool CanPermanentlyDeleteUsers(string role)
            {
                return role == SuperAdmin;
            }

            /// <summary>
            /// Check if a role can view archived users
            /// Only SuperAdmin can do this
            /// </summary>
            public static bool CanViewArchivedUsers(string role)
            {
                return role == SuperAdmin;
            }

            /// <summary>
            /// Check if a role has read-only access (Auditor)
            /// </summary>
            public static bool IsReadOnlyRole(string role)
            {
                return role == Auditor;
            }
        }

        /// <summary>
        /// Dashboard access control policies
        /// </summary>
        public static class DashboardAccess
        {
            public static bool CanAccessDashboard(string role) => !string.IsNullOrEmpty(role);

            public static bool CanAccessOperations(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Auditor ||
                       role == RoleHierarchy.Employee;
            }

            public static bool CanCreateOperations(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Employee;
            }

            public static bool CanApproveOperations(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Employee;
            }

            public static bool CanCompleteOperations(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Employee;
            }

            public static bool CanAccessDepartments(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Auditor ||
                       role == RoleHierarchy.Employee;
            }

            public static bool CanCreateDepartments(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR;
            }

            public static bool CanAccessEmployees(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Auditor ||
                       role == RoleHierarchy.Employee;
            }

            public static bool CanManageEmployees(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR;
            }

            public static bool CanAccessPerformance(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Auditor;
            }

            public static bool CanRecordPerformance(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR;
            }

            public static bool CanAccessBudget(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Auditor;
            }

            public static bool CanCreateBudget(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant;
            }

            public static bool CanAccessReports(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Auditor ||
                       role == RoleHierarchy.Employee;
            }

            public static bool CanGenerateReports(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR;
            }

            public static bool CanAccessEmployeeRequests(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Auditor ||
                       role == RoleHierarchy.Employee;
            }

            public static bool CanCreateEmployeeRequests(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin ||
                       role == RoleHierarchy.Accountant ||
                       role == RoleHierarchy.HR ||
                       role == RoleHierarchy.Auditor ||
                       role == RoleHierarchy.Employee;
            }

            public static bool CanViewAllRequests(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin;
            }

            public static bool CanApproveRequests(string role)
            {
                return role == RoleHierarchy.SuperAdmin ||
                       role == RoleHierarchy.Admin;
            }
        }

        /// <summary>
        /// Administration panel access control
        /// </summary>
        public static class AdministrationAccess
        {
            public static bool CanAccessAdminPanel(string role)
            {
                return role == RoleHierarchy.SuperAdmin || role == RoleHierarchy.Admin;
            }

            public static bool CanManageUsers(string role)
            {
                return role == RoleHierarchy.SuperAdmin || role == RoleHierarchy.Admin;
            }

            public static bool CanViewPendingApprovals(string role)
            {
                return role == RoleHierarchy.SuperAdmin || role == RoleHierarchy.Admin;
            }

            public static bool CanApprovePendingUsers(string role)
            {
                return role == RoleHierarchy.SuperAdmin || role == RoleHierarchy.Admin;
            }

            public static bool CanViewArchivedUsers(string role)
            {
                return role == RoleHierarchy.SuperAdmin;
            }

            public static bool CanPermanentlyDeleteUsers(string role)
            {
                return role == RoleHierarchy.SuperAdmin;
            }

            public static bool CanRestoreUsers(string role)
            {
                return role == RoleHierarchy.SuperAdmin;
            }

            public static bool CanViewSystemLogs(string role)
            {
                return role == RoleHierarchy.SuperAdmin || role == RoleHierarchy.Admin;
            }
        }

        /// <summary>
        /// Check if user can modify another user's role
        /// </summary>
        public async Task<bool> CanModifyUserRoleAsync(ApplicationUser currentUser, ApplicationUser targetUser)
        {
            var currentRoles = await _userManager.GetRolesAsync(currentUser);
            var targetRoles = await _userManager.GetRolesAsync(targetUser);
            var currentRole = currentRoles.FirstOrDefault();
            var targetRole = targetRoles.FirstOrDefault();

            // SuperAdmin cannot be modified by anyone
            if (targetRole == RoleHierarchy.SuperAdmin && currentRole != RoleHierarchy.SuperAdmin)
            {
                return false;
            }

            // Only SuperAdmin and Admin can modify roles
            if (!RoleHierarchy.IsAdministrative(currentRole))
            {
                return false;
            }

            // Admin cannot modify SuperAdmin
            if (currentRole == RoleHierarchy.Admin && targetRole == RoleHierarchy.SuperAdmin)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get role-specific dashboard data visibility
        /// </summary>
        public static Dictionary<string, bool> GetDashboardVisibility(string role)
        {
            var visibility = new Dictionary<string, bool>
            {
                { "KPICards", true }, // All roles can see KPI cards
                { "Charts", true }, // All roles can see charts
                { "BudgetSummary", true }, // All roles can see budget summary
                { "AllEmployees", role != RoleHierarchy.Employee }, // Employees cannot see all employees count
                { "AllDepartments", role != RoleHierarchy.Employee }, // Employees cannot see all departments count
                { "AllProcesses", true }, // All roles can see all processes
                { "AllBudgets", role != RoleHierarchy.Employee }, // Employees cannot see budgets
                { "AllPerformance", role != RoleHierarchy.Employee }, // Employees cannot see performance
                { "AllRequests", role == RoleHierarchy.SuperAdmin || role == RoleHierarchy.Admin }, // Only admin can see all requests
                { "FinancialMetrics", role == RoleHierarchy.Accountant || role == RoleHierarchy.SuperAdmin || role == RoleHierarchy.Admin }, // Only accountant and admin
                { "HRMetrics", role == RoleHierarchy.HR || role == RoleHierarchy.SuperAdmin || role == RoleHierarchy.Admin }, // Only HR and admin
                { "AuditMetrics", role == RoleHierarchy.Auditor || role == RoleHierarchy.SuperAdmin || role == RoleHierarchy.Admin } // Only auditor and admin
            };

            return visibility;
        }
    }
}
