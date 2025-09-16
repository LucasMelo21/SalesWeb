using SalesWebCourse.Data;
using SalesWebCourse.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebCourse.Services.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SalesWebCourse.Services

{
    public class SellerService 
    {
        private readonly SalesWebCourseContext _context;

        public SellerService(SalesWebCourseContext context)
        {
            _context = context;
        }
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.Include(s => s.Department).ToListAsync();
        }
        public async Task InsertAsync(Seller obj)
        {
            try
            {
                Console.WriteLine($"Salvando Seller: Id={obj.Id}, DepartmentId={obj.DepartmentId}, Name={obj.Name}");
                _context.Add(obj);
                await _context.SaveChangesAsync();
                Console.WriteLine($"Salvo com sucesso. DepartmentId={obj.DepartmentId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar: {ex.Message} - {ex.InnerException?.Message}");
                throw;
            }
        }
        public async Task<Seller> FindByIdAsync(int id)
        {
            var seller = await _context.Seller.Include(s => s.Department).FirstOrDefaultAsync(s => s.Id == id);
            if (seller != null)
            {
                Console.WriteLine($"Seller ID: {seller.Id}, Department: {(seller.Department != null ? seller.Department.Name : "null")}");
            }
            return seller;
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                if (obj != null)
                {
                    _context.Seller.Remove(obj);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }
        public async Task UpdateAsync(Seller obj)
        {
            if (! await _context.Seller.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
