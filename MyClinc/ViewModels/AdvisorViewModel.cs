using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Data.Models; // علشان MedicalSpecialty

namespace MyClinc.ViewModels
{
    public class AdvisorViewModel
    {
        [Key]
        public int AdvisorId { get; set; }

        [Required(ErrorMessage = "يرجى إدخال اسم الدكتور")]
        [Display(Name = "اسم الدكتور")]
        public string Name { get; set; }

        [Required(ErrorMessage = "يرجى إدخال البريد الإلكتروني")]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "يرجى إدخال كلمة المرور")]
        [Display(Name = "كلمة المرور")]
        public string? Password { get; set; }

        [Display(Name = "رقم الهاتف")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "يرجى اختيار التخصص")]
        [Display(Name = "التخصص الطبي")]
        public int MedicalSpecialtyId { get; set; }

        // ليست للتخصصات اللي لسه فاضية (ملهاش دكتور)
        public List<MedicalSpecialty>? AvailableSpecialties { get; set; }
    }
}
