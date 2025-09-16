using SalesWebCourse.Data;
using SalesWebCourse.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
