using DAL.Data;
using DAL.Data.Models;
using DAL.Data.Repositories.CoursesRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyClinc.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ClincDbContext _dbContext;

        public CoursesController(
            ClincDbContext dbContext,
            ICourseRepository courseRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _courseRepository = courseRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 4; // ??? ???????? ?? ?? ????
            var allCourses = _courseRepository.GetAll();
            var paginatedCourses = allCourses
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            int totalCourses = allCourses.Count();
            int totalPages = (int)Math.Ceiling(totalCourses / (double)pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedCourses);
        }

        [Authorize]
        public IActionResult Enroll(int id)
        {
            string userId = _userManager.GetUserId(User);

            var existingRequest = _dbContext.CoursePurchases
                .FirstOrDefault(r => r.CourseId == id && r.UserId == userId);

            if (existingRequest != null)
            {
                if (existingRequest.paymentStatuse == PaymentStatuse.Pending)
                {
                    TempData["Message"] = "لقد قمت مسبقًا بطلب شراء هذا الكورس، برجاء انتظار الموافقة.";
                }
                else if (existingRequest.paymentStatuse == PaymentStatuse.Approved)
                {
                    TempData["Message"] = "لقد تم شراء هذا الكورس بالفعل، يمكنك البدء في التعلم مباشرة.";
                }
                else
                {
                    TempData["Message"] = "تم رفض طلبك السابق على هذا الكورس. يمكنك المحاولة مرة أخرى لاحقًا.";
                }
                return RedirectToAction("Index");
            }

            var request = new CoursePurchaseRequest
            {
                CourseId = id,
                UserId = userId,
                CreatedAt = DateTime.Now,
                IsApproved = false,
                paymentStatuse = PaymentStatuse.Pending
            };

            _dbContext.CoursePurchases.Add(request);
            _dbContext.SaveChanges();

            var course = _dbContext.Courses.FirstOrDefault(c => c.Id == id);
            string message = $"مرحبا {User.Identity.Name}، لقد قمت بطلب الكورس: {course?.Title} بسعر {course?.Price} دولار.";

            string encodedMessage = Uri.EscapeDataString(message);

            string whatsappNumber = "201011845887"; // رقم الواتساب من غير +
            string whatsappUrl = $"https://wa.me/{whatsappNumber}?text={encodedMessage}";

            return Redirect(whatsappUrl);
        }


        [Authorize]
        public IActionResult MyCourses()
        {
            string userId = _userManager.GetUserId(User);

            var courses = _dbContext.CoursePurchases
                .Where(r => r.UserId == userId && r.IsApproved)
                .Include(r => r.Course)
                .Select(r => r.Course)
                .ToList();

            return View(courses);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Course course = _dbContext.Courses
                .Include(c => c.Chapters)
                .FirstOrDefault(c => c.Id == id);

            return View(course);
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyDetails(int id)
        {
            Course course = _dbContext.Courses
                .Include(v => v.Videos)
                .Include(c => c.Chapters)
                .FirstOrDefault(c => c.Id == id);

            return View(course);
        }
    }
}
