using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVM_FinalProject.Models
{
    /// <summary>
    /// Represents an organizational expense that requires tracking and approval
    /// Used for Accountant role to manage expenses
    /// </summary>
    [Table("Expenses")]
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Department { get; set; } = string.Empty;

        [Required]
        public DateTime ExpenseDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        [StringLength(500)]
        public string? ApprovalNotes { get; set; }

        [StringLength(100)]
        public string? RequestedBy { get; set; }

        [StringLength(100)]
        public string? ApprovedBy { get; set; }

        public DateTime? ApprovedAt { get; set; }

        [StringLength(100)]
        public string? ApprovedByUserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Completion tracking
        public DateTime? CompletedAt { get; set; }
        [StringLength(100)]
        public string? CompletedBy { get; set; }

        // Archive tracking
        public bool IsArchived { get; set; } = false;
        public DateTime? ArchivedAt { get; set; }
        [StringLength(100)]
        public string? ArchivedBy { get; set; }

        [ForeignKey("ApprovedByUserId")]
        public virtual ApplicationUser? Approver { get; set; }
    }
}
