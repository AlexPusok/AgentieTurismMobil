using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BazaDeDate.Models
{
    public class Vacation
    {
        [Key]
        public int VacationId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int DurationDays { get; set; }

        public DateTime? AvailableFrom { get; set; }

        public DateTime? AvailableTo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
