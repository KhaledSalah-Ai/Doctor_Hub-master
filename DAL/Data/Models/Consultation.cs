using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Models
{
    public class Consultation
    {
        [Key]
        public int ConsultationId { get; set; }

        [Required(ErrorMessage = "يرجى إدخال الاسم الكامل")]
        [Display(Name = "الاسم الكامل")]
        public string PatientName { get; set; }

        [Display(Name = "رقم الهاتف")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "يرجى إدخال رقم الهاتف كاملاً مع كود الدولة")]
        [Display(Name = "رقم الهاتف الدولي")]
        public string? FullPhoneNumber { get; set; }

        [Required(ErrorMessage = "يرجى إدخال تاريخ الميلاد")]
        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "هل أنت عراقي؟")]
        public bool IsIraqi { get; set; } = false;

        [Required]
        [Display(Name = "بلد الولادة")]
        public string BirthCountry { get; set; }

        [Required]
        [Display(Name = "بلد السكن الحالي")]
        public string CurrentCountry { get; set; }

        [Display(Name = "جهة العمل أو الدراسة")]
        public string? WorkOrStudyPlace { get; set; }

        [Display(Name = "الجنس")]
        public string? Gender { get; set; }

        [Display(Name = "الحالة الاجتماعية")]
        public string? MaritalStatus { get; set; }

        [Required(ErrorMessage = "يرجى اختيار نوع الاستشارة")]
        [Display(Name = "نوع الاستشارة")]
        public int MedicalSpecialtyId { get; set; }

        [ForeignKey("MedicalSpecialtyId")]
        public MedicalSpecialty? MedicalSpecialty { get; set; }

        [Display(Name = "رسوم الاستشارة")]
        public decimal ConsultationFee { get; set; }

        [Display(Name = "حالة الدفع")]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        [Display(Name = "تم إرسال الوصل؟")]
        public bool ReceiptSent { get; set; } = false;

        public string? ReceiptToken { get; set; }

        [Display(Name = "تاريخ الحجز")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Display(Name = "حالة الاستشارة")]
        public string Status { get; set; } = "قيد المراجعة"; // قيد المراجعة، مؤكد، مكتمل، ملغي

        [Display(Name = "ملاحظات الإدارة")]
        [StringLength(500)]
        public string? AdminNotes { get; set; }

        [Display(Name = "ما هي الاعراض الطبية؟")]
        [Required(ErrorMessage = "من فضلك أدخل الأعراض الطبية")]
        public string? MedicalSymptoms { get; set; }

        [Display(Name = "الموعد المختار")]
        public int AdvisorAvailabilityId { get; set; }

        [ForeignKey("AdvisorAvailabilityId")]
        public AdvisorAvailability? AdvisorAvailability { get; set; }


        public virtual ICollection<CustomerReview> Reviews { get; set; } = new List<CustomerReview>();
    }

    public enum PaymentStatus
    {
        Pending,
        Paid
    }
}
