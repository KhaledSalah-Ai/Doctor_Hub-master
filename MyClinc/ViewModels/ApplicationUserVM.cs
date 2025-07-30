using System.ComponentModel.DataAnnotations;

namespace MyClinc.ViewModels
{
    public class ApplicationUserVM
    {
        [MaxLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "رقم الهاتف يجب أن يحتوي على 11 رقمًا")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
