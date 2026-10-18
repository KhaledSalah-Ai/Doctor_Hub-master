using DAL.Data;
using DAL.Data.Models;
using DAL.Data.Repositories.ConsultationRepo;
using DAL.Data.Repositories.MedicalRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinc.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly IMedicalSpecialtyRepository _specialtyRepo;
        private readonly IConsultationRepository _consultationRepo;
        private readonly ClincDbContext _context;

        public ConsultationController(IMedicalSpecialtyRepository specialtyRepo, IConsultationRepository consultationRepo, ClincDbContext context)
        {
            _specialtyRepo = specialtyRepo;
            _consultationRepo = consultationRepo;
            _context = context;
        }

        // صفحة السؤال الأولى
        public IActionResult BookingQuestion()
        {
            return View();
        }

        // التعامل مع إجابة المستخدم
        [HttpPost]
        public IActionResult BookingQuestion(string answer)
        {
            if (answer == "yes")
            {
                // إذا أجاب بنعم، يذهب لصفحة إدخال الرقم
                return RedirectToAction("CheckPreviousBooking");
            }
            else if (answer == "no")
            {
                return RedirectToAction("Book");
            }

            ViewBag.ErrorMessage = "يرجى اختيار إجابة";
            return View();
        }

        // صفحة فحص الحجز السابق
        public IActionResult CheckPreviousBooking()
        {
            return View();
        }

        // التحقق من الرقم المدخل
        [HttpPost]
        public async Task<IActionResult> CheckPreviousBooking(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                ViewBag.ErrorMessage = "يرجى إدخال رقم الهاتف";
                return View();
            }

            // البحث عن المستخدم بالرقم
            var existingConsultation = await _context.Consultations
                .FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber || c.FullPhoneNumber == phoneNumber);

            if (existingConsultation != null)
            {
                // إذا وُجد الرقم، ننقله لصفحة الحجز مع البيانات المحفوظة
                TempData["ExistingConsultationId"] = existingConsultation.ConsultationId;
                return RedirectToAction("BookWithExistingData");
            }
            else
            {
                // إذا لم يوجد الرقم
                ViewBag.ErrorMessage = "لم نجد حجز سابق بهذا الرقم. سيتم نقلك لتعبئة البيانات الكاملة.";
                ViewBag.ShowFullFormButton = true;
                return View();
            }
        }



        // الانتقال للنموذج الكامل من صفحة فحص الحجز
        public IActionResult GoToFullForm()
        {
            return RedirectToAction("Book");
        }

        // صفحة الحجز مع البيانات الموجودة
        public async Task<IActionResult> BookWithExistingData()
        {
            var consultationId = TempData["ExistingConsultationId"];
            if (consultationId == null)
            {
                return RedirectToAction("BookingQuestion");
            }

            var existingConsultation = await _context.Consultations
                .Include(c => c.MedicalSpecialty)
                .FirstOrDefaultAsync(c => c.ConsultationId == (int)consultationId);

            if (existingConsultation == null)
            {
                return RedirectToAction("BookingQuestion");
            }

            // إعداد قائمة التخصصات
            var specialties = (await _specialtyRepo.GetAllAsync()).Where(s => s.IsVisibleToPatient).ToList();
            ViewBag.MedicalSpecialties = new SelectList(specialties, "Id", "Name");

            

            // تمرير البيانات الموجودة
            ViewBag.ExistingData = existingConsultation;

            return View(new Consultation());
        }

        // حفظ الحجز الجديد مع البيانات الموجودة
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookWithExistingData(Consultation model, int ExistingConsultationId)
        {
            // التأكد أن فيه حجز سابق
            var existingConsultation = await _context.Consultations
                .FirstOrDefaultAsync(c => c.ConsultationId == ExistingConsultationId);

            if (existingConsultation == null)
            {
                return RedirectToAction("BookingQuestion");
            }

            if (ModelState.IsValid)
            {
                // نسخ البيانات الشخصية من الحجز السابق
                model.PatientName = existingConsultation.PatientName;
                model.PhoneNumber = existingConsultation.PhoneNumber;
                model.FullPhoneNumber = existingConsultation.FullPhoneNumber;
                model.BirthDate = existingConsultation.BirthDate;
                model.BirthCountry = existingConsultation.BirthCountry;
                model.CurrentCountry = existingConsultation.CurrentCountry;
                model.Gender = existingConsultation.Gender;
                model.MaritalStatus = existingConsultation.MaritalStatus;
                model.WorkOrStudyPlace = existingConsultation.WorkOrStudyPlace;
                model.IsIraqi = existingConsultation.IsIraqi;

                // حساب رسوم الاستشارة حسب الدولة
                var specialty = await _specialtyRepo.GetByIdAsync(model.MedicalSpecialtyId);
                if (specialty != null)
                {
                    model.ConsultationFee = model.IsIraqi
                        ? specialty.PriceIQD ?? 0
                        : specialty.PriceUSD ?? 0;
                }

                model.BookingDate = DateTime.Now;
                model.PaymentStatus = PaymentStatus.Pending;
                model.Status = "قيد المراجعة";

                // نخزنها في TempData ونروح لاختيار المواعيد
                TempData["Consultation"] = JsonConvert.SerializeObject(model);

                return RedirectToAction("ChooseAvail");
            }

            // لو فيه أخطاء في ModelState، نرجع الفيو مع البيانات
            var specialties = (await _specialtyRepo.GetAllAsync())
                .Where(s => s.IsVisibleToPatient).ToList();

            ViewBag.MedicalSpecialties = new SelectList(specialties, "Id", "Name");
            ViewBag.ExistingData = existingConsultation;

            return View(model);
        }


        public IActionResult ChooseAvail()
        {
            if (TempData["Consultation"] == null)
            {
                return RedirectToAction("Book");
            }

            var model = JsonConvert.DeserializeObject<Consultation>(
                TempData["Consultation"].ToString()
            );

            TempData.Keep("Consultation");

            var availabilities = _context.advisorAvailabilities
                .Include(a => a.Advisor)
                .Where(a => a.Advisor.MedicalSpecialtyId == model.MedicalSpecialtyId && !a.IsBooked)
                .Select(a => new
                {
                    a.AvailabilityId,
                    Text = a.Date.ToShortDateString() + " - " + a.StartTime.ToString(@"hh\:mm")
                })
                .ToList();

            ViewBag.Availabilities = new SelectList(availabilities, "AvailabilityId", "Text");

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> ChooseAvail(int AvailabilityId)
        {
            if (TempData["Consultation"] == null)
            {
                return RedirectToAction("Book");
            }

            var model = JsonConvert.DeserializeObject<Consultation>(
                TempData["Consultation"].ToString()
            );

            var availability = await _context.advisorAvailabilities
                .Include(a => a.Advisor)
                .FirstOrDefaultAsync(a => a.AvailabilityId == AvailabilityId && !a.IsBooked);

            if (availability == null)
            {
                TempData["Error"] = "الموعد المختار غير متاح، حاول مرة أخرى.";
                return RedirectToAction("ChooseAvail");
            }

            // ربط الاستشارة بالمعاد والمستشار
            model.AdvisorAvailabilityId = availability.AvailabilityId;

            await _consultationRepo.AddAsync(model);
            await _consultationRepo.SaveAsync();

            availability.IsBooked = true;
            _context.advisorAvailabilities.Update(availability);
            await _context.SaveChangesAsync();

            return RedirectToAction("BookingConfirmation", new { phoneNumber = model.PhoneNumber });
        }











        // صفحة الحجز الكاملة (للمستخدمين الجدد)
        public async Task<IActionResult> Book()
        {
            var specialties = (await _specialtyRepo.GetAllAsync())
                .Where(s => s.IsVisibleToPatient)
                .ToList();

            ViewBag.MedicalSpecialties = specialties;

            return View();
        }


        // حفظ الحجز الكامل
        [HttpPost]
        public async Task<IActionResult> Book(Consultation model)
        {
            if (ModelState.IsValid)
            {
                var specialty = await _specialtyRepo.GetByIdAsync(model.MedicalSpecialtyId);
                if (specialty != null)
                {
                    model.ConsultationFee = model.IsIraqi
                        ? specialty.PriceIQD ?? 0
                        : specialty.PriceUSD ?? 0;
                }

                model.BookingDate = DateTime.Now;
                model.PaymentStatus = PaymentStatus.Pending;
                model.Status = "قيد المراجعة";

                TempData["Consultation"] = JsonConvert.SerializeObject(model);

                return RedirectToAction("ChooseAvail");
            }

            var specialties = (await _specialtyRepo.GetAllAsync())
                .Where(s => s.IsVisibleToPatient).ToList();
            ViewBag.MedicalSpecialties = specialties;

            return View(model);
        }



        // صفحة تأكيد الحجز
        public IActionResult BookingConfirmation(string phoneNumber)
        {
            ViewBag.PhoneNumber = phoneNumber;
            return View();
        }
    }
}