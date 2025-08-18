using DAL.Data.Models;
using DAL.Data.Repositories.ConsultationRepo;
using DAL.Data.Repositories.CoursesRepo;
using DAL.Data.Repositories.DoctorRequest;
using DAL.Data.Repositories.MedicalRepo;
using DAL.Data.Repositories.PartnershipRepo;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;
using MyClinc.Services;
using Microsoft.EntityFrameworkCore;
using MyClinc.ViewModels;

namespace MyClinc.Controllers
{
    public class AdvisorController : Controller
    {
        private readonly IDoctorJoinRequestRepo _doctorRepo;
        private readonly IMedicalSpecialtyRepository _specialtyRepo;
        private readonly IConsultationRepository _consultationRepo;
        private readonly IPartnershipRepository _partnershipRepo;
        private readonly ICourseRepository _courseRepository;
        private readonly IPdfService _pdfService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ClincDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly Dictionary<string, string> _advisorCredentials = new Dictionary<string, string>
        {
            { "doctor.cardiology@example.com", "CardioPass123" },
            { "doctor.dermatology@example.com", "DermaPass123" },
            { "doctor.neurology@example.com", "NeuroPass123" }
        };

        public AdvisorController(ClincDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: /Advisor/Login
        [HttpGet]
        public IActionResult Login()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("AdvisorEmail") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        // POST: /Advisor/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdvisorLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_advisorCredentials.ContainsKey(model.Email))
                {
                    if (_advisorCredentials[model.Email] == model.Password)
                    {
                        var advisor = await _dbContext.Advisors.FirstOrDefaultAsync(a => a.Email == model.Email);
                        if (advisor != null)
                        {
                            _httpContextAccessor.HttpContext.Session.SetString("AdvisorEmail", advisor.Email);
                            _httpContextAccessor.HttpContext.Session.SetInt32("AdvisorId", advisor.AdvisorId);

                            return RedirectToAction("Dashboard");
                        }
                    }
                }

                ModelState.AddModelError(string.Empty, "البريد الإلكتروني أو كلمة المرور غير صحيحة.");
            }
            return View(model);
        }

        // POST: /Advisor/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: /Advisor/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var advisorEmail = _httpContextAccessor.HttpContext.Session.GetString("AdvisorEmail");
            if (string.IsNullOrEmpty(advisorEmail))
            {
                return RedirectToAction("Login");
            }

            var advisor = await _dbContext.Advisors
                .Include(a => a.Availabilities)
                .FirstOrDefaultAsync(a => a.Email == advisorEmail);

            if (advisor == null)
            {
                return RedirectToAction("Login");
            }

            return View(advisor); 
        }
        [HttpGet]
        public IActionResult AddAvailability()
        {
            if (_httpContextAccessor.HttpContext.Session.GetInt32("AdvisorId") == null)
            {
                return RedirectToAction("Login");
            }
            return View(new AdvisorAvailability());
        }

        // POST: Advisor/AddAvailability
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAvailability(AdvisorAvailability availability)
        {
            var advisorId = _httpContextAccessor.HttpContext.Session.GetInt32("AdvisorId");
            if (advisorId == null)
            {
                return RedirectToAction("Login");
            }

            availability.AdvisorId = advisorId.Value;

            availability.Advisor = null;

            if (ModelState.IsValid)
            {
                if (availability.Date.Date < DateTime.Today.Date)
                {
                    ModelState.AddModelError("Date", "لا يمكن إضافة موعد في تاريخ سابق.");
                    return View(availability);
                }

                _dbContext.advisorAvailabilities.Add(availability);
                await _dbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "تمت إضافة الموعد بنجاح!";
                return RedirectToAction("Dashboard");
            }

            return View(availability);
        }


        // GET: EditAvailability
        [HttpGet]
        public async Task<IActionResult> EditAvailability(int id)
        {
            

            var Av = _dbContext.advisorAvailabilities.FirstOrDefault(a => a.AvailabilityId == id);
            if (Av == null)
            {
                return NotFound();
            }

            return View(Av);
        }

        // POST: EditAvailability
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAvailability(AdvisorAvailability availability)
        {
            if (!ModelState.IsValid)
            {
                return View(availability);
            }

            var Av = await _dbContext.advisorAvailabilities
                .FirstOrDefaultAsync(a => a.AvailabilityId == availability.AvailabilityId);

            if (Av == null)
            {
                return NotFound();
            }

            Av.Date = availability.Date;
            Av.StartTime = availability.StartTime;
            Av.DurationMinutes = availability.DurationMinutes;

            _dbContext.advisorAvailabilities.Update(Av);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Dashboard");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteAvailability(int id)
        {
            var availability = await _dbContext.advisorAvailabilities
                .FirstOrDefaultAsync(a => a.AvailabilityId == id);

            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAvailabilityConfirmed(int availabilityId)
        {
            // التأكد من وجود الـ Advisor في الـ Session
            var advisorId = _httpContextAccessor.HttpContext.Session.GetInt32("AdvisorId");
            if (!advisorId.HasValue)
            {
                return RedirectToAction("Login");
            }

            // البحث عن الموعد الخاص بالمستشار الحالي
            var availability = await _dbContext.advisorAvailabilities
                .FirstOrDefaultAsync(a => a.AvailabilityId == availabilityId && a.AdvisorId == advisorId.Value);

            if (availability == null)
            {
                TempData["ErrorMessage"] = "لم يتم العثور على الموعد أو ليس لديك صلاحية لحذفه.";
                return RedirectToAction("Dashboard");
            }

            // التحقق من إذا كان الموعد محجوز بالفعل
            if (availability.IsBooked)
            {
                TempData["ErrorMessage"] = "لا يمكن حذف موعد محجوز بالفعل.";
                return RedirectToAction("Dashboard");
            }

            // حذف الموعد وحفظ التغييرات
            _dbContext.advisorAvailabilities.Remove(availability);
            await _dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "تم حذف الموعد بنجاح.";
            return RedirectToAction("Dashboard");
        }


        // GET: /Advisor/MyConsultations
        [HttpGet]
        public async Task<IActionResult> MyConsultations()
        {
            var advisorId = _httpContextAccessor.HttpContext.Session.GetInt32("AdvisorId");
            if (!advisorId.HasValue)
            {
                return RedirectToAction("Login");
            }

            // هنجمع كل الاستشارات المرتبطة بمواعيد هذا الدكتور
            var consultations = await _dbContext.Consultations
                .Include(c => c.MedicalSpecialty)
                .Include(c => c.AdvisorAvailability)
                .Where(c => c.AdvisorAvailability.AdvisorId == advisorId.Value)
                .OrderByDescending(c => c.BookingDate)
                .ToListAsync();

            return View(consultations);
        }


    }
}

