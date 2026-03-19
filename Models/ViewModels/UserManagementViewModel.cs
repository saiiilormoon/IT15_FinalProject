namespace CVM_FinalProject.Models.ViewModels
{
    public class UserManagementViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}".Trim();
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Employee";
        public bool IsApproved { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        
        // Archive fields
        public bool IsArchived { get; set; }
        public DateTime? ArchivedAt { get; set; }
        public string? ArchivedBy { get; set; }
        
        // Computed status for display
        public string Status
        {
            get
            {
                if (IsArchived) return "Archived";
                if (!IsApproved) return "Pending";
                return "Active";
            }
        }
    }

    public class UserManagementPageViewModel
    {
        public List<UserManagementViewModel> Users { get; set; } = new();
        public List<UserManagementViewModel> ArchivedUsers { get; set; } = new();
        public Dictionary<string, int> RoleCounts { get; set; } = new();
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int PendingUsers { get; set; }
        public int ArchivedUsersCount { get; set; }
        public int NewUsersThisMonth { get; set; }
    }

    public class CreateUserViewModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Employee";
        public bool IsApproved { get; set; } = true;
    }

    public class EditUserViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Employee";
        public bool IsApproved { get; set; }
    }

    public class SystemLogViewModel
    {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string LogLevel { get; set; } = "Info";
    }
}
