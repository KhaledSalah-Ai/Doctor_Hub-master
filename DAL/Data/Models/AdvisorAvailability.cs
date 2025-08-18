using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public class AdvisorAvailability
    {
        [Key]
        public int AvailabilityId { get; set; }

        [Required]
        public int AdvisorId { get; set; }
        [ForeignKey("AdvisorId")]
        public Advisor? Advisor { get; set; }

        [Required]
        [Display(Name = "تاريخ الموعد")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "وقت البدء")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "مدة الجلسة بالدقائق")]
        public int DurationMinutes { get; set; }

        public bool IsBooked { get; set; } = false;
    }  
}
