using SalesWebCourse.Data;
using SalesWebCourse.Models;

namespace SalesWebCourse.Services

{
    public class SellerService 
    {
        private readonly SalesWebCourseContext _context;

        public SellerService(SalesWebCourseContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
