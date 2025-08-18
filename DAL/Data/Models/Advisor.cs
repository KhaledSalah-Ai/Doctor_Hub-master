using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Data.Models
{
    public class Advisor
    {
        [Key]
        public int AdvisorId { get; set; }

        [Required]
        [Display(Name = "اسم الدكتور")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        public string? Phone { get; set; }

        // الربط مع نوع الاستشارة (One-to-One)
        public int MedicalSpecialtyId { get; set; }

        [ForeignKey("MedicalSpecialtyId")]
        public MedicalSpecialty MedicalSpecialty { get; set; }

        // مواعيد الدكتور
        public ICollection<AdvisorAvailability> Availabilities { get; set; } = new List<AdvisorAvailability>();
    }
}
