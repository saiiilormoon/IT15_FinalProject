using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace CVM_FinalProject.Helpers
{
    /// <summary>
    /// Custom authorization filter for role-based access control
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RoleBasedAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _allowedRoles;

        public RoleBasedAuthorizeAttribute(params string[] roles)
        {
            _allowedRoles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context?.HttpContext?.User == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            var user = context.HttpContext.User;

            // Check if user is authenticated
            if (!user.Identity?.IsAuthenticated ?? false)
            {
                context.Result = new ForbidResult();
                return;
            }

            // If no roles specified, allow all authenticated users
            if (!_allowedRoles.Any())
            {
                return;
            }

            // Check if user has any of the allowed roles
            if (!_allowedRoles.Any(role => user.IsInRole(role)))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }

    /// <summary>
    /// Filter for SuperAdmin-only operations
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SuperAdminOnlyAttribute : RoleBasedAuthorizeAttribute
    {
        public SuperAdminOnlyAttribute() : base("SuperAdmin") { }
    }

    /// <summary>
    /// Filter for Admin-only operations (SuperAdmin + Admin)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminOnlyAttribute : RoleBasedAuthorizeAttribute
    {
        public AdminOnlyAttribute() : base("SuperAdmin", "Admin") { }
    }

    /// <summary>
    /// Filter for financial operations (Accountant + Admin roles)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class FinancialAuthorizeAttribute : RoleBasedAuthorizeAttribute
    {
        public FinancialAuthorizeAttribute() : base("SuperAdmin", "Admin", "Accountant") { }
    }

    /// <summary>
    /// Filter for HR operations
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HRAuthorizeAttribute : RoleBasedAuthorizeAttribute
    {
        public HRAuthorizeAttribute() : base("SuperAdmin", "Admin", "HR") { }
    }

    /// <summary>
    /// Filter for read-only operations (includes Auditor)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ReadOnlyAuthorizeAttribute : RoleBasedAuthorizeAttribute
    {
        public ReadOnlyAuthorizeAttribute()
            : base("SuperAdmin", "Admin", "Accountant", "HR", "Auditor", "Employee") { }
    }
}
