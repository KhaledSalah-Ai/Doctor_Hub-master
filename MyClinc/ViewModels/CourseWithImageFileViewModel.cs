using System.ComponentModel.DataAnnotations;
using DAL.Data.Models;

namespace MyClinc.ViewModels
{
    public class CourseWithImageFileViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string TargetAudience { get; set; }

        [Display(Name = "Upload Teaser Video")]
        public IFormFile TeaserVideoFile { get; set; }
        public string Benefits { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; }
        public string VideoTitle { get; set; }
        public string GoogleDriveLink { get; set; }
        public ICollection<CourseChapter>? Chapters { get; set; } = new List<CourseChapter>();
    }
}
