using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data.Models;

namespace DAL.Data.Repositories.CoursesRepo
{

    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course? GetById(int id);
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
        void ToggleActivation(int id);
        List<CoursePurchaseRequest> GetAllPurchaseRequests();
        void ApprovePurchase(int requestId);
        void RejectPurchase(int requestId);
        void Save();
    }
}
