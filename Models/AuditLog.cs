using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVM_FinalProject.Models
{
    /// <summary>
    /// Represents an audit log entry for tracking system actions
    /// </summary>
    public class AuditLog
    {
        [Key]
        [Column("Audit_ID")]
        public int AuditId { get; set; }

        [Required]
        [Column("user_ID")]
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;

        [Column("role_ID")]
        [ForeignKey("Role")]
        public int? RoleId { get; set; }

        [Required]
        [StringLength(200)]
        public string Action { get; set; } = string.Empty;

        [Column("assigned_at")]
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        [StringLength(50)]
        public string? IPAddress { get; set; }

        // Navigation properties
        public virtual ApplicationUser? User { get; set; }
        public virtual Role? Role { get; set; }
    }
}
