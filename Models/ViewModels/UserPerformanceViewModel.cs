namespace CVM_FinalProject.Models.ViewModels
{
    public class UserPerformanceViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Employee";
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class PerformancePageViewModel
    {
        public List<UserPerformanceViewModel> Users { get; set; } = new();
        public Dictionary<string, int> RoleCounts { get; set; } = new();
        public int TotalUsers { get; set; }
        public int ApprovedUsers { get; set; }
        public int PendingUsers { get; set; }
    }
}
