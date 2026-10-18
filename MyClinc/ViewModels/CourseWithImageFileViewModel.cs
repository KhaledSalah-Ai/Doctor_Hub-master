using System.ComponentModel.DataAnnotations;
using DAL.Data.Models;

namespace MyClinc.ViewModels
{
    public class CourseWithImageFileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان الكورس مطلوب")]
        [Display(Name = "عنوان الكورس")]
        public string Title { get; set; }

        [Required(ErrorMessage = "الوصف المختصر مطلوب")]
        [Display(Name = "وصف مختصر")]
        public string ShortDescription { get; set; }

        [Display(Name = "الفئة المستهدفة")]
        public string TargetAudience { get; set; }

        [Display(Name = "فيديو تعريفي")]
        public IFormFile TeaserVideoFile { get; set; }

        [Display(Name = "الفوائد")]
        public string Benefits { get; set; }

        [Required(ErrorMessage = "السعر مطلوب")]
        [Range(0, double.MaxValue, ErrorMessage = "السعر يجب أن يكون أكبر من أو يساوي صفر")]
        [Display(Name = "السعر")]
        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "صورة الكورس مطلوبة")]
        [Display(Name = "صورة الكورس")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "عنوان الفيديو")]
        public string VideoTitle { get; set; }

        [Display(Name = "رابط Google Drive")]
        [Url(ErrorMessage = "الرجاء إدخال رابط صحيح")]
        public string GoogleDriveLink { get; set; }

        public ICollection<CourseChapter>? Chapters { get; set; } = new List<CourseChapter>();
    }
}