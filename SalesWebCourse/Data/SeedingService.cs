using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebCourse.Models;
using SalesWebCourse.Models.Enums;
namespace SalesWebCourse.Data
{
    public class SeedingService
    {
        private SalesWebCourseContext _context;
        public SeedingService(SalesWebCourseContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            Console.WriteLine("Método Seed chamado...");
            //Verifying if any data already exists
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                Console.WriteLine("Banco já contém dados. Seed cancelado.");

                return; //DB has been seeded
            }

            Department d1 = new Department { Name = "Computers" };
            Department d2 = new Department { Name = "Electronic" };
            Department d3 = new Department {Name = "Fashion" };
            Department d4 = new Department {Name = "Books" };

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.SaveChanges();

            Seller s1 = new Seller {Name = "Bob Brown", Email = "bob@gmail.com", BirthDate =  new DateTime(1998, 4, 21).ToUniversalTime(), BaseSalary = 1000.0, Department = d1 };
            Seller s2 = new Seller { Name = "Maria Green", Email = "maria@gmail.com", BirthDate =  new DateTime(1979, 12, 31).ToUniversalTime(), BaseSalary = 3500.0, Department = d2 };
            Seller s3 = new Seller { Name = "Alex Grey", Email =  "alex@gmail.com", BirthDate = new DateTime(1988, 1, 15).ToUniversalTime(), BaseSalary = 2200.0, Department = d1 };
            Seller s4 = new Seller{ Name = "Martha Red", Email = "martha@gmail.com", BirthDate = new DateTime(1993, 11, 30).ToUniversalTime(), BaseSalary = 3000.0, Department = d4 };
            Seller s5 = new Seller{ Name = "Donald Blue", Email = "donald@gmail.com", BirthDate = new DateTime(2000, 1, 9).ToUniversalTime(), BaseSalary = 4000.0, Department = d3 };
            Seller s6 = new Seller{ Name = "Alex Pink", Email = "pink@gmail.com", BirthDate = new DateTime(1997, 3, 4).ToUniversalTime(), BaseSalary = 3000.0, Department = d2 };

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SaveChanges();

            SalesRecord r1 = new SalesRecord {Date = DateTime.SpecifyKind(new DateTime(2018, 09, 25), DateTimeKind.Utc), Amount = 11000.0, Status = SaleStatus.Billed, Seller = s1 };
            SalesRecord r2 = new SalesRecord {Date = DateTime.SpecifyKind(new DateTime(2018, 09, 4), DateTimeKind.Utc), Amount = 7000.0, Status = SaleStatus.Billed, Seller = s5 };
            SalesRecord r3 = new SalesRecord { Date = DateTime.SpecifyKind(new DateTime(2018, 09, 13), DateTimeKind.Utc), Status = SaleStatus.Canceled, Seller = s4 };
            SalesRecord r4 = new SalesRecord{ Date = DateTime.SpecifyKind( new DateTime(2018, 09, 1), DateTimeKind.Utc), Amount = 8000.0, Status = SaleStatus.Billed, Seller = s1 };
            SalesRecord r5 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 21), DateTimeKind.Utc), Amount = 3000.0, Status = SaleStatus.Billed, Seller = s3 };
            SalesRecord r6 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 15), DateTimeKind.Utc), Amount = 2000.0, Status = SaleStatus.Billed, Seller = s1 };
            SalesRecord r7 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 28), DateTimeKind.Utc), Amount = 13000.0, Status = SaleStatus.Billed, Seller = s2 };
            SalesRecord r8 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 11), DateTimeKind.Utc), Amount = 4000.0, Status = SaleStatus.Billed, Seller = s4 };
            SalesRecord r9 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 14), DateTimeKind.Utc), Amount = 11000.0, Status = SaleStatus.Pending, Seller = s6 };
            SalesRecord r10 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 7), DateTimeKind.Utc), Amount = 9000.0, Status = SaleStatus.Billed, Seller = s6 };
            SalesRecord r11 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 13), DateTimeKind.Utc), Amount = 6000.0, Status = SaleStatus.Billed, Seller = s2 };
            SalesRecord r12 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 25), DateTimeKind.Utc), Amount = 7000.0, Status = SaleStatus.Pending, Seller = s3 };
            SalesRecord r13 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 29), DateTimeKind.Utc), Amount = 10000.0, Status = SaleStatus.Billed, Seller = s4 };
            SalesRecord r14 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 4), DateTimeKind.Utc), Amount = 3000.0, Status = SaleStatus.Billed, Seller = s5 };
            SalesRecord r15 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 09, 12), DateTimeKind.Utc), Amount = 4000.0, Status = SaleStatus.Billed, Seller = s1 };
            SalesRecord r16 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 5), DateTimeKind.Utc), Amount = 2000.0, Status = SaleStatus.Billed, Seller = s4 };
            SalesRecord r17 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 1), DateTimeKind.Utc), Amount = 12000.0, Status = SaleStatus.Billed, Seller = s1 };
            SalesRecord r18 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 24), DateTimeKind.Utc), Amount = 6000.0, Status = SaleStatus.Billed, Seller = s3 };
            SalesRecord r19 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 22), DateTimeKind.Utc), Amount = 8000.0, Status = SaleStatus.Billed, Seller = s5 };
            SalesRecord r20 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 15), DateTimeKind.Utc), Amount = 8000.0, Status = SaleStatus.Billed, Seller = s6 };
            SalesRecord r21 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 17), DateTimeKind.Utc), Amount = 9000.0, Status = SaleStatus.Billed, Seller = s2 };
            SalesRecord r22 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 24), DateTimeKind.Utc), Amount = 4000.0, Status = SaleStatus.Billed, Seller = s4 };
            SalesRecord r23 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 19), DateTimeKind.Utc), Amount = 11000.0, Status = SaleStatus.Canceled, Seller = s2 };
            SalesRecord r24 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 12), DateTimeKind.Utc), Amount = 8000.0, Status = SaleStatus.Billed, Seller = s5 };
            SalesRecord r25 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 31), DateTimeKind.Utc), Amount = 7000.0, Status = SaleStatus.Billed, Seller = s3 };
            SalesRecord r26 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 6), DateTimeKind.Utc), Amount = 5000.0, Status = SaleStatus.Billed, Seller = s4 };
            SalesRecord r27 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 13), DateTimeKind.Utc), Amount = 9000.0, Status = SaleStatus.Pending, Seller = s1 };
            SalesRecord r28 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 7), DateTimeKind.Utc), Amount = 4000.0, Status = SaleStatus.Billed, Seller = s3 };
            SalesRecord r29 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 23), DateTimeKind.Utc), Amount = 12000.0, Status = SaleStatus.Billed, Seller = s5 };
            SalesRecord r30 = new SalesRecord{ Date = DateTime.SpecifyKind(new DateTime(2018, 10, 12), DateTimeKind.Utc), Amount = 5000.0, Status = SaleStatus.Billed, Seller = s2 };

            
            _context.SalesRecord.AddRange(
               r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
               r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
               r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
           );
            _context.SaveChanges();
        }
    }
}
