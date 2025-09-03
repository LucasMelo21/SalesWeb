using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebCourse.Models;

namespace SalesWebCourse.Data
{
    public class SalesWebCourseContext : DbContext
    {
        public SalesWebCourseContext (DbContextOptions<SalesWebCourseContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebCourse.Models.Department> Department { get; set; } = default!;
    }
}
