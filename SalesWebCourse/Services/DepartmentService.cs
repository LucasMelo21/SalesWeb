using SalesWebCourse.Data;
using SalesWebCourse.Models;
using System.Linq;

namespace SalesWebCourse.Services
{
    public class DepartmentService
    {
        private readonly SalesWebCourseContext _context;

        public DepartmentService(SalesWebCourseContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
