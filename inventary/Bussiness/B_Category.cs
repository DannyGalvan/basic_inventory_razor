using Entities;
using System.Collections.Generic;
using DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bussiness
{
    public class B_Category
    {
        private readonly InventaryContext _context;
        public B_Category(InventaryContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryEntity>> CategoryList()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<CategoryEntity> CategoryById(string id)
        {
            return await _context.Category.FirstOrDefaultAsync(p => p.Id == id);
        }

        public void CrearCategoria(CategoryEntity oCategory)
        {
            _context.Category.Add(oCategory);
            _context.SaveChanges();
        }

        public void UpdateCategoria(CategoryEntity oCategory)
        {
            _context.Category.Update(oCategory);
            _context.SaveChanges();
        }
    }
}
