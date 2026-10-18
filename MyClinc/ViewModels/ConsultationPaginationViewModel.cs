using DAL.Data.Models;

namespace MyClinc.ViewModels
{
    public class ConsultationPaginationViewModel
    {
        public List<Consultation> Consultations { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalCount / PageSize);
    }

}
