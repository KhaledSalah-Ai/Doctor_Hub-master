using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DAL.Data.Models
{
    public class MedicalSpecialty
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "يرجى إدخال اسم التخصص")]
        [Display(Name = "اسم التخصص")]
        public string Name { get; set; }

        [Display(Name = "وصف التخصص")]
        public string? Description { get; set; }

        [Display(Name = "سعر الاستشارة بالدولار")]
        [Range(0, double.MaxValue, ErrorMessage = "السعر يجب أن يكون رقم موجب")]
        public decimal? PriceUSD { get; set; }

        [Display(Name = "سعر الاستشارة بالدينار العراقي")]
        [Range(0, double.MaxValue, ErrorMessage = "السعر يجب أن يكون رقم موجب")]
        public decimal? PriceIQD { get; set; }

        [Display(Name = "رمز الأيقونة (اختياري)")]
        public string? IconClass { get; set; }

        public bool IsVisibleToPatient { get; set; } = false;

        [ValidateNever]  // عشان الـValidation ما يقفش عندها
        public Advisor Advisor { get; set; }

        [ValidateNever]
        public ICollection<Consultation>? Consultations { get; set; }

        [ValidateNever]
        public ICollection<DoctorSpecialty>? DoctorSpecialties { get; set; }
    }
}
