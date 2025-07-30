using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data.Models;

namespace DAL.Data.Repositories.CoursesRepo
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ClincDbContext _dbContext;

        public CourseRepository(ClincDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Course> GetAll()
        {
            return _dbContext.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _dbContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Course course)
        {
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
        }

        public void Update(Course course)
        {
            var existingCourse = _dbContext.Courses.FirstOrDefault(c => c.Id == course.Id);
            if (existingCourse != null)
            {
                existingCourse.Title = course.Title;
                existingCourse.ShortDescription = course.ShortDescription;
                existingCourse.TargetAudience = course.TargetAudience;
                existingCourse.TeaserVideoUrl = course.TeaserVideoUrl;
                existingCourse.Price = course.Price;
                existingCourse.IsActive = course.IsActive;

                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var course = _dbContext.Courses.Find(id);
            if (course != null)
            {
                _dbContext.Courses.Remove(course);
                _dbContext.SaveChanges();
            }
        }

        public void ToggleActivation(int id)
        {
            var course = _dbContext.Courses.Find(id);
            if (course != null)
            {
                course.IsActive = !course.IsActive;
                _dbContext.SaveChanges();
            }
        }

        public List<CoursePurchaseRequest> GetAllPurchaseRequests()
        {
            return _dbContext.CoursePurchases.ToList();
        }

        public void ApprovePurchase(int requestId)
        {
            var request = _dbContext.CoursePurchases.Find(requestId);
            if (request != null)
            {
                request.paymentStatuse = PaymentStatuse.Approved;
                _dbContext.SaveChanges();
            }
        }

        public void RejectPurchase(int requestId)
        {
            var request = _dbContext.CoursePurchases.Find(requestId);
            if (request != null)
            {
                request.paymentStatuse = PaymentStatuse.Rejected;
                _dbContext.SaveChanges();
            }
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
