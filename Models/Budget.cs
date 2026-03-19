using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVM_FinalProject.Models
{
    /// <summary>
    /// Represents a budget allocation for a department
    /// </summary>
    public class Budget
    {
        [Key]
        [Column("Budget_ID")]
        public int BudgetId { get; set; }

        [Required]
        [Column("department_ID")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [StringLength(100)]
        public string? BudgetPeriod { get; set; }

        [Column("allocated_amount")]
        public decimal AllocatedAmount { get; set; }

        [Column("used_amount")]
        public decimal UsedAmount { get; set; }

        [Column("remaining_amount")]
        public decimal RemainingAmount { get; set; }

        // Navigation properties
        public virtual Department? Department { get; set; }
    }
}
