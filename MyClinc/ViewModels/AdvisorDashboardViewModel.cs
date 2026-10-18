using DAL.Data.Models;

namespace MyClinc.ViewModels
{
    public class AdvisorDashboardViewModel
    {
        public Advisor Advisor { get; set; }
        public List<AdvisorAvailability> Availabilities { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    }

}
