using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieTurismMobil.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } // Navigation property for User

        [ForeignKey("Vacation")]
        public int VacationId { get; set; }
        public Vacation Vacation { get; set; } // Navigation property for Vacation

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int NrOfPeople { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Default value: 'Pending'
    }
}
