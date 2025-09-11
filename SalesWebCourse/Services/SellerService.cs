using SalesWebCourse.Data;
using SalesWebCourse.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(x => x.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
