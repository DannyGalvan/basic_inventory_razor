using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class B_Product
    {
        private readonly InventaryContext _context;
        public B_Product(InventaryContext context)
        {
            _context = context;
        }
        public async Task<List<ProductsEntity>> ProductList()
        {
            return await _context.Products.OrderBy(p => p.TotalQuantity).OrderByDescending(p => p.TotalQuantity).ToListAsync();
        }

        public ProductsEntity ProductById(string id)
        {
            return _context.Products.ToList().LastOrDefault(p => p.Id == id);
        }

        public void CrearProducto(ProductsEntity oProduct)
        {
            _context.Products.Add(oProduct);
            _context.SaveChanges();
        }

        public void UpdateProducto(ProductsEntity oProduct)
        {
            _context.Products.Update(oProduct);
            _context.SaveChanges();
        }
    }
}
