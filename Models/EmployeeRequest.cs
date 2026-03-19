using System.ComponentModel.DataAnnotations;

namespace CVM_FinalProject.Models
{
    /// <summary>
    /// Represents an employee request submitted by employees
    /// Employees can submit requests, but only Admins can approve/complete them
    /// </summary>
    public class EmployeeRequest
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string RequestId { get; set; } = string.Empty; // e.g., "EMP-0001"

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string RequestType { get; set; } = string.Empty; // e.g., "Leave", "Equipment", "Support"

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ApprovedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        // Who submitted the request
        [Required]
        public string SubmittedByUserId { get; set; } = string.Empty;

        [StringLength(200)]
        public string? SubmittedByName { get; set; }

        // Who approved the request (Admin only)
        public string? ApprovedByUserId { get; set; }

        [StringLength(200)]
        public string? ApprovedByName { get; set; }

        // Who completed the request (Admin only)
        public string? CompletedByUserId { get; set; }

        [StringLength(200)]
        public string? CompletedByName { get; set; }

        [StringLength(500)]
        public string? AdminNotes { get; set; }
    }

    /// <summary>
    /// Status enum for employee requests
    /// </summary>
    public enum RequestStatus
    {
        Pending = 0,      // Submitted, waiting for admin review
        Approved = 1,     // Admin approved the request
        Completed = 2     // Admin completed the request
    }
}
