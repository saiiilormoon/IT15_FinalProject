using CVM_FinalProject.Models;
using Microsoft.AspNetCore.Identity;

namespace CVM_FinalProject.Data
{
    public static class DbInitializer
    {
        /// <summary>
        /// Initializes the database with required roles for the CVM Centralized Organizational Management Information System.
        /// Target Users: SuperAdmin, Admin, Accountant, HR, Employee, Auditor
        /// </summary>
        public static async Task InitializeRolesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Define the roles based on project requirements
            string[] roles =
            {
                "SuperAdmin",   // Full system access, configures settings, manages all modules
                "Admin",        // Manages user accounts, accesses all modules, monitors performance/budgets
                "Accountant",   // Budget monitoring, operational processing, financial reports
                "HR",           // Employee management, performance monitoring, departmental reports
                "Employee",     // Basic access to view reports and own information
                "Auditor"       // Read-only access to all reports and logs for compliance
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        /// <summary>
        /// Seeds a default SuperAdmin user for initial system setup.
        /// </summary>
        public static async Task SeedSuperAdminAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Check if SuperAdmin already exists
            var superAdminEmail = configuration["SuperAdmin:Email"] ?? "admin@cvm.com";
            var existingAdmin = await userManager.FindByEmailAsync(superAdminEmail);

            if (existingAdmin == null)
            {
                var superAdmin = new ApplicationUser
                {
                    UserName = superAdminEmail,
                    Email = superAdminEmail,
                    FirstName = "System",
                    LastName = "Administrator",
                    EmailConfirmed = true,
                    IsApproved = true,
                    CreatedAt = DateTime.UtcNow
                };

                var password = configuration["SuperAdmin:Password"] ?? "Admin@123";
                var result = await userManager.CreateAsync(superAdmin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
                }
            }
            else
            {
                // Ensure existing SuperAdmin is always approved
                if (!existingAdmin.IsApproved)
                {
                    existingAdmin.IsApproved = true;
                    existingAdmin.EmailConfirmed = true;
                    await userManager.UpdateAsync(existingAdmin);
                }
            }
        }

        /// <summary>
        /// Seeds default users for each role (HR, Accountant, Auditor, Employee) for testing purposes.
        /// </summary>
        public static async Task SeedDefaultUsersAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Define default test users for each role
            var defaultUsers = new List<(string Email, string Password, string FirstName, string LastName, string Role)>
            {
                ("hr@cvm.com", "HR@123456", "Maria", "Santos", "HR"),
                ("accountant@cvm.com", "Accountant@123456", "Juan", "Dela Cruz", "Accountant"),
                ("auditor@cvm.com", "Auditor@123456", "Anna", "Garcia", "Auditor"),
                ("employee@cvm.com", "Employee@123456", "Robert", "Johnson", "Employee")
            };

            foreach (var (email, password, firstName, lastName, role) in defaultUsers)
            {
                var existingUser = await userManager.FindByEmailAsync(email);

                if (existingUser == null)
                {
                    var newUser = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        EmailConfirmed = true,
                        IsApproved = true,
                        CreatedAt = DateTime.UtcNow
                    };

                    var result = await userManager.CreateAsync(newUser, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser, role);
                    }
                }
                else
                {
                    // Ensure user is approved if they exist
                    if (!existingUser.IsApproved)
                    {
                        existingUser.IsApproved = true;
                        existingUser.EmailConfirmed = true;
                        await userManager.UpdateAsync(existingUser);
                    }
                    
                    // Ensure user has the correct role
                    var userRoles = await userManager.GetRolesAsync(existingUser);
                    if (!userRoles.Contains(role))
                    {
                        await userManager.AddToRoleAsync(existingUser, role);
                    }
                }
            }
        }

        /// <summary>
        /// Approves all existing users who don't have IsApproved set (for migration purposes).
        /// Call this once if you have existing users from before the approval system.
        /// </summary>
        public static async Task ApproveExistingUsersAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var unapprovedUsers = userManager.Users.Where(u => !u.IsApproved).ToList();

            foreach (var user in unapprovedUsers)
            {
                var roles = await userManager.GetRolesAsync(user);
                // Auto-approve SuperAdmins and Admins
                if (roles.Contains("SuperAdmin") || roles.Contains("Admin"))
                {
                    user.IsApproved = true;
                    await userManager.UpdateAsync(user);
                }
            }
        }
    }
}   