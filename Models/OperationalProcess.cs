using System.ComponentModel.DataAnnotations;

namespace CVM_FinalProject.Models
{
    /// <summary>
    /// Represents an operational process in the system.
    /// Processes flow through states: Pending ? Approved ? Completed
    /// </summary>
    public class OperationalProcess
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string ProcessId { get; set; } = string.Empty; // e.g., "OP-001"

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string AssignedTo { get; set; } = string.Empty;

        [Required]
        public ProcessStatus Status { get; set; } = ProcessStatus.Pending;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ApprovedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        /// <summary>
        /// Priority of the process
        /// </summary>
        [Required]
        public PriorityLevel Priority { get; set; } = PriorityLevel.Medium;
    }

    /// <summary>
    /// Status enum for operational processes
    /// NOTE: "Active" is an alias for "Approved" to support both naming styles
    /// </summary>
    public enum ProcessStatus
    {
        Pending = 0,
        Approved = 1,
        Active = Approved,
        Completed = 2
    }

    /// <summary>
    /// Priority levels for operational processes
    /// </summary>
    public enum PriorityLevel
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}

